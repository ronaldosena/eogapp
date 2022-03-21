using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Toolbox;
using Toolbox.Acquisition;
using System.Media;

namespace EOG_app
{
    public partial class MainWindow : MetroFramework.Forms.MetroForm
    {
        const int UP_THRESHOLD = 500;
        const int DOWN_THRESHOLD = 300;
        int estadoAtual = 0;
        int estadoAnterior = 0;
        int moveCounter = 0;
        int trigger = 0;
        Timer MoveMouse = new Timer();
        Processing Dot;
        List<string> FriendlyPortName;
        List<string> PortName = new List<string>();
        SoundPlayer somComer = new SoundPlayer(@"C:\Users\BioLAB2\Desktop\comer.wav");
        SoundPlayer somBeber = new SoundPlayer(@"C:\Users\BioLAB2\Desktop\beber.wav");

        public MainWindow()
        {
            InitializeComponent();

            MetroTabControl.SelectedTab = TabPage_Config;
            TabPage_Pointer.Controls.Add(MousePointer);
            TabPage_Pointer.Controls.Add(button_comer);
            //TabPage_Pointer.Controls.Add(button_beber);
            this.MinimumSize = new Size(500, 500);

            #region Setting initial values in combobox
            // Handles index changes
            ConfigComboBox.SelectedIndexChanged += new System.EventHandler(ConfigComboBox_SelectedIndexChanged);
            FriendlyPortName = SerialFunctions.GetFriendlyPortNames();
            //ConfigComboBox.Items.AddRange(FriendlyPortName.ToArray());
            foreach (var item in FriendlyPortName)
            {
                ConfigComboBox.Items.Add(item);
                int begingIndex = item.IndexOf('(') + 1;
                int endingIndex = item.IndexOf(')') - begingIndex;
                PortName.Add(item.Substring(begingIndex, endingIndex));
                ConfigComboBox.SelectedIndex = 0;
            }
            #endregion

            string portName = PortName.ElementAt(ConfigComboBox.SelectedIndex);
            Dot = new Processing(portName, ref PlotterConfig);
            MoveMouse.Interval = 10;
            MoveMouse.Tick += MoveMouse_Tick;
        }

        void MoveMouse_Tick(object sender, EventArgs e)
        {
            if (MetroTabControl.SelectedTab == TabPage_Pointer)
            {
                if (!Dot.DataQueue.IsEmpty)
                {
                    int x, y;
                    List<int> dataBuffer = new List<int>();
                    estadoAnterior = estadoAtual;

                    int tempSize = Dot.DataQueue.CurrentSize;
                    for (int i = 0; i < tempSize; i++)
                    {
                        dataBuffer.Add(Dot.DataQueue.Dequeue());
                    }
                    double media = dataBuffer.Average();

                    if (media > UP_THRESHOLD)
                    {
                        estadoAtual = 1;
                    }
                    else if (media < DOWN_THRESHOLD)
                    {
                        estadoAtual = -1;
                    }
                    else
                    {
                        estadoAtual = 0;
                    }

                    if( estadoAtual != estadoAnterior) // aciona o trigger na nova mudanca de estado
                    {
                        if (estadoAtual == 1 && estadoAnterior == 0) // transicao pra cima
                        {
                            trigger++;
                        }
                        else if (estadoAtual == -1 && estadoAnterior == 0) // transicao pra baixo
                        {
                            trigger--;
                        }
                    }
                    System.Diagnostics.Debug.WriteLine(trigger);


                    if (trigger > 0)
                    {
                        y = (int)(MousePointer.Location.Y + 1);
                    }
                    else if (trigger < 0)
                    {
                        y = (int)(MousePointer.Location.Y - 1);
                    }
                    else
                    {
                        y = (int)(MousePointer.Location.Y);
                    }
                    x = (int)(TabPage_Pointer.Width / 2.0);
                    MousePointer.Location = new Point(x, y);
                }                
            }
        }

        #region Event handler
        private void ConfigComboBox_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            string portName = PortName.ElementAt(ConfigComboBox.SelectedIndex);
            Dot = new Processing(portName, ref PlotterConfig);
        }
        #endregion

        #region MainWindows callbacks
        private void ConfigButton_Connect_Click(object sender, EventArgs e)
        {            
            if (!Dot.DAQ.AcquisitionBoard.IsOpen)
            {
                Dot.DAQ.OpenConnection();
                ConfigButton_Connect.BackgroundImage = mainImageList.Images["Connected"];
            }
            else
            {
                Dot.DAQ.CloseConnection();
                ConfigButton_Connect.BackgroundImage = mainImageList.Images["Disconnected"];
            }
        }

        private void ConfigButton_Led_Click(object sender, EventArgs e)
        {
            Dot.DAQ.ToggleLed();
            if (Dot.DAQ.LedState)
            {
                ConfigButton_Led.BackgroundImage = mainImageList.Images["Light On"];
            }
            else
            {
                ConfigButton_Led.BackgroundImage = mainImageList.Images["Light Off"];
            }
        }

        private void ConfigButton_Initiate_Click(object sender, EventArgs e)
        {
            if (!Dot.State)
            {
                Dot.Go();
                MoveMouse.Start();
                ConfigButton_Initiate.BackgroundImage = mainImageList.Images["Pause"];
            }
            else
            {
                Dot.Go();
                MoveMouse.Stop();
                ConfigButton_Initiate.BackgroundImage = mainImageList.Images["Play"];
            }
        }
        #endregion

        private void button_comer_Click(object sender, EventArgs e)
        {
            somComer.Play();
        }
    }
}

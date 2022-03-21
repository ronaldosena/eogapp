using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using ZedGraph;
using Toolbox.General;

namespace Toolbox
{
    public partial class Plotter : UserControl
    {
        #region Getters and Setters
        public GraphPane MainChart
        {
            get { return ZedGraphic.GraphPane; }
            private set { }
        }
        /// <summary>
        /// Set graph FPS rate
        /// </summary>
        public double FramesPerSecond
        {
            get => PlotterTimer.Interval;
            set => PlotterTimer.Interval = (int)(1000.0/value);
        }
        /// <summary>
        /// Period (ms) of the signal to be plotted
        /// </summary>
        public double SignalPeriod { get; set; }
        /// <summary>
        /// Indicates the maximum shown width (in seconds)
        /// </summary>
        public double MaxWidth { get; set; }
        /// <summary>
        /// Indicates the maximum shown height (points units)
        /// </summary>
        public double MaxHeight
        {
            get => MainChart.YAxis.Scale.Max;
            set => MainChart.YAxis.Scale.Max = value;
        }
        /// <summary>
        /// Maximum number of points to be store in the graph
        /// </summary>
        public int MaxPoints { get; set; }
        #endregion

        private RollingPointPairList PlotterRollingList;
        private LineItem PlotterLineItem;
        private Timer PlotterTimer = new Timer();
        private CircularQueue<double> PlotterBuffer;

        private int m_count = 0; // data point counter

        /// <summary>
        /// Default constructor
        /// </summary>
        public Plotter()
        {
            InitializeComponent();
            MainChart = ZedGraphic.GraphPane;
            MainChart.Border.IsVisible = false;
            MainChart.YAxis.Scale.Max = 1024;
            MainChart.YAxis.Scale.Min = 0;
            ZedGraphic.AxisChange();
            ZedGraphic.Invalidate();
        }

        public void SetPlotter(double _Period = 10, int _MaxWidth = 5, 
                               int _MaxHeight = 1024, int _MaxPoints = 10000, 
                               double _FramesPerSecond = 40)
        {
            // Setting the initial values
            FramesPerSecond = _FramesPerSecond;
            MaxWidth = _MaxWidth;
            MaxHeight = _MaxHeight;
            MaxPoints = _MaxPoints; // delete points after that amount
            SignalPeriod = _Period;

            PlotterRollingList = new RollingPointPairList(MaxPoints);
            PlotterBuffer = new CircularQueue<double>(MaxPoints);
            PlotterTimer.Interval = (int)FramesPerSecond;
            PlotterTimer.Tick += PlotterTimer_Tick;

            PlotterLineItem = MainChart.AddCurve("Channel 0", PlotterRollingList, Color.Blue, SymbolType.None);           
        }
        #region Timer related
        public void StartPlotting()
        {
            PlotterTimer.Start();
        }

        public void StopPlotting()
        {
            PlotterTimer.Stop();
        }

        private void PlotterTimer_Tick(object sender, EventArgs e)
        {
            PlotPoints();
        }
        #endregion

        #region Plotting related
        /// <summary>
        /// Add data in the plotter buffer
        /// </summary>
        /// <param name="data">Data to be added (double)</param>
        /// <returns>True if successful</returns>
        public bool AddToPlotterBuffer(double data)
        {
            try
            {
                return PlotterBuffer.Enqueue(data);
            }
            catch (Exception)
            {
                return false;
            }
        }

        private void PlotPoints()
        {
            LineItem curve = PlotterLineItem;
            IPointListEdit list = curve.Points as IPointListEdit;
            
            double time = 0;
            double val = 0;
            int aux = PlotterBuffer.CurrentSize;
            for (int j = 0; j < aux; j++)
            {
                val = PlotterBuffer.Dequeue();
                // Time is measured in seconds
                time = (m_count++ * SignalPeriod/1000.0);
                list.Add(time, val);
            }
            // Keep the X scale at a rolling 30 second interval, with one
            // major step between the max X value and the end of the axis
            Scale xScale = ZedGraphic.GraphPane.XAxis.Scale;
            if (time > xScale.Max)
            {
                xScale.Max = time;
                xScale.Min = xScale.Max - MaxWidth;
            }

            // Make sure the Y axis is rescaled to accommodate actual data
            ZedGraphic.AxisChange();
            // Force a redraw
            ZedGraphic.Invalidate();
        }
        #endregion
    }
}

/*  Saving this just for future references. Allow more than one plot line at a time
 
     public partial class Plotter : UserControl
    {
        #region Getters and Setters
        public GraphPane MainChart
        {
            get { return ZedGraphic.GraphPane; }
            private set { }
        }
        /// <summary>
        /// 
        /// </summary>
        public double FramesPerSecond { get; set; }
        /// <summary>
        /// Frequency (Hz) of the signal to be plotted
        /// </summary>
        public double Frequency { get; set; }
        /// <summary>
        /// Period (ms) of the signal to be plotted
        /// </summary>
        public double Period { get; set; }
        /// <summary>
        /// Number of channels available
        /// </summary>
        public int NumberOfChannels { get; set; }
        /// <summary>
        /// List with the labels of each channel
        /// </summary>
        public List<string> ChannelNames { get; set; }
        /// <summary>
        /// Indicates the maximum shown width (points units)
        /// </summary>
        public int MaxWidth { get; set; }
        /// <summary>
        /// Indicates the maximum shown height (points units)
        /// </summary>
        public int MaxHeight { get; set; }
        /// <summary>
        /// Maximum number of points to be shown at the graph
        /// </summary>
        public int MaxPoints { get; set; }
        #endregion

        RollingPointPairList[] Channels_RollingList;
        LineItem[] Channels_LineItem;
        Timer PlotterTimer;
        public CircularQueue<double>[] PlotterBuffer;

        private int m_count = 0; // data point counter

        #region Constructor
        /// <summary>
        /// Default constructor
        /// </summary>
        public Plotter()
        {
            InitializeComponent();
            MainChart = ZedGraphic.GraphPane;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_Period"></param>
        /// <param name="_NumberOfChannels"></param>
        /// <param name="_MaxWidth"></param>
        /// <param name="_MaxHeight"></param>
        /// <param name="_MaxPoints"></param>
        public void SetPlotter(double _Period = 100,
                               int _NumberOfChannels = 2, int _MaxWidth = 1000, 
                               int _MaxHeight = 150, int _MaxPoints = 3000)
        {
            PlotterBuffer = new CircularQueue<double>[_NumberOfChannels];
            PlotterTimer = new Timer();
            PlotterTimer.Interval = 50;
            PlotterTimer.Tick += PlotterTimer_Tick;

            // Setting the initial values
            MaxWidth = _MaxWidth;
            MaxHeight = _MaxHeight;
            MaxPoints = _MaxPoints; // delete points after that amount
            NumberOfChannels = _NumberOfChannels;
            Period = _Period;
            Frequency = 1/ Period;

            ChannelNames = new List<string>(NumberOfChannels);
            for (int i = 0; i < NumberOfChannels; i++)
            {
                ChannelNames.Add($"Channel {i}");
                PlotterBuffer[i] = new CircularQueue<double>(_MaxPoints);
            }
            // Setting up for each channel
            Channels_LineItem = new LineItem[NumberOfChannels];
            Channels_RollingList = new RollingPointPairList[NumberOfChannels];
            for (int i = 0; i < NumberOfChannels; i++)
            {
                Channels_RollingList[i] = new RollingPointPairList(MaxPoints);
                Channels_LineItem[i] = MainChart.AddCurve(ChannelNames[i], Channels_RollingList[i], Color.Blue, SymbolType.None);
            }            
        }
        private void PlotterTimer_Tick(object sender, EventArgs e)
        {
            PlotPoints();
        }
        #endregion

        public bool AddToPlotterBuffer(int channel, double data)
        {
            try
            {
                return PlotterBuffer[channel].Enqueue(data);
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void PlotPoints()
        {
            LineItem curve = Channels_LineItem[0];
            IPointListEdit list = curve.Points as IPointListEdit;
            
            double time = 0;
            double val = 0;
            //foreach (double val in Ypoints2add)
            int aux = PlotterBuffer[0].CurrentSize;
            for (int j = 0; j < aux; j++)
            {
                val = PlotterBuffer[0].Dequeue();
                // Time is measured in seconds
                time = (m_count++ * Period);
                list.Add(time, val);
            }
            // Keep the X scale at a rolling 30 second interval, with one
            // major step between the max X value and the end of the axis
            Scale xScale = ZedGraphic.GraphPane.XAxis.Scale;
            if (time > xScale.Max - 3)
            {
                xScale.Max = time + 3;
                xScale.Min = xScale.Max - 6;
            }

            // Make sure the Y axis is rescaled to accommodate actual data
            ZedGraphic.AxisChange();
            // Force a redraw
            ZedGraphic.Invalidate();
        }
    }
    

 */
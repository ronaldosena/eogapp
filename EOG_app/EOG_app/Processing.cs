using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toolbox.Acquisition;
using Toolbox.General;

namespace EOG_app
{
    class Processing
    {
        public DataAcquisition DAQ;
        public Threading MeshingThread;
        private Toolbox.Plotter _plotter;
        public bool State { get; set; }
        public CircularQueue<int> DataQueue;

        public Processing(string PortName, ref Toolbox.Plotter plotter)
        {
            State = false;
            _plotter = plotter;
            _plotter.SetPlotter();
            DAQ = new DataAcquisition(PortName);
            DataQueue = new CircularQueue<int>();
            MeshingThread = new Threading(ProcessingRoutine);
            MeshingThread.Start();
        }

        void ProcessingRoutine()
        {
            if (!DAQ.Ch1Buffer.IsEmpty)
            {
                int tempData = DAQ.Ch1Buffer.Dequeue();
                _plotter.AddToPlotterBuffer(tempData);
                DataQueue.Enqueue(tempData);
            }
        }

        public void Go()
        {
            if (!State)
            {
                State = true;
                _plotter.StartPlotting();
                DAQ.StartAcquisition();
                MeshingThread.Resume();
            }
            else
            {
                State = false;
                _plotter.StopPlotting();
                DAQ.StopAcquisition();
                MeshingThread.Pause();
            }
        }
    }
}

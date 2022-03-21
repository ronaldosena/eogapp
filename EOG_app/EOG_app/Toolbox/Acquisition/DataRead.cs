using System;

namespace Toolbox.Acquisition
{
    partial class DataAcquisition
    {
        byte[] incomingBuffer = new byte[1024];

        void AcquisitionRoutine()
        {
            if (AcquisitionBoard.IsOpen && AcquisitionState)
            {
                if (AcquisitionBoard.BytesToRead > 0)
                {
                    // Reads the first byte available, if it matches the start ID, read the next 5 bytes
                    //Then checks if the last one matches the end ID.
                    //If it does, enqueue each data into respective queue
                    AcquisitionBoard.Read(incomingBuffer, 0, 1);
                    if (incomingBuffer[0] == Commands.idBegin)
                    {
                        AcquisitionBoard.Read(incomingBuffer, 1, this.PackteSize - 1);
                        if (incomingBuffer[this.PackteSize - 1] == Commands.idEnd) //0 index
                        {
                            //I used lock statement when queuing/dequeuing, so mutex control is obsolete
                            //It works like a charm using mutex, if some performance issues occurs, go back 
                            //to mutex access control
                            //accessControl.WaitOne();
                            Ch1Buffer.Enqueue(incomingBuffer[1] << 8 | incomingBuffer[2]);
                            //Ch2Buffer.Enqueue(incomingBuffer[3] << 8 | incomingBuffer[4]);
                            //Debug.Write(incomingBuffer[1] << 8 | incomingBuffer[2]);
                            //accessControl.ReleaseMutex();
                        }
                    }
                }
            }
        }
    }
}

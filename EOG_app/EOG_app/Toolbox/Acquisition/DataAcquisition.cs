using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Diagnostics;
using System.IO.Ports;
using Toolbox.General;
using System.Management;

namespace Toolbox.Acquisition
{
    partial class DataAcquisition
    {
        public SerialPort AcquisitionBoard;
        public Threading AcquisitionThread;
        public CircularQueue<int> Ch1Buffer;
        public CircularQueue<int> Ch2Buffer;
                
        public bool LedState { get; private set; }
        public bool AcquisitionState { get; private set; }

        // Acquisition parameters
        public int PackteSize { get; set; }
        public int Frequency { get; set; }
        public int Period { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="portName"> Serial port name</param>
        /// <param name="baudRate">Baud rate used</param>
        public DataAcquisition(string portName = "COM14", int baudRate = 115200) // The portName property cannot be empty
        {
            Ch1Buffer = new CircularQueue<int>(1024);
            Ch2Buffer = new CircularQueue<int>(1024);
            AcquisitionThread = new Threading(AcquisitionRoutine);

            AcquisitionBoard = new SerialPort
            {
                PortName = portName,
                BaudRate = baudRate,
                ReadBufferSize = 1000,
                DtrEnable = true,
                RtsEnable = true
            };
            AcquisitionBoard.ReadTimeout = 5000;
            AcquisitionBoard.WriteTimeout = 5000;

            PackteSize = 6;
            Frequency = 100;
    }
        
        /// <summary>
        /// Send a single byte to the board
        /// </summary>
        /// <param name="thisByte">Byte to be send</param>
        public void SendThis(byte thisByte)
        {
            byte[] sendThis = new byte[1]; // Used to send individual commands since .NET doesn't support 
            sendThis[0] = thisByte;
            AcquisitionBoard.Write(sendThis, 0, sendThis.Length);
        }

        /// <summary>
        /// Open connection with acquisition board
        /// </summary>
        /// <returns>True if successful</returns>
        public bool OpenConnection()
        {
            try
            {
                if (!AcquisitionBoard.IsOpen)
                {
                    AcquisitionBoard.Open();
                    //AcquisitionBoard.DiscardOutBuffer();
                    //AcquisitionBoard.DiscardInBuffer();
                    Debug.Print("Connected!");
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Close connection with acquisition board
        /// </summary>
        /// <returns>True if successful</returns>
        public bool CloseConnection()
        {
            try
            {
                if (AcquisitionBoard.IsOpen)
                {
                    if (this.AcquisitionState)
                    {
                        AcquisitionState = false;
                        AcquisitionThread.Pause();
                        AcquisitionThread.Stop();
                    }
                    AcquisitionBoard.Close();
                    AcquisitionBoard.DiscardOutBuffer();
                    AcquisitionBoard.DiscardInBuffer();
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Toggle indicator led on the acquisition board.
        /// </summary>
        /// <returns>True if successful</returns>
        public bool ToggleLed()
        {
            try
            {
                if (AcquisitionBoard.IsOpen)
                {
                    SendThis(Commands.toggleLed);
                    LedState = !LedState;
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
                throw;
            }
            return false;
        }

        /// <summary>
        /// Start acquisition process
        /// </summary>
        /// <returns>True if successful</returns>
        public bool StartAcquisition()
        {
            try
            {
                if (AcquisitionBoard.IsOpen)
                {
                    SendThis(Commands.startAcq);
                    AcquisitionBoard.DiscardOutBuffer();
                    AcquisitionBoard.DiscardInBuffer();
                    AcquisitionState = true;
                    AcquisitionThread.Start();
                    AcquisitionThread.isPaused = false;
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Start acquisition process
        /// </summary>
        /// <returns>True if successful</returns>
        public bool StopAcquisition()
        {
            try
            {
                if (AcquisitionBoard.IsOpen)
                {
                    SendThis(Commands.stopAcq);
                    AcquisitionState = false;
                    AcquisitionThread.isPaused = true;
                    AcquisitionBoard.DiscardOutBuffer();
                    AcquisitionBoard.DiscardInBuffer();
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Resume acquisition process
        /// </summary>
        /// <returns>True if successful</returns>
        public bool ResumeAcquisition()
        {
            try
            {
                if (AcquisitionBoard.IsOpen)
                {
                    SendThis(Commands.startAcq);
                    AcquisitionBoard.DiscardOutBuffer();
                    AcquisitionBoard.DiscardInBuffer();
                    AcquisitionState = true;
                    AcquisitionThread.Resume();
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}

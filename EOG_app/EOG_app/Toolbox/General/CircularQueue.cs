using System;
using System.Diagnostics;

namespace Toolbox.General
{
    public class CircularQueue<ADT>
    {
        object lockProcess = new object();

        /// <summary>
        /// Storage array
        /// </summary>
        ADT[] circularQueue;

        /// <summary>
        /// Queue's current size
        /// </summary>
        public int CurrentSize { get; private set; }

        /// <summary>
        /// Queue's maximum size
        /// </summary>
        public int MaxSize { get; set; }

        /// <summary>
        /// Allow overwrite if full
        /// </summary>
        public bool Overwrite { get; set; }

        /// <summary>
        /// Last queued value
        /// </summary>
        private int head;

        /// <summary>
        /// First queued value
        /// </summary>
        private int tail;

        /// <summary>
        /// Construct. Default queue size is 1024
        /// </summary>
        public CircularQueue()
        {
            MaxSize = 1024; //By default
            CurrentSize = 0;
            head = 0;
            tail = 0;
            circularQueue = new ADT[MaxSize];
            Overwrite = true;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="maxSize">Maximum queue size</param>
        public CircularQueue(int maxSize)
        {
            MaxSize = maxSize;
            CurrentSize = 0;
            head = 0;
            tail = 0;
            circularQueue = new ADT[MaxSize];
            Overwrite = true;
        }

        /// <summary>
        /// Is the queue empty?
        /// </summary>
        public bool IsEmpty
        {
            get { return CurrentSize == 0; }
        }

        /// <summary>
        /// Is the queue full?
        /// </summary>
        public bool IsFull
        {
            get { return CurrentSize == MaxSize; }
        }

        /// <summary>
        /// Enqueue some data
        /// </summary>
        /// <param name="data">Data to insert</param>

        /// <summary>
        /// Enqueue some data
        /// </summary>
        /// <param name="data">Data to insert</param>
        /// <returns>True if successful</returns>
        public bool Enqueue(ADT data)
        {
            lock (lockProcess)
            {
                if (!IsFull)
                {
                    circularQueue[head] = data;
                    head = ++head % MaxSize;
                    CurrentSize++;
                    return true;
                }
                else
                {
                    if (Overwrite)
                    {
                        Dequeue();
                        Enqueue(data); // using recursion
                        return true;
                    }
                    else
                    {
                        Debug.WriteLine("Queue is full!");
                        return false;
                    }
                }
            }
        }

        /// <summary>
        /// Dequeue data. Check if there is anything inside of it first
        /// </summary>
        /// <returns>Returns the data in queue's tail</returns>
        public ADT Dequeue()
        {
            lock (lockProcess)
            {
                ADT data = circularQueue[tail];
                tail = ++tail % MaxSize;
                CurrentSize--;
                return data;
            }
        }

        /// <summary>
        /// Peeks the data that is about to be popped
        /// </summary>
        /// <returns>ADT data</returns>
        public ADT Peek()
        {
            lock (lockProcess)
            {
                if (!IsEmpty)
                {
                    return circularQueue[tail];
                }
                else
                    Debug.WriteLineIf(IsEmpty, "Queue is empty!");
                return default(ADT);
            }
        }
    }
}
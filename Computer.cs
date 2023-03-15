using System;

namespace Berkeley
{
    public class Computer
    {
        public Computer(int id, DateTime time, bool isMaster, bool isOnline)
        {
            Id = id;
            Time = time;
            IsMaster = isMaster;
            IsOnline = isOnline;
        }

        public int Id  { get; set; }
        public DateTime Time  { get; set; } 
        public bool IsMaster  { get; set; }
        public bool IsOnline  { get; set; }
    }
}
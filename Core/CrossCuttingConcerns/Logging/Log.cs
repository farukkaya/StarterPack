using System;

namespace Core.CrossCuttingConcerns.Logging
{
    public class Log
    {
        public int Id { get; set; }
        public string ActionName { get; set; }
        public string ActionBy { get; set; }
        public DateTime ActionDate { get; set; }
        public double ActionTotalSeconds { get; set; }
    }
}

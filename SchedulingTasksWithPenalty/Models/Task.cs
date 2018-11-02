using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace SchedulingTasksWithPenalty
{
    class Task
    {
        #region ctor
        public Task()
        {
        }
        public Task(string rawTask, int taskNumber)
        {
            if (!String.IsNullOrEmpty(rawTask))
            {
                string[] splitted = rawTask.Split(' ');
                splitted = splitted.Where(value => !String.IsNullOrEmpty(value)).ToArray();
                
                if (splitted.Length > 1)
                {
                    Time = Convert.ToInt32(splitted[0]);
                    ToSoonPenalty = Convert.ToInt32(splitted[1]);
                    TooLatePenalty = Convert.ToInt32(splitted[2]);
                    Id = taskNumber;
                }                
            }            
        }
        #endregion

        #region properties
        public int Id { get; set; }
        public int ToSoonPenalty{ get; set; }
        public int TooLatePenalty{ get; set; }
        public int Time { get; set; }
        public bool Done { get; set; }
        #endregion
    }
}

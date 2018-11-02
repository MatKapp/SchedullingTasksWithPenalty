using System;
using System.Collections.Generic;
using System.Text;

namespace SchedulingTasksWithPenalty.Models
{
    class Instance
    {
        #region ctor
        public Instance()
        {
            Tasks = new List<Task>();
        }
        #endregion

        #region properties
        public int Size { get; set; }
        public IList<Task> Tasks { get; set; }
        #endregion
    }
}

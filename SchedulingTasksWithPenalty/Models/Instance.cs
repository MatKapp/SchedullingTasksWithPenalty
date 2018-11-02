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

        public Instance(Instance _instance)
        {
            Size = _instance.Size;
            Tasks = new List<Task>();

            foreach (Task task in _instance.Tasks)
            {
                Tasks.Add(task);
            }
        }
        #endregion

        #region properties
        public int Size { get; set; }
        public IList<Task> Tasks { get; set; }
        #endregion
    }
}

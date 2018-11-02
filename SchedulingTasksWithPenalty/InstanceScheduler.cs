using SchedulingTasksWithPenalty.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace SchedulingTasksWithPenalty
{
    class InstanceScheduler
    {
        #region properties
        public Instance InstanceToSchedule{ get; set; }
        public Instance Result { get; set; }
        #endregion

        #region ctor
        public InstanceScheduler(Instance _instanceToSchedule)
        {
            InstanceToSchedule = _instanceToSchedule;
            Result = new Instance(InstanceToSchedule);
        }
        #endregion

        #region methods
        internal void Schedule()
        {
            Result.Tasks = Result.Tasks.OrderBy(task => task.ToSoonPenalty)
                .ThenBy(task => task.TooLatePenalty).ToList();
        }
            #endregion
        }
}

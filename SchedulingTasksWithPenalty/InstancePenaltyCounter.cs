using SchedulingTasksWithPenalty.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchedulingTasksWithPenalty
{
    class InstancePenaltyCounter
    {
        #region properties
        public Instance InstanceToCount { get; set; }
        public int TotalPenalty { get; set; }
        public int Deadline { get; set; }
        #endregion

        #region ctor
        public InstancePenaltyCounter(Instance _instanceToCount)
        {
            InstanceToCount = _instanceToCount;
        }
        #endregion

        #region methods

        public void CountPenalty()
        {
            int timer = 0;

            foreach (Task task in InstanceToCount.Tasks)
            {
                timer += task.Time;

                if (timer != Deadline)
                {
                    TotalPenalty += timer > Deadline ? task.TooLatePenalty : task.ToSoonPenalty;
                }
            }
        }
        #endregion
    }
}

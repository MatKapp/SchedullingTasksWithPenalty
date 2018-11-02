using SchedulingTasksWithPenalty.Models;
using System;
using System.IO;
using System.Linq;

namespace SchedulingTasksWithPenalty
{
    class Program
    {
        public static InstancesReader Reader { get; set; }
        public static InstanceScheduler Scheduler { get; set; }
        public static InstancePenaltyCounter PenaltyCounter{ get; set; }
        public static decimal RelativeDeadline { get; set; }
        static void Main(string[] args)
        {
            if (args == null)
            {
                throw new Exception("Args is null");
            }
            Reader = new InstancesReader(args[0]);
            Reader.ReadInstances();
            RelativeDeadline = 0.5m;

            foreach (Instance instance in Reader.Instances)
            {
                Scheduler = new InstanceScheduler(instance);
                int timeSummed = instance.Tasks.Sum(task => task.Time);
                PenaltyCounter = new InstancePenaltyCounter(instance);
                PenaltyCounter.Deadline = Convert.ToInt32(timeSummed * RelativeDeadline);
                PenaltyCounter.CountPenalty();
                Console.WriteLine($"Penalty before schedule: {PenaltyCounter.TotalPenalty}");
                Scheduler.Schedule();
                PenaltyCounter = new InstancePenaltyCounter(Scheduler.Result);
                PenaltyCounter.Deadline = Convert.ToInt32(timeSummed * RelativeDeadline);
                PenaltyCounter.CountPenalty();
                Console.WriteLine($"Penalty after schedule: {PenaltyCounter.TotalPenalty}");
            }


            Console.WriteLine(Reader.Instances);
        }
    }
}

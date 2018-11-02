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
        public static InstancePenaltyCounter PenaltyCounter { get; set; }
        public static decimal RelativeDeadline { get; set; }
        public static string Sequence { get; set; }
        static void Main(string[] args)
        {
            if (args.Length < 2)
            {
                throw new Exception("To few parameters specified");
            }
            Reader = new InstancesReader(args[0]);
            Reader.ReadInstances();
            RelativeDeadline = Convert.ToDecimal(args[1]);

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
                PrepareSequence();
                Console.WriteLine($"Result Seqence: {Sequence}");
                Console.WriteLine();
            }

            Console.WriteLine(Reader.Instances);
        }

        private static void PrepareSequence()
        {
            Sequence = "";
            foreach (Task task in Scheduler.Result.Tasks)
            {
                Sequence += $"T{task.Id} ";
            }
        }
    }
}

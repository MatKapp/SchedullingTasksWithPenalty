using System;
using System.IO;

namespace SchedulingTasksWithPenalty
{
    class Program
    {
        public static InstancesReader InstanceReader { get; set; }
        static void Main(string[] args)
        {
            if (args == null)
            {
                throw new Exception("Args is null");
            }
            InstanceReader = new InstancesReader(args[0]);
            InstanceReader.ReadInstances();
            Console.WriteLine(InstanceReader.Instances);
        }
    }
}

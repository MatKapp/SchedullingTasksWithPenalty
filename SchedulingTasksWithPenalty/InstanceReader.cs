using SchedulingTasksWithPenalty.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace SchedulingTasksWithPenalty
{
    class InstancesReader
    {
        #region properties
        public IList<Instance> Instances { get; set; }
        public string FilePath { get; set; }
        public int NumberOfInstances { get; set; }
        #endregion

        #region ctor
        public InstancesReader(string filePath)
        {
            FilePath = filePath;
            Instances = new List<Instance>();
        }
        #endregion

        #region methods
        public void ReadInstances()
        {
            var lines = File.ReadAllLines(FilePath);
            int actualLine = 0;
            Instance instance;
            Task task;
            NumberOfInstances = Convert.ToInt32(lines[actualLine++]);

            for (int instanceNumber = 0; instanceNumber < NumberOfInstances; instanceNumber++)
            {
                instance = new Instance();
                instance.Size = Convert.ToInt32(lines[actualLine++]);

                for (int taskNumber = 0; taskNumber < instance.Size; taskNumber++)
                {
                    task = new Task(lines[actualLine++], taskNumber);
                    instance.Tasks.Add(task);
                }
                Instances.Add(instance);
            }
        }
        #endregion
    }
}

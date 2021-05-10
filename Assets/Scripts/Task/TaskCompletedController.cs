using System;
using System.Collections.Generic;
using Runtime;

namespace Task
{
    public class TaskCompletedController : IController
    {
        public void OnStart()
        {

        }

        public void OnStop()
        {

        }

        public void Tick()
        {
            List<TaskData> completedTasks = new List<TaskData>();
            foreach (TaskData task in Game.Player.TaskDatas)
            {
                if (task.IsCompleted)
                {
                    completedTasks.Add(task);
                }
            }

            foreach (TaskData task in completedTasks)
            {
                task.TaskCompleted();
            }
        }
    }
}
using Employee;
using Runtime;
using Student;
using UnityEditor;
using UnityEngine;

namespace Task
{
    public class TaskController : IController
    {
        private float m_StartTime;

        public void OnStart()
        {

        }

        public void OnStop()
        {

        }

        public void Tick()
        {
            float deltaTime = Time.deltaTime;
            foreach (TaskData task in Game.Player.TaskDatas)
            {
                task.MakeProgress(deltaTime);
            }
            //m_PassedTimeAtPreviousFrame = passedTime;
        }
    }
}
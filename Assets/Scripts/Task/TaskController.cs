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
        private float m_TimeBeforeSpending = 600f;
        private float m_ScoreMultiplier = 5f;
        private float m_SkillMultiplier = 5f;
        private float m_BaseRaise = 1000f;

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
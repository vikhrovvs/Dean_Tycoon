using Runtime;
using UnityEngine;

namespace Task
{
    public class TaskPoolController : IController
    {
        private float m_StartTime;
        private float m_TimeBeforeUpdatingPool = 300f;
        private float m_BaseRaise = 1000f;

        public void OnStart()
        {
            Debug.Log("TaskPoolController OnStart");
            m_StartTime = Time.time;
            for (int i = 0; i < 3; i++)
            {
                GenerateTask();
            }
        }

        public void OnStop()
        {

        }

        public void Tick()
        {
            Debug.Log("TaskPoolController tick");
            float passedTime = Time.time - m_StartTime;
            if (passedTime > m_TimeBeforeUpdatingPool)
            {
                m_StartTime = Time.time;
                Game.Player.TaskPoolDatas.Clear();

                for (int i = 0; i < 3; i++)
                {
                    GenerateTask();
                }
            }
        }

        public void GenerateTask()
        {
            Game.Player.CreateTask();
        }
    }
}
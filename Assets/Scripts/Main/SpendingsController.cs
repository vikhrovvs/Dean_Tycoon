using Employee;
using Runtime;
using Student;
using UnityEngine;

namespace Main
{
    public class SpendingsController : IController
    {
        //public SpawnWavesAsset m_SpawnWaves;
        //private Grid m_Grid;

        private float m_StartTime;
        private float m_PassedTimeAtPreviousFrame = -1f;
        private float m_TimeBeforeSpending = 60f;
        private float m_ScoreMultiplier = 10f;
        private float m_SkillMultiplier = 20f;

        public void OnStart()
        {
            m_StartTime = Time.time;
        }

        public void OnStop()
        {

        }

        public void Tick()
        {
            float passedTime = Time.time - m_StartTime;
            float timeToSpawn = 0f;
            float charge = 0f;
            if (passedTime > m_TimeBeforeSpending)
            {
                Debug.Log("Spending " + Time.time);
                m_StartTime = Time.time;
                foreach (GroupData group in Game.Player.GroupDatas)
                {
                    charge += group.GetScore() * m_ScoreMultiplier;
                }

                foreach (DeskData desk in Game.Player.DeskDatas)
                {
                    charge += 1 * m_SkillMultiplier;
                }
                Game.Player.Charge(charge);
                return;
            }
            //m_PassedTimeAtPreviousFrame = passedTime;
        }
    }
}
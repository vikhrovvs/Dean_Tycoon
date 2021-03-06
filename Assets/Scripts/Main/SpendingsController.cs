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
        private float m_TimeBeforeRaising = 60f;
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
            float charge = 0f;
            if (passedTime > m_TimeBeforeRaising)
            {
                Debug.Log("Charge " + Time.time);
                m_StartTime = Time.time;
                foreach (GroupData group in Game.Player.GroupDatas)
                {
                    charge += group.GetScore() * m_ScoreMultiplier;
                }

                foreach (DeskData desk in Game.Player.DeskDatas)
                {
                    charge += desk.Skill * m_SkillMultiplier;
                }
                Debug.Log($"Charge: {charge}");
                Game.Player.Charge(charge);
                return;
            }
            //m_PassedTimeAtPreviousFrame = passedTime;
        }
    }
}
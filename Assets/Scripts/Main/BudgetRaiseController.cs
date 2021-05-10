using Employee;
using Runtime;
using Student;
using UnityEngine;

namespace Main
{
    public class BudgetRaiseController : IController
    {
        private float m_StartTime;
        private float m_TimeBeforeSpending = 600f;
        private float m_ScoreMultiplier = 5f;
        private float m_SkillMultiplier = 5f;
        private float m_BaseRaise = 1000f;

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
            float raising = m_BaseRaise;
            if (passedTime > m_TimeBeforeSpending)
            {
                Debug.Log("Raising " + Time.time);
                m_StartTime = Time.time;
                foreach (GroupData group in Game.Player.GroupDatas)
                {
                    raising += group.GetScore() * m_ScoreMultiplier;
                }

                foreach (DeskData desk in Game.Player.DeskDatas)
                {
                    raising += desk.Skill * m_SkillMultiplier;
                }
                Debug.Log($"Raising: {raising}");
                Game.Player.Raise(raising);
                return;
            }
            //m_PassedTimeAtPreviousFrame = passedTime;
        }
    }
}
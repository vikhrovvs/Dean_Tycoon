using System;
using Employee;
using Runtime;
using Student;
using UnityEditor;
using UnityEngine;

namespace Task
{
    public class TaskData
    {
        private float m_Price;
        private float m_MotivationDelta;
        private float m_ScoreDelta;
        private float m_Time;

        public event Action<float> ProgressChange;
        
        public float Price => m_Price;
        public DeskData AssignedDesk;
        public GroupData AssignedGroup;
        public float MotivationDelta => m_MotivationDelta;

        public float ScoreDelta => m_ScoreDelta;

        public float CurrentProgress;
        public float Duration;

        public TaskData(DeskData assignedDesk, GroupData assignedGroup)
        {
            m_Price = 1;
            m_MotivationDelta = 1;
            m_ScoreDelta = 1;
            m_Time = 60;

            AssignedDesk = assignedDesk;
            AssignedGroup = assignedGroup;
        }

        public void MakeProgress(float deltaTime)
        {
            float currentProgress = Mathf.Max(Duration, CurrentProgress + deltaTime * AssignedDesk.Skill);
            CurrentProgress = currentProgress;
            ProgressChange?.Invoke(CurrentProgress);
            
        }

        void TaskCompleted()
        {
            Debug.Log("Removed task");
            Game.Player.TaskDatas.Remove(this);
        }
    }
}
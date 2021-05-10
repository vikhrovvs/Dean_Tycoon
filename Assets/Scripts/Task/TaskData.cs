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
        public bool IsCompleted = false;
        
        public float Price => m_Price;
        public DeskData AssignedDesk;
        public GroupData AssignedGroup;
        public float MotivationDelta => m_MotivationDelta;

        public float ScoreDelta => m_ScoreDelta;

        public float CurrentProgress = 0f;
        public float Duration = 100f;

        public TaskData(DeskData assignedDesk, GroupData assignedGroup)
        {
            m_Price = 1;
            m_MotivationDelta = 1;
            m_ScoreDelta = 1;
            m_Time = 60;

            AssignedDesk = assignedDesk;
            AssignedGroup = assignedGroup;
            //Game.Player.TaskDatas.Add(this);
        }

        public void MakeProgress(float deltaTime)
        {
            float currentProgress = Mathf.Min(Duration, CurrentProgress + deltaTime * AssignedDesk.Skill);
            Debug.Log(CurrentProgress + " " + deltaTime);
            CurrentProgress = currentProgress;
            ProgressChange?.Invoke(CurrentProgress);
            if (CurrentProgress >= Duration)
            {
                IsCompleted = true;
            }
            
        }

        public void TaskCompleted()
        {
            Debug.Log("Removed task");
            AssignedGroup.PassCourse(this);
            Game.Player.TaskDatas.Remove(this);
        }
    }
}
using System;
using Employee;
using Runtime;
using Student;
using UI.InGame.TaskManagement;
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

        private TaskInfoUI m_UI;

        public TaskData(float price, float motivationDelta, float mScoreDelta, float duration)
        {
            m_Price = price;
            m_MotivationDelta = motivationDelta;
            m_ScoreDelta = ScoreDelta;


            //Game.Player.TaskDatas.Add(this);

    
        }

        public void AssignTask(DeskData assignedDesk, GroupData assignedGroup)
        {
            AssignedDesk = assignedDesk;
            AssignedGroup = assignedGroup;
            Game.Player.Charge(m_Price);
            m_UI = Game.Player.TaskManagementUI.AddTask(this);
        }

        public void MakeProgress(float deltaTime)
        {
            float currentProgress = Mathf.Min(Duration, CurrentProgress + deltaTime * AssignedDesk.Skill);
            
            m_UI.SetProgressBar(currentProgress/Duration);
            
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
            m_UI.Complete();
            Debug.Log("Removed task");
            AssignedGroup.PassCourse(this);
            Game.Player.TaskDatas.Remove(this);
        }
    }
}
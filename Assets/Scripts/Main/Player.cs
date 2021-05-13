using System;
using System.Collections.Generic;
using Employee;
using Field;
using Runtime;
using Student;
using Task;
using UI.InGame;
using UI.InGame.TaskManagement;
using UI.InGame.TaskSelection;
using UnityEngine;
using Grid = Field.Grid;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;

namespace Main
{
    public class Player
    {
        public float Money = 1000f;
        public float AverageScore = 0;
        
        public List<StudentData> Students;


        public readonly GridHolder GridHolder;
        public readonly Grid Grid;
        public List<DeskData> DeskDatas = new List<DeskData>();
        public List<GroupData> GroupDatas = new List<GroupData>();
        public List<TaskData> TaskDatas = new List<TaskData>();
        public List<TaskData> TaskPoolDatas = new List<TaskData>();

        public event Action<float> MoneyChanged;
        public event Action<float> ScoreChanged;


        //public readonly EnemySearch EnemySearch;
        public TaskManagementUI TaskManagementUI;
        public TaskSelectionUI TaskSelectionUI;
        public PauseHandler PauseHandler;

        public Player()
        {
            GridHolder = Object.FindObjectOfType<GridHolder>();
            GridHolder.CreateGrid();
            Grid = GridHolder.Grid;
            
            

            //EnemySearch = new EnemySearch(m_EnemyDatas);
        }

        public void HireStudent(StudentAsset asset)
        {
            StudentData data = new StudentData(asset);
            Game.Player.Charge((asset.m_MAXScore + asset.m_MINScore) * 2.5f + (asset.m_MAXMotivation  + asset.m_MINMotivation) * 7.5f);
            foreach (GroupData group in GroupDatas)
            {
                if (group.StudentDatas.Count < group.Asset.MaxGroupSize)
                {
                    group.AddStudent(data);
                    UpdateScore();
                    return;
                }
            }
            
            //DGroupView view = Object.Instantiate(asset.ViewPrefab);
            GroupData groupData = new GroupData(Game.s_Runner.InitGroupAsset);
            groupData.StudentDatas.Add(data);
            //data.AttachView(view);
            GroupDatas.Add(groupData);
            Debug.Log("Spawned Group");
            UpdateScore();
            //Students.Add(new StudentData(asset)); //maybe Students.add(data)...
        }

        public void Pause()
        {
            Time.timeScale = 0f;
            PauseHandler.Pause();
        }

        public void UnPause()
        {
            Time.timeScale = 1f;
            if (PauseHandler != null)
            {
                PauseHandler.UnPause();
            }
        }

        public void Charge(float charge)
        {
            Money -= charge;
            MoneyChanged?.Invoke(Money);

            if (Money < -2000f)
            {
                Game.GameOver();
            }
        }

        public void Raise(float raising)
        {
            Money += raising;
            MoneyChanged?.Invoke(Money);
        }

        public void UpdateScore()
        {
            int nGroups = 0;
            float totalScore = 0;
            foreach (GroupData groupData in GroupDatas)
            {
                totalScore += groupData.GetAvgScore();
                nGroups += 1;
            }

            AverageScore = totalScore / nGroups;
            ScoreChanged?.Invoke(AverageScore);
        }

        public void SetTaskManagementUI(TaskManagementUI taskManagementUI)
        {
            TaskManagementUI = taskManagementUI;
        }
        
        public void SetTaskSelectionUI(TaskSelectionUI taskSelectionUI)
        {
            TaskSelectionUI = taskSelectionUI;
        }

        public void SetPauseHandler(PauseHandler pauseHandler)
        {
            PauseHandler = pauseHandler;
        }
      
        public void CreateTask()
        {
            float scoreDelta = Random.Range(-2f, 10f);
            float motivationDelta = Random.Range(-0.5f, 1.5f);
            float price = Random.Range(0.8f, 1.2f) * (Mathf.Max(scoreDelta, 0) + Mathf.Max(motivationDelta, 0) * 3f) * 10f + 50f;
            float duration = Random.Range(0.8f, 1.2f) * 5f * price;
            TaskData newTask = new TaskData(price, motivationDelta, scoreDelta, duration);
            TaskPoolDatas.Add(newTask);
            //TODO Make a classification of the tasks based on the generated result
        }

        public void AssignTask(DeskData deskData, GroupData groupData, TaskData taskData)
        {
            taskData.AssignTask(deskData, groupData);
            TaskDatas.Add(taskData);
            TaskPoolDatas.Remove(taskData);
        }
    }
}
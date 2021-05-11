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
        public List<StudentData> Students;


        public readonly GridHolder GridHolder;
        public readonly Grid Grid;
        public List<DeskData> DeskDatas = new List<DeskData>();
        public List<GroupData> GroupDatas = new List<GroupData>();
        public List<TaskData> TaskDatas = new List<TaskData>();
        public List<TaskData> TaskPoolDatas = new List<TaskData>();

        public event Action<float> MoneyChanged;


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
                    return;
                }
            }
            
            //DGroupView view = Object.Instantiate(asset.ViewPrefab);
            GroupData groupData = new GroupData(Game.s_Runner.InitGroupAsset);
            groupData.StudentDatas.Add(data);
            //data.AttachView(view);
            GroupDatas.Add(groupData);
            Debug.Log("Spawned Group");
            //Students.Add(new StudentData(asset));
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
            Debug.Log("It's paying time, honey");
            Debug.Log($"Money: {Money}");

            if (Money < -2000f)
            {
                Game.GameOver();
            }
        }

        public void Raise(float raising)
        {
            Money += raising;
            MoneyChanged?.Invoke(Money);
            Debug.Log("It's raising time, honey");
            Debug.Log($"Money: {Money}");
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
            Debug.Log("Task created");
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
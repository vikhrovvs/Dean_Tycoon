using System;
using System.Collections.Generic;
using Runtime;
using Task;
using UnityEngine;

namespace UI.InGame.TaskManagement
{
    public class TaskManagementUI : MonoBehaviour
    {
        [SerializeField] private TaskInfoUI m_TaskInfoUIPrefab;
        [SerializeField] private Transform m_Content;
        
        private void Start()
        {
            Game.Player.SetTaskManagementUI(this);
        }

        public TaskInfoUI AddTask(TaskData data)
        {
            // TODO: pooling
            TaskInfoUI taskInfoUI = Instantiate(m_TaskInfoUIPrefab, m_Content);
            taskInfoUI.SetTask(data);
            return taskInfoUI;
        }
    }
}
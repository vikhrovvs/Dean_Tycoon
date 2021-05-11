using System.Collections.Generic;
using Runtime;
using Task;
using UnityEngine;

namespace UI.InGame.TaskSelection
{
    public class TaskSelectionUI : MonoBehaviour
    {
        [SerializeField] private GameObject m_SelectionObject;
        [SerializeField] private NewTaskInfoUI m_NewTaskInfoUIPrefab;
        private List<NewTaskInfoUI> m_Tasks = new List<NewTaskInfoUI>();
        
        private void Start()
        {
            Game.Player.SetTaskSelectionUI(this);
            CloseSelection();
        }

        public void OpenSelection()
        {
            Game.Player.Pause();
            m_SelectionObject.SetActive(true);
            foreach (TaskData taskData in Game.Player.TaskPoolDatas)
            {
                NewTaskInfoUI newTask = Instantiate(m_NewTaskInfoUIPrefab, m_SelectionObject.transform);
                newTask.SetTask(taskData, this);
                m_Tasks.Add(newTask);
            }
        }

        public void CloseSelection()
        {
            Debug.Log("Try to close selection");
            foreach (NewTaskInfoUI newTaskInfoUI in m_Tasks)
            {
                // TODO: pooling
                newTaskInfoUI.CloseUI();
            }
            m_Tasks.Clear();
            m_SelectionObject.SetActive(false);
            Game.Player.UnPause();
        }
    }
}
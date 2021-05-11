using System.Collections.Generic;
using Employee;
using Runtime;
using Student;
using Task;
using UnityEngine;
using UnityEngine.UI;

namespace UI.InGame.TaskSelection
{
    public class TaskSelectionUI : MonoBehaviour
    {
        [SerializeField] private GameObject m_SelectionObject;
        [SerializeField] private NewTaskInfoUI m_NewTaskInfoUIPrefab;
        [SerializeField] private Button m_CloseTaskSelectionButton;
        private List<NewTaskInfoUI> m_Tasks = new List<NewTaskInfoUI>();

        public DeskData m_DeskData;
        public GroupData m_GroupData;
        
        private void Start()
        {
            Game.Player.SetTaskSelectionUI(this);
            CloseSelection();
            m_CloseTaskSelectionButton.onClick.AddListener(CloseSelection);
        }

        public void OpenSelection(DeskData deskData, GroupData groupData)
        {
            Game.Player.Pause();
            m_DeskData = deskData;
            m_GroupData = groupData;
            
            m_SelectionObject.SetActive(true);
            m_CloseTaskSelectionButton.gameObject.SetActive(true);
            foreach (TaskData taskData in Game.Player.TaskPoolDatas)
            {
                NewTaskInfoUI newTask = Instantiate(m_NewTaskInfoUIPrefab, m_SelectionObject.transform);
                newTask.SetTask(taskData, this);
                m_Tasks.Add(newTask);
            }
        }

        public void CloseSelection()
        {
            foreach (NewTaskInfoUI newTaskInfoUI in m_Tasks)
            {
                // TODO: pooling
                newTaskInfoUI.CloseUI();
            }
            m_Tasks.Clear();
            m_CloseTaskSelectionButton.gameObject.SetActive(false);
            m_SelectionObject.SetActive(false);
            Game.Player.UnPause();
        }
    }
}
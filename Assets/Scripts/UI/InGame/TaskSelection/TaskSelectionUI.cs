using System.Collections;
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
        [SerializeField] private Text m_HireStudentsText;
        
        private List<NewTaskInfoUI> m_Tasks = new List<NewTaskInfoUI>();

        public DeskData m_DeskData;
        public GroupData m_GroupData;
        
        private void Start()
        {
            Game.Player.SetTaskSelectionUI(this);
            m_HireStudentsText.gameObject.SetActive(false);
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

        public void ShowText()
        {
            m_HireStudentsText.gameObject.SetActive(true);
            StartCoroutine(HideText());
        }

        IEnumerator HideText()
        {
            yield return new WaitForSeconds(1);
            m_HireStudentsText.gameObject.SetActive(false);
        }
    }
}
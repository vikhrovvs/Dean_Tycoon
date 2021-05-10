using System.Collections.Generic;
using Runtime;
using Student;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class HireStudentsUI : MonoBehaviour
    {
        [SerializeField] private Button m_OpenSelectionButton;
        [SerializeField] private Button m_CloseSelectionButton;

        [SerializeField] private GameObject m_SelectionObject;
        
        [SerializeField] private StudentInfoUI m_StudentInfoUIPrefab;
        [SerializeField] private Transform m_Content;
        
        private void Awake()
        {
            SubscribeOnButtons();
            ConstructStudentList();
            
            CloseSelection();
        }
        
        private void SubscribeOnButtons()
        {
            m_OpenSelectionButton.onClick.AddListener(OpenSelection);
            m_CloseSelectionButton.onClick.AddListener(CloseSelection);
        }
        
        private void OpenSelection()
        {
            m_SelectionObject.SetActive(true);
            m_OpenSelectionButton.gameObject.SetActive(false);
            
            Game.Player.Pause();
        }
        
        private void CloseSelection()
        {
            m_SelectionObject.SetActive(false);
            m_OpenSelectionButton.gameObject.SetActive(true);
            
            Game.Player.UnPause();
        }
        private void ConstructStudentList()
        {
            foreach (StudentAsset studentAsset in Game.CurrentLevel.StudentAssets)
            {
                StudentInfoUI studentInfoUI = Instantiate(m_StudentInfoUIPrefab, m_Content);
                studentInfoUI.SetStudent(studentAsset);
            }
        }
    }
}
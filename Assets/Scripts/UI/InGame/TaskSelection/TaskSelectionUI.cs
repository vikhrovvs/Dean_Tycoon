using UnityEngine;

namespace UI.InGame.TaskSelection
{
    public class TaskSelectionUI : MonoBehaviour
    {
        [SerializeField] private GameObject m_SelectionObject;
        [SerializeField]

        public void OpenSelection()
        {
            m_SelectionObject.SetActive(true);
        }

        public void CloseSelection()
        {
            m_SelectionObject.SetActive(false);
        }
    }
}
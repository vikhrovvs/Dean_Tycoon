using Task;
using UnityEngine;
using UnityEngine.UI;

namespace UI.InGame.TaskManagement
{
    public class TaskInfoUI : MonoBehaviour
    {
        [SerializeField] private Text duration;
        private TaskData m_Data;
        public void SetTask(TaskData data)
        {
            m_Data = data;
            duration.text = $"Duration: {data.Duration}";
        }
    }
}
using Task;
using UnityEngine;
using UnityEngine.UI;

namespace UI.InGame.TaskManagement
{
    public class TaskInfoUI : MonoBehaviour
    {
        [SerializeField] private Text duration;
        [SerializeField] private RectTransform m_ProgressBar;
        
        private TaskData m_Data;
        public void SetTask(TaskData data)
        {
            m_Data = data;
            duration.text = $"Сложность: {data.Duration}";
        }

        public void Complete()
        {
            Destroy(gameObject);
        }

        public void SetProgressBar(float percentage)
        {
            percentage = Mathf.Clamp01(percentage);
            
            m_ProgressBar.anchorMin = Vector2.zero;
            m_ProgressBar.anchorMax = new Vector2(percentage, 1f);
        }
    }
}
using Task;
using UnityEngine;
using UnityEngine.UI;

namespace UI.InGame.TaskSelection
{
    public class NewTaskInfoUI : MonoBehaviour
    {
        [SerializeField] private Text m_Price;
        [SerializeField] private Text m_Duration;
        [SerializeField] private Text m_Motivation;
        [SerializeField] private Text m_Score;

        private TaskData m_Data;

        public void SetTask(TaskData data)
        {
            m_Data = data;
            m_Price.text = $"Стоимость выполнения: {data.Price}";
            m_Duration.text = $"Сложность выполнения: {data.Duration}";
            m_Motivation.text = $"Изменит мотивацию студентов на: {data.MotivationDelta}";
            m_Price.text = $"Изменит балл студентов на: {data.ScoreDelta}";
        }
    }
}
using Runtime;
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
        [SerializeField] private Button m_Button;

        private TaskData m_Data;
        private TaskSelectionUI m_TaskSelectionUI;

        public void SetTask(TaskData data, TaskSelectionUI taskSelectionUI)
        {
            m_Data = data;
            m_Price.text = $"Стоимость выполнения: {data.Price}";
            m_Duration.text = $"Сложность выполнения: {data.Duration}";
            m_Motivation.text = $"Изменит мотивацию студентов на: {data.MotivationDelta}";
            m_Score.text = $"Изменит балл студентов на: {data.ScoreDelta}";

            m_TaskSelectionUI = taskSelectionUI;
            m_Button.onClick.AddListener(ChooseThisTask);
        }

        private void ChooseThisTask()
        {
            Game.Player.AssignTask(m_TaskSelectionUI.m_DeskData, m_TaskSelectionUI.m_GroupData, m_Data);
            m_TaskSelectionUI.CloseSelection();
        }

        public void CloseUI()
        {
            Destroy(this.gameObject);
        }
    }
}
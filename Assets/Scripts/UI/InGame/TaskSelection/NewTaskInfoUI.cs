using Runtime;
using Task;
using UI.InGame.TaskSelection;
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
            m_Price.text = $"Стоимость: {Round2f(data.Price)}";
            m_Duration.text = $"Сложность: {Round2f(data.Duration)}";
            m_Motivation.text = $"Мотивация: {Round2f(data.MotivationDelta)}";
            m_Score.text = $"Успеваемость: {Round2f(data.ScoreDelta)}";

            m_TaskSelectionUI = taskSelectionUI;
            m_Button.onClick.AddListener(ChooseThisTask);
        }

        private float Round2f(float f)
        {
            return Mathf.Round(f * 100f) / 100f;
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
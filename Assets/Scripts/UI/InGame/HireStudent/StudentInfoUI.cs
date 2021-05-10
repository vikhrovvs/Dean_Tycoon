using Runtime;
using Student;
using UnityEngine;
using UnityEngine.UI;

namespace UI.InGame.HireStudent
{
    public class StudentInfoUI: MonoBehaviour
    {
        [SerializeField] private Text m_StudentType;
        [SerializeField] private Text m_PriceText;
        [SerializeField] private Text m_ScoreText;
        [SerializeField] private Text m_MotivationText;

        [SerializeField] private Button m_ChooseButton;

        private StudentAsset m_Asset;

        public void SetStudent(StudentAsset asset)
        {
            m_Asset = asset;
            m_StudentType.text = asset.m_StudentType;
            m_PriceText.text = $"Стоимость обучения: {asset.price}";
            m_ScoreText.text = $"Начальный балл: от {asset.m_MINScore} до {asset.m_MAXScore}";
            m_MotivationText.text = $"Начальная мотивация: от {asset.m_MINMotivation} до {asset.m_MAXMotivation}";
            
            m_ChooseButton.onClick.AddListener(OnClick);
        }

        private void OnClick()
        {
            Debug.Log("Hired student " + m_Asset.m_StudentType);
            Game.Player.HireStudent(m_Asset);
        }
    }
}
using System.Collections.Generic;
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
            m_PriceText.text = $"Стоимость обучения: {2.5f*(asset.m_MAXScore + asset.m_MINScore) + 7.5f * (asset.m_MAXMotivation + asset.m_MINMotivation)}";
            m_ScoreText.text = $"Начальный балл: от {asset.m_MINScore} до {asset.m_MAXScore}";
            m_MotivationText.text = $"Начальная мотивация: от {asset.m_MINMotivation} до {asset.m_MAXMotivation}";

            foreach (Text text in new List<Text>{m_StudentType, m_PriceText, m_ScoreText, m_MotivationText})
            {
                text.font = Game.AssetRoot.MainFont;
            }
            
            m_ChooseButton.onClick.AddListener(OnClick);
        }

        private void OnClick()
        {
            Debug.Log("Hired student " + m_Asset.m_StudentType);
            Game.Player.HireStudent(m_Asset);
        }
    }
}
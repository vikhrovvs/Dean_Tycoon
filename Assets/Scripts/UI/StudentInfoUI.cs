using Runtime;
using Student;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class StudentInfoUI: MonoBehaviour
    {
        [SerializeField] private Text m_PriceText;
        [SerializeField] private Text m_ScoreText;
        [SerializeField] private Text m_MotivationText;

        [SerializeField] private Button m_ChooseButton;

        private StudentAsset m_Asset;

        public void SetStudent(StudentAsset asset)
        {
            m_Asset = asset;
            m_PriceText.text = $"Price: {asset.price}";
            m_ScoreText.text = $"Score: from {asset.m_MINScore} to {asset.m_MAXScore}";
            m_MotivationText.text = $"Score: from {asset.m_MINMotivation} to {asset.m_MAXMotivation}";
        }

        private void OnClick()
        {
            Game.Player.HireStudent(m_Asset);
        }
    }
}
using Runtime;
using UnityEngine;
using UnityEngine.UI;
using Utils;

namespace UI.InGame
{
    public class GameplayInfoUI : MonoBehaviour
    {
        [SerializeField] private Text m_MoneyText;
        [SerializeField] private Text m_ScoreText;

        private void OnEnable()
        {
            SetMoney(Game.Player.Money);
            m_MoneyText.font = Game.AssetRoot.MainFont;
            m_ScoreText.font = Game.AssetRoot.MainFont;
            Game.Player.MoneyChanged += SetMoney;
            Game.Player.ScoreChanged += SetScore;
        }

        private void SetMoney(float money)
        {
            m_MoneyText.text = $"Бюджет: {(int) money}";
        }

        private void SetScore(float score)
        {
            m_ScoreText.text = $"Средний балл: {MathUtils.Round2F(score)}";
        }
    }
}
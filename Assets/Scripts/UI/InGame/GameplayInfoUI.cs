using Runtime;
using UnityEngine;
using UnityEngine.UI;

namespace UI.InGame
{
    public class GameplayInfoUI : MonoBehaviour
    {
        [SerializeField] private Text m_MoneyText;

        private void OnEnable()
        {
            SetMoney(Game.Player.Money);
            Game.Player.MoneyChanged += SetMoney;
        }

        private void SetMoney(float money)
        {
            m_MoneyText.text = $"Money: {(int) money}";
        }
    }
}
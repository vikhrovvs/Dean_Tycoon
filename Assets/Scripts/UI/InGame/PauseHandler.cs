using System;
using Runtime;
using UnityEngine;
using UnityEngine.UI;

namespace UI.InGame
{
    public class PauseHandler : MonoBehaviour
    {
        [SerializeField] private Image m_Image;

        private void Start()
        {
            Game.Player.SetPauseHandler(this);
            m_Image.GetComponentInChildren<Text>().font = Game.AssetRoot.MainFont;
        }

        public void Pause()
        {
            m_Image.gameObject.SetActive(true);
        }

        public void UnPause()
        {
            m_Image.gameObject.SetActive(false);
        }
    }
}
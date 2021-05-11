using Assets;
using UnityEngine;

namespace Runtime
{
    public class GameOver : MonoBehaviour
    {
        // Start is called before the first frame update
        [SerializeField] private AssetRoot m_AssetRoot;

        private void Awake()
        {
            Game.SetAssetRoot(m_AssetRoot);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Game.StartLevel(m_AssetRoot.Levels[0]);
            }
        }
    }
}

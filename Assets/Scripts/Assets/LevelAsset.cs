using System;
using Employee;
using Field;
using Main;
using Runtime;
using UnityEditor;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Assets
{
    [CreateAssetMenu(menuName = "Assets/Level Asset", fileName = "Level Asset")]
    public class LevelAsset : ScriptableObject
    {
        public SceneAsset SceneAsset;
        public DeskAsset InitDeskAsset;
        public Vector3Int InitDeskPosition;

        private void OnValidate()
        {
            try
            {
                DeskView InitDeskView = Object.Instantiate(InitDeskAsset.ViewPrefab);
                DeskData InitDeskData = new DeskData(InitDeskAsset, Game.Player.Grid.GetNode(0, 0));
                InitDeskData.AttachView(InitDeskView);
            }
            catch (Exception e)
            {
                Debug.Log("No prefabs");
            }
            
        }
    }
}
using System;
using Employee;
using Field;
using Main;
using Runtime;
using Student;
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
        public StudentAsset[] StudentAssets;

    }
}
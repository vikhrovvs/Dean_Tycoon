using Student;
using UnityEngine;

namespace Assets
{
    [CreateAssetMenu(menuName = "Assets/Level Asset", fileName = "Level Asset")]
    public class LevelAsset : ScriptableObject
    {
        public string SceneName;
        public StudentAsset[] StudentAssets;
    }
}
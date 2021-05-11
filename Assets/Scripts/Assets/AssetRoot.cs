using UnityEngine;
using System.Collections.Generic;

namespace Assets
{
    [CreateAssetMenu(menuName = "Assets/Asset root", fileName = "Asset root")]
    public class AssetRoot: ScriptableObject
    {
        public string UISceneName;
        public List<LevelAsset> Levels;
    }
}
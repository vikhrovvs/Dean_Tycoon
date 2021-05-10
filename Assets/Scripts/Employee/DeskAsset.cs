using UnityEngine;

namespace Employee
{

    [CreateAssetMenu(menuName = "Assets/Desk Asset", fileName = "Desk Asset")]

    public class DeskAsset : ScriptableObject
    {
        public DeskView ViewPrefab;
        public float Skill = 10f;
    }
}
using UnityEngine;

namespace Student
{
    [CreateAssetMenu(menuName = "Assets/Group Asset", fileName = "Group Asset")]
    public class GroupAsset : ScriptableObject
    {
        [SerializeField] public int MaxGroupSize = 20;
    }
}
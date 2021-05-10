using UnityEngine;

namespace Student
{
    [CreateAssetMenu(menuName = "Assets/Student Asset", fileName = "Student Asset")]
    public class StudentAsset : ScriptableObject
    {
        public string m_StudentType;
        public float m_MINScore;
        public float m_MAXScore;

        public float m_MINMotivation;
        public float m_MAXMotivation;

        public int price;
    }
}
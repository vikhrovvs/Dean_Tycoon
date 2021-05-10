using System;
using Task;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Student
{
    public class StudentData
    {
        private float m_Score;
        private float m_Motivation;
        private StudentAsset m_Asset;

        public float Score => m_Score;

        public float Motivation => m_Motivation;

        public StudentData(StudentAsset asset)
        {
            m_Score = Random.Range(asset.m_MINScore, asset.m_MAXScore);
            m_Motivation = Random.Range(asset.m_MINMotivation, asset.m_MAXMotivation);
            m_Asset = asset;
        }

        public void PassCourse(TaskData task)
        {
            m_Score = Mathf.Clamp((m_Score + task.ScoreDelta * m_Motivation), m_Asset.m_MINScore, m_Asset.m_MAXScore);
            m_Motivation = Mathf.Clamp((m_Motivation + task.MotivationDelta), m_Asset.m_MINMotivation,
                m_Asset.m_MAXMotivation);
        }
    }
}
using System;
using Course;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Student
{
    public class StudentData
    {
        private float m_Score;
        private float m_Motivation;
        private StudentAsset m_Asset;

        public StudentData(StudentAsset asset)
        {
            m_Score = Random.Range(asset.m_MINScore, asset.m_MAXScore);
            m_Motivation = Random.Range(asset.m_MINMotivation, asset.m_MAXMotivation);
            m_Asset = asset;
        }

        public void PassCourse(CourseData course)
        {
            m_Score = Mathf.Clamp((m_Score + course.ScoreDelta * m_Motivation), m_Asset.m_MINScore, m_Asset.m_MAXScore);
            m_Motivation = Mathf.Clamp((m_Motivation + course.MotivationDelta), m_Asset.m_MINMotivation,
                m_Asset.m_MAXMotivation);
        }
    }
}
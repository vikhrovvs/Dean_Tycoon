using System.Collections.Generic;
using Runtime;
using Task;
using UnityEngine;

namespace Student
{
    public class GroupData
    {
        private GroupAsset m_Asset;

        public GroupAsset Asset => m_Asset;

        public List<StudentData> StudentDatas = new List<StudentData>();

        public GroupData(GroupAsset asset)
        {
            m_Asset = asset;
        }

        public int AddStudent(StudentData student)
        {
            if (StudentDatas.Count < m_Asset.MaxGroupSize)
            {
                StudentDatas.Add(student);
                return 0;
            }
            else
            {
                return -1;
            }
        }

        public void PassCourse(TaskData task)
        {
            foreach (StudentData student in StudentDatas)
            {
                student.PassCourse(task);
            }
            Game.Player.UpdateScore();
        }

        public float GetScore()
        {
            float score = 0;
            foreach (StudentData student in StudentDatas)
            {
                score += student.Score;
            }

            return score;
        }

        public float GetAvgScore()
        {
            return GetScore() / StudentDatas.Count;
        }

        public float GetMotivation()
        {
            float motivation = 0;
            foreach (StudentData student in StudentDatas)
            {
                motivation += student.Motivation;
            }

            return motivation;
        }
        
        public float GetAvgMotivation()
        {
            return GetMotivation() / StudentDatas.Count;
        }
    }
}
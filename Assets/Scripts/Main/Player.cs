using System.Collections.Generic;
using Field;
using Student;
using UnityEngine;
using Grid = Field.Grid;

namespace Main
{
    public class Player
    {
        public int money;
        public List<StudentData> Students;


        public readonly GridHolder GridHolder;
        public readonly Grid Grid;
        //public readonly EnemySearch EnemySearch;

        public Player()
        {
            GridHolder = Object.FindObjectOfType<GridHolder>();
            GridHolder.CreateGrid();
            Grid = GridHolder.Grid;


            //EnemySearch = new EnemySearch(m_EnemyDatas);
        }

        public void HireStudent(StudentAsset asset)
        {
            Students.Add(new StudentData(asset));
        }

        public void Pause()
        {
            Time.timeScale = 0f;
        }

        public void UnPause()
        {
            Time.timeScale = 1f;
        }
    }
}
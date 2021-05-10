using System.Collections.Generic;
using Employee;
using Field;
using Runtime;
using Student;
using UnityEngine;
using Grid = Field.Grid;

namespace Main
{
    public class Player
    {
        public float Money;
        public List<StudentData> Students;


        public readonly GridHolder GridHolder;
        public readonly Grid Grid;
        public List<DeskData> DeskDatas = new List<DeskData>();
        public List<GroupData> GroupDatas = new List<GroupData>();


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
            StudentData data = new StudentData(asset);
            
            foreach (GroupData group in GroupDatas)
            {
                if (group.StudentDatas.Count < group.Asset.MaxGroupSize)
                {
                    group.AddStudent(data);
                    return;
                }
            }
            
            //DGroupView view = Object.Instantiate(asset.ViewPrefab);
            GroupData groupData = new GroupData(Game.s_Runner.InitGroupAsset);
            groupData.StudentDatas.Add(data);
            //data.AttachView(view);
            GroupDatas.Add(groupData);
            Debug.Log("Spawned Group");
            //Students.Add(new StudentData(asset));
        }

        public void Pause()
        {
            Time.timeScale = 0f;
        }

        public void UnPause()
        {
            Time.timeScale = 1f;
        }

        public void Charge(float charge)
        {
            Money -= charge;
            Debug.Log("It's paying time, honey");
            Debug.Log("Money: " + Money);
        }
    }
}
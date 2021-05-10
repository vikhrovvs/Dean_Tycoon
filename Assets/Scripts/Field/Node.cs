using System.Collections.Generic;
//using Employee;
using UnityEngine;

namespace Field
{
    public enum OccupationAvailability
    {
        CanOccupy,
        CanNotOccupy,
        Undefined
    }
    public class Node
    {
        public Vector3 Position;

        public Node NextNode;
        public bool IsOccupied = false;
        
        public float PathWeight;
        public OccupationAvailability OccupationAvailability = OccupationAvailability.Undefined;
        //public List<EmployeeData> EnemyDatas;
        
        public Node(Vector3 position)
        {
            //EnemyDatas = new List<EmployeeData>();
            Position = position;
        }
        
        public void ResetWeight()
        {
            PathWeight = float.MaxValue;
        }


    }
}
using System.Collections.Generic;
using Field;
using UnityEngine;
using Grid = Field.Grid;

namespace Main
{
    public class Player
    {
        
        

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
    }
}
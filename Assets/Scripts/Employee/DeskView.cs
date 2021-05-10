using UnityEngine;
using Grid = Field.Grid;

namespace Employee
{
    public class DeskView : MonoBehaviour
    {
        private DeskData m_Data;

        public DeskData Data => m_Data;
        
        public void AttachData(DeskData data)
        {
            m_Data = data;
            transform.position = m_Data.Node.Position;
        }
    }
}
using System;
using System.Threading;
using UnityEngine;

namespace Field
{
    public class GridHolder : MonoBehaviour
    {
        [SerializeField] private int m_GridWidth = 20;
        [SerializeField] private int m_GridHeight = 20;




        [SerializeField] private float m_NodeSize = 1f;

        private Grid m_Grid;

        private Camera m_Camera;

        private Vector3 m_Offset;

        private void Awake()
        {

        }

        public Grid Grid => m_Grid;

        public void CreateGrid()
        {
            m_Camera = Camera.main;
            float width = m_GridWidth * m_NodeSize;
            float height = m_GridHeight * m_NodeSize;

            transform.localScale = new Vector3(
                width * 0.1f,
                1f,
                height * 0.1f);

            m_Offset = transform.position - (new Vector3(width, 0f, height) * 0.5f);
            m_Grid = new Grid(m_GridWidth, m_GridHeight, m_Offset, m_NodeSize);

        }

        // Identical to the one we wrote on the lesson
        public void RaycastInGrid()
        {
            if (m_Grid == null || m_Camera == null)
            {
                return;
            }

            Vector3 mousePosition = Input.mousePosition;

            Ray ray = m_Camera.ScreenPointToRay(mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (hit.transform != transform)
                {
                    m_Grid.UnselectNode();
                    return;
                }

                Vector3 hitPosition = hit.point;
                Vector3 difference = hitPosition - m_Offset;

                int x = (int) (difference.x / m_NodeSize);
                int y = (int) (difference.z / m_NodeSize);

                //Debug.Log(x + " " + y);
                m_Grid.SelectCoordinate(new Vector2Int(x, y));
                /*if (Input.GetMouseButtonDown(0))
                {
                    Node node = m_Grid.GetNode(x, y);
                    m_Grid.TryOccupyNode(new Vector2Int(x, y), !node.IsOccupied);
                }*/
            }
            else
            {
                m_Grid.UnselectNode();
            }
        }

        // Using OnValidate to be able to see the current grid
        // outside the game mode
        private void OnValidate()
        {
            m_Camera = Camera.main;
            float width = m_GridWidth * m_NodeSize;
            float height = m_GridHeight * m_NodeSize;

            transform.localScale = new Vector3(
                width * 0.1f,
                1f,
                height * 0.1f);

            m_Offset = transform.position - (new Vector3(width, 0f, height) * 0.5f);
            m_Grid = new Grid(m_GridWidth, m_GridHeight, m_Offset, m_NodeSize);
        }
    }
}
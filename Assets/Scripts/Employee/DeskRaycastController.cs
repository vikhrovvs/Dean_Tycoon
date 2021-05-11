using Field;
using Runtime;
using Student;
using UnityEngine;
using UnityEngine.UIElements;

namespace Employee
{
    public class DeskRaycastController : IController
    {
        private GridHolder m_GridHolder;

        public DeskRaycastController(GridHolder mGridHolder)
        {
            m_GridHolder = mGridHolder;
        }

        public void OnStart()
        {

        }

        public void OnStop()
        {

        }

        public void Tick()
        {
            
            if (Input.GetMouseButtonDown(0))
            {
                foreach (DeskData desk in Game.Player.DeskDatas)
                {
                    Vector3 mousePosition = Input.mousePosition;

                    Ray ray = m_GridHolder.Camera.ScreenPointToRay(mousePosition);
                    if (Physics.Raycast(ray, out RaycastHit hit))
                    {
                        if (hit.transform != desk.View.transform)
                        {
                            return;
                        }
                        Debug.Log("XYU " + Game.Player.DeskDatas.Count + " " + 
                                  Game.Player.GroupDatas.Count + " " +
                                  Game.Player.TaskPoolDatas.Count);
                        Game.Player.TaskSelectionUI.OpenSelection();
                        Game.Player.AssignTask(Game.Player.DeskDatas[0], Game.Player.GroupDatas[0], Game.Player.TaskPoolDatas[0]);
                        Debug.Log("Hit on the desk!");
                    }
                }
            }
        }
    }
}
using Field;
using Runtime;
using UnityEngine;
using Grid = Field.Grid;

namespace Employee
{
    public class DeskSpawnController : IController
    {
        private Grid m_Grid;

        public DeskSpawnController(Grid grid)
        {
            m_Grid = grid;
        }
        
        public void OnStart()
        {
            SpawnDesk(Game.s_Runner.InitDeskAsset, m_Grid.GetNode(0, 0));
        }

        public void OnStop()
        {
        }

        public void Tick()
        {
            if (m_Grid.HasSelectedNode() && Input.GetMouseButtonDown(0))
            {
                Node selectedNode = m_Grid.GetSelectedNode();

                if (selectedNode.IsOccupied /* || !m_Grid.CanOccupy(selectedNode)*/) // TODO think of implementing; problem - CanOccupy gets Vector2Int
                {
                    return;
                }

                //SpawnDesk(Game.s_Runner.InitDeskAsset, selectedNode);
            }
        }

        private void SpawnDesk(DeskAsset asset, Node node)
        {
            DeskView view = Object.Instantiate(asset.ViewPrefab);
            DeskData data = new DeskData(asset, node);
            
            data.AttachView(view);
            Game.Player.DeskDatas.Add(data);
            Debug.Log("Spawned Desk");
            Debug.Log(view.transform.position);
            //Game.Player.TurretSpawned(data);

            //node.IsOccupied = true; // TryOccupy()
            //m_Grid.UpdatePathfinding();
        }
    }
}
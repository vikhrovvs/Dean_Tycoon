using System.Collections;
using Assets;
using Field;
using Runtime;
using UnityEngine;

namespace Employee
{
    public class DeskData
    {
        private DeskView m_View;
        private Node m_Node;

        public DeskView View => m_View;
        public Node Node => m_Node;
        private DeskAsset m_Asset;

        public DeskAsset Asset => m_Asset;
        public DeskData(DeskAsset mAsset, Node node)
        {
            m_Asset = mAsset;
            m_Node = node;
        }

        public void AttachView(DeskView view)
        {
            m_View = view;
            m_View.AttachData(this);
        }

    }
}
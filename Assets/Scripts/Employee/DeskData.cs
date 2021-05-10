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

        private float m_Skill = 10f;
        public float Skill => m_Skill;

        public DeskAsset Asset => m_Asset;
        public DeskData(DeskAsset mAsset, Node node)
        {
            m_Asset = mAsset;
            m_Node = node;
            m_Skill = mAsset.Skill;
        }

        public void AttachView(DeskView view)
        {
            m_View = view;
            m_View.AttachData(this);
        }

    }
}
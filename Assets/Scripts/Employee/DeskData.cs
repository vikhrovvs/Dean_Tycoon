using System.Collections;
using Assets;
using Runtime;
using UnityEngine;

namespace Employee
{
    public class DeskData
    {
        private DeskView m_View;

        public DeskView View => m_View;

        private DeskAsset m_Asset;

        public DeskAsset Asset => m_Asset;
        public DeskData(DeskAsset mAsset)
        {
            m_Asset = mAsset;
        }

        public void AttachView(DeskView view)
        {
            m_View = view;
            m_View.AttachData(this);
        }

    }
}
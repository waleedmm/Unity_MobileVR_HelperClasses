using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.QuestSystemManagement
{
    [Serializable]
    public class QuestAcivation_GameObject
    {
        public GameObject m_AffectedObject;
        public bool m_DisableBeforeTask, 
            m_DisableAfterTask;
    }
}

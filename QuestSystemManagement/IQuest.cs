using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.QuestSystemManagement
{
    public interface IQuest
    {
        void Initialize();
        void ReportComplete();
        bool IsDone();

    }
}

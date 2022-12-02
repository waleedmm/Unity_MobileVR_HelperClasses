using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Experiment_01.UI
{
    public interface IUIManager
    {

        void ShowMessage(string message,bool makeBeep);
        void ClearMessages();
    }
}

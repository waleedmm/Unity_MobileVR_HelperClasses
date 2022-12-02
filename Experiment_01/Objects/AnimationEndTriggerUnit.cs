using System.Collections;
using UnityEngine; 
namespace Assets.Scripts.Experiment_01.Objects
{
    public class AnimationEndTriggerUnit : MonoBehaviour
    {
        [HideInInspector]
        public ExperimentItemManager m_TargetExperiment;

        /// <summary>
        /// note: This method name should be the same as animation event trigger in animation window
        /// https://docs.unity3d.com/Manual/script-AnimationWindowEvent.html
        /// </summary>
        public void TriggerEndOfAnimationClip()  //this name shall be used in animation window
        {
            if (m_TargetExperiment != null)
                m_TargetExperiment.ReportTaskCompletedSuccessfully();
        }
        // Use this for initialization
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
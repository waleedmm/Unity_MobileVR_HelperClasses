using System.Collections;
using UnityEngine;
using UnityEngine.Events;
namespace Assets.Scripts.Experiment_01.UI
{
    [RequireComponent(typeof(BoxCollider))]
    public class UIGazeSelectable : MonoBehaviour, IGazeSelectable
    {
        public CircularProgressManager m_CircularManager;
        public SceneSwitcher m_SceneSwitcher;
        public int m_TargetSceneIndex;
        public bool m_UseCurrentSceneIndex;
        public UIClickMode m_UIMode = UIClickMode.SwitchScene;
        public UnityEvent m_ToCallMethodOnCompletion;
        public void OnPointerClick()
        {
            Debug.Log(name + " Game Object Clicked!");
        }

        public void OnPointerEnter()
        {
            Debug.Log(name + " Game Object mouse entered!");
            //m_Animator.Play(m_AnimationName);
            m_CircularManager.enabled = true;
            m_CircularManager.StartProgress();
        }
        public void OnPointerExit()
        {
            Debug.Log(name + " Game Object Exit");
            m_CircularManager.CancelProgress();
        }

        public void OnGazeProgressCompleted()
        {
            //throw new System.NotImplementedException();
            if (m_SceneSwitcher != null)
            {
                switch(m_UIMode)
                {
                    case UIClickMode.SwitchScene:
                        m_SceneSwitcher.SwitchToScene(m_TargetSceneIndex);
                        break;
                    case UIClickMode.ExitApplication:
                        m_SceneSwitcher.ExitApplication();
                        break;
                    case UIClickMode.CallMethod:
                        if (m_ToCallMethodOnCompletion != null)
                            m_ToCallMethodOnCompletion.Invoke();
                        break;

                }
                
            }
        }

       

       

        // Use this for initialization
        void Start()
        {
            if (m_UseCurrentSceneIndex)
                m_TargetSceneIndex = UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex;
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
    public enum UIClickMode
    { 
        SwitchScene,CallMethod , ExitApplication
    }
}
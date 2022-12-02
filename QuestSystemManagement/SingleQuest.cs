using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.QuestSystemManagement
{
    
    public  class SingleQuest : MonoBehaviour 
    {
        public string m_Title , m_Description;
        public QuestState m_State;
        public QuestsManager m_Manager;
        public QuestAcivation_GameObject[] m_AffectedObjects;
        public AudioClip m_VoiceInstruction;

        public UnityEvent m_OnInitializationEvent, m_OnPostCompletionEvent;
        public virtual void Initialize()
        {
            print("Starting Task-" + m_Title);

            //enable pre objects
            foreach (QuestAcivation_GameObject q in m_AffectedObjects)
            {
               q.m_AffectedObject.SetActive(true);
            }

            m_State = QuestState.Ready;
            if (m_OnInitializationEvent != null)
                m_OnInitializationEvent.Invoke();
        }
        public void AskToRepeatLastInstruction()
        {
            m_Manager.RepeatLastAudioInstruction();
        }
        public bool IsMeInOrder()
        {
            return m_Manager.IsInOrderQuest(this);
        }
        public virtual void ReportComplete()
        {
            print("Task Completed-" + m_Title);
            m_State = QuestState.Completed;
            if (m_Manager != null)
                m_Manager.ReportTaskCompletion(this);

            //disable post objects
            foreach (QuestAcivation_GameObject q in m_AffectedObjects)
            {
                if (q.m_DisableAfterTask)
                    q.m_AffectedObject.SetActive(false);
            }

            if (m_OnPostCompletionEvent != null)
                m_OnPostCompletionEvent.Invoke();


        }
        public virtual bool IsDone() 
        {
            return m_State == QuestState.Completed;    
        }

        public virtual void UnLoad()
        {
            //disable pre objects
            foreach (QuestAcivation_GameObject q in m_AffectedObjects)
            {
                if (q.m_DisableBeforeTask)
                    q.m_AffectedObject.SetActive(false);
            }
        }
        // Use this for initialization
        void Start()
        {
            if(m_Manager==null)
                m_Manager = GameObject.FindObjectOfType<QuestsManager>();
  
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
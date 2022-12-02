using System.Collections;
using UnityEngine;
using System.Collections.Generic;
using Assets.Scripts.Experiment_01.UI;
using UnityEngine.Events;

namespace Assets.Scripts.QuestSystemManagement
{
    public class QuestsManager : MonoBehaviour
    {
        public SingleQuest[] m_Quests;

        private List<SingleQuest> m_RemainingQuests, m_DoneQuests;

        public VRInstructionUIManager m_UIManager;
        public bool m_WorkInSequence = false;

        public UnityEvent m_OnCompletingAllTasks;
        private bool m_AreAllTasksDone = false;

        
        private void Initialize()
        {
            m_RemainingQuests = new List<SingleQuest>();
            m_DoneQuests = new List<SingleQuest>();

            foreach (SingleQuest quest in m_Quests)
            {
                if (quest.m_State == QuestState.Completed)
                {
                    m_DoneQuests.Add(quest);
                }

                else
                {
                    m_RemainingQuests.Add(quest);
                }
            }
            if (m_WorkInSequence)
            {
                foreach (SingleQuest quest in m_Quests)
                {
                    quest.UnLoad();
                }
                AdvanceToNextQuest();
            }
            ShowMessage("Remaining quests:" + m_RemainingQuests.Count,false);

        }
        public bool IsInOrderQuest(SingleQuest toCheck)
        {
            if (!m_WorkInSequence)
                return true;
            else
            {
                if (m_RemainingQuests.Count > 0)
                    return m_RemainingQuests[0] == toCheck;
                else
                    return false;
            }
        }
        void AdvanceToNextQuest()
        {
            if (m_AreAllTasksDone)
            {
                print("All tasks are completed");
            }
            if (m_RemainingQuests.Count > 0)
            {
                if (m_WorkInSequence)
                {
                    m_RemainingQuests[0].Initialize();//always get top of remaining stack (index 0)
                    if(m_UIManager!=null)
                    {
                        m_UIManager.ShowMessage(m_RemainingQuests[0].m_Description,false);
                        m_UIManager.PlayInstructionAudioClip(m_RemainingQuests[0].m_VoiceInstruction);

                    }
                }
            }
            else
            {
                m_AreAllTasksDone = true;
                //m_UIManager.ShowMessage();
                m_UIManager.PromptFinalSuccessfulCompletion("All Tasks are Completed");
                if (m_OnCompletingAllTasks != null)
                    m_OnCompletingAllTasks.Invoke();
            }
        }
        public void RepeatLastAudioInstruction()
        {
            if (m_RemainingQuests.Count > 0)
            {
                m_UIManager.PlayInstructionAudioClip(m_RemainingQuests[0].m_VoiceInstruction);
            }
        }
        public void ReportTaskCompletion(SingleQuest quest)
        {
            if (m_RemainingQuests.Contains(quest))
            {
                quest.UnLoad();
                m_RemainingQuests.Remove(quest);
                m_DoneQuests.Add(quest);
                if(m_WorkInSequence)
                    AdvanceToNextQuest();
            }
            ShowMessage("Remaining quests:" + m_RemainingQuests.Count, true);


        }
        void ShowMessage(string message, bool makeBeep)
        {
            print(message);
            if (m_UIManager != null)
                m_UIManager.ShowMessage(message, makeBeep);
        }
        // Use this for initialization
        void Start()
        {
            Initialize();
        }

       

        // Update is called once per frame
        void Update()
        {

        }
    }
}
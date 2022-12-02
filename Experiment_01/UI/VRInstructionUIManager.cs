using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
namespace Assets.Scripts.Experiment_01.UI
{
    public class VRInstructionUIManager : MonoBehaviour, IUIManager
    {
        public TextMeshProUGUI m_MessagesTextMesh;
        public AudioSource m_AudioSource;
        public AudioClip m_UIConfirmClip;

        public AudioClip m_SuccessfullCompletionMessage;
        public void ClearMessages()
        {
            m_MessagesTextMesh.text = "";
        }
        public void PromptFinalSuccessfulCompletion(string message)
        {
            if (m_SuccessfullCompletionMessage != null && m_AudioSource != null)
                m_AudioSource.PlayOneShot(m_SuccessfullCompletionMessage);
            ShowMessage(message, false);
        }
        public void ShowMessage(string message,bool makeBeep=false)
        {
            m_MessagesTextMesh.text = message;
            if(makeBeep)
                PlayUIBeep();
        }

        public void PlayUIBeep()
        {
            if (m_AudioSource != null && m_UIConfirmClip != null)
            {
                m_AudioSource.PlayOneShot(m_UIConfirmClip);
            }
        }
        public void PlayInstructionAudioClip(AudioClip clip)
        {
            if (m_AudioSource != null && m_UIConfirmClip != null)
            {
                m_AudioSource.PlayOneShot(clip);
            }
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
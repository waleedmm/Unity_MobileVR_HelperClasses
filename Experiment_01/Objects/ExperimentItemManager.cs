using Assets.Scripts.Experiment_01.Objects;
using Assets.Scripts.QuestSystemManagement;
using System.Collections;
using UnityEngine;

public class ExperimentItemManager : MonoBehaviour, IGazeSelectable
{
    public Animator m_Animator;
    public string m_AnimationName ="" ;
    private Outline m_OutlineComponent;
    public GameObject m_PopupMenu;
    public CircularProgressManager m_CircularManager;
    public SingleQuest m_TargetQuest;
    private AnimationEndTriggerUnit m_EndAnimationTrigger;

    public void OnGazeProgressCompleted()
    {
        //throw new System.NotImplementedException();
        if(m_OutlineComponent!=null)
            m_OutlineComponent.enabled = false;
        m_PopupMenu.SetActive(false);
        if (m_TargetQuest != null)
        {
            if (m_TargetQuest.IsMeInOrder())
            {
                m_EndAnimationTrigger.m_TargetExperiment = this;
                m_Animator.Play(m_AnimationName);
            }
            else
                m_TargetQuest.AskToRepeatLastInstruction();
        }
    }
    public void ReportTaskCompletedSuccessfully()
    {
        if (m_TargetQuest != null)
            m_TargetQuest.ReportComplete();
    }
    public void OnPointerClick()
    {
        Debug.Log(name + " Game Object Clicked!");
    }

    public void OnPointerEnter()
    {
        Debug.Log(name + " Game Object mouse entered!");
        //m_Animator.Play(m_AnimationName);
        m_PopupMenu.SetActive(true);
        m_CircularManager.enabled = true;
        m_CircularManager.StartProgress();
    }
    public void OnPointerExit()
    {
        Debug.Log(name + " Game Object Exit");
        m_CircularManager.CancelProgress();
        m_PopupMenu.SetActive(false);
        
    }

    // Use this for initialization
    void Start()
    {
        if (m_Animator != null)
        {
            m_OutlineComponent = m_Animator.gameObject.GetComponent<Outline>();
            m_EndAnimationTrigger = m_Animator.gameObject.GetComponent<AnimationEndTriggerUnit>();
            if (m_EndAnimationTrigger == null)
            {
                m_EndAnimationTrigger= m_Animator.gameObject.AddComponent<AnimationEndTriggerUnit>();
            }
        }
        m_CircularManager.m_OnLoadComplete.AddListener(this.OnGazeProgressCompleted);
        m_PopupMenu.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {

    }
}
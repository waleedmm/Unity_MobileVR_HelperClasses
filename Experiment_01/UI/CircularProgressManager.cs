using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
public class CircularProgressManager : MonoBehaviour
{
    public Image m_TargetImage;
    //public Sprite[] m_ProgressSprites;
    public int m_StepsCount = 30;
    public bool m_IsOn = false;
    public float m_CountDownTime = 3;
    float m_StepTime;
    //int m_CurrentStepIndex = 0;
    float m_FillingPercentage = 0, m_FillingDelta;
    const float m_FullFillingPercentage = 1;

    public UnityEvent m_OnLoadComplete, m_OnCancel;
    public bool m_StartOnWake = true;
    public void Reset()
    {
        m_IsOn = false;
        m_FillingPercentage = 0;
        m_TargetImage.fillAmount = 0;
        m_TargetImage.enabled = false ;
    }
    public void StartProgress()
    {
        if(m_StepsCount==0)
        {
            m_StepsCount = 30;//default value
            
        }
        m_StepTime = m_CountDownTime / m_StepsCount;
        m_FillingDelta = 1.0f / m_StepsCount;
        m_IsOn = true;
        m_TargetImage.enabled = true;
        StartCoroutine(IncrementProgress());
    }
    public void CancelProgress()
    {
        print("progress canceled");
        m_IsOn = false;
        if (m_OnCancel != null)
            m_OnCancel.Invoke();
    }
    public bool IsCompleted
    {
        get {
            return m_FillingPercentage >= m_FullFillingPercentage;
        }
    }
    IEnumerator IncrementProgress()
    {
        m_TargetImage.enabled= true;
        while (m_IsOn && !IsCompleted)
        {
            m_TargetImage.fillAmount = m_FillingPercentage;
            yield return new WaitForSeconds(m_StepTime);
            m_FillingPercentage += m_FillingDelta;
        }
        if (m_IsOn)//no cancel
        {
            if (m_OnLoadComplete! != null)
            {
                print("progress completed");
                m_OnLoadComplete.Invoke();

            }
        }
        Reset(); //either on completion or cancel
    }
    // Start is called before the first frame update
    void Start()
    {
        if (m_StartOnWake)
            StartProgress();
        else if(!m_IsOn)
            Reset();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

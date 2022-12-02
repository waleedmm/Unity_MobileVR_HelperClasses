using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class TableBottleHolder : MonoBehaviour, IGazeSelectable
{
    public Animator m_Animator;
    public string m_AnimationName = "Syring-Into-Bottle";

    public void OnGazeProgressCompleted()
    {
        //throw new System.NotImplementedException();
    }

    public void OnPointerClick()
    {
        Debug.Log(name + " Game Object Clicked!");
    }

    public void OnPointerEnter()
    {
        Debug.Log(name + " Game Object mouse entered!");
        m_Animator.Play(m_AnimationName);
    }
    public void OnPointerExit()
    {
        Debug.Log(name + " Game Object Exit");
    }

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

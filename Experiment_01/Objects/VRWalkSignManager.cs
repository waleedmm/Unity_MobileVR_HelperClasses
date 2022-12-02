using System.Collections;
using UnityEngine;


public class VRWalkSignManager : MonoBehaviour, IGazeSelectable
{
    public PlayerTeleporter m_Player;
    public Transform m_Placeholder;
    public CircularProgressManager m_CircularProgress;

    public void OnGazeProgressCompleted()
    {
        m_Player.TeleportTo(m_Placeholder);
    }

    public void OnPointerClick()
    {
        //throw new System.NotImplementedException();
    }

    public void OnPointerEnter()
    {
        //throw new System.NotImplementedException();
        m_CircularProgress.StartProgress();
    }

    public void OnPointerExit()
    {
        //throw new System.NotImplementedException();
        m_CircularProgress.CancelProgress();
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
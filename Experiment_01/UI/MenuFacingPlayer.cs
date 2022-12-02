using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuFacingPlayer : MonoBehaviour
{
    public GameObject m_Player;
    public bool m_FaceThePlayer=true;
    private bool m_IsVisible=true;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (m_IsVisible && m_FaceThePlayer)
        {
            this.transform.LookAt(m_Player.transform.position);
        }
    }
}

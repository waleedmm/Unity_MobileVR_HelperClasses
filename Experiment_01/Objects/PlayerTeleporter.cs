using System.Collections;
using UnityEngine;


public class PlayerTeleporter : MonoBehaviour
{
    //public CharacterController m_CharacterController;

    public void TeleportTo(Transform positionPlaceholder)
    {
       this.transform.position=positionPlaceholder.position;
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
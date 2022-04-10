using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Observer : MonoBehaviour
{
    public Transform player;
    public GameEnding gameEnding;
    public GameObject hunter;
    public AudioSource alertSound;
    bool m_IsPlayerInRange;
    bool m_Entered = false;

    void OnTriggerEnter(Collider other)
    {
        if(other.transform == player)
        {
            m_IsPlayerInRange = true;
            m_Entered = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.transform == player)
        {
            m_IsPlayerInRange = false;
        }
    }

    void Update()
    {
        if(m_IsPlayerInRange)
        {
            Vector3 direction = player.position - transform.position + Vector3.up;
            Ray ray = new Ray(transform.position, direction);
            RaycastHit raycastHit;
            if (Physics.Raycast(ray, out raycastHit))
            {
                if (raycastHit.collider.transform == player)
                {
                    //Send the closest ghost to the player position
                    hunter.GetComponent<WaypointPatrol>().lastKnownPosition = player.position;
                    if (m_Entered)
                    {
                        m_Entered = false;
                        alertSound.Play();
                    }
                }
            }
        }
    }
}

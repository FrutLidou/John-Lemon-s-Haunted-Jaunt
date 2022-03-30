using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyItem : MonoBehaviour
{
    public GameObject player;
    public AudioSource pickupSound;
    public Vector3[] positionList;
    public OpenDoor doorScript;
    //Idle Rotation
    float m_rotationSpeed;
    //Idle Translation
    float m_translationSpeed;
    float m_topPoint;
    float m_bottomPoint;
    bool m_isGoingUp;
    bool m_isPaused;
    // Start is called before the first frame update
    void Start()
    {
        m_rotationSpeed = 2f;
        m_translationSpeed = 0.006f;
        m_topPoint = transform.position.y + 0.3f;
        m_bottomPoint = transform.position.y;
        m_isGoingUp = true;
        transform.position = positionList[Random.Range(0, 5)];
    }

    // Update is called once per frame
    void Update()
    {
        if(!m_isPaused)
        {
            transform.Rotate(0, m_rotationSpeed, 0);

            if (m_isGoingUp)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y + m_translationSpeed, transform.position.z);
            }
            else
            {
                transform.position = new Vector3(transform.position.x, transform.position.y - m_translationSpeed, transform.position.z);
            }
            if (transform.position.y < m_bottomPoint || transform.position.y > m_topPoint)
            {
                m_isGoingUp = !m_isGoingUp;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            pickupSound.Play();
            doorScript.obtainKey();
            Destroy(this.gameObject);
        }
    }

    public void pauseAnimation()
    {
        m_isPaused = true;
    }

    public void resumeAnimation()
    {
        m_isPaused = false;
    }
}

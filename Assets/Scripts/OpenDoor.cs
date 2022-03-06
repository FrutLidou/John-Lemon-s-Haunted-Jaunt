using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    public GameObject player;
    public AudioSource doorSound;
    public float rotationSpeed;
    bool m_hasKey;
    bool m_isOpening;
    float m_fullyOpenedAngle;
    Vector3 hinges;
    // Start is called before the first frame update
    void Start()
    {
        m_hasKey = false;
        m_isOpening = false;
        m_fullyOpenedAngle = 0;
        hinges = new Vector3(transform.position.x, transform.position.y, transform.position.z + transform.localScale.z/2f);
    }

    // Update is called once per frame
    void Update()
    {
        //Replace by touching the door
        if (m_isOpening)
        {
            if (transform.rotation.y > m_fullyOpenedAngle)
            {
                transform.RotateAround(hinges, new Vector3(0, 1, 0), -rotationSpeed);
            }
            else
            {
                m_isOpening = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player && m_hasKey)
        {
            m_isOpening = true;
            doorSound.Play();
        }
    }

    public void obtainKey()
    {
        m_hasKey = true;
    }
}

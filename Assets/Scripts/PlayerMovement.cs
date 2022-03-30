using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float thirdPersonTurnSpeed = 20f;
    public float firstPersonTurnSpeed = 3f;
    public Camera firstPersonCamera;
    public Camera thirdPersonCamera;
    Animator m_Animator;
    Rigidbody m_Rigidbody;
    AudioSource m_AudioSource;
    Vector3 m_Movement;
    Quaternion m_Rotation = Quaternion.identity;
    bool m_IsCameraKeyPressed = false;
    bool m_IsFirstPerson = false;

    // Start is called before the first frame update
    void Start()
    {
        m_Animator = GetComponent<Animator>();
        m_Rigidbody = GetComponent<Rigidbody>();
        m_AudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (!m_IsCameraKeyPressed)
            {
                m_IsCameraKeyPressed = true;
                m_IsFirstPerson = switchCamera();
            }
        }
        else
        {
            m_IsCameraKeyPressed = false;
        }
    }

    void FixedUpdate()
    {
        bool isWalking;
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 desiredForward;

        //Compute movement
        if (m_IsFirstPerson)
        {
            m_Movement = transform.forward * vertical;
            desiredForward = Vector3.RotateTowards(transform.forward, transform.right, firstPersonTurnSpeed * Time.deltaTime * horizontal, 0f);
        }
        else
        {
            m_Movement.Set(horizontal, 0f, vertical);
            desiredForward = Vector3.RotateTowards(transform.forward, m_Movement, thirdPersonTurnSpeed * Time.deltaTime, 0f);
        }
        m_Movement.Normalize();

        //Animate if there is movement
        bool hasHorizontalInput = !Mathf.Approximately(horizontal, 0f);
        bool hasVerticalInput = !Mathf.Approximately(vertical, 0f);
        isWalking = hasHorizontalInput || hasVerticalInput;
        m_Animator.SetBool("IsWalking", isWalking);

        //Manage walking sound
        if (isWalking)
        {
            if (!m_AudioSource.isPlaying)
            {
                m_AudioSource.Play();
            }
        }
        else
        {
            m_AudioSource.Stop();
        }

        //Turn
        m_Rotation = Quaternion.LookRotation(desiredForward);
    }

    private void OnAnimatorMove()
    {
        m_Rigidbody.MovePosition(m_Rigidbody.position + m_Movement * m_Animator.deltaPosition.magnitude);
        m_Rigidbody.MoveRotation(m_Rotation);
    }

    private bool switchCamera()
    {
        if (m_IsFirstPerson)
        {
            thirdPersonCamera.enabled = true;
            firstPersonCamera.enabled = false;
            return false;
        }
        else
        {
            firstPersonCamera.enabled = true;
            thirdPersonCamera.enabled = false;
            return true;
        }
    }
}

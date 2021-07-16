using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public AudioSource m_audioSource;
    AudioClip m_StepOnSound_Shoot;

    public Camera Camera_Transform;
     public float moveSpeed = 10.0f;
     public float PlayerHP = 100.0f;


    float SoundTime;

    public float m_RotSpeed;
    public bool Player_State = false;

    float JumpTime;

    Rigidbody m_Rigidbody =  null;
    void Start()
    {
        m_Rigidbody = this.gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        SoundTime += Time.deltaTime;
        JumpTime += Time.deltaTime;
       if (Player_State)
        {
            PlayerRot();
            Move();
        }
    }

    public void PlayeyHit()
    {
        PlayerHP -= 10.0f;
        Debug.Log("플레이어 타격");
    }

    void Player_Shoot()
    {
        Debug.Log("총알발사");
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "zombie")
        {
            //Debug.Log("좀비히트스캔");
            PlayeyHit();

        }
    }
    void Move()
    {
        m_Rigidbody.velocity = new Vector3(0, m_Rigidbody.velocity.y, 0);

        if (Input.GetKey(KeyCode.W) )
        {
            if(SoundTime > 0.5f)
            {
                m_audioSource.Play();
                SoundTime = 0;
            }
            m_Rigidbody.velocity += transform.forward.normalized * moveSpeed;
        }
        if (Input.GetKey(KeyCode.S))
        {
            if (SoundTime > 0.5f)
            {
                m_audioSource.Play();
                SoundTime = 0;
            }
            m_Rigidbody.velocity -= transform.forward.normalized * moveSpeed;
        }
        if (Input.GetKey(KeyCode.A))
        {
            if (SoundTime > 0.5f)
            {
                m_audioSource.Play();
                SoundTime = 0;
            }
            m_Rigidbody.velocity -= transform.right.normalized * moveSpeed;
        }
        if (Input.GetKey(KeyCode.D))
        {
            if (SoundTime > 0.5f)
            {
                m_audioSource.Play();
                SoundTime = 0;
            }
            m_Rigidbody.velocity += transform.right.normalized * moveSpeed;
        }
        if (Input.GetKey(KeyCode.Space) && JumpTime > 1)
        {
            m_Rigidbody.velocity += Vector3.up * moveSpeed / 2;
            JumpTime = 0f;
        }
    }

    void Rot()
    {
        // 좌우로 움직인 마우스의 이동량 * 속도에 따라 카메라가 좌우로 회전할 양 계산
        float yRotateSize = Input.GetAxis("Mouse X") * m_RotSpeed;  
        // 현재 y축 회전값에 더한 새로운 회전각도 계산
        float yRotate = transform.eulerAngles.y + yRotateSize;

        // 위아래로 움직인 마우스의 이동량 * 속도에 따라 카메라가 회전할 양 계산(하늘, 바닥을 바라보는 동작)
        float xRotateSize = -Input.GetAxis("Mouse Y") * m_RotSpeed;
        // 위아래 회전량을 더해주지만 -45도 ~ 80도로 제한 (-45:하늘방향, 80:바닥방향)
        // Clamp 는 값의 범위를 제한하는 함수
        m_RotSpeed = Mathf.Clamp(m_RotSpeed + xRotateSize, -45, 80);

        // 카메라 회전량을 카메라에 반영(X, Y축만 회전)
        this.transform.eulerAngles = new Vector3(0, yRotate, 0);
        Camera_Transform.transform.eulerAngles = new Vector3(m_RotSpeed, transform.eulerAngles.y, 0);
    }

    void CameraRot()
    {
        // 좌우로 움직인 마우스의 이동량 * 속도에 따라 카메라가 좌우로 회전할 양 계산
        float yRotateSize = Input.GetAxis("Mouse X") * m_RotSpeed;
        // 현재 y축 회전값에 더한 새로운 회전각도 계산
        float yRotate = transform.eulerAngles.y + yRotateSize;

        // 위아래로 움직인 마우스의 이동량 * 속도에 따라 카메라가 회전할 양 계산(하늘, 바닥을 바라보는 동작)
        float xRotateSize = -Input.GetAxis("Mouse Y") * m_RotSpeed;
        // 위아래 회전량을 더해주지만 -45도 ~ 80도로 제한 (-45:하늘방향, 80:바닥방향)
        // Clamp 는 값의 범위를 제한하는 함수
        m_RotSpeed = Mathf.Clamp(m_RotSpeed + xRotateSize, -45, 80);

        // 카메라 회전량을 카메라에 반영(X, Y축만 회전)
        this.transform.eulerAngles = new Vector3(0, yRotate, 0);
        Camera_Transform.transform.eulerAngles = new Vector3(m_RotSpeed, transform.eulerAngles.y, 0);
    }
    void PlayerRot()
    {
       // 좌우로 움직인 마우스의 이동량 * 속도에 따라 카메라가 좌우로 회전할 양 계산
        float yDelta = Input.GetAxis("Mouse X");

        Vector3 vRot = transform.localRotation.eulerAngles;
        vRot.y += yDelta * m_RotSpeed * Time.deltaTime ;
    
  
        this.transform.localRotation = Quaternion.Euler(vRot);
       
    }
}
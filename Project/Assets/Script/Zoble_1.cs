using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Zoble_1 : MonoBehaviour
{
    public ParticleSystem particle_shoot;
    public float m_speed;
     Transform m_Target;
    public bool Zombie001_State = false;

    public Player m_player;

    public float ZombieHp;
    public Animator m_Animator;
    public GameManager gameManager;
    private void Awake()
    {

    }
    private void Start()
    {
       // m_player = FindObjectOfType<Player>();
      //  gameManager = FindObjectOfType<GameManager>();
        ZombieHp = m_player.PlayerHP / 2;


        m_Target = m_player.transform;
        m_Animator.SetFloat("MoveSpeed", 3);
        Zombie001_State = true;
    }

    public void Init(Player player)
    {
        m_player = player;
        m_Animator.SetFloat("MoveSpeed", 1.0f);
    }
    void Update()
    {
        //m_Animator.SetFloat("MoveSpeed", 1.0f);
        m_Target.position = m_player.transform.position;
        //transform.position += new Vector3(10, 0, 10) * m_speed  * Time.deltaTime;
        if (Zombie001_State)
        {
            transform.position += transform.forward * Time.deltaTime * m_speed;
            transform.LookAt(m_Target);
        }
        if(ZombieHp <= 0)
        {
            Zombie_Die();
        }
          
    }

    public void Zombie_Hit()
    {
        particle_shoot.Play();
        ZombieHp -= gameManager.m_Gun_Damege;
        Debug.Log(ZombieHp);
    }

    void Zombie_Die()
    {
        gameManager.Score_Up();
        Destroy(gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public Zoble_1 zombie_1;
    public GameObject prefab_Zombie001;
    public List<Zoble_1> Zombie_List = new List<Zoble_1>();

    public Text text_3;
    public Text text_2;
    public Text text_1;
    public Text text_start;
    public Text HpText;
    public Text m_Score_Text;
    public Text Bullet_Text;

    public Player player;
    public Image hpimage;

    public float m_Score;
    public float Bullet_num;
    public float m_Gun_Damege;
    public float m_Shotgun_Damege;
    float game_start_time;
    [SerializeField] float m_Player_GunChange;

    public bool GameState;
    public bool m_Gun;
    public bool m_Shotgun;

    public int m_Player_GunState;
    int Gun_Reload_Count = 0;

    public AudioSource audioSource;
     AudioClip StepOnSound_Shoot;

    public AudioSource audioSource_Reload;
    AudioClip StepOnSound_Reload;

    Rigidbody player_rigdbody;
    public Player_Shoot m_Player_shoot;

    public GameObject Gun;


     Transform Start_Gun_pos = null;
     Transform Temp_Gun_pos = null;


    public Animator Gun_rebound; 


    [SerializeField] float m_Gun_Rebound;
    private void Awake()
    {
        player_rigdbody = player.GetComponent<Rigidbody>();
        audioSource = this.gameObject.GetComponent<AudioSource>();
        
    }
    void Start()
    {
        Start_Gun_pos = Gun.transform;


        //CreateZombie_001(5); // 좀비001 생성
        m_Gun_Rebound = 5f; //기본권총 반동
        m_Player_GunState = 0; // 기본권총

        m_Gun_Damege = 10.0f;
        m_Shotgun_Damege = 50.0f;


        text_3.gameObject.transform.position = new Vector3(700 , 400, 0);
        text_2.gameObject.transform.position = new Vector3(700, 400, 0);
        text_1.gameObject.transform.position = new Vector3(700, 400, 0);
        text_start.gameObject.transform.position = new Vector3(700, 400, 0);

        Bullet_num = 40;
        Gun_Reload_Count = 3;
        HpText.text = "" + player.PlayerHP;
        GameState = false;
    }

    void Update()
    {
        //게임시작 부분
        game_start_time += Time.deltaTime;

        if(Input.GetKeyDown(KeyCode.R) && Gun_Reload_Count != 0)
        {
            Gun_Reload_Count -= 1;
            Gun_Reload();
        }
        Bullet_Text.text = "총알 x " + Bullet_num;
        if (game_start_time > 0 && game_start_time < 1)
        {
            text_3.gameObject.SetActive(true);
            text_2.gameObject.SetActive(false);
            text_1.gameObject.SetActive(false);
            text_start.gameObject.SetActive(false);
        }
        else if (game_start_time > 1 && game_start_time < 2)
        {
            text_3.gameObject.SetActive(false);
            text_2.gameObject.SetActive(true);
            text_1.gameObject.SetActive(false);
            text_start.gameObject.SetActive(false);
        }
        else if (game_start_time > 2 && game_start_time < 3)
        {
            text_3.gameObject.SetActive(false);
            text_2.gameObject.SetActive(false);
            text_1.gameObject.SetActive(true);
            text_start.gameObject.SetActive(false);
        }
        else if (game_start_time > 3 && game_start_time < 4)
        {
            text_3.gameObject.SetActive(false);
            text_2.gameObject.SetActive(false);
            text_1.gameObject.SetActive(false);
            text_start.gameObject.SetActive(true);
        }
        else if (game_start_time > 4)
        {
            text_3.gameObject.SetActive(false);
            text_2.gameObject.SetActive(false);
            text_1.gameObject.SetActive(false);
            text_start.gameObject.SetActive(false);

            m_Player_shoot.Player_Shoot_State = true;
            for(int i =0; i < Zombie_List.Count; i++)
            {
                Zombie_List[i].Zombie001_State = true;
            }

            GameState = true;
            player.Player_State = true;
        }
        //게임 부분
        if(GameState)
        {
            m_Player_GunChange += Time.deltaTime; // 총 바꾸는 시간
            if (Input.GetKey(KeyCode.Q) && m_Player_GunChange > 3)
            {
                m_Player_GunChange = 0;
                if (m_Player_GunState >= 4)
                {
                    m_Player_GunState = 1;
                    return;
                }
                m_Player_GunState += 1;
            }
            switch (m_Player_GunState)
            {
                case 1: // 기본권총
                    m_Gun = true;
                    m_Shotgun = false;
                    break;
                case 2: // 샷건
                    m_Gun = false;
                    m_Shotgun = true;
                    break;
            }
            m_Score_Text.text = m_Score + "pts";
            Playerhp();
        }
    }
    public void Playerhp()
    {
        hpimage.fillAmount = player.PlayerHP / 100f;
        HpText.text = string.Format("{0}/100", player.PlayerHP);
    }
    public void Score_Up()
    {
        m_Score += 10; 
    }
    public void Shoot_sound()
    {
        this.audioSource.Play();
    }
    public void Shoot()
    {
       // Gun_Shoot();
        Shoot_sound();
        Bullet_num -= 1;
        //Temp_Gun_pos = Gun.transform;
        Gun_rebound.SetTrigger("Fire");
       // Gun_rebound.Play("Fire");

     }
    public void Gun_Reload()
    {
        Bullet_num = 40;
        this.audioSource_Reload.Play();
    }
    public void CreateZombie_001(int Count)
    {
        for(int i =0; i <= Count; i++)
        {
          int random;
          random = Random.Range(0, Count); 
          var a =  Instantiate(prefab_Zombie001);
          a.transform.position = new Vector3(random * 1, 0, 3 * random);
            Zoble_1 zo = a.GetComponent<Zoble_1>();
            zo.Init(player);
          Zombie_List.Add(zo);
        }
    }
    public void Gun_Shoot()  // 권총 반동.
    {
        Gun.transform.position += Vector3.up * m_Gun_Rebound;    
    }
}

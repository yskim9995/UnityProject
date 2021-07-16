using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Shoot : MonoBehaviour
{
    public GameObject bullet;
    public GameObject camera;
    
    public GameManager gamemanager;

    public bool Player_Shoot_State;

    // Start is called before the first frame update
    void Start()
    {
        Player_Shoot_State = false;
    }

    // Update is called once per frame
    void Update()
    {
        
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100))
            {
                Debug.DrawLine(ray.origin, hit.point);
                if (gamemanager.Bullet_num != 0)
                {
                    if (Input.GetMouseButtonDown(0))
                    {
                        gamemanager.Shoot();
                        if (hit.transform.tag == "zombie")
                        {
                            //gamemanager.Score_Up();
                            hit.collider.GetComponent<Zoble_1>().Zombie_Hit();  
                            Debug.Log("좀비타격");
                        }
                    }
                }

            }
        }
    
}

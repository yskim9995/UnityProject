using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody rigid;

    public Vector3 postion;

    float DestroyTime;
    private void Start()
    {
        rigid = GetComponent<Rigidbody>();
        Destroy(gameObject, 10f);
    }
    private void Update()
    {
        transform.LookAt(postion);
        DestroyTime += Time.deltaTime;
        if (DestroyTime > 4)
        {
            Destroy(gameObject);
        }
        transform.Translate(Vector3.forward * 0.5f);

    } 

}

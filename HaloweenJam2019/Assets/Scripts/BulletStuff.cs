using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletStuff : MonoBehaviour
{
    public float bulletDamage;
    public float bulletSpeed = 1.05f;

    void Start()
    {
        GetComponent<Rigidbody>().velocity = transform.up * bulletSpeed;
        Destroy(gameObject, .5f);
    }
    void Update()
    {
        
    }
}
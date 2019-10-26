using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletStuff : MonoBehaviour
{
    public float bulletDamage;
    public float bulletSpeed = 50f;

    void Start()
    {
        GetComponent<Rigidbody>().velocity = transform.up * bulletSpeed;
        Destroy(gameObject, 1f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            EnemyHealth health = other.GetComponent<EnemyHealth>();
            if (health != null)
            {
                health.Damage(bulletDamage);
            }
        }
        Destroy(gameObject);
    }
}
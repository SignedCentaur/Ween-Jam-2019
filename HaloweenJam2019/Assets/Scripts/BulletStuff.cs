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

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            EnemyHealth health = collision.gameObject.GetComponent<EnemyHealth>();
            if (health != null)
            {
                health.Damage(bulletDamage);
            }
        }
        Destroy(gameObject);
    }
}
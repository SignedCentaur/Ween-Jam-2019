﻿using UnityEngine;
using System.Collections;

public class GunUse : MonoBehaviour
{
    [Header("GameObjects")]
    public GameObject bullets;
    public GameObject player;
    public Transform gunEnd;
    public Animator childAnimator;
    public GameObject flash;
    public GameObject ammoUI;
    public Sprite[] ammoNumber;
    [Header("Math Stuff")]
    public int gunDamage;
    public float fireRate;
    public int bulletCount;
    public float bulletSpread;
    private int bulletPerMagazine = 6;
    private int currentAmmo = 6;
    [Header("Bools")]
    public bool isShooting = false;
    public bool isReloading = false;
    
    void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            StartCoroutine("Shoot");
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            StartCoroutine("Reload");
        }
    }
    IEnumerator Shoot()
    {
        if (!isShooting && !isReloading)
        {
            if (currentAmmo > 0)
            {
                isShooting = true;
                StartCoroutine("Flash");
                for (int i = 0; i < bulletCount; i += 1)
                {
                    GameObject temp = Instantiate(bullets, gunEnd.transform.position, gunEnd.transform.rotation * Quaternion.Euler(90 + Random.Range(-bulletSpread / 2, bulletSpread / 2), 0, Random.Range(-bulletSpread / 2, bulletSpread / 2)));
                }
                childAnimator.SetTrigger("Shoot");
                currentAmmo -= 1;
                ammoUI.GetComponent<UnityEngine.UI.Image>().sprite = ammoNumber[currentAmmo];

                yield return new WaitForSeconds(fireRate);
                isShooting = false;
            }
            else
            {
                //outta ammo
            }
        }
    }
    IEnumerator Reload()
    {
        if (!isReloading && !isShooting)
        {
            isReloading = true;

            childAnimator.SetTrigger("Reload");

            yield return new WaitForSeconds(2.3f);

            currentAmmo = bulletPerMagazine;
            ammoUI.GetComponent<UnityEngine.UI.Image>().sprite = ammoNumber[currentAmmo];
            isReloading = false;
        }
    }
    IEnumerator Flash()
    {
        flash.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        flash.SetActive(false);
    }
}
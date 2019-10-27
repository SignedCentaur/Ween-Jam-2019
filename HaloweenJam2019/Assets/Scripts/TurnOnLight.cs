using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOnLight : MonoBehaviour
{
    public GameObject Light;
    public bool InteractTrigger;
    public bool LightReset;
    public GameObject player;

    private void Awake()
    {
        Light.SetActive(false);
        LightReset = true;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnTriggerStay(Collider other)
    {
        if((other.gameObject.tag == "Player") && (LightReset == true))
        {
            InteractTrigger = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            InteractTrigger = false;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && (InteractTrigger == true))
        {
            Light.SetActive(true);
            StartCoroutine(LightDuration()); 
        }
    }

    IEnumerator LightDuration()
    {
        PlayerHealth health = player.GetComponent<PlayerHealth>();
        health.currentHealth = 10;
        InteractTrigger = false;
        yield return new WaitForSeconds(60);
        Light.SetActive(false);
        LightReset = false;
        InteractTrigger = false;
        yield return new WaitForSeconds(120);
        LightReset = true;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Destroy(other.gameObject);
        }
    }
}

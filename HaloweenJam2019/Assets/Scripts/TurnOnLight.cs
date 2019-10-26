using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOnLight : MonoBehaviour
{
    public GameObject Light;
    public bool InteractTrigger;
    public bool LightReset;

    private void Awake()
    {
        Light.SetActive(false);
        LightReset = true;
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
        Debug.Log ("Hello");
        yield return new WaitForSeconds(60);
        Light.SetActive(false);
        LightReset = false;
        InteractTrigger = false;
        yield return new WaitForSeconds(120);
        LightReset = true;
    }
}

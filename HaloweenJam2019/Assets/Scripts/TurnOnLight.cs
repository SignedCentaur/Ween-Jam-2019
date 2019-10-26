using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOnLight : MonoBehaviour
{
    public GameObject Light;
    bool InteractTrigger;

    private void Start()
    {
        gameObject.transform.GetChild(0).gameObject.SetActive(false);
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Player")
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
            gameObject.transform.GetChild(0).gameObject.SetActive(true);
        }
    }
}

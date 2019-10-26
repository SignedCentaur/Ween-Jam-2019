using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

    [RequireComponent(typeof(NavMeshAgent))]
public class EnemyFollowing : MonoBehaviour
{
    GameObject target;
    Vector3 destination;
    NavMeshAgent agent;

    void Start()
    {
        target = GameObject.FindWithTag("Player");
        agent = GetComponent<NavMeshAgent>();
        destination = agent.destination;
    }

    void Update()
    {
        if (Vector3.Distance(destination, target.transform.position) > 1.0f)
        {
            destination = target.transform.position;
            agent.destination = destination;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Light"))
        {
            Destroy(gameObject);
        }
    }

}

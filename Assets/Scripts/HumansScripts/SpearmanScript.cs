using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SpearmanScript : MonoBehaviour
{
    [SerializeField] GameManagerScript gameManager;

    private NavMeshAgent navMeshAgent;
    private Transform transform;
    private PriorityStategy priorityStrategy = new SpearmanPriority();

    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        transform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        navMeshAgent.destination = priorityStrategy.getNextTarget(gameManager, transform.position);
    }
}

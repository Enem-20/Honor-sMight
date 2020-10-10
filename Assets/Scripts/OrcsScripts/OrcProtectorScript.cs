using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class OrcProtectorScript : MonoBehaviour
{
    [SerializeField] GameManagerScript gameManager;

    private NavMeshAgent navMeshAgent;
    private Transform transform;
    private PriorityStategy priorityStrategy = new OrcProtectorPriority();

    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        transform = GetComponent<Transform>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManagerScript>();
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        navMeshAgent.destination = priorityStrategy.getNextTarget(gameManager, transform.position);
    }
}

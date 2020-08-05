using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class HumansPriority : MonoBehaviour
{
    [SerializeField] private GameObject[] Orcs;
    [SerializeField] private GameObject HeavyNavAgent;

    private NavMeshAgent _HeavyNavAgent;

    // Start is called before the first frame update
    void Start()
    {
        Orcs[1] = GameObject.Find("");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

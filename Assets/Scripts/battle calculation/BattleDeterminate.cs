using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

abstract public class BattleDeterminate : MonoBehaviour
{
    protected Rigidbody rigidbody;
    protected NavMeshAgent navMeshAgent;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
        navMeshAgent = GetComponent<NavMeshAgent>();
    }
}

sealed class BattleHeavy : BattleDeterminate
{
    private void OnTriggerEnter(Collider other)
    {
        rigidbody.velocity = Vector3.zero;
        navMeshAgent.velocity = Vector3.zero;
    }
    private void OnTriggerExit(Collider other)
    {
        rigidbody.velocity = Vector3.one;
        navMeshAgent.velocity = Vector3.one;
    }
}

sealed class BattleAvantGarde : BattleDeterminate
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Orcs")
        {
            //rigidbody.velocity = Vector3.zero;
            //navMeshAgent.velocity = Vector3.zero;
            navMeshAgent.isStopped = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Orcs")
        {
            //rigidbody.velocity = Vector3.one;
            //navMeshAgent.velocity = Vector3.one;
            navMeshAgent.isStopped = false;
        }
    }
}

sealed class BattleLight : BattleDeterminate
{
    private void OnTriggerEnter(Collider other)
    {
        rigidbody.velocity = Vector3.zero;
        navMeshAgent.velocity = Vector3.zero;
    }
    private void OnTriggerExit(Collider other)
    {
        rigidbody.velocity = Vector3.one;
        navMeshAgent.velocity = Vector3.one;
    }
}

public class BattleSpearman : BattleDeterminate
{
    private void OnTriggerEnter(Collider other)
    {
        rigidbody.velocity = Vector3.zero;
        navMeshAgent.velocity = Vector3.zero;
    }
    private void OnTriggerExit(Collider other)
    {
        rigidbody.velocity = Vector3.one;
        navMeshAgent.velocity = Vector3.one;
    }
}

sealed class BattleProtector : BattleDeterminate
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Humans")
        {
            //rigidbody.velocity = Vector3.zero;
            //navMeshAgent.velocity = Vector3.zero;
            navMeshAgent.isStopped = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Humans")
        {
            //rigidbody.velocity = Vector3.zero;
            //navMeshAgent.velocity = Vector3.zero;
            navMeshAgent.isStopped = false;
        }
        //rigidbody.velocity = Vector3.one;
        //navMeshAgent.velocity = Vector3.one;

    }
}

sealed class BattleChampions : BattleDeterminate
{
    private void OnTriggerEnter(Collider other)
    {
        rigidbody.velocity = Vector3.zero;
        navMeshAgent.velocity = Vector3.zero;
    }
    private void OnTriggerExit(Collider other)
    {
        rigidbody.velocity = Vector3.one;
        navMeshAgent.velocity = Vector3.one;
    }
}

sealed class BattleStone : BattleDeterminate
{
    private void OnTriggerEnter(Collider other)
    {
        rigidbody.velocity = Vector3.zero;
        navMeshAgent.velocity = Vector3.zero;
    }
    private void OnTriggerExit(Collider other)
    {
        rigidbody.velocity = Vector3.one;
        navMeshAgent.velocity = Vector3.one;
    }
}

sealed class BattleDwarf : BattleDeterminate
{
    private void OnTriggerEnter(Collider other)
    {
        rigidbody.velocity = Vector3.zero;
        navMeshAgent.velocity = Vector3.zero;
    }
    private void OnTriggerExit(Collider other)
    {
        rigidbody.velocity = Vector3.one;
        navMeshAgent.velocity = Vector3.one;
    }
}

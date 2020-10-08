using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace NBattle
{
    abstract public class BattleDeterminate : MonoBehaviour
    {
        protected Rigidbody rigidbody;
        protected NavMeshAgent navMeshAgent;
        public CharParam charParam;
        GameObject enemy;

        private void Awake()
        {
            rigidbody = GetComponent<Rigidbody>();
            navMeshAgent = GetComponent<NavMeshAgent>();
        }

        protected bool Blocked()
        {
            if (Random.Range(1, 101) > charParam.Block)
            {
                return Parried();
            }
            else
            {
                Debug.Log("Blocked!");
                return true;
            }
        }

        protected bool Parried()
        {
            if (Random.Range(1, 101) > charParam.Parry)
            {
                return Evaded();
            }
            else
            {
                Debug.Log("Parried!");
                return true;
            }
        }
        protected bool Evaded()
        {
            if (Random.Range(1, 101) > charParam.Evade)
            {
                return false;
            }
            else
            {
                Debug.Log("Evaded!");
                return true;
            }
        }

        protected void Die(GameObject enemy)
        {
            this.enemy = enemy;
            int childs_size = gameObject.transform.childCount - 4;
            float DieProbably = charParam.DieProbably;

            DieProbably = DieProbably + charParam.armor - enemy.GetComponent<BattleDeterminate>().charParam.weapon;

            if (DieProbably >= 100)
            {
                if (childs_size == 1)
                {
                    Debug.Log("Die!" + gameObject);
                    Destroy(gameObject);
                }
                else if (childs_size > 1)
                {
                    int result = Random.Range(0, childs_size);
                    Debug.Log("Die!" + gameObject.transform.GetChild(result));
                    Destroy(gameObject.transform.GetChild(result).gameObject);
                }
            }
            else
            {
                if (Random.Range(1, 101) < DieProbably)
                {
                    if (childs_size == 1)
                    {
                        Debug.Log("Die!" + gameObject);
                        Destroy(gameObject);
                    }
                    else if (childs_size > 1)
                    {
                        int result = Random.Range(0, childs_size);
                        Debug.Log("Die!" + gameObject.transform.GetChild(result));
                        Destroy(gameObject.transform.GetChild(result).gameObject);
                    }
                }
            }

        }
        protected IEnumerator AvoidenceOrDie(GameObject enemy)
        {
            Debug.Log("Start skirmish!");
            while (true)
            {
                if (!Blocked())
                {
                    Die(enemy);
                }
                yield return new WaitForSeconds(2);
            }
        }
        private void OnDestroy()
        {
            enemy.GetComponent<NavMeshAgent>().enabled = true;
        }
    }

    sealed class BattleHeavy : BattleDeterminate
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Orcs")
            {

                navMeshAgent.enabled = false;
                StartCoroutine("AvoidenceOrDie", other.gameObject);
            }
        }
        private void OnTriggerExit(Collider other)
        {
            if (other.tag == "Orcs")
            {
                navMeshAgent.enabled = true;
                StopCoroutine("AvoidenceOrDie");
                Debug.Log("Exit skirmish!");
            }
        }
    }

    sealed class BattleAvantGarde : BattleDeterminate
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Orcs")
            {
                navMeshAgent.enabled = false;
                StartCoroutine("AvoidenceOrDie", other.gameObject);
            }
        }
        private void OnTriggerExit(Collider other)
        {
            if (other.tag == "Orcs")
            {
                navMeshAgent.enabled = true;
                StopCoroutine("AvoidenceOrDie");
            }
        }
    }

    sealed class BattleLight : BattleDeterminate
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Orcs")
            {
                navMeshAgent.enabled = false;
                StartCoroutine("AvoidenceOrDie", other.gameObject);
            }
        }
        private void OnTriggerExit(Collider other)
        {
            if (other.tag == "Orcs")
            {
                navMeshAgent.enabled = true;
                StopCoroutine("AvoidenceOrDie");
            }
        }
    }

    public class BattleSpearman : BattleDeterminate
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Orcs")
            {
                navMeshAgent.enabled = false;
                StartCoroutine("AvoidenceOrDie", other.gameObject);
            }
        }
        private void OnTriggerExit(Collider other)
        {
            if (other.tag == "Orcs")
            {
                navMeshAgent.enabled = true;
                StopCoroutine("AvoidenceOrDie");
            }
        }
    }

    sealed class BattleProtector : BattleDeterminate
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Humans")
            {
                navMeshAgent.enabled = false;
                Debug.Log("Protector Avoidence");
                StartCoroutine("AvoidenceOrDie", other.gameObject);
            }
        }
        private void OnTriggerExit(Collider other)
        {
            if (other.tag == "Humans")
            {
                navMeshAgent.enabled = true;
                StopCoroutine("AvoidenceOrDie");
            }
        }
    }

    sealed class BattleChampions : BattleDeterminate
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Humans")
            {
                navMeshAgent.enabled = false;
                StartCoroutine("AvoidenceOrDie", other.gameObject);
            }
        }
        private void OnTriggerExit(Collider other)
        {
            if (other.tag == "Humans")
            {
                navMeshAgent.enabled = true;
                StopCoroutine("AvoidenceOrDie");
            }
        }
    }

    sealed class BattleStone : BattleDeterminate
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Humans")
            {
                navMeshAgent.enabled = false;
                StartCoroutine("AvoidenceOrDie", other.gameObject);
            }
        }
        private void OnTriggerExit(Collider other)
        {
            if (other.tag == "Humans")
            {
                navMeshAgent.enabled = true;
                StopCoroutine("AvoidenceOrDie");
            }
        }
    }

    sealed class BattleDwarf : BattleDeterminate
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Humans")
            {
                navMeshAgent.enabled = false;
                StartCoroutine("AvoidenceOrDie", other.gameObject);
            }
        }
        private void OnTriggerExit(Collider other)
        {
            if (other.tag == "Humans")
            {
                navMeshAgent.enabled = true;
                StopCoroutine("AvoidenceOrDie");
            }
        }
    }
}
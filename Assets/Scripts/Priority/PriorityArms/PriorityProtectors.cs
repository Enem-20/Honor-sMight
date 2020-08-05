//#define DEBUG

//#define queue.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PriorityProtectors : BattleProtectors
{
    
    public GameObject Castle;
    BattleProtectors battleProtectors;

    //[SerializeField] private GameObject Castle;
    [SerializeField] private GameObject Buf;

    [SerializeField]NavMeshAgent _ProtectorsNavAgent;
    NavMeshObstacle _ProtectorsNavObstacle;

    private Vector3 Freeze;     //Freeze position the object
    private Quaternion RotateProtectors;
    private Quaternion[] RotateEnemy;

    [SerializeField] private bool FightProtectors;

    public int ID;

    private void Awake()
    {
        ID = Random.Range(0, 65000);
        FightProtectors = false;

        _ProtectorsNavAgent = GetComponent<NavMeshAgent>();
        _ProtectorsNavObstacle = GetComponent<NavMeshObstacle>();

        Buf = GameObject.Find("GameManager");
        _ProtectorsNavAgent = GetComponent<NavMeshAgent>();
        Freeze = GetComponent<Transform>().position;
    }

    void Start()
    {

        //Jump.startTransform = GameObject.Find("StartJump(Clone)").transform;
        //Jump.endTransform = GameObject.Find("EndJump(Clone)").transform;
        
        Castle = GameObject.Find("CastleDamageZone(Clone)");      //Find zone for damage
        _ProtectorsNavAgent.SetDestination(Castle.transform.position);    //Default target - Castle   
    }

    void FixedUpdate()
    {
        if (Destroyed)
        {
           Destroyed = false;

            Debug.Log("Exit!");
            FightProtectors = false;
            _ProtectorsNavAgent.velocity = new Vector3(1, 1, 1);

            Buf.GetComponent<GameManager>().Heavy.RemoveAt(0);
        }
        if (FightProtectors)
        {
            _ProtectorsNavAgent.isStopped = true;      //Freeze Object
            _ProtectorsNavObstacle.enabled = true;

            Freeze = gameObject.transform.position;

            _ProtectorsNavAgent.velocity = new Vector3(0, 0, 0);
//#if DEBUG
//            Debug.Log("FreezeOrc");
//#endif
        }
        else
        {
            //#if DEBUG
            //            Debug.Log("Find Heavies!");
            //#endif

            _ProtectorsNavAgent.isStopped = false;
            _ProtectorsNavObstacle.enabled = false;

            //QueuePriority.Add(GameObject.Find("HeavyInfantrys(Clone)"));

            if (Buf.GetComponent<GameManager>().Heavy.Count > 0)
            {
                _ProtectorsNavAgent.destination = Buf.GetComponent<GameManager>().Heavy[0].transform.position;      //Get enemy position

                var rot = Quaternion.LookRotation(Buf.GetComponent<GameManager>().Heavy[0].transform.position - transform.position);
                transform.rotation = Quaternion.Slerp(transform.rotation, rot, Time.deltaTime);
            }
            else
            {
                _ProtectorsNavAgent.destination = Castle.transform.position;

                var rot = Quaternion.LookRotation(Castle.transform.position - transform.position);
                transform.rotation = Quaternion.Slerp(transform.rotation, rot, Time.deltaTime);
            }
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.name == "HeavyInfantrys(Clone)")
        {
#if DEBUG
            Debug.Log("Collision with Heavy!!!");
#endif
            FightProtectors = true;
        }
    }
}

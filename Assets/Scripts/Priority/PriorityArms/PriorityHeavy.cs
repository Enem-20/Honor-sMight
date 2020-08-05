//#define DEBUG

using UnityEngine;
using UnityEngine.AI;
using System.Collections.Generic;
using UnityEngine.UI;

public class PriorityHeavy : MonoBehaviour
{
    [SerializeField] GameObject Lair;

    [SerializeField] GameObject Buf;
    [SerializeField] Animator[] _HeavyAnim;

    private NavMeshAgent _HeavyNavAgent;    //NavMeshAgent for HeavyInfantry
    NavMeshObstacle _HeavyNavObstacle;
    Collider _This;

    private Transform RotateHeavy;
    private Transform[] RotateEnemy;

    private Vector3 Freeze;

    private int DeadCounter;
        
    private float Damage = 10f;

    private bool blocked;
    private bool parried;
    private bool evaded;
    public int ID;

    [SerializeField]private bool FightHeavy;

    private void Awake()
    {
        _HeavyNavAgent = GetComponent<NavMeshAgent>();
        _HeavyNavObstacle = GetComponent<NavMeshObstacle>();
        _HeavyAnim = new Animator[10];

        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            _HeavyAnim[i] = transform.GetChild(i).GetComponent<Animator>();
        }

        Freeze = GetComponent<Transform>().position;
        ID = Random.Range(0, 65000);

        Buf = GameObject.Find("GameManager");
    }

    void Start()
    {
        //_hasPath = HeavyNavAgent.GetComponent<NavMeshAgent>().hasPath;
        
        Lair = GameObject.Find("LairDamageZone(Clone)");
        _HeavyNavAgent.destination = Lair.transform.position;

        var Rotate = Quaternion.Euler(0, 1, 0);
        var Rotate180 = Quaternion.Euler(0, 180, 0);

        FightHeavy = false;
    }

    private void Update()
    {
        
    }
    void FixedUpdate()
    {
        
        //_AIEventSys._Event(transform, gameObject);
        if (FightHeavy)     //Check battle is gone
        {
//#if DEBUG
//            Debug.Log("isFight");
//#endif
            _HeavyNavAgent.isStopped = true;        //Freeze position object
            Freeze = gameObject.transform.position;

            _HeavyNavAgent.velocity = new Vector3(0,0,0);
//#if DEBUG
//            Debug.Log("Freeze");
//#endif
        }
        else
        {
//#if DEBUG
//            Debug.Log("Find Protectors!");
//#endif
            _HeavyNavAgent.isStopped = false;
            Buf.GetComponent<GameManager>().Protectors[0] = GameObject.Find("OrcProtectors_Empty(Clone)");    //Finder enemy
            if (Buf.GetComponent<GameManager>().Protectors.Count > 0)
            {
                _HeavyNavAgent.destination = Buf.GetComponent<GameManager>().Protectors[0].transform.position;

                var rot = Quaternion.LookRotation(Buf.GetComponent<GameManager>().Protectors[0].transform.position - transform.position);
                transform.rotation = Quaternion.Slerp(transform.rotation, rot, Time.deltaTime);
            }
            else
            {
                _HeavyNavAgent.destination = Lair.transform.position;

                var rot = Quaternion.LookRotation(Lair.transform.position - transform.position);
                transform.rotation = Quaternion.Slerp(transform.rotation, rot, Time.deltaTime);
            }
        }
        
    }
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.name == "OrcProtectors_Empty(Clone)")
        {
            FightHeavy = true;

            for (int i = 0; i < transform.childCount; i++)
            {
                _HeavyAnim[i].SetBool("Fight", true);
            }
            
            Freeze = gameObject.transform.position;
            _HeavyNavObstacle.enabled = true;
        }        
    }

    private void OnTriggerExit(Collider collider)       //Exit from fight
    {
        if (collider.name == "OrcProtectors_Empty(Clone)")
        {
            FightHeavy = false;
            _HeavyNavAgent.velocity = new Vector3(1, 1, 1);
            for (int i = 0; i < transform.childCount; i++)
            {
                _HeavyAnim[i].SetBool("Fight", false);
            }

            Buf.GetComponent<GameManager>().Protectors.RemoveAt(0);
            _HeavyNavObstacle.enabled = false;
        }
    }
    //public void GetHit(RaycastHit hit)
    //{
    //    this.hit = hit;
    //}
}
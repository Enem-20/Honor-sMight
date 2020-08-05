#define DEBUG

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.AI;

//using HumansCalculation;

public class BattleProtectors : CharParam
{
    [SerializeField] CharParam _CharParam;      //Get parameters for battle

    public GameObject Model;

    NavMeshAgent _ProtectorsNav;

    CharParam AmmunationO;
    CharParam AvoidenceHumans;

        //CharParam AmmunationO;
        //CharParam AvoidenceHumans;

        //CharParam => AvoidenceHumans;

    float Res_WeapArmor;
    float Dead = 100.0f;
    float CheckDead;
    float CheckAvoidence;
    float CheckProbabilityIsDead;
    int Died;
    int Max;
    int Avoided;

    float ArmorEnemy;
    float Weapon;

    float[] BPEenemy = new float[3];        //Put parameters units in massive

    public static bool Destroyed;

    //float ResBonusProtected;
    private void Awake()
    {
        GetComponent<PriorityProtectors>().enabled = true;
        Destroyed = false;
    }

    private void Start()
    {
        AvoidenceHumans = GetComponent<CharParam>();
        AmmunationO = GetComponent<CharParam>();
        _ProtectorsNav = GetComponent<NavMeshAgent>();   
    }

    // Start is called before the first frame update
    private void OnTriggerEnter(Collider collider)
    {
        if ((collider.name == "HeavyInfantrys(Clone)") && (Model == null))
        {
#if DEBUG
            Debug.Log("Collision!");
#endif
            Model = collider.gameObject;

            Max = collider.gameObject.transform.childCount - 1;
            StartCoroutine("AoD");       
        }

    }

    private void FixedUpdate()
    {
        //Debug.Log(Destroyed);
        if(Destroyed)
        {
            StopCoroutine("AoD");
        }
    }

    IEnumerator AoD()
    {
        while (true)
        {
            System.Random rand = new System.Random((int)DateTime.Now.Ticks);
#if DEBUG
            Debug.Log("StartCoroutine");
#endif
            CheckAvoidence = rand.Next(101);

            AvoidenceHumans.GetHeavy(BPEenemy);

#if DEBUG
            Debug.Log(CheckAvoidence);
#endif
            if (CheckAvoidence > BPEenemy[0])
            {
#if DEBUG
                Debug.Log("NotBlocked");
#endif

                CheckAvoidence = rand.Next(101);
#if DEBUG
                Debug.Log(CheckAvoidence);
#endif
                if (CheckAvoidence > BPEenemy[1])
                {
#if DEBUG
                    Debug.Log("NotParried");
#endif

                    CheckAvoidence = rand.Next(101);
#if DEBUG
                    Debug.Log(CheckAvoidence);
#endif
                    if (CheckAvoidence > BPEenemy[2])
                    {
#if DEBUG
                        Debug.Log("NotEvaded");
#endif

                        GetHeavy(Weapon, ArmorEnemy);

                        Res_WeapArmor = ArmorEnemy - Weapon;

                        if (Res_WeapArmor > 0)
                        {
                            Dead -= Res_WeapArmor;
                        }

                        CheckDead = rand.Next((int)Dead);

                        if (CheckDead <= Dead)
                        {
#if DEBUG
                            Debug.Log("Dead!");
#endif
                            //CheckProbabilityIsDead = Random.Range(1, 10);

                            //Destroy(this.Model.transform.GetChild((int)CheckProbabilityIsDead));
                            Died = UnityEngine.Random.Range(0, Max);
                            Destroy(Model.transform.GetChild(Died).gameObject);
                            Max = Model.transform.childCount - 1;
                            Debug.Log(Max + " - Max childs");
                            Dead = 100.0f;
                            if (Model.transform.childCount == 1)
                            {
#if DEBUG
                                Debug.Log("Destroy");
#endif
                                Destroy(Model);
                                Destroyed = true;
                                yield break;
                            }
                        }
                    }
                }
            }
            else
            {
                Avoided = UnityEngine.Random.Range(0, Max);

                Model.transform.GetChild(Avoided).gameObject.GetComponent<Animator>().SetBool("Blocked", true);
            }

            yield return new WaitForSeconds(1f);
        }
    }
}


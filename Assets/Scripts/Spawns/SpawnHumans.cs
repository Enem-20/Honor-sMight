
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class SpawnHumans : MonoBehaviour
{
    

    public Button HeavyInfantryCall;
    public Button Avant_gardeCall;
    public Button LightInfantryCall;
    public Button SpearmanCall;

    public GameObject[] Infantrys;
    public GameObject inst_infantry;
    public int isInfantry;
    private GameObject PriorityHeavyWrite;
    private Transform SpawnInfantry;
    void Start()
    {
        HeavyInfantryCall.onClick.AddListener(HeavyInfantryClick);
        Avant_gardeCall.onClick.AddListener(Avant_gardeClick);
        LightInfantryCall.onClick.AddListener(LightInfantryClick);
        SpearmanCall.onClick.AddListener(SpearmanInfantryClick);

        SpawnInfantry = GetComponent<Transform>();
       

    }
        
    public void HeavyInfantryClick()
    {
        inst_infantry = Instantiate(Infantrys[0],SpawnInfantry.transform.position, Quaternion.identity) as GameObject;
        //PriorityHeavyWrite = GameObject.Find("OrcProtectors_Empty(Clone)");
        //inst_infantry.GetComponent<PriorityHeavy>().Orcs[0] = PriorityHeavyWrite;
        //inst_infantry.GetComponent<Animator>().Play();
        isInfantry = 0;
    }
    void Avant_gardeClick()
    {
        inst_infantry = Instantiate(Infantrys[1], SpawnInfantry.transform.position, Quaternion.identity) as GameObject;
        isInfantry = 1;
    }
    void LightInfantryClick()
    {
        inst_infantry = Instantiate(Infantrys[2], new Vector3(156, 255, -878), Quaternion.identity) as GameObject;
        isInfantry = 2;
    }
    void SpearmanInfantryClick()
    {
        inst_infantry = Instantiate(Infantrys[3], new Vector3(156, 255, -878), Quaternion.identity) as GameObject;
        isInfantry = 3;
    }
   /* void HeavyInfantryClick()
    {
        inst_infantry = Instantiate(Infantrys[0], new Vector3(156, 255, -878), Quaternion.identity) as GameObject;
    }
    void HeavyInfantryClick()
    {
        inst_infantry = Instantiate(Infantrys[0], new Vector3(156, 255, -878), Quaternion.identity) as GameObject;
    }
    void HeavyInfantryClick()
    {
        inst_infantry = Instantiate(Infantrys[0], new Vector3(156, 255, -878), Quaternion.identity) as GameObject;
    }
    void HeavyInfantryClick()
    {
        inst_infantry = Instantiate(Infantrys[0], new Vector3(156, 255, -878), Quaternion.identity) as GameObject;
    }
    void HeavyInfantryClick()
    {
        inst_infantry = Instantiate(Infantrys[0], new Vector3(156, 255, -878), Quaternion.identity) as GameObject;
    }
    void HeavyInfantryClick()
    {
        inst_infantry = Instantiate(Infantrys[0], new Vector3(156, 255, -878), Quaternion.identity) as GameObject;
    }*/
    // Update is called once per frame
}
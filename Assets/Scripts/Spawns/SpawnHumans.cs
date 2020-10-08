
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using NBattle;
using NPriority;


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

    GameObject gameManager;

    private void Awake()
    {
        gameManager = GameObject.Find("GameManager");
    }
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
        inst_infantry.AddComponent<Heavy>();
        inst_infantry.GetComponent<Priority>().priorityDeterminate = inst_infantry.GetComponent<Heavy>();
        inst_infantry.GetComponent<Priority>().setUnit(inst_infantry.GetComponent<Priority>().priorityDeterminate);

        inst_infantry.AddComponent<BattleHeavy>();
        inst_infantry.GetComponent<Battle>().battleDeterminate = inst_infantry.GetComponent<BattleHeavy>();
        inst_infantry.GetComponent<Battle>().setUnit(inst_infantry.GetComponent<Battle>().battleDeterminate, new ParamHeavy());

        gameManager.GetComponent<GameManagerScript>().HeavyInfantryObjectsList.Add(inst_infantry);
        isInfantry = 0;
    }
    void Avant_gardeClick()
    {
        inst_infantry = Instantiate(Infantrys[1], SpawnInfantry.transform.position, Quaternion.identity) as GameObject;
        inst_infantry.GetComponent<Priority>().enabled = true;
        inst_infantry.AddComponent<AvantGarde>();
        inst_infantry.GetComponent<Priority>().priorityDeterminate = inst_infantry.GetComponent<AvantGarde>();
        inst_infantry.GetComponent<Priority>().setUnit(inst_infantry.GetComponent<Priority>().priorityDeterminate);

        inst_infantry.AddComponent<BattleAvantGarde>();
        inst_infantry.GetComponent<Battle>().battleDeterminate = inst_infantry.GetComponent<BattleAvantGarde>();
        inst_infantry.GetComponent<Battle>().setUnit(inst_infantry.GetComponent<Battle>().battleDeterminate, new ParamAvant());

        gameManager.GetComponent<GameManagerScript>().AvantGardeObjectsList.Add(inst_infantry);
        isInfantry = 1;
    }
    void LightInfantryClick()
    {
        inst_infantry = Instantiate(Infantrys[2], new Vector3(156, 255, -878), Quaternion.identity) as GameObject;
        inst_infantry.AddComponent<LightInfantry>();
        inst_infantry.GetComponent<Priority>().priorityDeterminate = inst_infantry.GetComponent<LightInfantry>();
        inst_infantry.GetComponent<Priority>().setUnit(inst_infantry.GetComponent<Priority>().priorityDeterminate);

        inst_infantry.AddComponent<BattleLight>();
        inst_infantry.GetComponent<Battle>().battleDeterminate = inst_infantry.GetComponent<BattleLight>();
        inst_infantry.GetComponent<Battle>().setUnit(inst_infantry.GetComponent<Battle>().battleDeterminate, new ParamLight());

        gameManager.GetComponent<GameManagerScript>().LightInfantryObjectsList.Add(inst_infantry);
        isInfantry = 2;
    }
    void SpearmanInfantryClick()
    {
        inst_infantry = Instantiate(Infantrys[3], new Vector3(156, 255, -878), Quaternion.identity) as GameObject;
        inst_infantry.AddComponent<Spearman>();
        inst_infantry.GetComponent<Priority>().priorityDeterminate = inst_infantry.GetComponent<Spearman>();
        inst_infantry.GetComponent<Priority>().setUnit(inst_infantry.GetComponent<Priority>().priorityDeterminate);

        inst_infantry.AddComponent<BattleSpearman>();
        inst_infantry.GetComponent<Battle>().battleDeterminate = inst_infantry.GetComponent<BattleSpearman>();
        inst_infantry.GetComponent<Battle>().setUnit(inst_infantry.GetComponent<Battle>().battleDeterminate, new ParamSpear());

        gameManager.GetComponent<GameManagerScript>().SpearmanObjectsList.Add(inst_infantry);
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
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnOrcs : MonoBehaviour
{
    [SerializeField] private Button Orc_ProtectorsCall;
    [SerializeField] public GameObject[] Orcs;
    public int isOrcs;
    

    private Transform _SpawnOrcs;
    public GameObject inst_Orcs;
    GameObject gameManager;

    private void Awake()
    {
        gameManager = GameObject.Find("GameManager");
    }
    // Start is called before the first frame update
    void Start()
    {
        _SpawnOrcs = GetComponent<Transform>();
        Orc_ProtectorsCall.onClick.AddListener(Orc_ProtectorsClick);
    }

    public void Orc_ProtectorsClick()
    {
        inst_Orcs = Instantiate(Orcs[0], _SpawnOrcs.transform.position, Quaternion.identity) as GameObject;
        inst_Orcs.AddComponent<Protectors>();
        inst_Orcs.GetComponent<Priority>().priorityDeterminate = inst_Orcs.GetComponent<Protectors>();
        inst_Orcs.GetComponent<Priority>().setUnit(inst_Orcs.GetComponent<Priority>().priorityDeterminate);

        inst_Orcs.AddComponent<BattleProtector>();
        inst_Orcs.GetComponent<Battle>().battleDeterminate = inst_Orcs.GetComponent<BattleProtector>();
        inst_Orcs.GetComponent<Battle>().setUnit(inst_Orcs.GetComponent<Battle>().battleDeterminate);

        gameManager.GetComponent<GameManagerScript>().OrcProtectorObjectsList.Add(inst_Orcs);
        isOrcs = 0;
    }
}

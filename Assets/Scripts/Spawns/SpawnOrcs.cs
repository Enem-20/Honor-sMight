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

    // Start is called before the first frame update
    void Start()
    {
        _SpawnOrcs = GetComponent<Transform>();
        Orc_ProtectorsCall.onClick.AddListener(Orc_ProtectorsClick);
    }

    public void Orc_ProtectorsClick()
    {
        inst_Orcs = Instantiate(Orcs[0], _SpawnOrcs.transform.position, Quaternion.identity) as GameObject;
        isOrcs = 0;
    }
}

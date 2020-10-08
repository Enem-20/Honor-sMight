//#define DEBUG

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject CastleHpText;
    private Text _CastleHpText;

    [SerializeField]private GameObject CastleHpBar;
    private RectTransform _CastleHpBar;

    [SerializeField] private GameObject HpBarLair;
    [SerializeField] private GameObject HpTextLair;
    private RectTransform _HpBarLair;
    private Text _HpTextLair;

    [SerializeField] private GameObject StartJump;
    [SerializeField] private GameObject EndJump;

    [SerializeField] private GameObject SpawnHumans;
    [SerializeField] private GameObject SpawnOrcs;

    [SerializeField] private Button UnitOrcs;
    [SerializeField] private Button UnitHumans;

    [SerializeField] private List<GameObject> CallOrcs;
    [SerializeField] private List<GameObject> CallHumans;
    [SerializeField] private GameObject[] DamageCastleLair;

    [SerializeField] private GameObject[] Cameras;
    CharacterController _charControl;
    public List<GameObject> Heavy;        //enemies
    public List<GameObject> Avant;
    public List<GameObject> Light;
    public List<GameObject> Spear;

    public List<GameObject> Protectors;
    public List<GameObject> StoneHands;
    public List<GameObject> Champions;
    public List<GameObject> Dwarfs;

    private GameObject inst;
    private bool ShowButtonsOrcs = false;
    private bool ShowButtonsHumans = false;
    private bool _GamePad = false;
    private int Spawn = 0;
    private int ifButtonDown = 0;

    private float RotationXgmpd;
    private float RotationYgmpd;
    public float minimumVert = -90.0f;
    public float maximumVert = 90.0f;
    public float SensitivityHor = 9.0f;
    public float SensitivityVert = 9.0f;
    private float speed = 1000f;

    // Start is called before the first frame update

    private void Awake()
    {
        for (int i = 0; i < UnitOrcs.transform.childCount; ++i)
        {
            CallOrcs.Add(UnitOrcs.transform.GetChild(i).gameObject);
        }
        for (int i = 0; i < UnitHumans.transform.childCount; ++i)
        {
            CallHumans.Add(UnitHumans.transform.GetChild(i).gameObject);
        }


    }
    void Start()
    {
        //_CastleHpBar = CastleHpBar.GetComponent<RectTransform>();

        //_CastleHpText = CastleHpText.GetComponent<Text>();

        //_HpBarLair = HpBarLair.GetComponent<RectTransform>();

        //_HpTextLair = HpTextLair.GetComponent<Text>();

        UnitOrcs.onClick.AddListener(CallOrcsClick);
        UnitHumans.onClick.AddListener(CallHumansClick);       

    }

    void Update()
    {



    }

    private void FixedUpdate()
    {
 
    }

    void CallOrcsClick()
    {
        switch (ShowButtonsOrcs)
        {
            case true:
                for (int i = 1; i < UnitOrcs.transform.childCount; i++)
                {
                    CallOrcs[i].SetActive(false);
                }
                ShowButtonsOrcs = false;
                break;
            case false:
                for (int i = 1; i < UnitOrcs.transform.childCount; i++)
                {
                    CallOrcs[i].SetActive(true);
                }
                ShowButtonsOrcs = true;
                break;
        }
    }
    void CallHumansClick()
    {
        switch (ShowButtonsHumans) 
        {
            case true:
                for (int i = 1; i < UnitHumans.transform.childCount; i++)
                {
                    CallHumans[i].SetActive(false);
                }
                ShowButtonsHumans = false;
                break;
            case false:
                for (int i = 1; i < UnitHumans.transform.childCount; i++)
                {
                    CallHumans[i].SetActive(true);
                }
                ShowButtonsHumans = true;
                break;

        }
    }
    
}

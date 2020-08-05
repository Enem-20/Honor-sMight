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

    [SerializeField] private GameObject Spawn_CastleDamageZone;
    private Transform _Spawn_CastleDamageZone;

    [SerializeField] private GameObject StartJump;
    [SerializeField] private GameObject EndJump;

    [SerializeField] private GameObject SpawnHumans;
    [SerializeField] private GameObject SpawnOrcs;

    [SerializeField] private Button UnitOrcs;
    [SerializeField] private Button UnitHumans;

    [SerializeField] private GameObject[] CallOrcs;
    [SerializeField] private GameObject[] CallHumans;
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
    void Start()
    {
        _CastleHpBar = CastleHpBar.GetComponent<RectTransform>();
        _CastleHpBar.sizeDelta = new Vector2(400, 8);

        _CastleHpText = CastleHpText.GetComponent<Text>();
        _CastleHpText.text = 400.ToString();

        _HpBarLair = HpBarLair.GetComponent<RectTransform>();
        _HpBarLair.sizeDelta = new Vector2(400, 8);

        _HpTextLair = HpTextLair.GetComponent<Text>();
        _HpTextLair.text = 400.ToString();

        _Spawn_CastleDamageZone = Spawn_CastleDamageZone.GetComponent<Transform>();

        UnitOrcs.onClick.AddListener(CallOrcsClick);
        UnitHumans.onClick.AddListener(CallHumansClick);

        inst = Instantiate(DamageCastleLair[1], Spawn_CastleDamageZone.transform.position, Quaternion.identity) as GameObject;
        inst = Instantiate(DamageCastleLair[0], transform.position, Quaternion.identity) as GameObject;
        inst = Instantiate(StartJump, new Vector3(17.7f, -331.7f, -793.7f), Quaternion.identity) as GameObject;
        inst = Instantiate(EndJump, new Vector3(16f, -326.1f, -816.8f), Quaternion.identity) as GameObject;
        //DamageInfantry = GetComponent<PriorityHeavy>().Damage;
        

    }

    void Update()
    {
//#if DEBUG
//        Debug.Log(Input.GetJoystickNames());
//#endif
        Cameras[1] = GameObject.Find("Camera(Clone)");

        if (Cameras[1] != null)
        {
            _GamePad = true;
            _charControl = Cameras[1].GetComponent<CharacterController>();

            if (Input.GetAxis("DPad_XAxis_1") > 0)
            {
                CallOrcs[0].SetActive(true);
                if (Input.GetKeyDown(KeyCode.Joystick1Button0))
                {
                    inst = Instantiate(SpawnOrcs.GetComponent<SpawnOrcs>().Orcs[0], SpawnOrcs.transform.position, Quaternion.identity) as GameObject;
                }
            }
            else
            {
                CallOrcs[0].SetActive(false);
            }

            ///////////////////////////////////////////////////Left Stick

            //float deltaX = Input.GetAxis("Left_YAxis_1") * speed;
            //float deltaZ = Input.GetAxis("Left_XAxis_1") * speed;
            //Vector3 movement = new Vector3(deltaX, 0, deltaZ);
            //movement = Vector3.ClampMagnitude(movement, speed);

            //movement *= Time.deltaTime;
            //movement = Cameras[1].transform.TransformDirection(movement);
            //_charControl.transform.position += movement;

            /////////////////////////////////////////////////////Right Stick

            //if ((Input.GetAxis("R_XAxis_1") != 0) && (Input.GetAxis("R_YAxis_1") == 0))
            //{
            //    Cameras[1].transform.Rotate(0, Input.GetAxis("R_XAxis_1"), 0);
            //}
            //else if ((Input.GetAxis("R_YAxis_1") != 0) && (Input.GetAxis("R_XAxis_1") == 0))
            //{
            //    RotationXgmpd += Input.GetAxis("R_YAxis_1");
            //    RotationXgmpd = Mathf.Clamp(RotationXgmpd, minimumVert, maximumVert);

            //    float RotationYgmpd = Cameras[1].transform.localEulerAngles.y;

            //    Cameras[1].transform.localEulerAngles = new Vector3(RotationXgmpd, RotationYgmpd, 0);
            //}
            //else if (!(Input.GetAxis("R_XAxis_1") == 0) && !(Input.GetAxis("R_YAxis_1") == 0))
            //{
            //    RotationXgmpd += Input.GetAxis("R_YAxis_1");
            //    RotationXgmpd = Mathf.Clamp(RotationXgmpd, minimumVert, maximumVert);

            //    float delta = Input.GetAxis("R_XAxis_1");
            //    float RotationYgmpd = Cameras[1].transform.localEulerAngles.y + delta;
            //    Cameras[1].transform.localEulerAngles = new Vector3(RotationXgmpd, RotationYgmpd, 0);
            //}
        }


    }

    private void FixedUpdate()
    {
        int _isOrcs = transform.GetChild(1).GetComponent<SpawnOrcs>().isOrcs;

        if (transform.GetChild(1).GetComponent<SpawnOrcs>().inst_Orcs != null)
        {
            switch (_isOrcs)
            {
                case 0:
                    Protectors.Add(transform.GetChild(1).GetComponent<SpawnOrcs>().inst_Orcs);
                    transform.GetChild(1).GetComponent<SpawnOrcs>().inst_Orcs = null;
                    break;
                case 1:
                    Champions.Add(transform.GetChild(1).GetComponent<SpawnOrcs>().inst_Orcs);
                    transform.GetChild(1).GetComponent<SpawnOrcs>().inst_Orcs = null;
                    break;
                case 2:
                    StoneHands.Add(transform.GetChild(1).GetComponent<SpawnOrcs>().inst_Orcs);
                    transform.GetChild(1).GetComponent<SpawnOrcs>().inst_Orcs = null;
                    break;
                case 3:
                    Dwarfs.Add(transform.GetChild(1).GetComponent<SpawnOrcs>().inst_Orcs);
                    transform.GetChild(1).GetComponent<SpawnOrcs>().inst_Orcs = null;
                    break;
            }
        }

        int _isInfantry = transform.GetChild(0).GetComponent<SpawnHumans>().isInfantry;

        if (transform.GetChild(0).GetComponent<SpawnHumans>().inst_infantry != null)
        {
            switch (_isInfantry)
            {
                case 0:
                    GetComponent<GameManager>().Heavy.Add(transform.GetChild(0).GetComponent<SpawnHumans>().inst_infantry);
                    transform.GetChild(0).GetComponent<SpawnHumans>().inst_infantry = null;
                    break;
                case 1:
                    GetComponent<GameManager>().Avant.Add(transform.GetChild(0).GetComponent<SpawnHumans>().inst_infantry);
                    transform.GetChild(0).GetComponent<SpawnHumans>().inst_infantry = null;
                    break;
                case 2:
                    GetComponent<GameManager>().Light.Add(transform.GetChild(0).GetComponent<SpawnHumans>().inst_infantry);
                    transform.GetChild(0).GetComponent<SpawnHumans>().inst_infantry = null;
                    break;
                case 3:
                    GetComponent<GameManager>().Spear.Add(transform.GetChild(0).GetComponent<SpawnHumans>().inst_infantry);
                    transform.GetChild(0).GetComponent<SpawnHumans>().inst_infantry = null;
                    break;
            }
        }
    }

    void CallOrcsClick()
    {
        switch (ShowButtonsOrcs)
        {
            case true:
                for (int i = 0; i < 4; i++)
                {
                    CallOrcs[i].SetActive(false);
                }
                ShowButtonsOrcs = false;
                break;
            case false:
                for (int i = 0; i < 4; i++)
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
                for (int i = 0; i < 4; i++)
                {
                    CallHumans[i].SetActive(false);
                }
                ShowButtonsHumans = false;
                break;
            case false:
                for (int i = 0; i < 4; i++)
                {
                    CallHumans[i].SetActive(true);
                }
                ShowButtonsHumans = true;
                break;

        }
    }
    
}

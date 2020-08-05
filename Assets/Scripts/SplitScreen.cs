using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SplitScreen : MonoBehaviour
{
    [SerializeField] GameObject Second;
    [SerializeField] GameObject CallOrcs;

    Camera First;
    Camera Sec;

    GameObject _Second;
    GameObject _CallOrcs;

    // Start is called before the first frame update
    void Start()
    {
        First = GetComponent<Camera>();
        _Second = Instantiate(Second) as GameObject;
        Sec = _Second.GetComponent<Camera>();
        _CallOrcs = CallOrcs;
        _Second.SetActive(false);
        _CallOrcs.SetActive(true);
        First.rect = new Rect(0, 0, 1, 1);
        Sec.rect = new Rect(0, 0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.O))
        {
            if(_Second.activeInHierarchy)
            {
                _Second.SetActive(false);
                _CallOrcs.SetActive(true);
                First.rect = new Rect(0, 0, 1, 1);
                Sec.rect = new Rect(0, 0, 0, 0);
            }
            else
            {
                _Second.SetActive(true);
                First.rect = new Rect(0, 0, 0.5f, 1);
                Sec.rect = new Rect(0.5f, 0, 0.5f, 1);
                _CallOrcs.SetActive(false);
            }
        }
    }
    
}

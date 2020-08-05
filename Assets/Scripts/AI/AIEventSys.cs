using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIEventSys : MonoBehaviour
{
    // Start is called before the first frame update
    PriorityHeavy _PriorityHeavy;

    GameObject _Object;

    Transform Get;

    Vector3 fwd;

    public void _Event(Transform Set, GameObject _Object)
    {
        Get = Set;
        this._Object = _Object;
    }

    void Start()
    {
        fwd = transform.TransformDirection(Vector3.forward);
    }

    RaycastHit hit;

    // Update is called once per frame
    void Update()
    {
        //if(Physics.Raycast(Get.position, fwd, out hit))
        //{
        //    _PriorityHeavy.GetHit(hit);
        //}

    }
}

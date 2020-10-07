using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetComponent_Transform : MonoBehaviour
{
    [SerializeField] Transform getterTransform;
    // Start is called before the first frame update
    void Start()
    {
       getterTransform =  GameObject.Find("DamageOrcs").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

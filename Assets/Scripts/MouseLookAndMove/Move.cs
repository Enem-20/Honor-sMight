using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if(transform.position.z < 105)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, 105);
        }
    }
}

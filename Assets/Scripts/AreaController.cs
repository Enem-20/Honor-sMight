using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AreaController : MonoBehaviour
{
    enum Areas {Walkable, NotWalkable, Jump, Swamp }
    [SerializeField] Areas areas;

    // Start is called before the first frame update
    void Start()
    {
        switch(areas)
        {
            case Areas.Walkable :
                break;
            case Areas.NotWalkable :
                break;
            case Areas.Jump :
                break;
            case Areas.Swamp:
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

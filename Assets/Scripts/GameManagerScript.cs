using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;


abstract public class PriorityStategy
{
    abstract public Vector3 getNextTarget(GameManagerScript gameManager, Vector3 currentPositon);

    protected Vector3 GetNearObject(Vector3 position, List<GameObject> list)
    {
        float length2 = 9999;
        Vector3 returnedVector = Vector3.zero;
        foreach (GameObject currentElement in list)
        {
            Vector3 distance = position - currentElement.transform.position;
            float calculatedLength2 = distance.x * distance.x + distance.y * distance.y + distance.z * distance.z;
            if (calculatedLength2 < length2)
            {
                length2 = calculatedLength2;
                returnedVector = currentElement.transform.position;
            }
        }
        return returnedVector;
    }
}

public class HeavyInfantryPriority : PriorityStategy
{
    override public Vector3 getNextTarget(GameManagerScript gameManager, Vector3 currentPositon)
    {
        if (gameManager.OrcProtectorObjectsList.Count != 0)
        {
            return GetNearObject(currentPositon, gameManager.OrcProtectorObjectsList);
        }
        else if (gameManager.OrcChampionObjectsList.Count != 0)
        {
            return GetNearObject(currentPositon, gameManager.OrcChampionObjectsList);
        }
        else if (gameManager.OrcDwarfObjectsList.Count != 0)
        {
            return GetNearObject(currentPositon, gameManager.OrcDwarfObjectsList);
        }
        else if (gameManager.OrcOfStoneObjectsList.Count != 0)
        {
            return GetNearObject(currentPositon, gameManager.OrcOfStoneObjectsList);
        }
        return currentPositon;
    }
}

public class AvantGardePriority : PriorityStategy
{
    override public Vector3 getNextTarget(GameManagerScript gameManager, Vector3 currentPositon)
    {
        if (gameManager.OrcChampionObjectsList.Count != 0)
        {
            return GetNearObject(currentPositon, gameManager.OrcChampionObjectsList);
        }
        else if(gameManager.OrcProtectorObjectsList.Count != 0)
        {
            return GetNearObject(currentPositon, gameManager.OrcProtectorObjectsList);
        }
        else if (gameManager.OrcOfStoneObjectsList.Count != 0)
        {
            return GetNearObject(currentPositon, gameManager.OrcOfStoneObjectsList);
        }
        else if (gameManager.OrcDwarfObjectsList.Count != 0)
        {
            return GetNearObject(currentPositon, gameManager.OrcDwarfObjectsList);
        }
        return currentPositon;
    }
}

public class LightInfantryPriority : PriorityStategy
{
    override public Vector3 getNextTarget(GameManagerScript gameManager, Vector3 currentPositon)
    {
        if (gameManager.OrcOfStoneObjectsList.Count != 0)
        {
            return GetNearObject(currentPositon, gameManager.OrcOfStoneObjectsList);
        }
        else if (gameManager.OrcDwarfObjectsList.Count != 0)
        {
            return GetNearObject(currentPositon, gameManager.OrcDwarfObjectsList);
        }
        else if (gameManager.OrcChampionObjectsList.Count != 0)
        {
            return GetNearObject(currentPositon, gameManager.OrcChampionObjectsList);
        }
        else if (gameManager.OrcProtectorObjectsList.Count != 0)
        {
            return GetNearObject(currentPositon, gameManager.OrcProtectorObjectsList);
        }
        return currentPositon;
    }
}

public class SpearmanPriority : PriorityStategy
{
    override public Vector3 getNextTarget(GameManagerScript gameManager, Vector3 currentPositon)
    {
        if (gameManager.OrcProtectorObjectsList.Count != 0)
        {
            return GetNearObject(currentPositon, gameManager.OrcProtectorObjectsList);
        }
        else if (gameManager.OrcChampionObjectsList.Count != 0)
        {
            return GetNearObject(currentPositon, gameManager.OrcChampionObjectsList);
        }
        else if (gameManager.OrcOfStoneObjectsList.Count != 0)
        {
            return GetNearObject(currentPositon, gameManager.OrcOfStoneObjectsList);
        }
        else if (gameManager.OrcDwarfObjectsList.Count != 0)
        {
            return GetNearObject(currentPositon, gameManager.OrcDwarfObjectsList);
        }
        return currentPositon;
    }
}

public class GameManagerScript : MonoBehaviour
{
    // Humans
    [SerializeField] GameObject HeavyInfantryObject;
    [SerializeField] GameObject AvantGardeObject;
    [SerializeField] GameObject LightInfantryObject;
    [SerializeField] GameObject SpearmanObject;

    // Orcs
    [SerializeField] GameObject OrcProtectorObject;
    [SerializeField] GameObject OrcChampionObject;
    [SerializeField] GameObject OrcOfStoneObject;
    [SerializeField] GameObject OrcDwarfObject;

    [SerializeField] Transform HumansSpawn;
    [SerializeField] Transform OrcsSpawn;

    public List<GameObject> HeavyInfantryObjectsList;
    public List<GameObject> AvantGardeObjectsList;
    public List<GameObject> LightInfantryObjectsList;
    public List<GameObject> SpearmanObjectsList;

    public List<GameObject> OrcProtectorObjectsList;
    public List<GameObject> OrcChampionObjectsList;
    public List<GameObject> OrcOfStoneObjectsList;
    public List<GameObject> OrcDwarfObjectsList;

    GameObject obj;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            HeavyInfantryObjectsList.Add(Instantiate(HeavyInfantryObject, HumansSpawn.transform.position, Quaternion.identity) as GameObject);
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            AvantGardeObjectsList.Add(Instantiate(AvantGardeObject, HumansSpawn.transform.position, Quaternion.identity) as GameObject);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            LightInfantryObjectsList.Add(Instantiate(LightInfantryObject, HumansSpawn.transform.position, Quaternion.identity) as GameObject);
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            SpearmanObjectsList.Add(Instantiate(SpearmanObject, HumansSpawn.transform.position, Quaternion.identity) as GameObject);
        }



        if (Input.GetKeyDown(KeyCode.Y))
        {
            OrcProtectorObjectsList.Add(Instantiate(OrcProtectorObject, OrcsSpawn.transform.position, Quaternion.identity) as GameObject);
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            OrcChampionObjectsList.Add(Instantiate(OrcChampionObject, OrcsSpawn.transform.position, Quaternion.identity) as GameObject);
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            OrcOfStoneObjectsList.Add(Instantiate(OrcOfStoneObject, OrcsSpawn.transform.position, Quaternion.identity) as GameObject);
        }
        if (Input.GetKeyDown(KeyCode.V))
        {
            OrcDwarfObjectsList.Add(Instantiate(OrcDwarfObject, OrcsSpawn.transform.position, Quaternion.identity) as GameObject);
        }
    }
}

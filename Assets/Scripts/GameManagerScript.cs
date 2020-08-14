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
        return gameManager.Lair.transform.position;
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
        return gameManager.Lair.transform.position;
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
        return gameManager.Lair.transform.position;
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
        return gameManager.Lair.transform.position;
    }
}


public class OrcProtectorPriority : PriorityStategy
{
    override public Vector3 getNextTarget(GameManagerScript gameManager, Vector3 currentPositon)
    {
        if (gameManager.HeavyInfantryObjectsList.Count != 0)
        {
            return GetNearObject(currentPositon, gameManager.HeavyInfantryObjectsList);
        }
        else if (gameManager.AvantGardeObjectsList.Count != 0)
        {
            return GetNearObject(currentPositon, gameManager.AvantGardeObjectsList);
        }
        else if (gameManager.SpearmanObjectsList.Count != 0)
        {
            return GetNearObject(currentPositon, gameManager.SpearmanObjectsList);
        }
        else if (gameManager.LightInfantryObjectsList.Count != 0)
        {
            return GetNearObject(currentPositon, gameManager.LightInfantryObjectsList);
        }
        return gameManager.Castle.transform.position;
    }
}


public class OrcChampionPriority : PriorityStategy
{
    override public Vector3 getNextTarget(GameManagerScript gameManager, Vector3 currentPositon)
    {
        if (gameManager.AvantGardeObjectsList.Count != 0)
        {
            return GetNearObject(currentPositon, gameManager.AvantGardeObjectsList);
        }
        else if (gameManager.HeavyInfantryObjectsList.Count != 0)
        {
            return GetNearObject(currentPositon, gameManager.HeavyInfantryObjectsList);
        }
        else if (gameManager.LightInfantryObjectsList.Count != 0)
        {
            return GetNearObject(currentPositon, gameManager.LightInfantryObjectsList);
        }
        else if (gameManager.SpearmanObjectsList.Count != 0)
        {
            return GetNearObject(currentPositon, gameManager.SpearmanObjectsList);
        }
        return gameManager.Castle.transform.position;
    }
}


public class OrcOfStoneHandPriority : PriorityStategy
{
    override public Vector3 getNextTarget(GameManagerScript gameManager, Vector3 currentPositon)
    {
        if (gameManager.LightInfantryObjectsList.Count != 0)
        {
            return GetNearObject(currentPositon, gameManager.LightInfantryObjectsList);
        }
        else if (gameManager.SpearmanObjectsList.Count != 0)
        {
            return GetNearObject(currentPositon, gameManager.SpearmanObjectsList);
        }
        else if (gameManager.AvantGardeObjectsList.Count != 0)
        {
            return GetNearObject(currentPositon, gameManager.AvantGardeObjectsList);
        }
        else if (gameManager.HeavyInfantryObjectsList.Count != 0)
        {
            return GetNearObject(currentPositon, gameManager.HeavyInfantryObjectsList);
        }
        return gameManager.Castle.transform.position;
    }
}

public class OrcDwarfPriority : PriorityStategy
{
    override public Vector3 getNextTarget(GameManagerScript gameManager, Vector3 currentPositon)
    {
        if (gameManager.HeavyInfantryObjectsList.Count != 0)
        {
            return GetNearObject(currentPositon, gameManager.HeavyInfantryObjectsList);
        }
        else if (gameManager.AvantGardeObjectsList.Count != 0)
        {
            return GetNearObject(currentPositon, gameManager.AvantGardeObjectsList);
        }
        else if (gameManager.SpearmanObjectsList.Count != 0)
        {
            return GetNearObject(currentPositon, gameManager.SpearmanObjectsList);
        }
        else if (gameManager.LightInfantryObjectsList.Count != 0)
        {
            return GetNearObject(currentPositon, gameManager.LightInfantryObjectsList);
        }
        return gameManager.Castle.transform.position;
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

    public GameObject Castle;
    public GameObject Lair;

    public List<GameObject> HeavyInfantryObjectsList;
    public List<GameObject> AvantGardeObjectsList;
    public List<GameObject> LightInfantryObjectsList;
    public List<GameObject> SpearmanObjectsList;

    public List<GameObject> OrcProtectorObjectsList;
    public List<GameObject> OrcChampionObjectsList;
    public List<GameObject> OrcOfStoneObjectsList;
    public List<GameObject> OrcDwarfObjectsList;

    GameObject obj;

    private void Awake()
    {
        Lair = GameObject.Find("DamageOrcs");
        Castle = GameObject.Find("DamageHumans");
    }
}

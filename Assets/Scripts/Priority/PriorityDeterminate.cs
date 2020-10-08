using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace NPriority
{
    abstract public class PriorityDeterminate : MonoBehaviour
    {
        protected GameManagerScript gameManagerScript;
        protected NavMeshAgent navMeshAgent;


        public virtual void Go()
        {
            navMeshAgent.destination = Target();
        }

        abstract public Vector3 Target();

        protected Vector3 GetNearObject(Vector3 position, List<GameObject> list)
        {
            float length2 = 99999;
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

        private void Awake()
        {
            navMeshAgent = GetComponent<NavMeshAgent>();
        }
        private void Start()
        {
            gameManagerScript = GameObject.Find("GameManager").GetComponent<GameManagerScript>();
        }
    }

    sealed class Heavy : PriorityDeterminate
    {
        public override void Go()
        {
            base.Go();
        }
        public override Vector3 Target()
        {

            if (gameManagerScript.OrcProtectorObjectsList.Count != 0)
            {
                return GetNearObject(gameObject.transform.position, gameManagerScript.OrcProtectorObjectsList);
            }
            else if (gameManagerScript.OrcChampionObjectsList.Count != 0)
            {
                return GetNearObject(gameObject.transform.position, gameManagerScript.OrcChampionObjectsList);
            }
            else if (gameManagerScript.OrcDwarfObjectsList.Count != 0)
            {
                return GetNearObject(gameObject.transform.position, gameManagerScript.OrcDwarfObjectsList);
            }
            else if (gameManagerScript.OrcOfStoneObjectsList.Count != 0)
            {
                return GetNearObject(gameObject.transform.position, gameManagerScript.OrcOfStoneObjectsList);
            }
            else
            {
                return gameManagerScript.Lair.transform.position;
            }
        }

        private void OnDestroy()
        {
            gameManagerScript.HeavyInfantryObjectsList.Remove(gameManagerScript.HeavyInfantryObjectsList.Find(same => same == gameObject));
        }
    }

    sealed class AvantGarde : PriorityDeterminate
    {
        public override void Go()
        {
            base.Go();
        }
        public override Vector3 Target()
        {

            if (gameManagerScript.OrcChampionObjectsList.Count != 0)
            {
                return GetNearObject(gameObject.transform.position, gameManagerScript.OrcChampionObjectsList);
            }
            else if (gameManagerScript.OrcProtectorObjectsList.Count != 0)
            {
                return GetNearObject(gameObject.transform.position, gameManagerScript.OrcProtectorObjectsList);
            }
            else if (gameManagerScript.OrcOfStoneObjectsList.Count != 0)
            {
                return GetNearObject(gameObject.transform.position, gameManagerScript.OrcOfStoneObjectsList);
            }
            else if (gameManagerScript.OrcDwarfObjectsList.Count != 0)
            {
                return GetNearObject(gameObject.transform.position, gameManagerScript.OrcDwarfObjectsList);
            }
            else
            {
                return gameManagerScript.Lair.transform.position;
            }
        }
        private void OnDestroy()
        {
            gameManagerScript.AvantGardeObjectsList.Remove(gameManagerScript.AvantGardeObjectsList.Find(same => same == gameObject));
        }
    }

    sealed class LightInfantry : PriorityDeterminate
    {
        public override void Go()
        {
            base.Go();
        }
        public override Vector3 Target()
        {
            if (gameManagerScript.OrcOfStoneObjectsList.Count != 0)
            {
                return GetNearObject(gameObject.transform.position, gameManagerScript.OrcOfStoneObjectsList);
            }
            else if (gameManagerScript.OrcDwarfObjectsList.Count != 0)
            {
                return GetNearObject(gameObject.transform.position, gameManagerScript.OrcDwarfObjectsList);
            }
            else if (gameManagerScript.OrcChampionObjectsList.Count != 0)
            {
                return GetNearObject(gameObject.transform.position, gameManagerScript.OrcChampionObjectsList);
            }
            else if (gameManagerScript.OrcProtectorObjectsList.Count != 0)
            {
                return GetNearObject(gameObject.transform.position, gameManagerScript.OrcProtectorObjectsList);
            }
            return gameManagerScript.Lair.transform.position;
        }

        private void OnDestroy()
        {
            gameManagerScript.LightInfantryObjectsList.Remove(gameManagerScript.LightInfantryObjectsList.Find(same => same == gameObject));
        }
    }

    public class Spearman : PriorityDeterminate
    {
        public override void Go()
        {
            base.Go();
        }
        override public Vector3 Target()
        {
            if (gameManagerScript.OrcProtectorObjectsList.Count != 0)
            {
                return GetNearObject(gameObject.transform.position, gameManagerScript.OrcProtectorObjectsList);
            }
            else if (gameManagerScript.OrcChampionObjectsList.Count != 0)
            {
                return GetNearObject(gameObject.transform.position, gameManagerScript.OrcChampionObjectsList);
            }
            else if (gameManagerScript.OrcOfStoneObjectsList.Count != 0)
            {
                return GetNearObject(gameObject.transform.position, gameManagerScript.OrcOfStoneObjectsList);
            }
            else if (gameManagerScript.OrcDwarfObjectsList.Count != 0)
            {
                return GetNearObject(gameObject.transform.position, gameManagerScript.OrcDwarfObjectsList);
            }
            return gameManagerScript.Lair.transform.position;
        }

        private void OnDestroy()
        {
            gameManagerScript.SpearmanObjectsList.Remove(gameManagerScript.SpearmanObjectsList.Find(same => same == gameObject));
        }
    }

    sealed class Protectors : PriorityDeterminate
    {
        //public override void Go()
        //{
        //    base.Go();
        //}
        public override Vector3 Target()
        {
            if (gameManagerScript.HeavyInfantryObjectsList.Count != 0)
            {
                return GetNearObject(gameObject.transform.position, gameManagerScript.HeavyInfantryObjectsList);
            }
            else if (gameManagerScript.AvantGardeObjectsList.Count != 0)
            {
                return GetNearObject(gameObject.transform.position, gameManagerScript.AvantGardeObjectsList);
            }
            else if (gameManagerScript.SpearmanObjectsList.Count != 0)
            {
                return GetNearObject(gameObject.transform.position, gameManagerScript.SpearmanObjectsList);
            }
            else if (gameManagerScript.LightInfantryObjectsList.Count != 0)
            {
                return GetNearObject(gameObject.transform.position, gameManagerScript.LightInfantryObjectsList);
            }
            return gameManagerScript.Castle.transform.position;
        }
        private void OnDestroy()
        {
            gameManagerScript.OrcProtectorObjectsList.Remove(gameManagerScript.OrcProtectorObjectsList.Find(same => same == gameObject));
        }
    }

    sealed class Champions : PriorityDeterminate
    {
        public override Vector3 Target()
        {
            if (gameManagerScript.AvantGardeObjectsList.Count != 0)
            {
                return GetNearObject(gameObject.transform.position, gameManagerScript.AvantGardeObjectsList);
            }
            else if (gameManagerScript.HeavyInfantryObjectsList.Count != 0)
            {
                return GetNearObject(gameObject.transform.position, gameManagerScript.HeavyInfantryObjectsList);
            }
            else if (gameManagerScript.LightInfantryObjectsList.Count != 0)
            {
                return GetNearObject(gameObject.transform.position, gameManagerScript.LightInfantryObjectsList);
            }
            else if (gameManagerScript.SpearmanObjectsList.Count != 0)
            {
                return GetNearObject(gameObject.transform.position, gameManagerScript.SpearmanObjectsList);
            }
            return gameManagerScript.Castle.transform.position;
        }
        private void OnDestroy()
        {
            gameManagerScript.OrcChampionObjectsList.Remove(gameManagerScript.OrcChampionObjectsList.Find(same => same == gameObject));
        }
    }

    sealed class Stone : PriorityDeterminate
    {
        public override void Go()
        {
            base.Go();
        }
        public override Vector3 Target()
        {
            if (gameManagerScript.LightInfantryObjectsList.Count != 0)
            {
                return GetNearObject(gameObject.transform.position, gameManagerScript.LightInfantryObjectsList);
            }
            else if (gameManagerScript.SpearmanObjectsList.Count != 0)
            {
                return GetNearObject(gameObject.transform.position, gameManagerScript.SpearmanObjectsList);
            }
            else if (gameManagerScript.AvantGardeObjectsList.Count != 0)
            {
                return GetNearObject(gameObject.transform.position, gameManagerScript.AvantGardeObjectsList);
            }
            else if (gameManagerScript.HeavyInfantryObjectsList.Count != 0)
            {
                return GetNearObject(gameObject.transform.position, gameManagerScript.HeavyInfantryObjectsList);
            }
            return gameManagerScript.Castle.transform.position;
        }

        private void OnDestroy()
        {
            gameManagerScript.OrcOfStoneObjectsList.Remove(gameManagerScript.OrcOfStoneObjectsList.Find(same => same == gameObject));
        }
    }

    sealed class Dwarf : PriorityDeterminate
    {
        public override void Go()
        {
            base.Go();
        }
        public override Vector3 Target()
        {
            if (gameManagerScript.HeavyInfantryObjectsList.Count != 0)
            {
                return GetNearObject(gameObject.transform.position, gameManagerScript.HeavyInfantryObjectsList);
            }
            else if (gameManagerScript.AvantGardeObjectsList.Count != 0)
            {
                return GetNearObject(gameObject.transform.position, gameManagerScript.AvantGardeObjectsList);
            }
            else if (gameManagerScript.SpearmanObjectsList.Count != 0)
            {
                return GetNearObject(gameObject.transform.position, gameManagerScript.SpearmanObjectsList);
            }
            else if (gameManagerScript.LightInfantryObjectsList.Count != 0)
            {
                return GetNearObject(gameObject.transform.position, gameManagerScript.LightInfantryObjectsList);
            }
            return gameManagerScript.Castle.transform.position;
        }

        private void OnDestroy()
        {
            gameManagerScript.OrcDwarfObjectsList.Remove(gameManagerScript.OrcDwarfObjectsList.Find(same => same == gameObject));
        }
    }
}
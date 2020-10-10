using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace NPriority
{
    public class Priority : MonoBehaviour
    {
        public PriorityDeterminate priorityDeterminate;

        public PriorityContext context;

        public delegate void SetUnit(PriorityDeterminate priorityDeterminate);

        public SetUnit setUnit;

        private void Awake()
        {
            context = new PriorityContext();
            setUnit = context.SetUnits;
        }


        private void Update()
        {
            context.GoToTarget();
        }
    }

    sealed public class PriorityContext
    {
        PriorityDeterminate priorityDeterminate;
        public void GoToTarget()
        {
            priorityDeterminate.Go();
        }
        public void SetUnits(PriorityDeterminate priority)
        {
            this.priorityDeterminate = priority;
        }
    }
}
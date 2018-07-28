using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SampleGame
{  
    public class Objective : MonoBehaviour
    {
        // is the objective complete?
        private bool _isComplete;
        public bool IsComplete { get { return _isComplete; } }

        // set the objective to complete
        public void CompleteObjective()
        {
            _isComplete = true;
        }
    }
}

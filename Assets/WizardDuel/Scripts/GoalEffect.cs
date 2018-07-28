using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SampleGame
{
    public class GoalEffect : MonoBehaviour
    {
        // delay before particles trigger
        [SerializeField]
        private float _delay = 1f;

        public void PlayEffect()
        {
            StartCoroutine(PlayEffectRoutine());
        }

        // find all of the ParticleSystem components and play
        IEnumerator PlayEffectRoutine()
        {
            // wait for a delay
            yield return new WaitForSeconds(_delay);
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using LevelManagement;

namespace SampleGame
{
    public class GameManager : MonoBehaviour
    {
        //enum for controlling turn phases
        public enum Phase { cast1, peek, cast2, result };

        //capture what turnnumber and the active phase of the battle
        public Phase activePhase;
        public int _turnNumber;

        // reference to objective
        private Objective _objective;

        private bool _isGameOver;
        public bool IsGameOver { get { return _isGameOver; } }

        private static GameManager _instance;
        public static GameManager Instance { get { return _instance; } }

        [SerializeField]
        private TransitionFader _endTransitionPrefab;

        // initialize references
        private void Awake()
        {
            if (_instance != null)
            {
                Destroy(gameObject);
            }
            else
            {
                _instance = this;
            }
            
            _objective = Object.FindObjectOfType<Objective>();
        }

        private void OnDestroy()
        {
            if (_instance == this)
            {
                _instance = null;
            }
        }

        void Start()
        {
            ResetGame();
        }

        private void ResetGame()
        {
            _isGameOver = false;
            _turnNumber = 1;
            activePhase = Phase.cast1;
        }

        // end the level
        public void EndLevel()
        {
            // check if we have set IsGameOver to true, only run this logic once
            if (!_isGameOver)
            {
                _isGameOver = true;
                StartCoroutine(WinRoutine());
            }
        }

        private IEnumerator WinRoutine()
        {
            TransitionFader.PlayTransition(_endTransitionPrefab);

            float fadeDelay  = (_endTransitionPrefab != null) ?
                _endTransitionPrefab.Delay + _endTransitionPrefab.FadeOnDuration : 0f;
            
            yield return new WaitForSeconds(fadeDelay);
            WinScreen.Open();
        }


        // check for the end game condition on each frame
        private void Update()
        {
            if (_objective != null && _objective.IsComplete)
            {
                EndLevel();
            }
        }
    }
}
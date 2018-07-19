using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //keep a connection to both players
    GameObject player1;
    GameObject player2;

    //enum for controlling turn phases
    public enum Phase {cast1, peek, cast2, result };

    //capture what turnnumber and the active phase of the battle
    public Phase activePhase;
    public int turnNumber;

    //todo: need an event for players to listen to, to update power etc.

    // Use this for initialization
    void Start ()
    {
        player1 = GameObject.Find("Player1");
        player2 = GameObject.Find("Player2");
        turnNumber = 1;
        activePhase = Phase.cast1;
	}
	
	// Update is called once per frame
	void Update ()
    {
		//listen for button press from both players, move turn Phase
        //once phase result is complete, check for player with no health/mana
        //increment turn number, message players
	}
}

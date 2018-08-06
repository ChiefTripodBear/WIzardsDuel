using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonActions : MonoBehaviour
{
    public GameManager gm;



	// Update is called once per frame
	void Update ()
    {
        gm = FindObjectOfType<GameManager>();
	}

    void NextPhase()
    { //pressing button to commence next spell phase
        if (gm.activePhase == GameManager.Phase.cast1)
        {
            gm.activePhase = GameManager.Phase.peek;
        }
        else if (gm.activePhase == GameManager.Phase.peek)
        {
            gm.activePhase = GameManager.Phase.cast2;
        }
        else if (gm.activePhase == GameManager.Phase.cast2)
        {
            gm.activePhase = GameManager.Phase.result;
        }
        else if (gm.activePhase == GameManager.Phase.result)
        {
            gm.activePhase = GameManager.Phase.cast1;
        }

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class phaseManager : MonoBehaviour
{
    public bool playerPhase = true;

    enemyControl ec;

    // Start is called before the first frame update
    void Start()
    {
        ec = GetComponent<enemyControl>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Called by the player's torch
    public void ChangePhase()
    {
        playerPhase = !playerPhase;
    }

    //These two next voids only account for the enemies
    public void FlickerOn()
    {
        foreach (GameObject enemy in ec.enemies)
        {
            if (enemy.GetComponent<enemyEyeFlicker>() != null)
            {
                enemy.GetComponent<enemyEyeFlicker>().light.intensity = 10f;
            }
            //enemy.GetComponent<targeterEyeAttack>().TurnOn();
        }
    }

    public void FlickerOff()
    {
        foreach (GameObject enemy in ec.enemies)
        {
            if (enemy.GetComponent<enemyEyeFlicker>() != null)
            {
                enemy.GetComponent<enemyEyeFlicker>().light.intensity = 0;
            }
            //enemy.GetComponent<targeterEyeAttack>().TurnOff();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class targeterEyeAttack : MonoBehaviour
{
    LineRenderer lr;

    public Transform eye;

    public GameObject laserEffect;
    public GameObject lineEffect;

    public int damage = 2;
    public float damageTime = 0.1f;

    public Material laserMat;

    phaseManager pm;

    bool canAttack = true;
    bool canAttackPlayer = true;

    // Start is called before the first frame update
    void Start()
    {
        pm = playerManager.instance.pm;

        // for (int i = 0; i <= eyes.Length; i++)
        //{
        //  lrs[i] = transform.GetChild(2).GetChild(i).gameObject.GetComponent<LineRenderer>();
        // lrs[i].SetPosition(0, eyes[i].position);
        //}

        laserEffect = Instantiate(laserEffect, transform.position, Quaternion.identity);
        lineEffect = Instantiate(lineEffect, transform.position, Quaternion.identity);

        laserEffect.SetActive(false);
        lineEffect.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //Sending out the ray from their eyes

        RaycastHit hit;

        if (Physics.Raycast(eye.position, eye.forward, out hit))
        {
            if (canAttack && canAttackPlayer)
            {

                lineEffect.transform.position = eye.transform.position;
                lineEffect.transform.rotation = eye.transform.rotation;
                laserEffect.transform.position = hit.normal;

                Debug.Log("hey");

                //If we've hit the player

                //Debug.Log()
                if (hit.transform.gameObject.layer == 9)
                {
                    Debug.Log("OH COME ONNNNNNN");

                    hit.transform.parent.gameObject.GetComponent<playerHealth>().TakeDamage(damage);
                    canAttackPlayer = false;

                    Invoke("ResetCanAttackPlayer", damageTime);
                }
            }
        }

        if (pm.playerPhase == true)
        {
            canAttack = false;

            lineEffect.SetActive(false);
            laserEffect.SetActive(false);
        }
        else
        {
            canAttack = true;

            lineEffect.SetActive(true);
            laserEffect.SetActive(true);
        }
    }

    //public void TurnOn()
    //{
      //  canAttack = true;
    //}

    //public void TurnOff()
    //{
      //  canAttack = false;
    //}

    void ResetCanAttackPlayer()
    {
        canAttackPlayer = true;
    }

    LineRenderer SetUpLR(LineRenderer lr)
    {
        lr.startWidth = 0.2f;
        lr.endWidth = 0.2f;
        lr.materials[0] = laserMat;

        return lr;
    }
}

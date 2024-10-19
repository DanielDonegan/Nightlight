using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class torchFlicker : MonoBehaviour
{
    Light lt;
    phaseManager pm;

    // Start is called before the first frame update
    void Start()
    {
        lt = transform.GetChild(0).gameObject.GetComponent<Light>();
        if (playerManager.instance.pm != null)
        {
            pm = playerManager.instance.pm;
        }

        int ran = Random.Range(3, 7);
        Invoke("WaitForFlicker", ran);
        //WaitForFlicker();
        Debug.Log("ohhh dear");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void WaitForFlicker()
    {
        Debug.Log("have pm");
        //yield return new WaitForSeconds(ran);

        StartCoroutine("Flicker");
    }

    IEnumerator Flicker()
    {
        Debug.Log("Flickering");

        for (int i = 0; i <= 5; i++)
        {
            yield return new WaitForSeconds(0.1f);

            if (pm != null)
            {
                pm.FlickerOff();
            }
            lt.intensity = 35f;

            yield return new WaitForSeconds(0.1f);

            if (pm != null)
            {
                pm.FlickerOn();
            }
            lt.intensity = 0;
        }

        //Torch is now fully off <-- (so tell the torch damage script the news)
        if (GetComponent<torchDamage>() != null)
        {
            GetComponent<torchDamage>().LightsOff();
        }

        //Changing phase
        if (pm != null)
        {
            pm.ChangePhase();
        }
        

        int ranWait = Random.Range(3, 5);

        //yield return new WaitForSeconds(ranWait);
        Invoke("WaitToTurnBackOn", ranWait);

        StopCoroutine("Flicker");
    }

    void WaitToTurnBackOn()
    {
        if (GetComponent<torchDamage>() != null)
        {
            GetComponent<torchDamage>().LightsOn();
        }
        //Torch is now back on <-- (so tell the DAMAGE SCRIPT!!!)

        if (pm != null)
        {
            pm.FlickerOff();
        }
        lt.intensity = 35f;
        Debug.Log("Turning back on...");

        //Changing phase
        pm.ChangePhase();

        int ran = Random.Range(3, 7);
        Invoke("WaitForFlicker", ran);
    }
}

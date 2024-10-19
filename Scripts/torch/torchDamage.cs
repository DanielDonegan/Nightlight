using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class torchDamage : MonoBehaviour
{
    Light light;

    float lightAngle;
    public float damageTime = 0.1f;
    public float torchDepth = 2f;

    public int torchDam;

    public Transform rayFirePoint;
    Vector3 rayHitSpherePoint = Vector3.zero;

    public enemyControl ec;

    torchFlicker tf;

    GameObject player;
    GameObject currentlyViewedEnemy;

    public LayerMask enemyLayers;
    public LayerMask wallLayers;

    int rayRes = 5;

    bool canDamage = true;
    bool canBurn = true;

    // Start is called before the first frame update
    void Start()
    {
        light = transform.GetChild(0).gameObject.GetComponent<Light>();
        tf = GetComponent<torchFlicker>();
        lightAngle = light.spotAngle;

        player = playerManager.instance.player;
    }

    // Update is called once per frame
    void Update()
    {
        if (canDamage && canBurn)
        {
            foreach (GameObject enemy in ec.enemies)
            {
                currentlyViewedEnemy = enemy;

                Vector3 dir = player.transform.position - enemy.transform.position;

                float angle = Mathf.Atan2(dir.x, dir.z) * Mathf.Rad2Deg + 180;

                if (angle >= (player.transform.rotation.eulerAngles.y) - (lightAngle / 2) && angle <= (player.transform.rotation.eulerAngles.y) + (lightAngle / 2))
                {
                    RaycastHit hit;

                    if (Physics.Raycast(rayFirePoint.position, -dir, out hit, Mathf.Infinity, wallLayers))
                    {
                        float dis1 = Vector3.Distance(transform.position, enemy.transform.position);
                        float dis2 = Vector3.Distance(transform.position, hit.point);

                        rayHitSpherePoint = hit.point;

                        if (dis1 < dis2 && dis1 <= torchDepth)
                        {
                            rayHitSpherePoint = enemy.transform.position;

                            DoDamage();
                        }
                    }
                    else if (Vector3.Distance(transform.position, enemy.transform.position) <= torchDepth)
                    {
                        DoDamage();
                    }
                }
            }
        }

        //Debug.Log(lightAngle);
        
    }

    void DoDamage()
    {
        if (currentlyViewedEnemy.GetComponent<enemyHealth>() != null)
        {
            currentlyViewedEnemy.GetComponent<enemyHealth>().TakeDamage(torchDam);
            canBurn = false;

            Invoke("ResetCanBurn", damageTime);
        }
    }

    void ResetCanBurn()
    {
        canBurn = true;
    }

    //These two next voids are being accesed by brother torchFlicker script
    public void LightsOff()
    {
        canDamage = false;
    }

    public void LightsOn()
    {
        canDamage = true;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(rayHitSpherePoint, 1f);
    }
}

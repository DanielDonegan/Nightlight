using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class targeterAttack : MonoBehaviour
{
    GameObject player;

    playerHealth ph;

    public float killRadius = 2f;

    public int minDamage = 5;
    public int maxDamage = 10;

    bool canDamage = true;

    // Start is called before the first frame update
    void Start()
    {
        player = playerManager.instance.player;
        ph = player.GetComponent<playerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        //Get distance from targeter to player (basic melee damage)
        if (player != null)
        {
            float dist = Vector3.Distance(transform.position, player.transform.position);

            if (dist <= killRadius && canDamage)
            {
                Debug.Log("Kill player");

                int ranDamage = Random.Range(minDamage, maxDamage);

                DamagePlayer(ranDamage);
            }
        }

        //Advanced Eye Damage


    }

    void DamagePlayer(int damage)
    {
        Debug.Log("Damaging player");
        ph.TakeDamage(damage);

        canDamage = false;

        Invoke("ResetCanDamage", 1f); ;
    }

    void ResetCanDamage()
    {
        canDamage = true;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, killRadius);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bomb : MonoBehaviour
{
    public float explodeTime = 2f;
    public float explodeRadius = 1f;

    public int damage = 10;

    public GameObject pEffect;

    enemyControl ec;

    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = playerManager.instance.player;
        ec = playerManager.instance.ec;

        StartCoroutine("Explode");
    }

    // Update is called once per frame
    IEnumerator Explode()
    {

        yield return new WaitForSeconds(explodeTime);

        float distance = Vector3.Distance(transform.position, player.transform.position);

        if (distance <= explodeRadius)
        {
            player.GetComponent<playerHealth>().TakeDamage(damage);
        }

        GameObject effect = Instantiate(pEffect, transform.position, Quaternion.identity);
        Destroy(effect, 2f);

        ec.enemies.Remove(transform.parent.gameObject);
        Destroy(transform.parent.gameObject);

        StopCoroutine("Explode");
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, explodeRadius);
    }
}

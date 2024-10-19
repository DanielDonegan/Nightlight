using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyHealth : MonoBehaviour
{
    public int health;
    public int maxHealth;

    public enemyHealthBar ehb;

    GameObject enemBody;

    Animator animator;

    enemyControl ec;

    // Start is called before the first frame update
    void Start()
    {
        enemBody = transform.GetChild(1).gameObject;
        animator = enemBody.GetComponent<Animator>();
        ec = playerManager.instance.ec;

        health = maxHealth;
        ehb.MaximumHealthIs(health);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        ehb.SetHealthTo(health);

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        animator.SetBool("dead", true);
        //Turning on the particle system
        //enemBody.transform.GetChild(0).gameObject.SetActive(true);

        //Taking the enemy out of the list in ec
        ec.enemies.Remove(gameObject);

        Destroy(gameObject, 1f);
    }
}

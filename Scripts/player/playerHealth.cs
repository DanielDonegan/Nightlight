using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerHealth : MonoBehaviour
{
    public int health;
    public int maxHealth;

    public playerHealthBar phb;
    public Animator deathScreenAnim;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        phb.MaximumHealthIs(health);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        phb.SetHealthTo(health);

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Yo, you deeeeead");

        deathScreenAnim.SetBool("playerDead", true);
        Destroy(gameObject, 1f);
    }
}

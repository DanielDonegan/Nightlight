using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class targeterDeath : MonoBehaviour
{
    //This script is attatched to the targeter's particle system for convenience

    ParticleSystem ps;

    // Start is called before the first frame update
    void Start()
    {
        ps = GetComponent<ParticleSystem>();

        ps.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

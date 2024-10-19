using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyEyeFlicker : MonoBehaviour
{
    public Light light;

    // Start is called before the first frame update
    void Start()
    {
        light = transform.GetChild(0).gameObject.GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

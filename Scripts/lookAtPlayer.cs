using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lookAtPlayer : MonoBehaviour
{
    public Transform player;

    void Update()
    {
        transform.LookAt(Camera.main.gameObject.transform.position);
    }
}

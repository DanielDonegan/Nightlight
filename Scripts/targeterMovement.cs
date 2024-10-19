using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class targeterMovement : MonoBehaviour
{
    GameObject player;

    public float movementLeniency = 2f;

    NavMeshAgent nav;

    // Start is called before the first frame update
    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        player = playerManager.instance.player;
    }

    // Update is called once per frame
    void Update()
    {
        float ranX = Random.Range(-movementLeniency, movementLeniency);
        float ranZ = Random.Range(-movementLeniency, movementLeniency);

        if (player != null)
        {
            Vector3 targetSpot = new Vector3(player.transform.position.x + ranX, transform.position.y, player.transform.position.z + ranZ);

            nav.SetDestination(player.transform.position);
        }
        else
        {
            return;
        }
    }
}

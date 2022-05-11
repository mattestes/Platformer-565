using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayerOnCollision : MonoBehaviour
{
    //public GameObject platfrom;
    public GameObject player;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            player.transform.parent = transform;
            Debug.Log("Entered");
        }
        Debug.Log("some Entered");

    }
    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject == player)
        {
            player.transform.parent = null;
            Debug.Log("Exited");
        }

    }
}

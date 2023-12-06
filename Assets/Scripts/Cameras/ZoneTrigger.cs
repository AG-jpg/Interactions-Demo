using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneTrigger : MonoBehaviour
{
    public GameObject startpoint;
    private Player player;

    private void OnTriggerEnter2D(Collider2D other)
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        player.transform.position = startpoint.transform.position;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneTrigger : MonoBehaviour
{
    public GameObject startpoint;
    private Player player;
    [SerializeField] public GameObject fade;

    private void OnTriggerEnter2D(Collider2D other)
    {
        fade.SetActive(true);
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        player.transform.position = startpoint.transform.position;
        StartCoroutine(Fades());
    }

    private IEnumerator Fades()
    {
        yield return new WaitForSeconds(2f);
        fade.SetActive(false);
    }
}

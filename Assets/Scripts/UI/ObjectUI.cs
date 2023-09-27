using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectUI : MonoBehaviour
{
    [SerializeField] public GameObject UIBox;
    [SerializeField] public GameObject Background;

    private bool interact;
    private bool PanelActive;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            interact = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            interact = false;
            UIBox.SetActive(false);
            Background.SetActive(false);
        }
    }

    private void Update()
    {
        OpenPanel();
    }

    private void OpenPanel()
    {
        if (interact && Input.GetKeyDown(KeyCode.Return))
        {
            UIBox.SetActive(true);
            Background.SetActive(true);
        }
        else if (interact && Input.GetKeyDown(KeyCode.Space))
        {
            UIBox.SetActive(false);
            Background.SetActive(false);
        }
    }
}

using UnityEngine;
using UnityEngine.SceneManagement;

public class Intro : MonoBehaviour
{
    public int sceneID;
    public GameObject Screen01;
    public GameObject Screen02;
    private bool readLine;

    void Start()
    {
        readLine = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) && readLine == false)
        {
            readLine = true;
            Destroy(Screen01);
            SoundManager.Instance.ButtonSound();
            Screen02.SetActive(true);
        }
        else if (Input.GetKeyDown(KeyCode.Return) && readLine == true)
        {
            SoundManager.Instance.ButtonSound();
            SceneManager.LoadScene(sceneID);
        }        
    }
}

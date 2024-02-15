using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public int sceneID;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            SoundManager.Instance.ButtonSound();
            SceneManager.LoadScene(sceneID);
        }
    }

    public void PressButton(int sceneID)
    {
        SoundManager.Instance.ButtonSound();
        SceneManager.LoadScene(sceneID);
    }
}

using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public void PressButton(int sceneID)
    {
        SoundManager.Instance.ButtonSound();
    }
}

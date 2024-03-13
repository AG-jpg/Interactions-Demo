using UnityEngine;

public class Link : MonoBehaviour
{
    public string URL;
    public void Open()
    {
        Application.OpenURL(URL);
    }
}

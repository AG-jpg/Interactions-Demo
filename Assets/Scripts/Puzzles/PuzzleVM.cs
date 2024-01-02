using UnityEngine;
using UnityEngine.SceneManagement;

public class PuzzleVM : MonoBehaviour
{
    public int sceneID;

    //[HideInInspector] 
    public bool puzzleInitiated;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) && puzzleInitiated)
        {
            puzzleInitiated = false;
            SceneManager.LoadScene(sceneID);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        puzzleInitiated = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        puzzleInitiated = false;
    }
}

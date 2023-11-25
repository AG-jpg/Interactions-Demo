using UnityEngine;
using UnityEngine.SceneManagement;

public class PuzzleVM : MonoBehaviour
{
    public int sceneID;
     [HideInInspector] public bool puzzleInitiated;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) && puzzleInitiated == true)
        {
            SceneManager.LoadScene(sceneID);
            puzzleInitiated = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            puzzleInitiated = true;
        }
    }
}

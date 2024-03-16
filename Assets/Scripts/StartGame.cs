using BayatGames.SaveGameFree;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    public void CleanGame()
    {
        SaveGame.DeleteAll(); //Erase Saved Data
    }
}

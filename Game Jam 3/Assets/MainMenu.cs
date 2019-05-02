using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
     public void PlayGame()
     {
        Application.LoadLevelAsync("Level 1");
     }

     public void QuitGame()
     {
         Debug.Log("QUIT!");
         Application.Quit();
     }
}

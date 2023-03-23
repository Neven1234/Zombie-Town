using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuControler : MonoBehaviour
{
   // start game
   public void StartGame()
    {
        SceneManager.LoadScene("shooting");
    }
    public void Option()
    {

    }
    public void Progress()
    {

    }
    public void Exit()
    {
        Application.Quit();
    }
}

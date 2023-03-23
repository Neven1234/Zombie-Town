using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    // Start is called before the first frame update
   public void Setup()
    {
        gameObject.SetActive(true);
    }
    public void Restart()
    {
        SceneManager.LoadScene("shooting");
    }
    public void Menue()
    {
        SceneManager.LoadScene("Menu");
    }
}

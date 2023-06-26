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
    public void RestartL1()
    {
        SceneManager.LoadScene("shooting");
    }
    public void RestartL2()
    {
        SceneManager.LoadScene("shooting L2");
    }
    public void RestartL3()
    {
        SceneManager.LoadScene("shooting L3");
    }
    public void RestartL4()
    {
        SceneManager.LoadScene("shooting L4");
    }
    public void Menue()
    {
        SceneManager.LoadScene("Menu");
    }
}

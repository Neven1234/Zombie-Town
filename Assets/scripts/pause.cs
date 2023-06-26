using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pause : MonoBehaviour
{
    public GameObject pauseMenu;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void pauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }
    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
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

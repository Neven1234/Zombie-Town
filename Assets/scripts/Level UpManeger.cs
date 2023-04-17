using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelUpManeger : MonoBehaviour
{
    // Start is called before the first frame update
    public int levelNum = 2;
    
    public void Setup()
    {
        gameObject.SetActive(true);
    }

    public void NextLevel()
    {

        SceneManager.LoadScene("shooting L"+levelNum.ToString());
        gameObject.SetActive(false);
    }
    public void Menu()
    {
        SceneManager.LoadScene("Menu");
        gameObject.SetActive(false);
    }
    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuControler : MonoBehaviour
{
    // start game
    public GameObject off;
    public static MenuControler menuControler;
    bool flag;
    //public GameObject[] potions;
    private void Awake()
    {
        menuControler = this;
        flag = gameControler.GameControler.on;
        //off.SetActive(flag);
    }
    public void Start()
    {
        //int levelPassed = PlayerPrefs.GetInt("levelPassed",-1);
        //for(int i=0;i<potions.Length;i++)
        //{
        //    if (i >levelPassed)
        //    {
        //        potions[i].SetActive(true);
        //    }
        //    else if (i <= levelPassed)
        //    {
        //        potions[i].SetActive(false);
        //    }

        //}
    }
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

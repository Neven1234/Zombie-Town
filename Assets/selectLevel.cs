using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class selectLevel : MonoBehaviour
{
    int levelIsUnlocked;
    public Button[] level;
    // Start is called before the first frame update
    public void Start()
    {
        levelIsUnlocked = PlayerPrefs.GetInt("LevelUnlock", 1);
        
        for(int i=0;i<level.Length;i++)
        {
            level[i].interactable = false;
        }
        for (int i = 0; i < levelIsUnlocked; i++)
        {
            level[i].interactable = true;
        }
       
    }
    public void levelOneLoad()
    {
        SceneManager.LoadScene("shooting");
    }
    public void levelTowLoad()
    {
        SceneManager.LoadScene("shooting L2");
    }
}

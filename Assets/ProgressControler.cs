using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressControler : MonoBehaviour
{
    int potionCollected;
    
    public GameObject[] potions;
    // Start is called before the first frame update
    void Start()
    {
        potionCollected = PlayerPrefs.GetInt("potionCollected", -1);
        for (int i = 0; i < potionCollected; i++)
        {
            potions[i].SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

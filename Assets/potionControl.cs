using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class potionControl : MonoBehaviour
{
    private Animator moves;
    RaycastHit hit;
    public int nextlevel = 2;
    public int PNumber = 1;
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("LevelUnlock", 2);
        PlayerPrefs.SetInt("potionCollected", PNumber);
        PlayerPrefs.Save();
        moves = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(Rotate());
        //if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        //{
        //    Ray ray = Camera.main.ScreenPointToRay(Input.touches[0].position);
      
        //    if (Physics.Raycast(ray, out hit,Mathf.Infinity))
        //    {
                
        //        //SceneManager.LoadScene("Level Passed");
        //    }
        //}

    }
    IEnumerator Rotate()
    {
        yield return new WaitForSeconds(1.30f);
        moves.SetBool("rotate", true);

    }
}

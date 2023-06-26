using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class potionControl : MonoBehaviour
{
    private Animator moves;
    RaycastHit hit;
    public int nextlevel = 2;
    public int PNumber = 1;
    //public LineRenderer line;
    //public string  player;
    //private GameObject objectToFollow;
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("LevelUnlock", nextlevel);
        PlayerPrefs.SetInt("potionCollected", PNumber);
        PlayerPrefs.Save();
        moves = GetComponent<Animator>();
        //objectToFollow = GameObject.FindGameObjectWithTag(player);
        //line.positionCount = 2;
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(Rotate());
        //line.SetPosition(0,objectToFollow.transform.position);
        //line.SetPosition(1, gameObject.transform.position);


    }
    IEnumerator Rotate()
    {
        yield return new WaitForSeconds(1.30f);
        moves.SetBool("rotate", true);

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class potionControl : MonoBehaviour
{
    private Animator moves;
    // Start is called before the first frame update
    void Start()
    {
        moves = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(Rotate());
    }
    IEnumerator Rotate()
    {
        yield return new WaitForSeconds(1.30f);
        moves.SetBool("rotate", true);

    }
}

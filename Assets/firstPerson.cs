using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class firstPerson : MonoBehaviour
{
    public Transform cmra;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = cmra.position;
    }
}

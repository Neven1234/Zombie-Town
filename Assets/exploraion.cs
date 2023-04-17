using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class exploraion : MonoBehaviour
{

    //public GameObject zombie;
    //public Animator catAnim;
    RaycastHit Hit;
    float wapoRange = 2000;
    private void Start()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "zombie")
        {
            el8abyScribt el8Aby = other.GetComponent<el8abyScribt>();
           
            el8Aby.ZombieDamage(50);
        }
       
        //if (other.tag == "zombie2")
        //{
        //    zombieGded gded = other.GetComponent<zombieGded>();

        //    gded.ZombieDamage(50);
        //}
    }
    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.transform.tag == "zombie")
    //    {
    //        catAnim.SetTrigger("IsDieing");
    //        Destroy(collision.transform.gameObject); // destroy zombie
    //        Instantiate(explosion, collision.transform.position, collision.transform.rotation);



    //    }
    //}
    private void Update()
    {
        if (Physics.Raycast(gameObject.transform.position, gameObject.transform.forward, out Hit, wapoRange))
        {
            if (Hit.transform.tag == "zombie")
            {
                Elzakyscript elzaky = Hit.transform.GetComponent<Elzakyscript>();
                elzaky.ZombieDamage(50);
                Destroy(gameObject);
            }
            else if (Hit.transform.tag == "zombie2")
            {
                zombie2 zombie = Hit.transform.GetComponent<zombie2>();
                zombie.ZombieDamage(50);
                Destroy(gameObject);
            }
        }
    }
    IEnumerator destroy()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }
}

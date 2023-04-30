using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooting : MonoBehaviour
{
    public Transform ARCamera;
    public GameObject projectil;
    public Animator Gun; 
    public float shootForce = 500.0f;
    public ParticleSystem Fighr;
    float wapoRange=2000;
    RaycastHit Hit;

    // Update is called once per frame
    public void shoot()
    {
        
        StartCoroutine(shootSound());
        GameObject bullet = Instantiate(projectil, ARCamera.position, ARCamera.rotation) as GameObject;
        Fighr.Play();
        Gun.SetTrigger("Fire");
        bullet.GetComponent<Rigidbody>().AddForce(ARCamera.forward * shootForce);
    }
    void Update()
    {
        //if(Input.touchCount >0 && Input.GetTouch(0).phase == TouchPhase.Began )
        //{

        //    StartCoroutine(shootSound());
        //    GameObject bullet = Instantiate(projectil, ARCamera.position, ARCamera.rotation) as GameObject;
        //    Gun.SetTrigger("Fire");
        //    bullet.GetComponent<Rigidbody>().AddForce(ARCamera.forward * shootForce);
        //    //if (Physics.Raycast(bullet.transform.position, bullet.transform.forward, out Hit, wapoRange))
        //    //{
        //    //    if (Hit.transform.tag == "zombie")
        //    //    {
        //    //        Elzakyscript el8Aby = Hit.transform.GetComponent<Elzakyscript>();
        //    //        el8Aby.ZombieDamage(50);
        //    //    }
        //    //}

        //}
    }
    IEnumerator shootSound()
    {
        AudioManager.instance.Play("Shoot");
        yield return new WaitForSeconds(0.7f);
        AudioManager.instance.Stop("Shoot");
    }
}

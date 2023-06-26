using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooting : MonoBehaviour
{
    public Transform ARCamera;
    public GameObject projectil;
    public Animator Gun; 
    public float shootForce = 500.0f;
    public string BullitSound;
    public ParticleSystem Fighr;
    float wapoRange=2000;
    RaycastHit Hit;
    ////// try something
    /////
    public float timeBetweenShots;
    public int magazineSize, bulletsPerTap;
    int bulletsLeft, bulletsShot;
    private void Awake()
    {
        bulletsLeft = magazineSize;
    }

        // Update is called once per frame
    public void shoot()
    {
        bulletsShot = bulletsPerTap;
        AudioManager.instance.Play(BullitSound);
        GameObject bullet = Instantiate(projectil, ARCamera.position, ARCamera.rotation) as GameObject;
       Fighr.Play();
       Gun.SetTrigger("Fire");
       bullet.GetComponent<Rigidbody>().AddForce(ARCamera.forward * shootForce);
        /////// new
        bulletsLeft--;
        bulletsShot--;
        if (bulletsShot > 0 && bulletsLeft > 0)
            Invoke("Shoot", timeBetweenShots);
    }
    ///// new
   
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
    //IEnumerator shootSound()
    //{
    //    AudioManager.instance.Play(BullitSound);
    //    yield return new WaitForSeconds(0.7f);
    //    AudioManager.instance.Stop("Shoot");
    //}
}

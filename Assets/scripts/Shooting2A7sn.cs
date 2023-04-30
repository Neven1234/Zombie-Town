using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting2A7sn : MonoBehaviour
{
    public Transform ARCamera;
    public GameObject projectil;
    public Animator Gun;
    public float shootForce = 500.0f;
    public ParticleSystem Fighr;
    float wapoRange = 2000;
    RaycastHit Hit;
    // new system
    public float timeBetweenShooting, reloadTime, timeBetweenShots;
    public int magazineSize, bulletsPerTap;
    int bulletsLeft, bulletsShot;

    bool shooting, readyToShoot, reloading;
    // Update is called once per frame
    private void Awake()
    {
        bulletsLeft = magazineSize;
        readyToShoot = true;
    }
    public void shoot()
    {
        readyToShoot = false;
        StartCoroutine(shootSound());
        GameObject bullet = Instantiate(projectil, ARCamera.position, ARCamera.rotation) as GameObject;
        Fighr.Play();
        Gun.SetTrigger("Fire");
        bullet.GetComponent<Rigidbody>().AddForce(ARCamera.forward * shootForce);
        ///new
        bulletsLeft--;
        bulletsShot--;

        Invoke("ResetShot", timeBetweenShooting);

        if (bulletsShot > 0 && bulletsLeft > 0)
            Invoke("Shoot", timeBetweenShots);
    }
    IEnumerator shootSound()
    {
        AudioManager.instance.Play("Shoot");
        yield return new WaitForSeconds(0.7f);
        AudioManager.instance.Stop("Shoot");
    }
    ///new
    private void ResetShot()
    {
        readyToShoot = true;
    }
}

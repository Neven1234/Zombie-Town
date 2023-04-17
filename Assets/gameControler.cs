using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameControler : MonoBehaviour
{
    
    public static gameControler GameControler;
    public GameObject Gameplay;
    public GameObject PotionBottel;
    private GameObject potionTospawen;
    public GameObject shooting;
    public int DeadZombieNum =4 ;
    public Pose pose;
    public int ZombieType;
    public  int couter = 0;
    public bool on;
    public LevelUpManeger LevelUpManeger;
    // Start is called before the first frame update
    private void Awake()
    {
        GameControler = this;
    }

    // Update is called once per frame
    void Update()
    {
        if(ZombieType==1)
        {
            if (Elzakyscript.signletonn.IsDead == true)
            {
                couter++;
            }
        }
        else if(ZombieType==2)
        {
            if (zombie2.signletonn.IsDead == true)
            {
                couter++;
            }
        }
       
      
       if(couter== DeadZombieNum)
        {
            //pose = placeObjectOnPlane.place.hit[0].pose;
            shooting.SetActive(false);
            AudioManager.instance.Stop("Shoot");
            StartCoroutine(Wait());

        }
    }
    IEnumerator Wait()
    {
        potionTospawen = Instantiate(PotionBottel, new Vector3(pose.position.x, pose.position.y + 1, pose.position.z), pose.rotation);
        yield return new WaitForSeconds(5f);
        LevelUpManeger.Setup();
    }
}

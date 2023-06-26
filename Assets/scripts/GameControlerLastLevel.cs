using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameControlerLastLevel : MonoBehaviour
{
    public Text ZombieNumberKilled;
    public static GameControlerLastLevel LastLevel;
    //public GameObject PoseOfPotion;
    public GameObject Gameplay;
    public GameObject PotionBottel;
    private GameObject potionTospawen;
    public GameObject shooting;
    public int DeadZombieNum = 4;
    public Vector3 gap;
    public Pose pose;
    public int ZombieType;
    public int couter = 0;
    public bool on;
    public LevelUpManeger LevelUpManeger;
    int C = 0;
    // Start is called before the first frame update
    private void Awake()
    {
        LastLevel = this;
    }

    // Update is called once per frame
    void Update()
    {
        ZombieNumberKilled.text = couter.ToString();
        //if (ZombieType == 1)
        //{
        //    if (Elzakyscript.signletonn.IsDead == true)
        //    {
        //        couter++;
        //    }
        //}
        //else if (ZombieType == 2)
        // {
        //     if (zombie2.signletonn.IsDead == true)
        //     {
        //         couter++;
        //     }
        // }


        if (couter == DeadZombieNum && C == 0)
        {
            C++;
            //pose = placeObjectOnPlane.place.hit[0].pose;
            shooting.SetActive(false);
            //AudioManager.instance.Stop("Shoot");
            StartCoroutine(Wait());

        }
    }
    IEnumerator Wait()
    {
        //pose.position = PoseOfPotion.transform.position+gap;
        //pose.rotation = PoseOfPotion.transform.rotation;
        potionTospawen = Instantiate(PotionBottel, new Vector3(pose.position.x, pose.position.y + 1, pose.position.z), pose.rotation);
        yield return new WaitForSeconds(5f);
        LevelUpManeger.Setup();
    }
}

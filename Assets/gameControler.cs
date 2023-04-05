using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameControler : MonoBehaviour
{
    
    public static gameControler GameControler;
    public GameObject PotionBottel;
    private GameObject potionTospawen;
    public Pose pose;
    public  int couter = 0;
    // Start is called before the first frame update
    private void Awake()
    {
        GameControler = this;
    }

    // Update is called once per frame
    void Update()
    {
        if(Elzakyscript.signletonn.IsDead==true)
        {
            couter++;
        }
      
       if(couter==5)
        {
            //pose = placeObjectOnPlane.place.hit[0].pose;
            potionTospawen = Instantiate(PotionBottel,new Vector3( pose.position.x,pose.position.y+1,pose.position.z),pose.rotation);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ARRplacemnt : MonoBehaviour
{
    public GameObject ObjectToSpawn;
    public GameObject placementIndecator;
    public GameObject shoot;
    public GameObject startButton;
    private GameObject spawenedOpject;
    private Pose placementPose;
    private ARRaycastManager ARRaycastManager;
    private bool placementValide = false;
    int ZombeiCount = 0;
    float zpos;
    float xpos;

    // Start is called before the first frame update
    void Start()
    {
        ARRaycastManager = FindObjectOfType<ARRaycastManager>();
        shoot.SetActive(false);

    }

    // Update is called once per frame
   public void Update()
    {
        if(spawenedOpject==null && placementValide && Input.touchCount>0 && Input.GetTouch(0).phase==TouchPhase.Began)
        {
            startButton.SetActive(false);
            StartCoroutine(ARPlaceObject());
            shoot.SetActive(true);
        }
        updatePlacementPosetion();
        updatePlacementIndecator();
    }
    void updatePlacementPosetion()
    {
        //var screen = Camera.current.ViewportToScreenPoint(new Vector3(0.5f, 0.5f));
        var hits = new List<ARRaycastHit>();
        ARRaycastManager.Raycast(new Vector2(Screen.width / 2, Screen.height / 2), hits, TrackableType.Planes);
        placementValide = hits.Count > 0;
        if(placementValide)
        {
            placementPose = hits[0].pose;
        }

    }
    void updatePlacementIndecator()
    {
        if(spawenedOpject==null && placementValide)
        {
            placementIndecator.SetActive(true);
            placementIndecator.transform.SetPositionAndRotation(placementPose.position, placementPose.rotation);
        }
        else
        {
            placementIndecator.SetActive(false);
        }
    }
    
   IEnumerator ARPlaceObject()
    {
        while(ZombeiCount<5)
        {
            xpos = Random.Range(placementPose.position.x-1, placementPose.position.x + 2);
            zpos = Random.Range(placementPose.position.z, placementPose.position.z + 4);
            spawenedOpject = Instantiate(ObjectToSpawn, new Vector3(xpos, placementPose.position.y, zpos), placementPose.rotation);
            yield return new WaitForSeconds(5f);
            ZombeiCount += 1;
        }
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class placeObjectOnPlane : MonoBehaviour
{
    // Start is called before the first frame update
    private ARPlaneManager arplanemanger;
    private ARRaycastManager raycastManager;
    public List<ARRaycastHit> hit = new List<ARRaycastHit>();
    public GameObject placeObject;
   
    public GameObject shoot;
    public GameObject startButton;
    public GameObject plane;
    public int FirstZombienumbers=5;
   // public GameObject anotherZombie;
    public static placeObjectOnPlane place;
    private GameObject spawenedOpject;
    
    private Pose placementPose;
    private bool placementValide = false;
    int Zombei1Count = 0;
    float zpos;
    float xpos;
    bool IsPlna = false;
    private void Awake()
    {
        place = this;
        raycastManager = GetComponent<ARRaycastManager>();
        arplanemanger = GetComponent<ARPlaneManager>();
    }
    void Start()
    {
        shoot.SetActive(false);
    }

    // Update is called once per frame
    public void Update()
    {
        if (!placementValide)
        {
            updatePlacementPosetion();
        }
        else if (spawenedOpject == null && placementValide && Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            startButton.SetActive(false);
            plane.SetActive(false);
            StartCoroutine(ARPlaceObject());
            shoot.SetActive(true);
        }
        
    }
    // new
    void updatePlacementPosetion()
    {
        //var screen = Camera.current.ViewportToScreenPoint(new Vector3(0.5f, 0.5f));
       
        raycastManager.Raycast(new Vector2(Screen.width / 2, Screen.height / 2), hit, TrackableType.Planes);
        placementValide = hit.Count > 0;
        if (placementValide)
        {
            startButton.SetActive(true);
            placementPose = hit[0].pose;
        }

    }
    IEnumerator ARPlaceObject()
    {
        while (Zombei1Count < FirstZombienumbers)
        {
            xpos = Random.Range(placementPose.position.x - 1, placementPose.position.x + 2);
            zpos = Random.Range(placementPose.position.z, placementPose.position.z + 4);

            AudioManager.instance.Play("ZombiWalk");
            spawenedOpject = Instantiate(placeObject, new Vector3(xpos, placementPose.position.y, zpos), placementPose.rotation);
            
            yield return new WaitForSeconds(5.0f);
            Zombei1Count += 1;

        }

    }
    //public void PlaceObject()
    //{
    //    Touch touch = Input.GetTouch(0);
    //    if (touch.phase == TouchPhase.Began && !IsPosisionOverUiObject())
    //    {
    //        if (raycastManager.Raycast(new Vector2(Screen.width / 2, Screen.height / 2), hit, TrackableType.Planes))
    //        {
    //            Pose hitPos = hit[0].pose;
    //            //xpos = Random.Range(hitPos.position.x, hitPos.position.x + 15);
    //           // zpos = Random.Range(hitPos.position.z, hitPos.position.z + 15);
    //            Instantiate(placeObject, hitPos.position, hitPos.rotation);
    //        }
    //    }


    //}
    //private bool IsPosisionOverUiObject()
    //{
    //    PointerEventData eventDataCurrenPosision = new PointerEventData(EventSystem.current);
    //    eventDataCurrenPosision.position = new Vector2(Input.GetTouch(0).position.x, Input.GetTouch(0).position.y);
    //    List<RaycastResult> results = new List<RaycastResult>();
    //    EventSystem.current.RaycastAll(eventDataCurrenPosision, results);
    //    return results.Count > 0;
    //}
}

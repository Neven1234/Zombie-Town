using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class place : MonoBehaviour
{
    public ARPlaneManager aRPlaneManager;
    public Material occluion, planMat;
    public GameObject planPrefab;
   public void setOcclutionMatrial()
    {
        planPrefab.GetComponent<Renderer>().material = occluion;
        foreach(var plane in aRPlaneManager.trackables)
        {
            plane.GetComponent<Renderer>().material = occluion;
        }
    }
    public void setPlaneMatrial()
    {
        planPrefab.GetComponent<Renderer>().material = planMat;
        foreach (var plane in aRPlaneManager.trackables)
        {
            plane.GetComponent<Renderer>().material = planMat;
        }
    }
}

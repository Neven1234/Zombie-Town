using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShootButtonControl : MonoBehaviour
{
    public Button Shoot;
    public float Time;
    public void TimeInBetween()
    {
        StartCoroutine(Break());
    }
    IEnumerator Break()
    {
        Shoot.interactable = false;
        yield return new WaitForSeconds(Time);
        Shoot.interactable = true;

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeBetweenShootd : MonoBehaviour
{
    public Button ShootinButton;
    public float TimeBetweenShooting;
    public void breaking()
    {
        StartCoroutine(Break());
    }
    IEnumerator Break()
    {
        ShootinButton.interactable = false;
        yield return new WaitForSeconds(TimeBetweenShooting);
        ShootinButton.interactable = true;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BigZombieHealth : MonoBehaviour
{
    public static BigZombieHealth health;
    public Slider Health;
   // public Text HealthCount;
    public float currentHealthe;
    public float MaxHealth = 1000;
    // Start is called before the first frame update
    private void Awake()
    {
        health = this;
    }
    void Start()
    {
        currentHealthe = MaxHealth;
        UpdateHealthCounter();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateHealthCounter();
    }
    void UpdateHealthCounter()
    {
        Health.value = currentHealthe;
    }
}

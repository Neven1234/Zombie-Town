using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    // Start is called before the first frame update
    public static PlayerHealth signleton;
    public Slider Health;
    public Text HealthCount;
    private float currentHealthe;
    private float MaxHealth = 100;
    private bool IsDead = false;
    public GameObject bloood;
    public GameObject shooting;
    bool isAttacking;
    public GameOverScreen GameOverScreen;

    private void Awake()
    {
        signleton = this;
    }
    void Start()
    {
        
        currentHealthe = MaxHealth;
        //Health.value = MaxHealth;
        UpdateHealthCounter();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlayerDamage(float damage)
    {
        if(currentHealthe>0)
        {
            if(damage== currentHealthe)
            {
                StartCoroutine(BlooD());
                
                isAttacking = true;
                Dead();
                shooting.SetActive(false);
                GameOverScreen.Setup();
            }
            else
            {
                StartCoroutine(BlooD());
                isAttacking = true;
                currentHealthe -= damage;
                //Health.value -= damage;

            }
            UpdateHealthCounter();
        }
    }
    void Dead()
    {
        AudioManager.instance.Stop("Shoot");

        currentHealthe = 0;
        UpdateHealthCounter();
        //Health.value = 0;
        IsDead = true;
        
    }
    void UpdateHealthCounter()
    {
        Health.value = currentHealthe;
        HealthCount.text = currentHealthe.ToString();
    }
     IEnumerator BlooD()
    {
        bloood.SetActive(true);
        yield return new WaitForSeconds(0.7f);
        bloood.SetActive(false);

    }
}

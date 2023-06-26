using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BigZombie : MonoBehaviour
{
    
    public string gameObjectTag;
    public static BigZombie signletonn;
    private Animator MonsterAnim;
    private GameObject objectToFollow;
    public float speed = 2f;
    public float stoppingDistance = 1f;
    public bool CanAttack = true;
    public int zombieDamage = 25;

    ////health
    //public Slider Health;
   // public Text HealthCount;
    private float currentHealthe;
    private float MaxHealth = 1000;
    public bool IsDead = false;
    public bool IsFired = true;
    bool flag = true;
    public int NumberOfZombie = 6;
    bool DeadOnce = false;
    /// Group of Zombie
    public GameObject GroupOfZombie;
    private GameObject SpownZombies;
    bool Starting=true;
    // Start is called before the first frame update
    private void Awake()
    {
        signletonn = this;
    }
    void Start()
    {
        objectToFollow = GameObject.FindGameObjectWithTag(gameObjectTag);
        MonsterAnim=GetComponent<Animator>();
        currentHealthe = MaxHealth;
        updateSlaider();
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.LookAt(objectToFollow.transform);
        if (objectToFollow != null)
        {
            gameControler.GameControler.pose.position = gameObject.transform.position;
            gameControler.GameControler.pose.rotation = gameObject.transform.rotation;
            if (gameControler.GameControler.couter==4 || Starting)
            {
                StartCoroutine(SpownZombie());
                Starting=false;
                gameControler.GameControler.couter = 0;
            }
            
            if (IsDead)
            {               
                StartCoroutine(Dead());
            }
            

        }
        else
        {
            Debug.Log("no object");
        }
    }
    
    
    public void ZombieBossDamage(float damage)
    {

        if (currentHealthe > 0)
        {
            if (damage >= currentHealthe)
            {
                
                IsFired = true;
                IsDead = true;
                currentHealthe -= damage;
                if (DeadOnce == false)
                {
                    gameControler.GameControler.BigDied++;
                    DeadOnce = true;
                }
                AudioManager.instance.Play("Die");
                CanAttack = false;
                flag = false;
                updateSlaider();

            }
            else
            {
                IsFired = true;
                currentHealthe -= damage;               
            }
            updateSlaider();
        }
    }
    IEnumerator Dead()

    {
        yield return new WaitForSeconds(0.5f);
        updateSlaider();
        Destroy(gameObject);
        Destroy(SpownZombies);
    }
    IEnumerator SpownZombie()
    {
        AudioManager.instance.Play("MonsterRoor");
        MonsterAnim.SetBool("Roor", true);
        SpownZombies = Instantiate(GroupOfZombie, gameObject.transform.position, gameObject.transform.rotation);
        yield return new WaitForSeconds(10.0f);
        //MonsterAnim.SetBool("Roor", false);

    }
    void updateSlaider()
    {
        BigZombieHealth.health.currentHealthe = currentHealthe;
    }
}

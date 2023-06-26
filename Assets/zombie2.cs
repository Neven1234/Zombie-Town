using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class zombie2 : MonoBehaviour
{

    NavMeshAgent agent;
    public string gameObjectTag;
    public static zombie2 signletonn;
    public Slider slider;
    float zpos;
    float xpos;
    bool canDis = true;
    //public SphereCollider bullit;
    private GameObject objectToFollow;
    public float speed = 2f;
    public float stoppingDistance = 1f;
    public bool CanAttack = true;
    public int zombieDamage = 25;
    private Animator zombieAnim;
    ////health
    private float currentHealthe;
    public float MaxHealth = 500;
    public float DisappearingHe = 300;
    public bool IsDead = false;
    public bool IsFired = true;
    bool flag = true;
    public int NumberOfZombie = 6;
    bool DeadOnce = false;
    // Start is called before the first frame update
    private void Awake()
    {
        signletonn = this;
    }
    void Start()
    {
        objectToFollow = GameObject.FindGameObjectWithTag(gameObjectTag);
        zombieAnim = GetComponent<Animator>();
        currentHealthe = MaxHealth;
        agent = gameObject.GetComponent<NavMeshAgent>();
        updatSlider();
    }

    // Update is called once per frame
    void Update()
    {
        if (objectToFollow != null)
        {
            updatSlider();
            float disrance = Vector3.Distance(transform.position, objectToFollow.transform.position);
            if (disrance >= stoppingDistance)
            {
                zombieAnim.SetBool("Attack", false);
                agent.SetDestination(objectToFollow.transform.position);
                if(canDis==true && currentHealthe== DisappearingHe)
                {
                    Disappear();

                }
            }
            else if (CanAttack)
            {
                Attack();
            }

            if (IsDead)
            {
                if (gameControler.GameControler.couter == NumberOfZombie)
                {
                    gameControler.GameControler.pose.position = gameObject.transform.position;
                    gameControler.GameControler.pose.rotation = gameObject.transform.rotation;
                }
                StartCoroutine(Dead());
            }
            

        }
        else
        {
            Debug.Log("no object");
        }
        
    }
    private void Attack()
    {
        zombieAnim.SetBool("Attack", true);
        AudioManager.instance.Play("ZombieDie");
        StartCoroutine(AttackTime());
    }
    IEnumerator AttackTime()
    {
        if (flag)
        {
            CanAttack = false;
            yield return new WaitForSeconds(0.5f);
            PlayerHealth.signleton.PlayerDamageZ2(zombieDamage);
            if (canDis == true && currentHealthe == DisappearingHe)
            {
                Disappear();

            }
            yield return new WaitForSeconds(2);
            CanAttack = true;
        }

    }
    public void ZombieDamage(float damage)
    {

        if (currentHealthe > 0)
        {
            if (damage >= currentHealthe)
            {
                currentHealthe -= damage;
                IsFired = true;
                IsDead = true;
                if (DeadOnce == false)
                {
                    gameControler.GameControler.couter++;
                    DeadOnce = true;
                }
                AudioManager.instance.Play("Die");
                CanAttack = false;
                flag = false;
                updatSlider();
            }
            else
            {
                IsFired = true;
                currentHealthe -= damage;
                updatSlider();
            }

        }
    }
    IEnumerator Dead()

    {
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }
    public void Disappear()
    {
        List<float> poses = new List<float>();
        poses.Add(gameObject.transform.position.x -6);
        poses.Add(gameObject.transform.position.x +6);
        int index = Random.Range(0,poses.Count);

        canDis = false;
       // xpos = Random.Range(gameObject.transform.position.x - 20, gameObject.transform.position.x -10);
        zpos = Random.Range(gameObject.transform.position.z, gameObject.transform.position.z + 10);
        gameObject.transform.position = new Vector3(poses[index], gameObject.transform.position.y, zpos);
    }
    public void updatSlider()
    {
        slider.value = currentHealthe;
    }
}

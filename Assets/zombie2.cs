using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class zombie2 : MonoBehaviour
{

    NavMeshAgent agent;
    public string gameObjectTag;
    public static zombie2 signletonn;
    //public SphereCollider bullit;
    private GameObject objectToFollow;
    public float speed = 2f;
    public float stoppingDistance = 1f;
    public bool CanAttack = true;
    public int zombieDamage = 25;

    ////health
    private float currentHealthe;
    private float MaxHealth = 150;
    public bool IsDead = false;
    public bool IsFired = true;
    bool flag = true;
    public int NumberOfZombie = 8;
    // Start is called before the first frame update
    private void Awake()
    {
        signletonn = this;
    }
    void Start()
    {
        objectToFollow = GameObject.FindGameObjectWithTag(gameObjectTag);

        currentHealthe = MaxHealth;
        agent = gameObject.GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (objectToFollow != null)
        {

            float disrance = Vector3.Distance(transform.position, objectToFollow.transform.position);
            if (disrance > stoppingDistance)
            {
                agent.SetDestination(objectToFollow.transform.position);

            }
            else if (CanAttack)
            {
                Attack();
            }

            if (IsDead)
            {

                StartCoroutine(Dead());
            }
            if (gameControler.GameControler.couter == NumberOfZombie )
            {
                gameControler.GameControler.pose.position = gameObject.transform.position;
                gameControler.GameControler.pose.rotation = gameObject.transform.rotation;
            }

        }
        else
        {
            Debug.Log("no object");
        }
    }
    private void Attack()
    {
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
            yield return new WaitForSeconds(2);
            CanAttack = true;
        }

    }
    public void ZombieDamage(float damage)
    {

        if (currentHealthe > 0)
        {
            if (damage == currentHealthe)
            {

                IsFired = true;
                IsDead = true;
                AudioManager.instance.Play("Die");
                CanAttack = false;
                flag = false;

            }
            else
            {
                IsFired = true;
                currentHealthe -= damage;

            }

        }
    }
    IEnumerator Dead()

    {
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }
}

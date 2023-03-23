using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Elzakyscript : MonoBehaviour
{
	NavMeshAgent agent;
	public string gameObjectTag;
	public static Elzakyscript signletonn;
	//public SphereCollider bullit;
	private GameObject objectToFollow;
	public float speed = 2f;
	public float stoppingDistance = 1f;
	private Animator zombieAnim;
	public bool CanAttack = true;

    ////health
    private float currentHealthe;
    private float MaxHealth = 100;
    private bool IsDead = false;
    public bool IsFired = true;
    bool flag = true;

    private void Awake()
	{
		signletonn = this;
	}
	// Use this for initialization
	void Start()
	{

		objectToFollow = GameObject.FindGameObjectWithTag(gameObjectTag);
		zombieAnim = GetComponent<Animator>();
		currentHealthe = MaxHealth;
		agent = gameObject.GetComponent<NavMeshAgent>();
		StartCoroutine(Wait());


	}
	IEnumerator Wait()
	{
		zombieAnim.SetBool("Ideal", true);
		yield return new WaitForSeconds(0.7f);
	}
	// Update is called once per frame
	void Update()
	{



		if (objectToFollow != null)
		{

			float disrance = Vector3.Distance(transform.position, objectToFollow.transform.position);
			if (disrance > stoppingDistance)
			{
				StartCoroutine(Wait());
				zombieAnim.SetBool("IsWalking", true);
				agent.SetDestination(objectToFollow.transform.position);

			}
			else if (CanAttack)
			{
				
				Attack();

			}

		    if (IsDead)
			{
				AudioManager.instance.Play("Die");
				AudioManager.instance.Stop("ZombiWalk");

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
		zombieAnim.SetBool("IsAttacking", true);
		AudioManager.instance.Play("ZombieDie");
		StartCoroutine(AttackTime());
	}
		IEnumerator AttackTime()
	   {
		if (flag)
		{
			CanAttack = false;
			yield return new WaitForSeconds(0.5f);
			PlayerHealth.signleton.PlayerDamage(25);
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
		zombieAnim.SetTrigger("IsDieing");
		yield return new WaitForSeconds(3);
		Destroy(gameObject);
	}

}

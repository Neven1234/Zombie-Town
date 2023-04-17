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
	public int zombieDamage = 25;
	placeObjectOnPlane placeObjectOnPlane;
    ////health
    private float currentHealthe;
    private float MaxHealth = 100;
    public bool IsDead = false;
    public bool IsFired = true;
    bool flag = true;
	public int NumberOfZombie = 4;
	/// potion placed

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

	}
	
	// Update is called once per frame
	void Update()
	{



		if (objectToFollow != null)
		{

			float disrance = Vector3.Distance(transform.position, objectToFollow.transform.position);
			if (disrance > stoppingDistance)
			{
				zombieAnim.SetBool("IsWalking", true);
				zombieAnim.SetBool("IsAttacking", false);
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
			if(gameControler.GameControler.couter==NumberOfZombie)
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
		zombieAnim.SetBool("IsAttacking", true);
		zombieAnim.SetBool("IsWalking", false);
		AudioManager.instance.Play("ZombieDie");
		StartCoroutine(AttackTime());
	}
	IEnumerator AttackTime()
	{
		if (flag)
		{
			CanAttack = false;
			yield return new WaitForSeconds(0.5f);
			PlayerHealth.signleton.PlayerDamage(zombieDamage);
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
		zombieAnim.SetTrigger("IsDieing");
		yield return new WaitForSeconds(1.5f);
		Destroy(gameObject);
	}

}

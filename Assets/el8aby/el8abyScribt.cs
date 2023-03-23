using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class el8abyScribt : MonoBehaviour
{
	public string gameObjectTag;
	public static el8abyScribt signletonn;
	//public SphereCollider bullit;
	private GameObject objectToFollow;
	public float speed = 2f;
	public float stoppingDistance = 1f;
	private Animator catAnim;
	public bool CanAttack = true;

	//health
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
	void Start () {
		objectToFollow = GameObject.FindGameObjectWithTag (gameObjectTag);
		catAnim = GetComponent<Animator>();
		currentHealthe = MaxHealth;
		
	}
	
	// Update is called once per frame
	void Update () {



		if (objectToFollow != null) {

			float disrance = Vector3.Distance(transform.position, objectToFollow.transform.position);
			if (disrance > stoppingDistance) {
				catAnim.SetBool("IsWalking", true);
				Vector3 tempPos = objectToFollow.transform.position;
				tempPos.y = 0;
				transform.position = Vector3.MoveTowards (transform.position, tempPos, speed * Time.deltaTime);

				var lookPos = objectToFollow.transform.position - transform.position;
				lookPos.y = 0;
				var rotation = Quaternion.LookRotation (lookPos);
				transform.rotation = Quaternion.Slerp (transform.rotation, rotation, Time.deltaTime * 10f);

			} else if(CanAttack ) {
				Attack();
			}
			else if (IsDead)
            {

				//catAnim.SetBool("IsDieing", true);
				//Destroy(gameObject);
				StartCoroutine(Dead());

			}
			
		}
        else
        {
			Debug.Log("no object");
        }
	}
	//private void OnCollisionEnter(Collision collision)
	//{
	//	if (collision.transform.tag == "bullit")
	//	{
	//		catAnim.SetBool("IsDieing", true);
	//		catAnim.SetBool("IsWalking", false);
	//		catAnim.SetBool("isAttacking", false);

	//		//Destroy(collision.transform.gameObject); // destroy zombie
	//		//Instantiate(explosion, collision.transform.position, collision.transform.rotation);
	//	}
	//}
	private void Attack()
    {
		catAnim.SetBool("isAttacking", true);
		catAnim.SetBool("IsWalking", false);
		StartCoroutine(AttackTime());
		//catAnim.SetBool("IsDieing", true)
	}
	IEnumerator AttackTime()
    {
		if(flag)
        {
			CanAttack = false;
			yield return new WaitForSeconds(0.5f);
			PlayerHealth.signleton.PlayerDamage(25);
			yield return new WaitForSeconds(2);
			CanAttack = true;
		}
		
	}
	///zombie health
	
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
		catAnim.SetBool("IsDieing", true);
		catAnim.SetBool("isAttacking", false);
		catAnim.SetBool("IsWalking", false);
		yield return new WaitForSeconds(3);
		Destroy(gameObject);
	}
    
}

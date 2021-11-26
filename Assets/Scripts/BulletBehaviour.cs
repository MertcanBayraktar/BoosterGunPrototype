using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
	private string nameTag = "";
	[SerializeField] private Vector3 parent;
	[SerializeField] private GameObject go;
	public Collider[] hitColliders;
	bool hit = false;

	private void Start()
	{	
		parent = this.transform.position;
	}
	private void OnCollisionEnter(Collision collision)
	{
		switch (collision.transform.tag)
		{
			case "Bomb":
				hitColliders = Physics.OverlapSphere(collision.transform.position, 6f);
				foreach (var item in hitColliders)
				{
					if (item.gameObject.tag == "Enemy")
					{
						item.GetComponent<Animator>().enabled = false;
						item.GetComponent<enemyMove>().enabled = false;
					}
				}
				EventManager.instance.MovePlayerToNextDestination();
				break;
			case "PlayerJoint":
				collision.transform.gameObject.GetComponentInParent<Animator>().SetBool("hit", true);
				EventManager.instance.TurnOnRagDollState(collision.transform.gameObject.GetComponentInParent<RagdollController>().id);
				go = collision.gameObject;				
				hit = true;
				nameTag = "PlayerJoint";
				break;
			case "PlayerJointHead":
				EventManager.instance.OnHeadshot();
				collision.transform.gameObject.GetComponentInParent<Animator>().SetBool("hit", true);
				EventManager.instance.TurnOnRagDollState(collision.transform.gameObject.GetComponentInParent<RagdollController>().id);
				go = collision.gameObject;
				hit = true;
				nameTag = "PlayerJointHead";
				break;
			case "PlayerJointLeftArm":
				collision.transform.gameObject.GetComponentInParent<Animator>().SetBool("hit", true);
				EventManager.instance.TurnOnRagDollState(collision.transform.gameObject.GetComponentInParent<RagdollController>().id);
				go = collision.gameObject;
				hit = true;
				nameTag = "PlayerJointLeftArm";
				break;
			case "PlayerJointLeftLeg":
				collision.transform.gameObject.GetComponentInParent<Animator>().SetBool("hit", true);
				EventManager.instance.TurnOnRagDollState(collision.transform.gameObject.GetComponentInParent<RagdollController>().id);
				go = collision.gameObject;
				hit = true;
				nameTag = "PlayerJointLeftLeg";
				break;
			case "PlayerJointRightArm":
				collision.transform.gameObject.GetComponentInParent<Animator>().SetBool("hit", true);
				EventManager.instance.TurnOnRagDollState(collision.transform.gameObject.GetComponentInParent<RagdollController>().id);
				go = collision.gameObject;
				hit = true;
				nameTag = "PlayerJointRightArm";
				break;
			case "PlayerJointRightLeg":
				collision.transform.gameObject.GetComponentInParent<Animator>().SetBool("hit", true);
				EventManager.instance.TurnOnRagDollState(collision.transform.gameObject.GetComponentInParent<RagdollController>().id);
				go = collision.gameObject;
				hit = true;
				nameTag = "PlayerJointRightLeg";
				break;
		}

	}
	private void Update()
	{
		if (hit)
		{
			switch (nameTag)
			{
				case "PlayerJoint":
					go.GetComponent<Rigidbody>().velocity = Vector3.up *10;
					go.GetComponent<Rigidbody>().velocity = new Vector3(go.GetComponent<Rigidbody>().velocity.x, go.GetComponent<Rigidbody>().velocity.y + 0.1f, go.GetComponent<Rigidbody>().velocity.z);
					break;
				case "PlayerJointHead":					
					go.GetComponent<Rigidbody>().velocity = Vector3.up * 10;
					go.GetComponent<Rigidbody>().velocity = new Vector3(go.GetComponent<Rigidbody>().velocity.x, go.GetComponent<Rigidbody>().velocity.y + 0.1f, go.GetComponent<Rigidbody>().velocity.z);
					break;
				case "PlayerJointLeftArm":
					go.GetComponent<Rigidbody>().velocity = Vector3.left * 12;
					go.GetComponent<Rigidbody>().velocity = new Vector3(go.GetComponent<Rigidbody>().velocity.x + 0.13f, go.GetComponent<Rigidbody>().velocity.y + 0.18f, go.GetComponent<Rigidbody>().velocity.z);

					break;
				case "PlayerJointLeftLeg":
					go.GetComponent<Rigidbody>().velocity = new Vector3(go.GetComponent<Rigidbody>().velocity.x + 0.13f, go.GetComponent<Rigidbody>().velocity.y + 0.18f, go.GetComponent<Rigidbody>().velocity.z);

					break;
				case "PlayerJointRightArm":
					go.GetComponent<Rigidbody>().velocity = Vector3.right * 12;
					go.GetComponent<Rigidbody>().velocity = new Vector3(go.GetComponent<Rigidbody>().velocity.x - 0.13f, go.GetComponent<Rigidbody>().velocity.y + 0.18f, go.GetComponent<Rigidbody>().velocity.z);

					break;
				case "PlayerJointRightLeg":
					go.GetComponent<Rigidbody>().velocity = new Vector3(go.GetComponent<Rigidbody>().velocity.x - 0.13f, go.GetComponent<Rigidbody>().velocity.y + 0.18f, go.GetComponent<Rigidbody>().velocity.z);
					break;
			}
		}
	}
	private void OnEnable()
	{
		StartCoroutine(SelfDeactive());
	}
	IEnumerator SelfDeactive()
	{
		yield return new WaitForSeconds(7.5f);
		this.gameObject.SetActive(false);
		this.transform.position = parent;
	}	
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagdollController : MonoBehaviour
{
	public int id;
	public List<Collider> RagdollPartsCollider = new List<Collider>();
	public List<Rigidbody> RagdollPartsRigidbody = new List<Rigidbody>();
	public Animator animator;
	public BoxCollider bCollider;
	private void Start()
	{
		SetRagDollParts();
		SetCollidersEnabled(enabled);
		EventManager.instance.turnOnRagdollState += ActivateRagDoll;
	}
	public void SetRagDollParts()
	{
		Collider[] colliders = this.gameObject.GetComponentsInChildren<Collider>();
		Rigidbody[] rigidbodies = this.gameObject.GetComponentsInChildren<Rigidbody>();
		foreach (Rigidbody rb in rigidbodies)
		{
			if (rb.gameObject != this.gameObject)
			{
				RagdollPartsRigidbody.Add(rb);
			}
		}
		foreach (Collider c in colliders)
		{
			if (c.gameObject != this.gameObject)
			{
				RagdollPartsCollider.Add(c);
			}
		}

	}
	private void SetCollidersEnabled(bool enabled)
	{
		foreach (Collider col in RagdollPartsCollider)
		{
			col.enabled = enabled;
		}
	}
	private void SetRigidbodiesKinematic(bool kinematic)
	{
		foreach (Rigidbody rb in RagdollPartsRigidbody)
		{
			rb.isKinematic = kinematic;
		}
	}
	public void ActivateRagDoll(int id)
	{
		if (id == this.id)
		{
			bCollider.enabled = false;
			animator.enabled = false;
			SetCollidersEnabled(true);
			SetRigidbodiesKinematic(false);
		}
	}
	IEnumerator WaitforXSecond(float x)
	{
		yield return new WaitForSeconds(x);
	}
}

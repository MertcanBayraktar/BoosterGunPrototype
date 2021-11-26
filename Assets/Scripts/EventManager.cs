using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
	#region Singleton
	public static EventManager instance;
	private void Awake()
	{
		if(instance != null)
		{
			Destroy(this);
		}
		else
		{
			instance = this;
		}
	}
	#endregion
	public Action movePlayerToNextDestination;
	public Action<bool> canShoot;
	public Action<int> turnOnRagdollState;
	public Action onHeadshot;
	public void OnHeadshot()
	{
		if(onHeadshot != null)
		{
			onHeadshot();
		}
	}
	public void CanShoot(bool canFire)
	{
		if(canShoot != null)
		{
			canShoot(canFire);
		}
	}
	public void MovePlayerToNextDestination()
	{
		if(movePlayerToNextDestination != null)
		{			
			movePlayerToNextDestination();
		}
	}
	public void TurnOnRagDollState(int id)
	{
		if(turnOnRagdollState != null)
		{
			turnOnRagdollState(id);
		}
	}
}

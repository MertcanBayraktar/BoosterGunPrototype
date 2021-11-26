using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
	public GameObject bulletPrefab;
	public int spawnCount;
	public List<GameObject> bulletList;
	public GameObject gunBarrel;
	public bool CanFire;
	private void Start()
	{
		EventManager.instance.canShoot += CanShoot; 
		for (int i = 0; i < spawnCount; i++)
		{
			GameObject bullet = Instantiate(bulletPrefab) as GameObject;
			bulletList.Add(bullet);
			bullet.transform.parent = this.transform;
			bullet.SetActive(false);
		}
	}
	private void Update()
	{
		if (CanFire)
			if (Input.GetMouseButtonDown(1))
			{
				for (int i = 0; i < bulletList.Count; i++)
				{
					if (bulletList[i].activeInHierarchy == false)
					{
						bulletList[i].transform.position = gunBarrel.transform.position;
						bulletList[i].SetActive(true);
						Fire(bulletList[i].GetComponent<Rigidbody>());
						break;
					}
				}
			}
	}
	
	void Fire(Rigidbody rb)
	{
		rb.velocity = gunBarrel.transform.forward * 10f;
	}
	private void CanShoot(bool result)
	{
		CanFire = result;
	}
}

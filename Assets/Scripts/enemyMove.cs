    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMove : MonoBehaviour
{ 
    [SerializeField] private Vector3 startPos;
    public GameObject hipPosition;
    public GameObject player;
    private bool moveToNextWaypoint = false;
	private void Start()
	{
        startPos = hipPosition.transform.position;
	}
	void FixedUpdate()
    {

        if (Vector3.Distance(this.transform.position, player.transform.position) <= 15 && Vector3.Distance(this.transform.position, player.transform.position) >= 2)
        {
            transform.position = Vector3.MoveTowards(this.transform.position, new Vector3(player.transform.position.x, this.transform.position.y, player.transform.position.z), 1f * Time.deltaTime);
        }
        if(Vector3.Distance( this.transform.position , hipPosition.transform.position) > 4)
		{
			if (!moveToNextWaypoint)
			{
                moveToNextWaypoint = true;
                EventManager.instance.movePlayerToNextDestination();                 
			}
		}
    }
}
	

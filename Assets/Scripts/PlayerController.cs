using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
public class PlayerController : MonoBehaviour
{
	
	public List<GameObject> aiPath = new List<GameObject>();
	[SerializeField] private NavMeshAgent agent;
	[SerializeField] private CharacterController characterController;
	private int pathIndex;
	public GameObject headShotCanvas;
	public GameObject IntroductionPanel;
	
	private void Start()
	{
		pathIndex = 0;
		characterController = GetComponent<CharacterController>();
		agent = this.GetComponent<NavMeshAgent>();
		EventManager.instance.movePlayerToNextDestination += PlayerSetDestination;
		EventManager.instance.onHeadshot += EnableHeadshotCanvas;
	}
	private void Update()
	{
		if (!agent.pathPending)
		{
			if (agent.remainingDistance <= agent.stoppingDistance)
			{
				if (!agent.hasPath || agent.velocity.sqrMagnitude == 0f)
				{
					EventManager.instance.canShoot(true);
				}
			}
		}
	}
	public void PlayerSetDestination()
	{
		agent.SetDestination(aiPath[pathIndex].transform.position);
		if (pathIndex + 1 < aiPath.Count )
		{
			pathIndex++;
		}
		EventManager.instance.CanShoot(false);
	}
	public void EnableHeadshotCanvas()
	{
		StartCoroutine(TimeScaleOnHeadshot());
		headShotCanvas.gameObject.SetActive(true);
		StartCoroutine(SetCanvasDisabled());
	}
	IEnumerator SetCanvasDisabled()
	{
		yield return new WaitForSeconds(1f);
		headShotCanvas.gameObject.SetActive(false);
	}
	IEnumerator TimeScaleOnHeadshot()
	{
		Time.timeScale = 0.4f;
		yield return new WaitForSecondsRealtime(0.5f);
		Time.timeScale = 1f;
	}
	public void CloseIntroductionWindow()
	{
		IntroductionPanel.SetActive(false);
	}
}

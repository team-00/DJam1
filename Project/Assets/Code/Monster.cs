using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Monster : MonoBehaviour
{
	[SerializeField] private Transform[] footstepPositions;
	[SerializeField] private GameObject footstepPrefab;
	[SerializeField] private float chaseSpeed;
	[SerializeField] private float patrolSpeed;
	[SerializeField] private Transform[] patrolPoints;

	private CharController player;
	private NavMeshAgent agent;
	private NavMeshPath path;

	private int currentPatrolPointTarget;

	private void Start()
	{
		agent = GetComponent<NavMeshAgent>();
		path = new NavMeshPath();
		if (agent == null) agent = transform.parent.GetComponent<NavMeshAgent>();
		player = GameManager.Instance.Player;
		currentPatrolPointTarget = 0;
	}

	private void Update()
	{
		if (agent.CalculatePath(player.transform.position, path))
		{

			agent.SetPath(path);
			agent.speed = chaseSpeed;
		}
		
		else
		{
			currentPatrolPointTarget = 
				Vector3.Distance(transform.position, patrolPoints[currentPatrolPointTarget].position) < .1f 
				? (currentPatrolPointTarget + 1) % patrolPoints.Length 
				: currentPatrolPointTarget;

			agent.CalculatePath(patrolPoints[currentPatrolPointTarget].position, path);
			agent.SetPath(path);
			agent.speed = patrolSpeed;
		}
		//agent.SetDestination(player.transform.position);
	}


	public void SpawnFootStep(int footID)
	{
		var footstep = Instantiate(footstepPrefab, footstepPositions[footID].position, Quaternion.identity);
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player") && player.enabled == true)
		{
			player.enabled = false;
			other.GetComponent<Animator>().SetTrigger("Death");
		}
	}
}

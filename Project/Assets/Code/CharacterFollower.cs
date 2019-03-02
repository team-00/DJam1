using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterFollower : MonoBehaviour
{
	[SerializeField] private Transform playerTrans;

	private Vector3 startOffset;
	private Vector3 currentVelocity;

	private void Awake()
	{
		startOffset = transform.position - playerTrans.position;
	}

	private void Update()
	{
		transform.position = Vector3.SmoothDamp
			(transform.position, new Vector3(playerTrans.position.x, 0f, playerTrans.position.z) + startOffset, 
			ref currentVelocity, 
			.2f);
	}
}

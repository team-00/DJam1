using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharController : MonoBehaviour
{
	[SerializeField] private float moveSpeed;
	
	private Animator ownAnimator;
	private Rigidbody ownRigidbody;
	private Quaternion currentDirectionTarget;

	private float hInput;
	private float vInput;
	private float currentMoveSpeed;
	private Vector3 dir;

	private void Awake()
	{
		ownAnimator = GetComponentInChildren<Animator>();
		ownRigidbody = GetComponent<Rigidbody>();
	}

	void Update()
	{
		hInput = Input.GetAxis("Horizontal");
		vInput = Input.GetAxis("Vertical");
		currentMoveSpeed = Mathf.Min(1f, Mathf.Abs(hInput) + Mathf.Abs(vInput));

		ownAnimator.SetFloat("MovementSpeed", currentMoveSpeed);
		
		dir = new Vector3((vInput + hInput) * .5f, 0f, (vInput - hInput) * .5f).normalized * currentMoveSpeed * Time.deltaTime;
		if (currentMoveSpeed > 0f) currentDirectionTarget = Quaternion.LookRotation(dir);
		transform.rotation = Quaternion.RotateTowards(transform.rotation, currentDirectionTarget, 5f);
		transform.Translate(dir * moveSpeed, Space.World);

		if (Input.GetMouseButtonDown(0)) HandleMouseClick();
	}

	private void HandleMouseClick()
	{
		Debug.Log("click");
	}
}

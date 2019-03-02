using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharController : MonoBehaviour
{
	public Camera MainCam;
	public Transform KeyCarryTransform;
	public float StandardMoveSpeed;
	public float SlowMoveSpeed;
	public float maxInteractionDistance;

	internal bool Sitting;
	private Key currentlyCarriedKey;
	internal Key CurrentlyCarriedKey
	{
		get => currentlyCarriedKey;
		set
		{
			currentlyCarriedKey = value;
			MoveSpeed = value == null ? StandardMoveSpeed : SlowMoveSpeed;
		}
	}

	private Animator ownAnimator;
	private Rigidbody ownRigidbody;
	private Quaternion currentDirectionTarget;

	private float MoveSpeed;
	private float hInput;
	private float vInput;
	private float currentMoveSpeed;
	private Vector3 dir;


	private void Awake()
	{
		ownAnimator = GetComponentInChildren<Animator>();
		ownRigidbody = GetComponent<Rigidbody>();

		GameManager.Instance.RegisterPlayer(this);
		MoveSpeed = StandardMoveSpeed;
	}

	void Update()
	{
		HandleMovement();
		if (Input.GetMouseButtonDown(0)) HandleMouseClick();
	}

	private void HandleMovement()
	{
		if (!Sitting)
		{
			hInput = Input.GetAxis("Horizontal");
			vInput = Input.GetAxis("Vertical");
			currentMoveSpeed = Mathf.Min(1f, Mathf.Abs(hInput) + Mathf.Abs(vInput));
		}
		else
		{
			hInput = 0f;
			vInput = 0f;
			currentMoveSpeed = 0f;
			Debug.Log("REEE");
		}

		ownAnimator.SetFloat("MovementSpeed", currentMoveSpeed);

		dir = new Vector3((vInput + hInput) * .5f, 0f, (vInput - hInput) * .5f).normalized * currentMoveSpeed * Time.deltaTime;
		if (dir != Vector3.zero) currentDirectionTarget = Quaternion.LookRotation(dir);
		transform.rotation = Quaternion.RotateTowards(transform.rotation, currentDirectionTarget, 5f);
		transform.Translate(dir * MoveSpeed, Space.World);
	}

	private void HandleMouseClick()
	{
		if (Physics.Raycast(MainCam.ScreenPointToRay(Input.mousePosition), out var hitInfo))
		{
			IClickable clickable = hitInfo.collider.GetComponent<IClickable>();
			float dist = Vector2.Distance(new Vector2(hitInfo.point.x, hitInfo.point.z), new Vector2(transform.position.x, transform.position.z));
			if (clickable != null && dist < maxInteractionDistance)
				clickable.OnClick(this);
		}
	}

	internal void ToggleSitting(Vector3 newLookTarget = default)
	{
		Sitting = !Sitting;
		if(newLookTarget != default) currentDirectionTarget = Quaternion.LookRotation(newLookTarget);
		var collider = GetComponentInChildren<BoxCollider>();
		collider.center = Sitting ? new Vector3(0f, .8f, 0f) : new Vector3(0f, .5f, 0f);
		Debug.Log(collider.center);
	}
}

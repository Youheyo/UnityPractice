using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering.Universal.Internal;
using UnityEngine.TextCore.Text;

[RequireComponent(typeof(CharacterController))]
public class Movement : MonoBehaviour
{

	[Header("Movement Stats")]
	[SerializeField] private float MoveSpeed = 10;
	[SerializeField] private float JumpHeight = 10;


	// * Movement Input Related
	Vector3 input_vector;
	float yVelocity;

	// * Controller
	CharacterController charController;

	readonly float gravity = -9.8f;

	void Start()
	{
		charController = GetComponent<CharacterController>();
	}

	void Update()
	{
		Move();
	}

	private void Move()
	{
		Vector3 worldSpaceInput = transform.TransformVector(input_vector.x, 0f, input_vector.z);
		Vector3 TargetVelocity = worldSpaceInput * MoveSpeed;


		// * Gravity Handler
		yVelocity += gravity * Time.deltaTime;
		if (charController.isGrounded && yVelocity < 0) yVelocity = gravity;

		TargetVelocity += new Vector3(0,yVelocity);

		charController.Move(TargetVelocity * Time.deltaTime);
	}

	public void OnMove(InputValue input)
	{

		input_vector.x = input.Get<Vector2>().x;
		input_vector.z = input.Get<Vector2>().y;

	}

	public void OnJump() {

		if (charController.isGrounded)
		{
			yVelocity += Mathf.Sqrt(JumpHeight * -3.0f * gravity);
		}
	}

}
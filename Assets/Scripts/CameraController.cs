using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{

	[SerializeField] Camera cam;
	[SerializeField] float sensitivity = 10f;

	private float xRotation = 0f;


	void Start()
	{
		if (cam!) cam = GetComponentInChildren<Camera>();
		Cursor.lockState = CursorLockMode.Confined;
	}

	public void OnLook(InputValue input)
	{
		float mouseX = input.Get<Vector2>().x;
		float mouseY = input.Get<Vector2>().y;

		xRotation -= mouseY * Time.deltaTime * sensitivity;
		xRotation = Mathf.Clamp(xRotation, -90f, 90f);

		cam.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
		transform.Rotate(Vector3.up * mouseX * sensitivity);
	}

}
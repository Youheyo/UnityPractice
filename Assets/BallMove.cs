using Unity.VisualScripting;
using UnityEditor.Rendering.LookDev;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class BallMove : MonoBehaviour
{

    Rigidbody rb;
    GameObject Ball;
    [SerializeField] Camera cam;
    [SerializeField] float AccelSpeed = 1f;
    [SerializeField] float BrakeForce = 10f;
    [SerializeField] float JumpForce = 10f;

    Vector3 movementVector = Vector3.zero;
    bool brakes = false;


    Vector3 initPosition;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if(!cam){
            cam = FindFirstObjectByType<Camera>();
        }

        initPosition = transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        // rb.AddTorque(new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical")) * AccelSpeed);
        if(Input.GetKey("q")){
            ResetBall();
        }
        PushBall(movementVector);

    }

    private void ResetBall(){

        rb.linearVelocity = Vector3.zero;
        transform.position = initPosition;
    }

    public void OnMove(InputValue value){
        movementVector = new Vector3(value.Get<Vector2>().x, 0f, value.Get<Vector2>().y);

        movementVector = (FlattenVector(cam.transform.forward) * movementVector.z + FlattenVector(cam.transform.right) * movementVector.x).normalized;

        // rb.AddForce(playerVector * AccelSpeed);
        // this.transform.localPosition += new Vector3(value.Get<Vector2>().x, 0f, value.Get<Vector2>().y) * Time.fixedDeltaTime;


    }

    private Vector3 FlattenVector(Vector3 vector)
    {
        return new Vector3(vector.x, 0, vector.z).normalized;
    }

    private void PushBall(Vector3 value){

        rb.AddForce(value * AccelSpeed);

    }

    private void Brakes(){
        rb.AddForce(rb.linearVelocity * -BrakeForce);
    }

    public void OnBrakeHeld(InputAction.CallbackContext value){
        // Debug.Log("Brakes Pressed " + value.action.IsPressed());
        Debug.Log("Brakes Being Pressed ");
        // Debug.Log(value.Get<InputAction>());
    }

    public void OnJump(){
        Debug.Log($"JUMPING");

        rb.AddForce(new Vector3(0, JumpForce, 0));
    }
}

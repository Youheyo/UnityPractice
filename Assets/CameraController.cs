using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{

    [SerializeField] GameObject targetPlayer;
    Vector3 offsetTransform;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(!targetPlayer){
            targetPlayer = GameObject.FindFirstObjectByType<PlayerInput>().gameObject;
        }

        // transform.position = targetPlayer.transform.position;
        // transform.position = transform.forward + new Vector3(0,5,5);

        offsetTransform = transform.position + new Vector3(0,5,-5) - targetPlayer.transform.position;



        transform.position = targetPlayer.transform.position + offsetTransform;
        transform.LookAt(targetPlayer.transform);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * Time.deltaTime);
        transform.LookAt(targetPlayer.transform);

    }
}

using UnityEngine;

public class LaunchPad : MonoBehaviour
{
    Collider collider;
    [SerializeField] float PushForce = 1000f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        collider = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision){
        // if(collision.rigidbody<Rigidbody>(out Rigidbody body)){
        //     body.AddForce(new Vector3(0, PushForce, 0));
        // }

        collision.rigidbody.AddForce(Vector3.up + new Vector3(0, PushForce));

    }
}

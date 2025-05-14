using Unity.VisualScripting;
using UnityEngine;

public class LaunchPad : MonoBehaviour
{
    [SerializeField] GameObject ForwardArrow;

    [Header("Launchpad settings")]
    [SerializeField] float PushForce = 1000f;
    [SerializeField] bool PushForward = false;
    [SerializeField] float ForwardPushForce = 1000;

	private void OnValidate()
	{
        if(ForwardArrow){
            ForwardArrow.SetActive(PushForward);
        }
	}

	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
    {
        if(!ForwardArrow) ForwardArrow = GetComponentInChildren<TextMesh>().gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision){
        // if(collision.rigidbody<Rigidbody>(out Rigidbody body)){
        //     body.AddForce(new Vector3(0, PushForce, 0));
        // }

        collision.rigidbody.AddForce(!PushForward ? Vector3.up * PushForce: transform.forward * ForwardPushForce + Vector3.up * PushForce);

    }
}

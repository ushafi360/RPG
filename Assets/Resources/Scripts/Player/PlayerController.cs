using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public float rotateSpeed = 5.0f;
    public float forwardSpeed = 5.0f;
    private CharacterController playerCont;

	// Use this for initialization
	void Start () {
        if (GetComponent<CharacterController>() == null)
        {
            playerCont = gameObject.AddComponent<CharacterController>();
        }
        else
        {
            playerCont = GetComponent<CharacterController>();
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("space") && playerCont.isGrounded)
        {
            playerCont.Move(Vector3.up);
        }
        transform.Rotate(Vector3.up * rotateSpeed * Input.GetAxis("Horizontal"));
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        float speed = forwardSpeed * Input.GetAxis("Vertical");
        playerCont.SimpleMove(speed * forward);
        
	}
}

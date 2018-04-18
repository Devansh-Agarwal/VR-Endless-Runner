using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour {

	private CharacterController controller;
	//private float h;
	private Vector3 moveVector;
	public Transform Head;
	public float speed;
	private float gravity = 9.8f;
	private float verticalVelocity = 0.0f;
	private bool isDead = false;
	// Use this for initialization
	void Start () {
		controller = GetComponent<CharacterController> ();
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButtonDown("Fire1"))
		     SceneManager.LoadScene("scene1");
		if (isDead)
			return;
		moveVector = Vector3.zero;
		if (controller.isGrounded)			verticalVelocity = 0.0f;
		else
			verticalVelocity -= gravity * Time.deltaTime;
		moveVector.x = Input.GetAxisRaw("Horizontal") * speed;
		moveVector.y = verticalVelocity;
		moveVector.z = speed;

		//Vector3 forward = Head.TransformDirection(Vector3.forward);
		controller.Move(moveVector * Time.deltaTime);
		//transform.position += new Vector3(h * Time.deltaTime, 0f, 0f);	
	}
	public void SetSpeed(float modifier)
	{		speed = 2.0f + modifier *0.5f;
	}
	private void OnControllerColliderHit(ControllerColliderHit hit)
	{
		if ((hit.point.z > transform.position.z + controller.radius)&& hit.point.y >.3f&& hit.point.x < 1.7f)
		{
			Death();
		}
	}
	private void Death()
	{
		isDead = true;
		GetComponent<Score>().OnDeath(); 
	}
}

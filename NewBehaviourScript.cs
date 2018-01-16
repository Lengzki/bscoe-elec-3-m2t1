using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour {
	public float thrust;
	public GameObject targetPad;
	Rigidbody _rigidbody;
	
	void Start () {
		_rigidbody = GetComponent<Rigidbody>();
	}

	void OnCollisionEnter(Collision collision)
	{
		if(collision.gameObject.tag == "Obstacle"){ 
			SceneManager.LoadScene(SceneManager.GetActiveScene().name);          
			Debug.Log("Collided with: " + collision.gameObject.name);
		}

		if(collision.gameObject.tag == "target"){
			collision.gameObject.GetComponent<Renderer>().material.color = Color.green;
			print("You Won~!!");
			Debug.Log("Triggered with: " + collision.gameObject.name);
		}
	}

	void Update () {
		ProcessInput();
	}

	private void ProcessInput(){

		float rcsThrust = 100f;
		float rotation = rcsThrust * Time.deltaTime;

		if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.Space)){
            print("Up");
			_rigidbody.AddRelativeForce(Vector3.up * thrust);
		}
		
		if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)){
            print("Left");
			transform.Rotate(Vector3.forward * rotation);
		}

		if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)){
            print("Right");
			transform.Rotate(-Vector3.forward);
		}
	}
}

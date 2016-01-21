using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour {
	
	public float speed;

	private int count;

	public Text countText;

	public Text winText; 
	
	private Rigidbody rb;
	
	void Start ()
	{
		rb = GetComponent<Rigidbody>();
		count = 0;
		printCount ();
		winText.text = "";
	}
	
	void FixedUpdate ()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		
		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		
		rb.AddForce (movement * speed);
	}
	
	void OnTriggerEnter(Collider other) 
	{
		if (other.gameObject.CompareTag ("Pick Up"))
		{
			other.gameObject.SetActive (false);
			count = count + 10;
		}
		printCount ();
		if (count >= 100) {
			winText.text = "You Win !!! Yay bro !!";
		}

	}

	void printCount()
	{
		countText.text = "Score :" + count.ToString ();
	}

}
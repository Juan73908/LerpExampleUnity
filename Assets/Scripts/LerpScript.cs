using UnityEngine;
using System.Collections;

// Example script that shows the two most common uses of Lerp.
public class LerpScript : MonoBehaviour {

	// Assigned in the inspector
	public Transform position1;
	public Transform position2;

	// Auxiliar variables
	protected Transform destination;

	// How fast the character moves
	public float speed = 1.0f;

	// Two types of lerp
	public enum LerpType{Constant, Smooth};
	public LerpType lerpType;

	// Constant Lerp variables
	protected float timer = 0.0f;

	// Initialization
	void Start(){
		destination = position1;
	}


	// Called when the character should move
	public void ChangeDestination(){
		// Change the destination
		if (destination == position1){
			destination = position2;
		}
		else{
			destination = position1;
		}
	}

	// Lerp is done over time
	void Update(){
		// Check for the selected type of lerp
		switch (lerpType) {
		case LerpType.Constant:
			// From position1 to position2 with incresing t
			transform.position = Vector3.Lerp(position1.position, position2.position, speed * timer);
			break;
		case LerpType.Smooth:
			// From actual position to destination with "constant" t
			transform.position = Vector3.Lerp(transform.position, destination.position, speed  * 3.0f * Time.deltaTime);
			break;
		}
		// Increase or decrease the constant lerp timer
		if (destination == position1){
			// Go to position1 t = 0.0f
			timer = Mathf.Clamp(timer - Time.deltaTime, 0.0f, 1.0f/speed);
		} else {
			// Go to position2 t = 1.0f
			timer = Mathf.Clamp(timer + Time.deltaTime, 0.0f, 1.0f/speed);
		}
	}
}

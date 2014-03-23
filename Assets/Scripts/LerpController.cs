using UnityEngine;
using System.Collections;

// Controlls the interaction with the GUI
public class LerpController : MonoBehaviour {

	// Assigned in the inspector
	public LerpScript[] scripts;

	// Lerp variables for the button
	public float speed = 3.0f;

	public Color color1;
	public Color color2;
	protected Color destinationColor;

	public Vector3 rotation1;
	public Vector3 rotation2;
	protected Quaternion destinationRotation;

	// Cache variables
	protected SpriteRenderer spriteRenderer;
	
	// Initialization
	void Start() {
		destinationColor = color1;
		destinationRotation.eulerAngles = rotation1;

		spriteRenderer = GetComponent<SpriteRenderer>();
	}

	// When clicked
	void OnMouseDown(){
		// Change destination of the Lerp Scripts
		foreach (LerpScript script in scripts){
			script.ChangeDestination();
		}

		// Change color and rotation
		if (destinationColor == color1){
			destinationColor = color2;
			destinationRotation.eulerAngles = rotation2;
		}
		else{
			destinationColor = color1;
			destinationRotation.eulerAngles = rotation1;
		}
	}

	// Lerp every frame
	void Update (){
		// Lerp color
		spriteRenderer.color = Color.Lerp(spriteRenderer.color, destinationColor, speed * Time.deltaTime);

		// Lerp rotation
		transform.rotation = Quaternion.Lerp(transform.rotation, destinationRotation , speed * 4.0f * Time.deltaTime);
	}
}

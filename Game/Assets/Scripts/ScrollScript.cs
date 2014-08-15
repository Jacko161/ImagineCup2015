using UnityEngine;
using System.Collections;

public class ScrollScript : MonoBehaviour 
{
	// Multiplyer for scrolling speed.
	public float 				ScrollSpeed = 1.0f;

	// Multiplyer for zoom speed.
	public float				zoomSpeed 	= 1.0f;

	// Percentage of the screen size from the edge of the screen that will cause scrolling.
	public float				ScrollFactor = 0.2f;



	//
	// Start
	// 
	void Start () 
	{
		
	}



	//
	// Update
	//
	void Update () 
	{
		if ( Input.mousePosition.x > ( Screen.width - ( Screen.width * ScrollFactor ) ) ) 
		{
			transform.Translate( Vector3.right * ScrollSpeed * Time.deltaTime );
		}
		else if( Input.mousePosition.x < ( Screen.width * ScrollFactor ) )
		{
			transform.Translate( Vector3.left * ScrollSpeed * Time.deltaTime );
		}

		if ( Input.mousePosition.y > ( Screen.height - ( Screen.height * ScrollFactor ) ) ) 
		{
			transform.Translate( Vector3.up * ScrollSpeed * Time.deltaTime );
		}
		else if( Input.mousePosition.y < ( Screen.height * ScrollFactor ) )
		{
			transform.Translate( Vector3.down * ScrollSpeed * Time.deltaTime );
		}


		// Get the direction of the mouse from the camera.
		Vector3			zoomDirection	  = ( camera.ScreenToWorldPoint( new Vector3( Input.mousePosition.x, Input.mousePosition.y, camera.nearClipPlane ) ) - transform.position ).normalized;

		// Translate the transform towards the mouse.
		transform.Translate( new Vector3( zoomDirection.x, zoomDirection.z, -zoomDirection.y ) * Input.GetAxis( "Mouse ScrollWheel" ) * zoomSpeed );
	}
}

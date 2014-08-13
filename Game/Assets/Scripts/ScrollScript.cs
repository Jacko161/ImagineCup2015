using UnityEngine;
using System.Collections;

public class ScrollScript : MonoBehaviour 
{
	// Multiplyer for scrolling speed.
	public float 				ScrollSpeed = 1.0f;

	// Multiplyer for zoom speed.
	public float				zoomSpeed 	= 1.0f;

	// Distance from the edge of the screen in pixels that the mouse will scroll in.
	public int 					ScrollDistance = 200;



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
		if ( Input.mousePosition.x > ( Screen.width - ScrollDistance ) ) 
		{
			transform.Translate( Vector3.right * ScrollSpeed * Time.deltaTime );
		}
		else if( Input.mousePosition.x < ScrollDistance )
		{
			transform.Translate( Vector3.left * ScrollSpeed * Time.deltaTime );
		}

		if ( Input.mousePosition.y > ( Screen.height - ScrollDistance ) ) 
		{
			transform.Translate( Vector3.up * ScrollSpeed * Time.deltaTime );
		}
		else if( Input.mousePosition.y < ScrollDistance )
		{
			transform.Translate( Vector3.down * ScrollSpeed * Time.deltaTime );
		}


		// Get the direction of the mouse from the camera.
		Vector3			zoomDirection	  = ( camera.ScreenToWorldPoint( new Vector3( Input.mousePosition.x, Input.mousePosition.y, camera.nearClipPlane ) ) - transform.position ).normalized;

		// Translate the transform towards the mouse.
		transform.Translate( new Vector3( zoomDirection.x, zoomDirection.z, -zoomDirection.y ) * Input.GetAxis( "Mouse ScrollWheel" ) * zoomSpeed );
	}
}

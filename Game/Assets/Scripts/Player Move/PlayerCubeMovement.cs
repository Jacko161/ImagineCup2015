using UnityEngine;
using System.Collections;

public class PlayerCubeMovement : MonoBehaviour 
{
	private NavMeshAgent 	agent;
	private Vector3 		target;


	//
	//
	//
	void Start () 
	{
		agent 				= GetComponent<NavMeshAgent>();
		target 				= gameObject.transform.position;
	}

	//
	//
	//
	void Update () 
	{
		if ( Input.GetMouseButtonDown( 0 ) )
		{
			Move();
		}

		agent.SetDestination( target );
	}


	//
	// Get the point of impact of the ray and move to it.
	//
	void Move()
	{
		RaycastHit 	hit;
		// set ray conditions to from camera to mouse
		Ray 		ray 	= Camera.main.ScreenPointToRay( Input.mousePosition );

		Physics.Raycast( ray, out hit );

		if ( hit.collider.tag == "Level" )
		{
			target 			= hit.point;
		}
	}
}

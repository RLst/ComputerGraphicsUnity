using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour 
{
	float animSpeedFactor;
	float animAngSpeedFactor;
	Camera cam;

	NavMeshAgent agent;
	Animator anim;
	VelocityTracker vt;

	void Start()
	{
		agent = GetComponent<NavMeshAgent>();
		cam = FindObjectOfType<Camera>();
		anim = GetComponent<Animator>();
		vt = GetComponent<VelocityTracker>();
	}

	void Update()
	{
		//Calc current speeds
		animSpeedFactor = 1f / agent.speed;
		animAngSpeedFactor = 1f / agent.angularSpeed;
		
		//Move to place clicked
		if (Input.GetMouseButtonDown(0))
		{
			Ray ray = cam.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;

			if (Physics.Raycast(ray, out hit))
			{
				agent.SetDestination(hit.point);
			}
		}

		//Set animator params
		// Debug.Log("Current speed: " + vt.velocity.magnitude * animSpeedFactor);
		// Debug.Log("Current turn speed: " + vt.angularVelocity.y * animAngSpeedFactor);
		anim.SetFloat("Speed", vt.velocity.magnitude * animSpeedFactor);
		anim.SetFloat("Turn", vt.angularVelocity.y * animAngSpeedFactor);
	}

}

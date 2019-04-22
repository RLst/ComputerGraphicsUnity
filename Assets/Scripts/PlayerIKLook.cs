using UnityEngine;

public class PlayerIKLook : MonoBehaviour
{
	[SerializeField] float lookRange = 5f;
	[SerializeField] float lookAtWeight = 0.8f;

	//Caches
	Animator anim;
	Camera cam;

	Vector3 IKLookTarget;
	private bool rayHit;

	void Start()
	{
		anim = GetComponent<Animator>();
		cam = FindObjectOfType<Camera>();
	}

	void Update()
	{
		var ray = cam.ScreenPointToRay(Input.mousePosition);
		RaycastHit hitInfo;
		//If the ray cast hit something...
		if (Physics.Raycast(ray, out hitInfo))
		{
			rayHit = true;
			//and the position hit is within range then look at it
			if (Vector3.Distance(transform.position, hitInfo.point) < lookRange)
			{
				IKLookTarget = hitInfo.point;
			}
		}
		else
		{
			rayHit = false;
			IKLookTarget = Vector3.zero;
		}
	}

	void OnAnimatorIK()
	{
		if (rayHit)
		{
			//Set weights
			anim.SetLookAtWeight(lookAtWeight);

			//Set targets
			anim.SetLookAtPosition(IKLookTarget);
		}
		else
		{
			anim.SetLookAtWeight(0);
		}
	}
}

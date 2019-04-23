using UnityEngine;

public class RTSCameraController : MonoBehaviour
{
	[SerializeField] float panBorderSize = 20f;
	[SerializeField] float panSpeed = 10f;
	[SerializeField] float turnSpeed = 100f;

	public Vector3 rigPos;
	private Camera cam;

	void Start()
	{
		cam = GetComponentInChildren<Camera>();

		//Look at center of rig
		cam.transform.LookAt(transform.position, Vector3.up);
	}

	void Update()
	{
		rigPos = transform.position;

		//Pan Up
		if (Input.mousePosition.y >= Screen.height - panBorderSize || Input.GetKey(KeyCode.W))
		{
			rigPos += transform.forward * panSpeed * Time.deltaTime;
		}
		//Pan Down
		if (Input.mousePosition.y <= panBorderSize || Input.GetKey(KeyCode.S))
		{
			rigPos -= transform.forward * panSpeed * Time.deltaTime;
		}
		//Pan Left
		if (Input.mousePosition.x <= panBorderSize || Input.GetKey(KeyCode.A))
		{
			rigPos -= transform.right * panSpeed * Time.deltaTime;
		}
		//Pan Right
		if (Input.mousePosition.x >= Screen.width - panBorderSize || Input.GetKey(KeyCode.D))
		{
			rigPos += transform.right * panSpeed * Time.deltaTime;
		}

		//Rotate about
		if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.Mouse1))
		{
			var mxInput = Input.GetAxis("Mouse X"); 
			// var myInput = Input.GetAxis("Mouse Y");

			//Rotate about Y
			transform.Rotate(Vector3.up, Time.deltaTime * mxInput * turnSpeed);
		}

		//Clamp and set position
		transform.position = rigPos;
	}
}

using UnityEngine;

public class VelocityTracker : MonoBehaviour
{
	//Tracks object velocity and angular velocity
	//Angular velocity does not have sudden jumps when going between 360 to 0

	public Vector3 velocity
	{
		get { return deltaPosition / Time.deltaTime; }
	}
	public Vector3 angularVelocity
	{
		get { return axis * magnitude / Time.deltaTime; }
	}

	Vector3 deltaPosition;
	Vector3 prevFramePosition;
	Vector3 m_velocity;

	Quaternion prevFrameRotation;
	float magnitude;
	Vector3 axis;

	void Start()
	{
		prevFramePosition = transform.position;
		prevFrameRotation = transform.rotation;
	}

	void Update()
	{
		deltaPosition = transform.position - prevFramePosition;

		//Angular
		Quaternion deltaRotation = transform.rotation * Quaternion.Inverse(prevFrameRotation);
		deltaRotation.ToAngleAxis(out magnitude, out axis);

		//Record last
		prevFramePosition = transform.position;
		prevFrameRotation = transform.rotation;
	}
}
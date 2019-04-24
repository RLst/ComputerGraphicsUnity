using UnityEngine;
using UnityChan;

namespace ComputerGraphics
{
    public class WindController : MonoBehaviour
    {
        SpringBone[] springBones;

		[SerializeField] float windForce = 30f;

		float windFineTuneFactor = 0.001f;	//Wind is too sensitive

        void Start()
        {
            springBones = GetComponent<SpringManager>().springBones;
        }

        void Update()
        {
            Vector3 force = Vector3.zero;
			force = new Vector3(Mathf.PerlinNoise(Time.time, 0.0f) * windFineTuneFactor * windForce, 0, 0);

			//Go through all spring bones and apply force
			for (int i = 0; i < springBones.Length; i++)
			{
				springBones[i].springForce = force;
			}
        }

		public void UpdateWindValue(float value)
		{
			windForce = value;
		}
	}
}
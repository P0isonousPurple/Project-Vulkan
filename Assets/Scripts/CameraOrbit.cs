using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectVulkan
{
	public class CameraOrbit : MonoBehaviour
	{
		[SerializeField] private float speed = 3.0f;
		[SerializeField] private Transform target;

		private void Update()
		{
			transform.LookAt(target);
    		transform.Translate(Vector3.right * Time.deltaTime * speed);
		}
	}
}

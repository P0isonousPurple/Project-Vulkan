using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectVulkan
{
	public class CameraOrbit : MonoBehaviour
	{
		[SerializeField] private float speed = 3.0f;

		private void Update()
		{
			transform.Rotate(0, speed * Time.deltaTime, 0);
		}
	}
}

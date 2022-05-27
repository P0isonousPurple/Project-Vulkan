using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectVulkan
{
	public class EruptionTrigger : MonoBehaviour
	{
		[SerializeField] private KeyCode _triggerKey;
		[Space]
		[SerializeField] private ParticleSystem _particleEffect;

		private AudioSource _source;
		private bool _isExpired;

		public KeyCode GetTriggerKeyCode() => _triggerKey;

		private void Awake()
		{
			_source = GetComponent<AudioSource>();
		}

		private void Update()
		{
			if(Input.GetKeyDown(_triggerKey) && !_isExpired)
			{
				if (_particleEffect != null) { _particleEffect.Play(); }
				if(_source != null) { _source.Play(); }
				_isExpired = true;
			}
		}
	}
}

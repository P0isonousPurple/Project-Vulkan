using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectVulkan
{
	public class LoadSettings : MonoBehaviour
	{
		[Header("SFX Volume Settings")]
		[SerializeField] private AudioSource[] _audioSources;

		private void Start()
		{
			if(_audioSources.Length > 0)
			{
				for (int i = 0; i < _audioSources.Length; i++)
				{
					if(_audioSources[i] != null)
					{
						_audioSources[i].volume = SettingsLoader.AudioSFXLevel;
					}
				}
			}
		}
	}
}

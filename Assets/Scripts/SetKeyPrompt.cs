using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace ProjectVulkan
{
	public class SetKeyPrompt : MonoBehaviour
	{
		[SerializeField] private TMP_Text _text;
		[SerializeField] private EruptionTrigger _trigger;

		private void Start()
		{
			_text.text = $"Press <color=red>{_trigger.GetTriggerKeyCode()}</color> key to begin the simulation";
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectVulkan
{
	public class PanelManager : MonoBehaviour
	{
		[Header("Panels")]
		[SerializeField] private int _startingPanelIndex = 0;
		[SerializeField] private GameObject[] _panels;

		private void Start()
		{
			SetPanel(_startingPanelIndex);
		}

		public void SetPanel(int panelIndex)
		{
			for (int i = 0; i < _panels.Length; i++)
			{
				_panels[i].SetActive(i == panelIndex);
			}
		}
	}
}

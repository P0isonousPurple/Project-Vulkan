using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace ProjectVulkan
{
	public class SettingsManager : MonoBehaviour
	{
		[Header("Quality Settings")]
		[SerializeField] private Slider _qualitySlider;
		[SerializeField] private TMP_Text _lowText;
		[SerializeField] private TMP_Text _mediumText;
		[SerializeField] private TMP_Text _highText;
		[SerializeField] private Color _selectedColor;
		[Space]
		[Header("Audio Settings")]
		[SerializeField] private Slider _audioSFXSlider;
		[SerializeField] private TMP_Text _audioLevelPercentageText;

		private Color _initialTextColor;

		private void Awake()
		{
			_qualitySlider.onValueChanged.AddListener(delegate { SetGraphicsQuality(); });
			_audioSFXSlider.onValueChanged.AddListener(delegate { SetSFXLevels(); });
		}

		private void Start()
		{
			_initialTextColor = _lowText.color;
		}

		public void SetGraphicsQuality()
		{
			int qualityIndex = (int)_qualitySlider.value;
			QualitySettings.SetQualityLevel(qualityIndex);

			Debug.Log(qualityIndex);

			switch (qualityIndex)
			{
				case 1:
					_lowText.color = _selectedColor;
					_mediumText.color = _initialTextColor;
					_highText.color = _initialTextColor;
					break;
				case 2:
					_lowText.color = _initialTextColor;
					_mediumText.color = _selectedColor;
					_highText.color = _initialTextColor;
					break;
				case 3:
					_lowText.color = _initialTextColor;
					_mediumText.color = _initialTextColor;
					_highText.color = _selectedColor;
					break;
			}
		}

		public void SetSFXLevels()
		{
			SettingsLoader.AudioSFXLevel = _audioSFXSlider.value;

			_audioLevelPercentageText.text = $"{Mathf.FloorToInt(_audioSFXSlider.value)}%";
		}
	}
}

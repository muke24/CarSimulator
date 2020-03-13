﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class AllSettings : MonoBehaviour
{
	public Button applyButton;

	//public Slider volumeSlider;
	public Slider resolutionSlider;
	public Slider reflectSlider;
	public Slider mouseX;
	public Slider mouseY;

	public InputField mXinput;
	public InputField mYinput;

	public MouseLook mlY;
	public MouseLook mlX;

	public Dropdown rtReflections;

	public ReflectionProbe ReflectionProbe1;
	public ReflectionProbe ReflectionProbe2;

	//public Text volumeText;
	public Text resolutionText;
	public Text resolutionSize;
	public Text reflectionValueText;

	public string resText;

	//public int volumeInt;
	public int resolutionIntWidth;
	public int resolutionIntHeight;

	public int resWidth;
	public int resHeight;

	public int realtimeReflections = 0;

	public bool start = true;
	public bool resChanged;
	public bool settingsChanged;
	public bool dragging = false;

	// Start is called before the first frame update
	void Start()
	{
		start = true;
		if (start)
		{
			ApplySettings();
		}
		resChanged = false;
		settingsChanged = false;
		resWidth = Screen.width;
		resHeight = Screen.height;

		ReflectionProbe1.enabled = true;
		ReflectionProbe2.enabled = true;
		ReflectionProbe1.resolution = 512;
		ReflectionProbe2.resolution = 512;
		reflectionValueText.text = "High";

		mXinput.text = mouseX.value.ToString();
		mYinput.text = mouseY.value.ToString();
	}

	// Update is called once per frame
	void Update()
	{

		if (settingsChanged == false)
		{
			applyButton.gameObject.SetActive(false);
		}

		if (settingsChanged == true)
		{
			applyButton.gameObject.SetActive(true);
		}

		resolutionIntWidth = Mathf.RoundToInt(resWidth * resolutionSlider.value);
		resolutionIntHeight = Mathf.RoundToInt(resHeight * resolutionSlider.value);

		resolutionText.text = resText;
		resText = resolutionSlider.value.ToString();
		if (resText.Length > 3)
		{
			resText = resText.Substring(0, 3);
		}

		//volumeInt = Mathf.RoundToInt(volumeSlider.value);
		//volumeText.text = volumeSlider.value.ToString() + "%";

		resolutionSize.text = resolutionIntWidth.ToString() + " x " + resolutionIntHeight.ToString();

	}

	public void ApplySettings()
	{
		if (resChanged)
		{
			Screen.SetResolution(resolutionIntWidth, resolutionIntHeight, FullScreenMode.ExclusiveFullScreen);

			resChanged = false;
		}
		if (settingsChanged == true || start == true)
		{
			if (reflectSlider.value == 0)
			{
				ReflectionProbe1.enabled = false;
				ReflectionProbe2.enabled = false;
				reflectionValueText.text = "Off";
			}
			if (reflectSlider.value == 1)
			{
				ReflectionProbe1.enabled = true;
				ReflectionProbe2.enabled = true;
				ReflectionProbe1.resolution = 64;
				ReflectionProbe2.resolution = 64;
				reflectionValueText.text = "Low";
			}
			if (reflectSlider.value == 2)
			{
				ReflectionProbe1.enabled = true;
				ReflectionProbe2.enabled = true;
				ReflectionProbe1.resolution = 256;
				ReflectionProbe2.resolution = 256;
				reflectionValueText.text = "Medium";
			}
			if (reflectSlider.value == 3)
			{
				ReflectionProbe1.enabled = true;
				ReflectionProbe2.enabled = true;
				ReflectionProbe1.resolution = 512;
				ReflectionProbe2.resolution = 512;
				reflectionValueText.text = "High";
			}
			if (reflectSlider.value == 4)
			{
				ReflectionProbe1.enabled = true;
				ReflectionProbe2.enabled = true;
				reflectionValueText.text = "Custom";
			}

			if (rtReflections.value == 0)
			{
				ReflectionProbe1.refreshMode = UnityEngine.Rendering.ReflectionProbeRefreshMode.EveryFrame;
				ReflectionProbe2.refreshMode = UnityEngine.Rendering.ReflectionProbeRefreshMode.EveryFrame;
				ReflectionProbe1.timeSlicingMode = UnityEngine.Rendering.ReflectionProbeTimeSlicingMode.NoTimeSlicing;
				ReflectionProbe2.timeSlicingMode = UnityEngine.Rendering.ReflectionProbeTimeSlicingMode.NoTimeSlicing;
			}
			if (rtReflections.value == 1)
			{
				ReflectionProbe1.refreshMode = UnityEngine.Rendering.ReflectionProbeRefreshMode.EveryFrame;
				ReflectionProbe2.refreshMode = UnityEngine.Rendering.ReflectionProbeRefreshMode.EveryFrame;
				ReflectionProbe1.timeSlicingMode = UnityEngine.Rendering.ReflectionProbeTimeSlicingMode.AllFacesAtOnce;
				ReflectionProbe2.timeSlicingMode = UnityEngine.Rendering.ReflectionProbeTimeSlicingMode.AllFacesAtOnce;
			}
			if (rtReflections.value == 2)
			{
				ReflectionProbe1.refreshMode = UnityEngine.Rendering.ReflectionProbeRefreshMode.OnAwake;
				ReflectionProbe2.refreshMode = UnityEngine.Rendering.ReflectionProbeRefreshMode.OnAwake;
				ReflectionProbe1.timeSlicingMode = UnityEngine.Rendering.ReflectionProbeTimeSlicingMode.AllFacesAtOnce;
				ReflectionProbe2.timeSlicingMode = UnityEngine.Rendering.ReflectionProbeTimeSlicingMode.AllFacesAtOnce;
			}

			mlX.sensitivityX = mouseX.value;
			mlY.sensitivityY = mouseY.value;

			start = false;
			settingsChanged = false;
		}

		//AudioListener.volume = volumeSlider.value;
	}

	public void ResolutionChanged()
	{
		resChanged = true;
	}

	public void SettingsHasChanged()
	{
		settingsChanged = true;
	}

	public void OnDragX(IDragHandler eventData)
	{
		mXinput.text = mouseX.value.ToString();
	}
	public void OnDragY(IDragHandler eventData)
	{
		mYinput.text = mouseY.value.ToString();
	}

}

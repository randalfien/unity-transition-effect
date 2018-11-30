using DG.Tweening;
using UnityEngine;

public class SwitchScript : MonoBehaviour {

	public GameObject Root1;
	public GameObject Root2;

	public GameObject Wiper;

	public Camera Camera1;
	public Camera Camera2;

	private bool _toggled;
	private bool _transitionActive;

	public bool Circle = false;
	private void Awake()
	{
		SetupCameras();
		
		Root1.SetActive(true);
		Root2.SetActive(false);
	}

	private void SetupCameras()
	{
		Camera1.clearFlags = CameraClearFlags.SolidColor;
		Camera1.depth = 0;
		Camera1.cullingMask = 1 << Root1.layer;
		
		Camera2.clearFlags = CameraClearFlags.Nothing;
		Camera2.depth = 1;
		Camera2.cullingMask = 1 << Root2.layer;
	}

	private void Update()
	{
		if (!_transitionActive && Input.GetKeyDown(KeyCode.Space))
		{
			ToggleTransition();
		}
	}

	private void ToggleTransition()
	{
		_toggled = !_toggled;	
		
		Root1.SetActive(true);
		Root2.SetActive(true);
		if (Circle)
		{
			var targetScale = !_toggled ? 11f : 0.001f;
			var startScale = !_toggled ? 0.001f : 11f;
			Wiper.transform.localScale = new Vector3(startScale,startScale,startScale);
			Wiper.transform.DOScale(targetScale, 1.5f).OnComplete(OnTransitionFinished);
		}
		else
		{
			Wiper.transform.position = new Vector3(_toggled ? 0 : -31, 0, -9f);
			Wiper.transform.DOMoveX(_toggled ? -31 : 0, 1.5f).OnComplete(OnTransitionFinished);
		}
		_transitionActive = true;
	}

	private void OnTransitionFinished()
	{
		_transitionActive = false;
		Root1.SetActive(!_toggled);
		Root2.SetActive(_toggled);
	}
}

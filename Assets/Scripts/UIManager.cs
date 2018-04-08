using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GoogleARCore.HelloAR;

public class UIManager : MonoBehaviour {

	public Image toast;
	public GameObject confirmPosition;
	public GameObject addCapture;
	public GameObject shareScreen;
	public GameObject arController;

	void Start(){
		confirmPosition.gameObject.SetActive (false);
		addCapture.gameObject.SetActive (false);
		shareScreen.gameObject.SetActive (false);
	
	}


	// Toast
	public void changeToast(string t){
		setToastActive();
		toast.sprite = Resources.Load<Sprite> ("toast-"+t);
	}

	public void toggleToastVisibility(){
		toast.gameObject.SetActive (!toast.gameObject.activeSelf);
	}

	public void setToastActive(){
		toast.gameObject.SetActive (true);
	}


	// ConfirmPosition
	public void toggleConfirmPositionVisibility(){
		confirmPosition.gameObject.SetActive (!confirmPosition.gameObject.activeSelf);
	}


	// Add and Capture
	public void toggleAddCaptureVisibility(){
		addCapture.gameObject.SetActive (!addCapture.gameObject.activeSelf);
	}

	public void setAddCaptureInactive(){
		addCapture.gameObject.SetActive (false);
	}

	// Share
	public void toggleShareScreenVisibility(){
		shareScreen.gameObject.SetActive (!shareScreen.gameObject.activeSelf);
	}

	void TogglePositioning(bool b)
	{
		arController.GetComponent<ARController> ().TelaUI = b;
	}
}

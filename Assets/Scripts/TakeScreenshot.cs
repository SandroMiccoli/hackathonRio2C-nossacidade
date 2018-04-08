using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.UI;
using System.IO;
using System.Security.AccessControl;

#if !UNITY_EDITOR && ( UNITY_ANDROID || UNITY_IOS )
using NativeGalleryNamespace;
#endif

public class TakeScreenshot : MonoBehaviour {

	public GameObject hideGameObject;
	public Image Img;
	private Texture2D t;

	public void TakeShot()
	{
		if (hideGameObject != null) hideGameObject.SetActive(false);
		StartCoroutine ("Capture");
	}

	IEnumerator Capture()
	{
		yield return new WaitForEndOfFrame ();

		t = ScreenCapture.CaptureScreenshotAsTexture();

		if (hideGameObject != null) hideGameObject.SetActive(true);
		NativeGallery.SaveImageToGallery (t, "rio2c",  "rio2c.jpg");
		getImage ();
	}

	public void getImage(){
//		Debug.Log (Application.dataPath);
		Texture2D tex = NativeGallery.LoadImageAtPath("/storage/emulated/0/DCIM/rio2c/rio2c.jpg");
		Sprite mySprite = Sprite.Create(tex, new Rect(0.0f, 0.0f, tex.width, tex.height), new Vector2(0.5f, 0.5f), 100.0f);
		Img.sprite = mySprite;
	}

}

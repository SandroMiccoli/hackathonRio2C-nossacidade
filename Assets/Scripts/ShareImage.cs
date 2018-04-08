using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.IO;

public class ShareImage : MonoBehaviour {

	private bool isProcessing = false;

	private string shareText  = "Fuck Yah\n";
	private string gameLink = "Download the game on play store at "+"\nhuehue.com";
	private string subject = "Rebus Guess The Movie Game";
	private string imageName = "rio2c"; // without the extension, for iinstance, MyPic 

	public void shareImage(){

		if(!isProcessing)
			StartCoroutine( ShareScreenshot() );

	}

	private IEnumerator ShareScreenshot(){
		isProcessing = true;
		yield return new WaitForEndOfFrame();

		Texture2D screenTexture = new Texture2D(1080, 1080,TextureFormat.RGB24,true);
		screenTexture.Apply();

//		byte[] dataToSave = Resources.Load<TextAsset>(imageName).bytes;
//		byte [] dataToSave = File.ReadAllBytes("/storage/emulated/0/DCIM/rio2c/rio2c.jpg");

//		string destination = Path.Combine(Application.persistentDataPath,System.DateTime.Now.ToString("yyyy-MM-dd-HHmmss") + ".png");
//		Debug.Log(destination);
//		File.WriteAllBytes(destination, dataToSave);

		if(!Application.isEditor)
		{

			AndroidJavaClass intentClass = new AndroidJavaClass("android.content.Intent");
			AndroidJavaObject intentObject = new AndroidJavaObject("android.content.Intent");
			intentObject.Call<AndroidJavaObject>("setAction", intentClass.GetStatic<string>("ACTION_SEND"));
			AndroidJavaClass uriClass = new AndroidJavaClass("android.net.Uri");
//			AndroidJavaObject uriObject = uriClass.CallStatic<AndroidJavaObject>("parse","file://" + destination);
			AndroidJavaObject uriObject = uriClass.CallStatic<AndroidJavaObject>("parse", "/storage/emulated/0/DCIM/rio2c/rio2c.jpg");
			intentObject.Call<AndroidJavaObject>("putExtra", intentClass.GetStatic<string>("EXTRA_STREAM"), uriObject);
			intentObject.Call<AndroidJavaObject>("putExtra", intentClass.GetStatic<string>("EXTRA_TEXT"), shareText + gameLink);
//			intentObject.Call<AndroidJavaObject>("putExtra", intentClass.GetStatic<string>("EXTRA_SUBJECT"), subject);
			intentObject.Call<AndroidJavaObject>("setType", "image/jpeg");
			AndroidJavaClass unity = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
			AndroidJavaObject currentActivity = unity.GetStatic<AndroidJavaObject>("currentActivity");

			currentActivity.Call("startActivity", intentObject);

		}

		isProcessing = false;

	}

}
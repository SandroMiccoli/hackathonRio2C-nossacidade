using UnityEngine;
using UnityEngine.SceneManagement;


public class MySceneManager : MonoBehaviour {

	public void loadScene(string scene)
	{
		SceneManager.LoadScene("Scenes/"+scene, LoadSceneMode.Single);
	}
}

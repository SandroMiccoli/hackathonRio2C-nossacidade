using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PartaGames.Android;

public class Permissions : MonoBehaviour {

	private static readonly string WRITE_EXTERNAL_STORAGE = "android.permission.WRITE_EXTERNAL_STORAGE";
	private static readonly string READ_EXTERNAL_STORAGE = "android.permission.WRITE_EXTERNAL_STORAGE";
	private static readonly string CAMERA = "android.permission.CAMERA";
	private static readonly string WRITE_INTERNAL_STORAGE = "android.permission.WRITE_INTERNAL_STORAGE";
	private static readonly string READ_INTERNAL_STORAGE = "android.permission.READ_INTERNAL_STORAGE";

	// Use this for initialization
	void Start () {
//		PermissionGranterUnity.GrantPermission(WRITE_INTERNAL_STORAGE, PermissionGrantedCallback);
		PermissionGranterUnity.GrantPermissions(new string[] {WRITE_INTERNAL_STORAGE, READ_INTERNAL_STORAGE, 
															  WRITE_EXTERNAL_STORAGE,READ_EXTERNAL_STORAGE,
															  CAMERA}, PermissionGrantedCallback);
//		PermissionGranterUnity.GrantPermissions(new string[] {WRITE_INTERNAL_STORAGE, READ_INTERNAL_STORAGE}, PermissionGranterUnity.PermissionRequestCallback);
//		PermissionGranterUnity.GrantPermission(READ_INTERNAL_STORAGE, PermissionGranterUnity.PermissionRequestCallback);
//		PermissionGranterUnity.GrantPermission (WRITE_EXTERNAL_STORAGE, PermissionGranterUnity.PermissionRequestCallback);
	}
	
	public void PermissionGrantedCallback(string permission, bool isGranted)
	{
//		text.text += "\nPermission granted: " + permission + ": " + (isGranted ? "Yes" : "No");
	}
}

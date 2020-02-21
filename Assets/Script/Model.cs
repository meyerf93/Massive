using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Model : MonoBehaviour
{
	public static Model controller;    
	public static ConfigScene confScene;

	// Start is called before the first frame update
	private void Awake()
	{
		
        if (controller == null)
        {
            DontDestroyOnLoad(gameObject);
            controller = this;
		}
        else if (controller != this)
        {
            Destroy(gameObject);
        }

		string file_path = "Massive_Cards.xml";      
		string path = "";
        if (Application.platform == RuntimePlatform.WindowsEditor || Application.platform == RuntimePlatform.OSXEditor
            || Application.platform == RuntimePlatform.WindowsPlayer || Application.platform == RuntimePlatform.OSXPlayer)
        {
            //Debug.Log("in windows or mac platform");
			path = Application.streamingAssetsPath + "/" + file_path;
        }
		else if (Application.platform == RuntimePlatform.Android)
        {
			//Debug.Log("in android platform");
			path = "Massive_Cards";
        }
        else if (Application.platform == RuntimePlatform.IPhonePlayer)
        {
            //Debug.Log("in iphone plateform");
			path = "file://"+ Application.streamingAssetsPath + "/" + file_path;
        }

        Debug.Log("path : " + path);


		confScene = new ConfigScene();
		confScene = ConfigScene.Load(path);
	}
	public ConfigScene GetConfigScene()
	{
		return confScene;
	}
}

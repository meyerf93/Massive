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

		confScene = new ConfigScene();
	}
	void Start()
    {
		string filepath = getPath("Assets/StreamingAssets/Massive_Cards.xml");
		Debug.Log(filepath);
		confScene = ConfigScene.Load("Assets/StreamingAssets/Massive_Cards.xml");
		Debug.Log(confScene.Cards.Count);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	public string getPath(string filename)
    {
		/*if (Application.platform == RuntimePlatform.WindowsEditor || Application.platform == RuntimePlatform.OSXEditor)
        {
			return "+filename;

            //Debug.Log("in windows or mac platform");
        }
        else if (Application.platform == RuntimePlatform.Android)
        {
			return "jar:file://"  + "!/assets/" + filename;

        }
        else if (Application.platform == RuntimePlatform.IPhonePlayer)
        {
            //Debug.Log("in iphone plateform");
			return "file://"  + "/" + filename;
         
        }*/
		return filename;
    }
}

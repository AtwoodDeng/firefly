using UnityEngine;
using System.Collections;

public class testMechSphere : MonoBehaviour {

	int tag = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI(){
		GUILayout.TextField( tag.ToString()  );
	}

	void OnTap(){
		tag ++;

	}

	void OnRec( PointCloudGesture gesture ){
		tag ++;
	}
}

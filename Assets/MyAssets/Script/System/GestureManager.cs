using UnityEngine;
using System.Collections;

public class GestureManager : MonoBehaviour {

	public PointCloudRegognizer pointCloudRec;

	// Use this for initialization
	void Awake () {
		if ( pointCloudRec == null )
		{
//			pointCloudRec = this.gameObject.AddComponent<PointCloudRegognizer>();
//			foreach( string path in Global.GESTURE_PATH )
//			{
//				pointCloudRec.AddTemplate( Resources.Load( path ) as PointCloudGestureTemplate );
//			}

		}
		
		pointCloudRec.EventMessageName = "OnRec";
		pointCloudRec.EventMessageTarget  = this.gameObject;

		pointCloudRec.MaxMatchDistance = 5f;
		pointCloudRec.MinDistanceBetweenSamples = 8f;
		
	}

	void OnRec( PointCloudGesture gesture )
	{

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

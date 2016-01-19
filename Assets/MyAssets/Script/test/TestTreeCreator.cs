using UnityEngine;
using System.Collections;

public class TestTreeCreator : MonoBehaviour {

	public GameObject TreePrefab;
	public int treeNum;
	public float Xrange = 100f ;
	public float Zrange = 3f;

	public float MainCameraSpeed = 1f;

	// Use this for initialization
	void Awake () {
	
		for ( int i = 0 ; i < treeNum ; ++i )
		{
			AddTree( Xrange , Zrange );
		}

	}

	void AddTree( float Xrange , float Zrange )
	{
		GameObject tree = Instantiate( TreePrefab ) as GameObject;
		Vector3 pos = tree.transform.position ;
		pos.x = Random.Range( 0 , Xrange );
		float z = pos.z = Random.Range( 0 , Zrange );
		tree.transform.position = pos;
		tk2dSprite sprite =	 tree.GetComponent<tk2dSprite>();
		sprite.color = new Color( 1 - z/Zrange/2 , 1 - z/Zrange/2 , 1 - z/Zrange/2 );

	}


	// Update is called once per frame
	void Update () {
		MoveCamera();
		TestMouse();

	}

	void MoveCamera() {
		Vector3 pos = Camera.main.transform.position ;
		pos.x += MainCameraSpeed;
		Camera.main.transform.position  = pos;
	}

	Camera mainCamera;
	public Vector3 mousePos;
	RaycastHit hit;
	void TestMouse() {
		if ( mainCamera == null )
			mainCamera = Camera.main;
		//		GUIDebug.add(ShowType.label , Screen.width + " " + Screen.height );
		
		mousePos = Input.mousePosition;
		mousePos.x -= Screen.width / 2;
		mousePos.y -= Screen.height / 2 ;
		mousePos.x *= mainCamera.orthographicSize / ( Screen.height / 2 ) ;
		mousePos.y *= mainCamera.orthographicSize / ( Screen.height / 2 ) ;
		// mousePos += mainCamera.transform.position;
		mousePos.z = Global.BstaticPosition.z;

		Vector3 dir = mousePos;
		dir.z = 1f;
		Ray ray = new Ray( mainCamera.transform.position , dir );
		if ( Physics.Raycast( ray , out hit ) )
		{
			Tree hitTree = hit.collider.gameObject.transform.parent.GetComponent<Tree>();
			if ( hitTree != null )
			{
				hitTree.Active();
			}
		}

	}

	void OnGUI()
	{
		GUILayout.TextField( "mouse Pos " + mousePos.ToString() );
	}

}

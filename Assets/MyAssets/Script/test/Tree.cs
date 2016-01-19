using UnityEngine;
using System.Collections;

public class Tree : MonoBehaviour {

	public ParticleSystem sparkPar;
	public GameObject blue;
	public float blueYRange = 1f;
	public float bluePossibility = 0.33f;
	public float sparkDuration = 0.5f;
	public float emitRate;

	// Use this for initialization
	void Awake () {
		Vector3 pos = blue.transform.position ;
		pos.y += Random.Range( -blueYRange , blueYRange );
		blue.transform.position = pos;
		blue.SetActive( false );
		if ( Random.Range( 0 , 1f ) < bluePossibility ) 
		{
			blue.SetActive( true );
		}
		emitRate = sparkPar.emissionRate;
	}

	float sparkTime = 0f;
	// Update is called once per frame
	void Update () {
		sparkTime += Time.deltaTime;
		if ( sparkTime > sparkDuration )
		{
			DisActive();
		}
	}

	public void Active()
	{
		sparkPar.emissionRate *= emitRate * 3f;
		sparkTime = 0f;
	}

	public void DisActive()
	{
		sparkPar.emissionRate = emitRate;
	}

}

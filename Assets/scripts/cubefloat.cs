using UnityEngine;
using System.Collections;

public class cubefloat : MonoBehaviour {
	
	public float speed,tilt;
	private Vector3 target = new Vector3(0,2.52f,0);

	// Update is called once per frame
	void Update () {
		transform.position = Vector3.MoveTowards (transform.position,target,Time.deltaTime*speed);
		if (transform.position == target && target.y!= 1.28f)
			target.y = 1.28f;
		else if (transform.position==target && target.y==1.28f)
			target.y = 2.52f;
	
		transform.Rotate (Vector3.up * Time.deltaTime * tilt);	
	}
}

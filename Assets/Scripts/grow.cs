using UnityEngine;
using System.Collections;

public class grow : MonoBehaviour {
	public Transform Snowman;

	void Awake(){
		Snowman = GetComponent<Transform> ();
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Space))
			Snowman.transform.localScale += new Vector3 (2f,2f,2f);

	}
}


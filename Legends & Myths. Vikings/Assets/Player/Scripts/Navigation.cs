using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Navigation : MonoBehaviour {

    public float moveSpeed = 0.001f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //Up
        if (Input.GetKey("w")){
            Vector3 vec = this.transform.position;
            vec.y = vec.y + moveSpeed;
            this.transform.position = vec;
        }
        //Down
        if (Input.GetKey("s"))
        {
            Vector3 vec = this.transform.position;
            vec.y = vec.y - moveSpeed;
            this.transform.position = vec;
        }
        //Left
        if (Input.GetKey("a")){
            Vector3 vec = this.transform.position;
            vec.x = vec.x - moveSpeed;
            this.transform.position = vec;
        }
        //Right
        if (Input.GetKey("d")){
            Vector3 vec = this.transform.position;
            vec.x = vec.x + moveSpeed;
            this.transform.position = vec;
        }

    }
}

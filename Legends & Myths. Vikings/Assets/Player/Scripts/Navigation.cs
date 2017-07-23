using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Navigation : MonoBehaviour
{

    public float moveSpeed = 0.001f;
    public bool moving = false;
    public bool battle = false;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        //World navigation
        if (!battle)
        {
            moving = false;
            //Up
            if (Input.GetKey("w"))
            {
                Vector3 vec = this.transform.position;
                vec.y = vec.y + moveSpeed;
                this.transform.position = vec;
                moving = true;
            }
            //Down
            if (Input.GetKey("s"))
            {
                Vector3 vec = this.transform.position;
                vec.y = vec.y - moveSpeed;
                this.transform.position = vec;
                moving = true;
            }
            //Left
            if (Input.GetKey("a"))
            {
                Vector3 vec = this.transform.position;
                vec.x = vec.x - moveSpeed;
                this.transform.position = vec;
                moving = true;
            }
            //Right
            if (Input.GetKey("d"))
            {
                Vector3 vec = this.transform.position;
                vec.x = vec.x + moveSpeed;
                this.transform.position = vec;
                moving = true;
            }
        }
        //Battle navigation
        else if (battle)
        {

        }
    }
}

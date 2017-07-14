using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerMoveInScene : MonoBehaviour {
    
    //public int level;
    public Vector3 destination;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player"){

            //Application.LoadLevel(level);
            collision.transform.position = destination;
        }
    }
}

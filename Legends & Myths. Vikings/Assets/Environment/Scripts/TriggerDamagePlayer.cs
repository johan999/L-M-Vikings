using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDamagePlayer : MonoBehaviour {

    public int damage = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<Stats>().healthPoints = collision.GetComponent<Stats>().healthPoints-damage;
            collision.GetComponent<Stats>().UpdateText();
        }
    }
}

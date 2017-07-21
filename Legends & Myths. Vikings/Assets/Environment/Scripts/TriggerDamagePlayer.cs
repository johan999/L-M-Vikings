using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDamagePlayer : MonoBehaviour {

    public int damage = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            PlayerInfo.data.healthPoints -= damage;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MonsterEncounter : MonoBehaviour
{

    public int monsterZone = 0;
    public int chance = 100;
   

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (GameObject.Find("Player").GetComponent<Navigation>().moving)
            {
                if (Random.Range(0, chance) == 0)
                {
                    SceneManager.LoadScene(1);
                }
            }
        }
    }
}
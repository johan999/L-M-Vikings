using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Battle : MonoBehaviour {

    Vector3 oldPos;
    GameObject worldSprite;


    //Detta ska hämtas från en databas
    public int enemyehp;
    public int enemyattack;
    public int enemyxp;



	// Use this for initialization
	void Start () {

        //Disable player world sprite
        worldSprite = GameObject.Find("PlayerSprite");
        worldSprite.SetActive(false);
        GameObject player = GameObject.Find("Player");
        player.GetComponent<Navigation>().battle = true;

        //Center the camera
        oldPos = player.transform.position;
        player.transform.position = new Vector3(0f, 0f, 0f);
	}


    void EnemyTurn()
    {
        if (enemyehp > 0)
        {
            Debug.Log("Höh, nu är det min tur");
            PlayerInfo.info.healthPoints -= enemyattack;
        }
        else
        {
            PlayerInfo.info.experience += enemyxp;
            LeaveBattle();
        }
    }

    void LeaveBattle()
    {
        worldSprite.SetActive(true);
        GameObject.Find("Player").transform.position = oldPos;
        GameObject.Find("Player").GetComponent<Navigation>().battle = false;
        SceneManager.LoadScene(0);
    }


    void OnGUI()
    {
        if (GameObject.Find("Player").GetComponent<Navigation>().battle)
        {
            GUI.Label(new Rect(10, 10, 200, 30), "Enemy Health: " + enemyehp);
            GUI.Label(new Rect(10, 500, 200, 30), "Player Health: " + PlayerInfo.info.healthPoints);
            GUI.Label(new Rect(10, 540, 200, 30), "Experience: " + PlayerInfo.info.experience);

            if (GUI.Button(new Rect(10, 580, 100, 30), "Attack"))
            {
                enemyehp -= PlayerInfo.info.attack;
                EnemyTurn();

            }

            if (GUI.Button(new Rect(10, 620, 100, 30), "Heal"))
            {
                PlayerInfo.info.healthPoints += 50;
                EnemyTurn();
            }

            if (GUI.Button(new Rect(10, 660, 100, 30), "Flee"))
            {
                LeaveBattle();
            }
        }
    }
}

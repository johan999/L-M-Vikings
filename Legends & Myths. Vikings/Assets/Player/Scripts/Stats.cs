using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Stats : MonoBehaviour {

    public int healthPoints;
    public int attack;
    public int defence;
    public int speed;

    public Text hp;

    void Start() {
        healthPoints = 100;
        attack = 10;
        defence = 5;
        speed = 12;
        UpdateText();
    }

    public void UpdateText()
    {
        hp.text = "HP: " + healthPoints.ToString();
    }


}

using UnityEngine;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class PlayerInfo : MonoBehaviour {

    public static PlayerInfo info;

    public int healthPoints;
    public int experience;
    public int attack;

    private void Awake()
    {

        if (info == null)
        {
            DontDestroyOnLoad(gameObject);
            info = this;
        }
        else if (info != this)
        {
            Destroy(gameObject);
        }
    }

    void OnGUI()
    {
        if (!GameObject.Find("Player").GetComponent<Navigation>().battle)
        {
            GUI.Label(new Rect(10, 10, 100, 30), "Health: " + healthPoints);
            GUI.Label(new Rect(10, 40, 100, 30), "Experience: " + experience);

            if (GUI.Button(new Rect(10, 70, 100, 30), "Save"))
            {
                Save();
            }
            if (GUI.Button(new Rect(10, 100, 100, 30), "Load"))
            {
                Load();
            }
        }
    }

    public void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/playerInfo.dat");

        PlayerData data = new PlayerData();
        data.healthPoints = healthPoints;
        data.experience = experience;
        data.attack = attack;
        data.playerXPos = this.transform.position.x;
        data.playerYPos = this.transform.position.y;
        data.playerZPos = this.transform.position.z;


        bf.Serialize(file, data);
        file.Close();
    }

    public void Load()
    {
        if(File.Exists(Application.persistentDataPath + "/playerInfo.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/playerInfo.dat", FileMode.Open);
            PlayerData data = (PlayerData)bf.Deserialize(file);

            healthPoints = data.healthPoints;
            experience = data.experience;
            attack = data.attack;

            this.transform.position = new Vector3(data.playerXPos, data.playerYPos, data.playerZPos);
        }
    }
}

[Serializable]
class PlayerData
{
    public int healthPoints;
    public int experience;
    public int attack;
    public float playerXPos;
    public float playerYPos;
    public float playerZPos;
}
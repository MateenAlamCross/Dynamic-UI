using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.Networking;
public class JsonHandler : MonoBehaviour
{
    public TextAsset jsonData;

    [System.Serializable]
    public class Player
    {
        public String name;
        public String code;
        // public String code;
    }
    [System.Serializable]
    public class PlayerList
    {
        public Player[] country;
    }
    public PlayerList players = new PlayerList();

    private void Start()
    {
        // Debug.Log(JsonUtility.FromJson(string jsonData.text));
       players = JsonUtility.FromJson<PlayerList>(jsonData.text);
       //
       for (int i = 0; i < players.country.Length; i++)
       {
           Debug.Log("Country Name: " + players.country[i].name);
       }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    public TextAsset jsonData;
    public RawImage saved;
    public static string folderName = "images";
    static string imageName = "saved.png";
    static string imagePath =  folderName + "/" + imageName;

    public string url = "C:/Users/Administrator/Dynamic UI/Assets/images/saved.png";
    // private Texture2D texture;
    // Texture2D texture = AssetDatabase.LoadAssetAtPath<Texture2D>(imagePath);
    private void Awake()
    {
        // texture = Resources.Load<Texture2D>(imagePath);

    }

    // public string imageUrl = Assets/images/saved.png;
    [System.Serializable]
    public class JsonData
    {
        public MainMenu[] data;
    }
    [System.Serializable]
    public class MainMenu
    {
        public string mainCategoryName;
        public string mainCategoryImage;
    }
    public JsonData players = new JsonData();
    // Texture2D texture = AssetDatabase.LoadAssetAtPath<Texture2D>(imageUrl);

    private void Start()
    {
        byte[] bytes = File.ReadAllBytes(url);
        Texture2D texture = new Texture2D(2, 2);
        texture.LoadImage(bytes);

        JsonData jsn = JsonUtility.FromJson<JsonData>(jsonData.text);
        Debug.Log("Country Name: " + jsn.data[0].mainCategoryName);
        Debug.Log("Country Name: " + jsn.data[0].mainCategoryImage);
        Debug.Log("Country Name: " + jsn.data.Length);
        // saved.sprite = jsn.data[0].mainCategoryImage;
        saved.texture = texture;
        // RawImage rawImage = GetComponent<RawImage>();
        // rawImage.texture = texture;

    }
  
}

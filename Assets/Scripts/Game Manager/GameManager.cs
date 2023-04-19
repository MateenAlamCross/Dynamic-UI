using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    // public RawImage saved;
    // public Image img;

    

    string jsonURL= "https://mateenalamcross.github.io/DynamicUIApi/DynamicApi.json";
    
    string jsonString;

    [SerializeField]
    public RootModel rootModel;

    public RootObject jsonData;

    // public List<Datum> dataList;
    private void OnEnable()
    {
        if (instance == null)
        {
            instance = this;
        }

        GetData();

    }
    
    public void GetData()
    {
    StartCoroutine(FetchData());
    
    }
    public IEnumerator FetchData()
    {
        using (UnityWebRequest request = UnityWebRequest.Get(jsonURL))
        {
            yield return request.SendWebRequest();

    
            if (request.result == UnityWebRequest.Result.Success)
            {
                Debug.Log(request.result);
                
                jsonString = request.downloadHandler.text;
                Debug.Log(jsonString);
                Debug.Log(jsonURL);
              
                
                rootModel = JsonConvert.DeserializeObject<RootModel>(jsonString);
           
                PostData();
                for (int i = 0; i < GameManager.instance.rootModel.data.Count; i++)
                {
                    //Debug.Log(rootModel.data[i].mainCategoryName);
                }
              

            }
            else
            {
                Debug.Log(request.error);
              
            }
        }
    }
    public void PostData()
    {
        Debug.Log(rootModel.data.Count);
        // Debug.Log(jsonData.data.Count);
        // jsonData.data.Count = rootModel.data.Count;
        // jsonData.data.Add(rootModel.data);
        // jsonData.data.Append(rootModel.data.ToArray()); = rootModel.data.ToArray();
        // jsonData.data = new List<Data>(rootModel.data.Count);
        // gameData.data = new List<Data>(rootModel.data.Count);
        // gameData.data = new Data[rootModel.data.Count];
        jsonData.data = new Data[rootModel.data.Count];
        Debug.Log(jsonData.data);
        Debug.Log(jsonData.data.Length);
        // int count = rootModel.data.Count;
        // jsonData.data.Length = count;
        // Debug.Log(gameData.data.Count);

//        gameData.datalist = new Datum[myData.Count];
        //  System.Convert.ToInt32(jsonData.data.Count);
        //  jsonData.data.ToArray();
        // Debug.Log(System.Convert.ToInt32(jsonData.data.Count));

        
        jsonData.data[0].mainCategoryName = rootModel.data[0].mainCategoryName.ToString();

        for (int i = 0; i < rootModel.data.Count; i++)
        {
            Debug.Log(rootModel.data[i].mainCategoryName);
            Debug.Log(i);
            jsonData.data[i].mainCategoryName = rootModel.data[i].mainCategoryName.ToString();
            jsonData.data[i].mainCategoryImage = rootModel.data[i].mainCategoryImage.ToString();
            jsonData.data[i].height = rootModel.data[i].height;
            jsonData.data[i].width = rootModel.data[i].width;
            jsonData.data[i].hasSubcategory = rootModel.data[i].hasSubCategory;
            //
            // foreach (var VARIABLE in rootModel.data[i].subCategory)
            // {
            //     // jsonData.data[i].subCategory.Add((VARIABLE.items[i].paymentType.ToString()));
            // }
        }

    }

    
    
    [System.Serializable]
    public class Item
    {
        public string paymentType;
        public int price;
        public string icon;
        public string itemsImage;
    }
    [System.Serializable]
    public class SubCategory
    {
        public string subCategory;
        public List<Item> items;
        public string subCategoryName;
        public string subCategoryImage;
        public int? width;
        public int? height;
        public string paymentType;
        public int? price;
        public string icon;
    }
    [System.Serializable]
    public class Data
    {
        public string mainCategoryName;
        public string mainCategoryImage;
        public long width;
        public long height;
        public bool hasSubcategory;
        // public List<SubCategory> subCategory;
    }
    [System.Serializable]
    public class RootObject
    {
        // public List<Data> data;
        public Data[] data;
    }

}













// model = JsonUtility.FromJson<RootModel>(request.downloadHandler.text);
                // Debug.Log(model.data[0].mainCategoryName);

                // // RootModel inventory = new RootModel();
                // JSONDataModel.RootObject inventory = GetComponent<JSONDataModel.RootObject>();
                //  // inventory = JsonUtility.FromJson<RootModel>(jsonString);
                //  inventory = JsonUtility.FromJson<JSONDataModel.RootObject>(jsonString);
                // Debug.Log(inventory.data[0].mainCategoryName);
                
                // playerStat = JsonUtility.FromJson<JSONDataModel.RootObject>(request.downloadHandler.text);
                // playerStat = JsonUtility.FromJson<JSONDataModel.RootObject>(request.downloadHandler.text);
                 // playerS = JsonUtility.FromJson<JSONDataModel.Data>(request.downloadHandler.text);
                // playerStat = JsonUtility.FromJson<JSONDataModel.RootObject>(request.downloadHandler.data);
                // Debug.Log(playerS.mainCategoryName);

                // Debug.Log(playerStat.data[1].mainCategoryName);
                // playerStatusPanel.transform.GetChild(0).GetComponent<Text>().text = playerStat.playerName;
                // playerStatusPanel.transform.GetChild(1).GetComponent<Text>().text = "HP : " + playerStat.hp.ToString();
                // playerStatusPanel.transform.GetChild(2).GetComponent<Text>().text = "MP : " + playerStat.mp.ToString();
                // playerStatusPanel.transform.GetChild(3).GetComponent<Text>().text = "Attack : " + playerStat.atk.ToString();
                // playerStatusPanel.transform.GetChild(4).GetComponent<Text>().text = "Defende : " + playerStat.def.ToString();
                // playerStatusPanel.transform.GetChild(5).GetComponent<Text>().text = "Agility : " + playerStat.agi.ToString();
                
                
                
                
                
                
//     public IEnumerator JsonRequest()
//     {
//         UnityWebRequest web = UnityWebRequest.Get(jsonURL);
//         yield return web.SendWebRequest();
//
//
//         if (web.result == UnityWebRequest.Result.Success)
//         {
//             jsonString = web.downloadHandler.text;
//             jsonLoaded = true;
//             Debug.Log("SUCCESSFUL");
//             ReadJSONFile();
//             
//         }
//         else
//         {
//             Debug.Log("UNSUCCESSFUL");
//             jsonLoaded = false;
//         }
//
//     }
//     private void ReadJSONFile()
//     {
//         JSONDataModel.RootObject jsonObj= JsonUtility.FromJson<JSONDataModel.RootObject>(jsonString);
//         // PlayerManager.data=jsonObj.data;
//         PlayerManager.data=jsonObj.data;
//     }
//     public string jsonurl = "https://mateenalamcross.github.io/DynamicUIApi/DynamicApi.json";
//    
//
//     // public static JSONDataModel.RootObject CreateFromJSON(string json){
//     //
//     //     JSONDataModel.RootObject apparel = JsonUtility.FromJson <JSONDataModel.RootObject> (json);
//     //
//     //
//     //     return apparel;
//     //
//     // }
//
//
//
//
// }








// void Prime(){
//     string url = jsonurl;
//     WWW www = new WWW(url);
//     StartCoroutine(WaitForContentJSON(www));
//
//
// }
//
// IEnumerator WaitForContentJSON(WWW contentData)
// {
//     yield return contentData;
//
//     string json_string = contentData.text;
//     var JSONDATA = CreateFromJSON(json_string);
//
//
//     GameObject buttonTemplate = transform.GetChild(0).gameObject;
//     GameObject objectInstance;
//     
//     for (int i = 0; i < JSONDATA.data.Length; i++)
//     {
//         objectInstance = Instantiate(buttonTemplate, transform);
//         Texture2D myTexture = Resources.Load(JSONDATA.data[i].mainCategoryImage) as Texture2D;
//         // Debug.Log(g.transform);
//         Debug.Log(JSONDATA.data[i].mainCategoryImage);
//         objectInstance.transform.GetComponent<Image>().sprite = Sprite.Create(myTexture,
//             new Rect(0, 0, myTexture.width, myTexture.height), new Vector2(0.5f, 0.5f));
//     }
//
//     Destroy(buttonTemplate);
// }



// [System.Serializable]
// public class JsonData
// {
//     public MainMenu[] data;
// }
// [System.Serializable]
// public class MainMenu
// {
//     public string mainCategoryName;
//     public string mainCategoryImage;
//     public int width;
//     public int height;
// }
// public JsonData players = new JsonData();



// private void Start()
// {
//     
//     Prime();
//     // var JSONDATA = CreateFromJSON(url);
//     // GameObject buttonTemplate = transform.GetChild(0).gameObject;
//     // GameObject objectInstance;
//     //
//     // // JsonData jsn = JsonUtility.FromJson<JsonData>(jsonData.text);
//     //
//     // for (int i = 0; i < JSONDATA.data.Length; i++)
//     // {
//     //     objectInstance = Instantiate(buttonTemplate, transform);
//     //     Texture2D myTexture = Resources.Load(JSONDATA.data[i].mainCategoryImage) as Texture2D;
//     //     // Debug.Log(g.transform);
//     //     Debug.Log(JSONDATA.data[i].mainCategoryImage);
//     //     objectInstance.transform.GetComponent<Image>().sprite =Sprite.Create (myTexture, new Rect (0, 0, myTexture.width, myTexture.height), new Vector2 (0.5f,0.5f));
//     // }
//   
//     //for (int i = 0; i < jsn.data.Length; i++)
//     // {
//     //     objectInstance = Instantiate(buttonTemplate, transform);
//     //     Texture2D myTexture = Resources.Load(jsn.data[i].mainCategoryImage) as Texture2D;
//     //     // Debug.Log(g.transform);
//     //     Debug.Log(jsn.data[i].mainCategoryImage);
//     //     objectInstance.transform.GetComponent<Image>().sprite =Sprite.Create (myTexture, new Rect (0, 0, myTexture.width, myTexture.height), new Vector2 (0.5f,0.5f));
//     // }
//     // Destroy(buttonTemplate);
//     
// }



//***//*****
// for (int i = 0; i < jsn.data.Length; i++)
        // {
        //     Debug.Log("Category Name: " + jsn.data[i].mainCategoryName);
        //     Debug.Log("Category path: " + jsn.data[i].mainCategoryImage);
        //     Texture2D myTexture = Resources.Load(jsn.data[i].mainCategoryImage) as Texture2D;
        //     img.sprite = Sprite.Create (myTexture, new Rect (0, 0, myTexture.width, myTexture.height), new Vector2 (0.5f,0.5f));
        //
        // }
        // Debug.Log("Category Name: " + jsn.data[0].mainCategoryName);
        // Debug.Log("Category path: " + jsn.data[0].mainCategoryImage);
        // Debug.Log("Objects Length: " + jsn.data.Length);
        // Texture2D myTexture = Resources.Load(jsn.data[0].mainCategoryImage) as Texture2D;
        // // saved.texture = myTexture(jsn.data[0].height);
        // img.sprite = Sprite.Create (myTexture, new Rect (0, 0, myTexture.width, myTexture.height), new Vector2 (0.5f,0.5f));
        // img.sprite = Sprite.Create (myTexture, new Rect (0, 0, jsn.data[0].width, jsn.data[0].height), new Vector2 (0.5f,0.5f));
        






//////////////////////

// saved.sprite = jsn.data[0].mainCategoryImage;
// saved.texture = Resources.Load ("images/saved") as Texture2D;
// Texture2D texture = AssetDatabase.LoadAssetAtPath<Texture2D>(imageUrl);
// // byte[] bytes = File.ReadAllBytes(url);
//         // Texture2D texture = new Texture2D(2, 2);
//         // texture.LoadImage(bytes);
//         // RawImage rawImage = GetComponent<RawImage>();
//         // rawImage.texture = texture;
//         public static string folderName = "images";
//         static string imageName = "saved.png";
//         static string imagePath =  folderName + "/" + imageName;
//
//         public string url = "C:/Users/Administrator/Dynamic UI/Assets/images/saved.png";
//         // private Texture2D texture;
//         // Texture2D texture = AssetDatabase.LoadAssetAtPath<Texture2D>(imagePath);
//         private void Awake()
//         {
//             // texture = Resources.Load<Texture2D>(imagePath);
//
//         }
//
//         // public string imageUrl = Assets/images/saved.png;

// var jsonStr = JsonHelper.FromJson<rootModel.data>();
// rootModel = JsonConvert.DeserializeObject<RootModel>(jsonString);

// rootM = JsonConvert.DeserializeObject<RootModel>(jsonString);
// var model = GetComponent<JSONDataModel.RootObject>();
// model.data[0].mainCategoryName = rootModel.data[0].mainCategoryName;
// Debug.Log( model.data[0].mainCategoryName);
// Debug.Log(jsonStr[0].data[0].mainCategoryName);

// if (rootModel.data != null)
// {
//     Debug.Log(rootModel.data.Capacity);
//
// }
// Debug.Log(rootModel.data.Capacity);
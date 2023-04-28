using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;  //remove unused libs
public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    
    //JSON URL FOR Fetching Data
    string jsonURL= "https://mateenalamcross.github.io/DynamicUIApi/DynamicApi.json";
    

    [SerializeField]
    public RootModel rootModel;

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
                
                string jsonString = request.downloadHandler.text;
                Debug.Log(jsonString);
                Debug.Log(jsonURL);

                rootModel = JsonConvert.DeserializeObject<RootModel>(jsonString);
                
            }
            else
            {
                Debug.Log(request.error);
            }
        }
    }
}












//
//
//
//
// private void Start()
// {
//     SpawnCash.instance.DestroyAllSpawned();
//     SpawnCash.instance.DestroyAllSubMenuItems();
// }
//
// private void OnDisable()
// {
//     SpawnCash.instance.DestroyAllSpawned();
//     SpawnCash.instance.DestroyAllSubMenuItems();
// }
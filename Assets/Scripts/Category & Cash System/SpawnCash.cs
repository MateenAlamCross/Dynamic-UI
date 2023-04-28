using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine.Networking;
using UnityEngine.Serialization;
using UnityEngine.UI;


public class SpawnCash : MonoBehaviour
{
    public static SpawnCash instance;
    [Header("Payment Spawn Prefab")]
    public GameObject invetoryGameObject;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    
    public void DestroyAllSpawned()
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
    }

    public void DestroyAllSubMenuItems()
    {
        foreach (Transform child in GameObject.Find("Subcategory").transform)
        {
            Destroy(child.gameObject);
        }
    }

    public async void  SpawnPayment(string mainCategory, string subCategory = null)
    {
        foreach (var dataItem in GameManager.instance.rootModel.data)
        {
            if (dataItem.mainCategoryName == mainCategory)
            {
                if (dataItem.hasSubCategory && mainCategory == "hotItems")
                {
                    foreach (var subObj in dataItem.subCategory)
                    {
                        if (subObj.subCategoryName.ToString() == subCategory)
                        {
                            foreach (var obj in subObj.items)
                            {
                                
                                GameObject spawnedEntry = Instantiate(invetoryGameObject,
                                    GameObject.Find("All Inventory Objects").transform);

                                Texture2D paymentIcon = Resources.Load(obj.paymentType.ToString()) as Texture2D;
                                spawnedEntry.transform.GetChild(1).transform.GetComponent<Image>().sprite =
                                    Sprite.Create(paymentIcon,
                                        new Rect(0.0f, 0.0f, paymentIcon.width, paymentIcon.height),
                                        new Vector2(0.5f, 0.5f), 100.0f);

                                spawnedEntry.transform.GetChild(2).GetComponent<Text>().text = obj.price.ToString();
                                
                            }
                            int count = 0;
                            foreach (var item in subObj.items)
                            {
                                Texture2D objectTexture = new Texture2D(50, 50);

                                objectTexture = await GetRemoteTexture(item.icon.ToString());
                                gameObject.transform.GetChild(count).GetChild(3).GetComponent<Image>().sprite = Sprite.Create(objectTexture, 
                                    new Rect(0.0f, 0.0f, objectTexture.width, objectTexture.height), new Vector2(0.5f, 0.5f), 100.0f);
                                count++;
                            }
                        }
                    }
                }
                else
                {
                 
                    DestroyAllSubMenuItems();
                    foreach (var item in dataItem.subCategory)
                    {
                        GameObject spawnedEntry = Instantiate(invetoryGameObject,
                            GameObject.Find("All Inventory Objects").transform);

                        Texture2D paymentIcon = Resources.Load(item.paymentType.ToString()) as Texture2D;
                        spawnedEntry.transform.GetChild(1).transform.GetComponent<Image>().sprite =
                            Sprite.Create(paymentIcon,
                                new Rect(0.0f, 0.0f, paymentIcon.width, paymentIcon.height),
                                new Vector2(0.5f, 0.5f), 100.0f);

                        spawnedEntry.transform.GetChild(2).GetComponent<Text>().text = item.price.ToString();

                    }

                    int count = 0;
                    foreach (var item in dataItem.subCategory)
                    {
                        Texture2D objectTexture = new Texture2D(50, 50);

                        objectTexture = await GetRemoteTexture(item.icon.ToString());
                        gameObject.transform.GetChild(count).GetChild(3).GetComponent<Image>().sprite = Sprite.Create(objectTexture, 
                            new Rect(0.0f, 0.0f, objectTexture.width, objectTexture.height), new Vector2(0.5f, 0.5f), 100.0f);
                        count++;
                    }
                }
            }
        }
        gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(gameObject.GetComponent<RectTransform>().sizeDelta.x, gameObject.GetComponent<GridLayoutGroup>().preferredHeight);
    }

    public static async Task<Texture2D> GetRemoteTexture ( string url )
    {
        using( UnityWebRequest www = UnityWebRequestTexture.GetTexture(url) )
        {
            // begin request:
            var asyncOp = www.SendWebRequest();

            // await until it's done: 
            while( asyncOp.isDone==false )
                // await Task.Delay( 1000/30 );//30 hertz
                await Task.Delay( 1000/700 );
        
            // read results:
            if( www.isNetworkError || www.isHttpError )
            {
                #if DEBUG
                    Debug.Log( $"{www.error}, URL:{www.url}" );
                #endif
            
                // nothing to return on error:
                return null;
            }
            else
            {
                // return valid results:
                var objectTexture =  DownloadHandlerTexture.GetContent(www);

                return objectTexture;
            }
        }
    }
}










// Use of Only Synce But Showing Error like
//MissingReferenceException: The object of type 'GameObject' has been destroyed but you are still trying to access it.
// Your script should either check if it is null or you should not destroy the objec

// Texture2D objectTexture = new Texture2D(50, 50);
//
// objectTexture = await GetRemoteTexture(item.icon.ToString());
//         
// spawnedEntry.transform.GetChild(3).GetComponent<Image>().sprite = Sprite.Create(objectTexture, 
//     new Rect(0.0f, 0.0f, objectTexture.width, objectTexture.height), new Vector2(0.5f, 0.5f), 100.0f);
// spawnedEntry.transform.GetChild(3).GetComponent<Image>().sprite = Sprite.Create(objectTexture, 
//     new Rect(0.0f, 0.0f, objectTexture.width, objectTexture.height), new Vector2(0.5f, 0.5f), 100.0f);




//StartCoroutine(GetRemoteTexture(obj.icon.ToString(),img));
// spawnedEntry.transform.GetChild(3).GetComponent<Image>().sprite = Sprite.Create(img,
// new Rect(0.0f, 0.0f, img.width, img.height), new Vector2(0.5f, 0.5f), 100.0f);



// StartCoroutine(GetRemoteTexture(obj.icon.ToString()));
//
// IEnumerator GetRemoteTexture(string url)
// {
//     UnityWebRequest request = UnityWebRequestTexture.GetTexture(url);
//     yield return request.SendWebRequest();
//     if (request.isNetworkError || request.isHttpError)
//         Debug.Log(request.error);
//     else
//         objectTexture = ((DownloadHandlerTexture)request.downloadHandler).texture;
//
//     spawnedEntry.transform.GetChild(3).GetComponent<Image>().sprite = Sprite.Create(
//         objectTexture,
//         new Rect(0.0f, 0.0f, objectTexture.width, objectTexture.height),
//         new Vector2(0.5f, 0.5f), 100.0f);
// }





// StartCoroutine(GetRemoteTexture(item.icon.ToString()));
//
// IEnumerator  GetRemoteTexture(string url)
//  {
//      UnityWebRequest request = UnityWebRequestTexture.GetTexture(url);
//      yield return request.SendWebRequest();
//      if(request.isNetworkError || request.isHttpError) 
//          Debug.Log(request.error);
//      else
//          objectTexture =  ((DownloadHandlerTexture) request.downloadHandler).texture;
//      
//      spawnedEntry.transform.GetChild(3).GetComponent<Image>().sprite = Sprite.Create(objectTexture, 
//          new Rect(0.0f, 0.0f, objectTexture.width, objectTexture.height), new Vector2(0.5f, 0.5f), 100.0f);
//  }
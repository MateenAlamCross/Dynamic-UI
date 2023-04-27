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
    [FormerlySerializedAs("spawned")] [Header("Is Spawned")]
    public bool canBeSpawn ;
    [Header("Payment Spawn")]
    public GameObject invetoryGameObject;

    public Image objImage;
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

    public void SpawnPayment(string mainCategory, string subCategory = null)
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

                                Texture2D img1 = Resources.Load(obj.paymentType.ToString()) as Texture2D;
                                spawnedEntry.transform.GetChild(1).transform.GetComponent<Image>().sprite =
                                    Sprite.Create(img1, new Rect(0.0f, 0.0f, img1.width, img1.height),
                                        new Vector2(0.5f, 0.5f), 100.0f);

                                spawnedEntry.transform.GetChild(2).GetComponent<Text>().text = obj.price.ToString();
                              
                                Texture2D img= new Texture2D(50,50);
                                //StartCoroutine(GetRemoteTexture(obj.icon.ToString(),img));
                                // var objImage =  img as Texture2D;
                                // spawnedEntry.transform.GetChild(3).GetComponent<Image>().sprite = Sprite.Create(objImage,
                                //     new Rect(0.0f, 0.0f, img.width, img.height), new Vector2(0.5f, 0.5f), 100.0f);
                                // spawnedEntry.transform.GetChild(3).GetComponent<Image>().sprite = Sprite.Create(img,
                                    // new Rect(0.0f, 0.0f, img.width, img.height), new Vector2(0.5f, 0.5f), 100.0f);
                                    
                                    StartCoroutine(GetRemoteTexture(obj.icon.ToString()));
                                    IEnumerator  GetRemoteTexture(string url)
                                    {
                                        UnityWebRequest request = UnityWebRequestTexture.GetTexture(url);
                                        yield return request.SendWebRequest();
                                        if(request.isNetworkError || request.isHttpError) 
                                            Debug.Log(request.error);
                                        else
                                            img =  ((DownloadHandlerTexture) request.downloadHandler).texture;
                                        Debug.Log(img);
                             
                                        spawnedEntry.transform.GetChild(3).GetComponent<Image>().sprite = Sprite.Create(img, 
                                            new Rect(0.0f, 0.0f, img.width, img.height), new Vector2(0.5f, 0.5f), 100.0f);;
                                    }
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
                        Texture2D img1 = Resources.Load(item.paymentType.ToString()) as Texture2D;
                        spawnedEntry.transform.GetChild(1).transform.GetComponent<Image>().sprite =
                            Sprite.Create(img1, new Rect(0.0f, 0.0f, img1.width, img1.height),
                                new Vector2(0.5f, 0.5f), 100.0f);

                        spawnedEntry.transform.GetChild(2).GetComponent<Text>().text = item.price.ToString();
                        
                        Texture2D img= new Texture2D(50,50);

                        StartCoroutine(GetRemoteTexture(item.icon.ToString()));
                        
                        //  StartCoroutine(GetRemoteTexture(item.icon.ToString(),img));
                        
                         IEnumerator  GetRemoteTexture(string url)
                         {
                             UnityWebRequest request = UnityWebRequestTexture.GetTexture(url);
                             yield return request.SendWebRequest();
                             if(request.isNetworkError || request.isHttpError) 
                                 Debug.Log(request.error);
                             else
                                 img =  ((DownloadHandlerTexture) request.downloadHandler).texture;
                             Debug.Log(img);
                             
                             spawnedEntry.transform.GetChild(3).GetComponent<Image>().sprite = Sprite.Create(img, 
                                 new Rect(0.0f, 0.0f, img.width, img.height), new Vector2(0.5f, 0.5f), 100.0f);;
                         }
                         
                    }
                }
            }
        }
    }

    IEnumerator SetInventoryViewSize()
    {
        yield return new WaitForSeconds(2f);
        gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(gameObject.GetComponent<RectTransform>().sizeDelta.x, gameObject.GetComponent<GridLayoutGroup>().preferredHeight);

    }
    
}



















// IEnumerator  GetRemoteTexture(string url)
// {
//     UnityWebRequest request = UnityWebRequestTexture.GetTexture(url);
//     yield return request.SendWebRequest();
//     if(request.isNetworkError || request.isHttpError) 
//         Debug.Log(request.error);
//     else
//         img =  ((DownloadHandlerTexture) request.downloadHandler).texture;
//     Debug.Log(img);
//     objImage.sprite = Sprite.Create(img as Texture2D, 
//         new Rect(0.0f, 0.0f, img.width, img.height), new Vector2(0.5f, 0.5f), 100.0f);
//
//
//     // UnityWebRequest request = UnityWebRequestTexture.GetTexture(url);
//     // yield return request.SendWebRequest();
//     // if(request.isNetworkError || request.isHttpError) 
//     //     Debug.Log(request.error);
//     // else{
//     //     // ImageComponent.texture = ((DownloadHandlerTexture) request.downloadHandler).texture;
//     //
//     //     Texture2D tex = ((DownloadHandlerTexture) request.downloadHandler).texture;
//     //     Debug.Log("Tex: " + tex.name.ToString());
//     //     img = Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height), new Vector2(0.5f, 0.5f),100.0f);
//     // }
// }









// objectToBuy = Resources.Load(subItem.icon.ToString()) as Texture2D;
// objectToBuy = objectToBuy[subItem] as Texture2D;
// spawnedEntry.transform.GetChild(3).transform.GetComponent<Image>().sprite = Sprite.Create(objectToBuy, new Rect(0.0f,0.0f,objectToBuy.width,objectToBuy.height),new Vector2(0.5f,0.5f), 100.0f);
// Texture2D buyObject = Resources.Load(subItem.icon.ToString()) as Texture2D;










///////For the Hot Button
///         // if (spawned == true)
        // {
        //     
        //     GameObject SpawnGameObject = Instantiate(invetoryGameObject, GameObject.Find("All Inventory Objects").transform);
        //     GameObject buttonTemplate = transform.GetChild(0).gameObject;
        //     GameObject objectInstance;
        //     
        //         
        //     for (int i = 0; i < GameManager.instance.rootModel.data.Count; i++)
        //     {
        //         if (GameManager.instance.rootModel.data[i].mainCategoryName == name )
        //         // if (GameManager.instance.rootModel.data[i].mainCategoryName == "hotItems" )
        //         {
        //             int count = GameManager.instance.rootModel.data[i].subCategory.Count;
        //             for (int j = 0; j < count; j++)
        //             {
        //                 if (GameManager.instance.rootModel.data[i].hasSubCategory)
        //                     {
        //                         if(GameManager.instance.rootModel.data[i].subCategory[j].subCategoryName == "all")
        //                         {
        //                             for (int k = 0; k < GameManager.instance.rootModel.data[i].subCategory[j].items.Count; k++)
        //                             {
        //
        //
        //                                 objectInstance = Instantiate(buttonTemplate, transform);
        //                                 objectInstance.SetActive(true);
        //                                 
        //                                 
        //                                 // Payment Icon Refrence Passing
        //                               var paymentTypeIcon = Resources.Load(GameManager.instance.rootModel.data[i].subCategory[j]
        //                               .items[k].paymentType.ToString()) as Texture2D;
        //                               var paymentSprite = Sprite.Create(paymentTypeIcon, new Rect(0.0f,0.0f,paymentTypeIcon.width,paymentTypeIcon.height), new Vector2(0.5f,0.5f), 100.0f);
        //
        //                               objectInstance.transform.GetChild(1).GetComponent<Image>().sprite = paymentSprite;
        //                               
        //
        //                               //Price In term of Coin & Diamonds
        //                                 objectInstance.transform.GetChild (2).GetComponent <Text> ().text = GameManager.instance.rootModel.data[i].subCategory[j].items[k].price.ToString();
        //
        //
        //                                 // Passing Objects references which User will Buy 
        //                                 Debug.Log(GameManager.instance.rootModel.data[i].subCategory[j].items[k].icon.ToString());
        //                                 // var objectBuyIcon = StartCoroutine("GetRemoteTexture(GameManager.instance.rootModel.data[i].subCategory[j].items[k].icon.ToString())");
        //                                 var objectBuyIcon = Resources.Load(GameManager.instance.rootModel.data[i].subCategory[j]
        //                                 .items[k].icon.ToString()) as Texture2D;

        //                                // var objectBuyIcon = await GetRemoteTexture(GameManager.instance.rootModel.data[i].subCategory[j].items[k].icon.ToString());

        //                                 // var tex = Resources.Load<Texture2D>("Sprites/transparent");
        //                                 var ObjectBuyIcon = Sprite.Create(objectBuyIcon, new Rect(0.0f,0.0f,objectBuyIcon.width,objectBuyIcon.height), new Vector2(0.5f,0.5f), 100.0f);
        //                                 objectInstance.transform.GetChild(3).GetComponent<Image>().sprite = ObjectBuyIcon;
        //                                 
        //                                 // Nameing the spawning Object In term of Coin  OR Diamond
        //                                 objectInstance.transform.gameObject.name = objectBuyIcon.name;
        //
        //                                 objectInstance.transform.GetChild(0).GetComponent<Image>().enabled = true;
        //
        //                                 objectInstance.transform.GetChild(1).GetComponent<Image>().enabled = true;
        //                                 objectInstance.transform.GetChild(2).GetComponent<Text>().enabled = true;
        //                                 objectInstance.transform.GetChild(3).GetComponent<Image>().enabled = true;
        //                             }
        //                         } 
        //                     }
        //                
        //                 
        //             }
        //         }
        //         Destroy(SpawnGameObject);
        //     }
        //     Destroy(buttonTemplate);
        //   
        // }
        // Just for Other Main Menu
         // public void SpawnJacket()
    // {
    //     if (spawned == true)
    //     {
    //         
    //         GameObject SpawnGameObject = Instantiate(invetoryGameObject, GameObject.Find("All Inventory Objects").transform);
    //
    //         GameObject buttonTemplate = transform.GetChild(0).gameObject;
    //         
    //         GameObject objectInstance;
    //             
    //         for (int i = 0; i < GameManager.instance.rootModel.data.Count; i++)
    //         {
    //             if (GameManager.instance.rootModel.data[i].mainCategoryName == "jacket" )
    //             {
    //                 int count = GameManager.instance.rootModel.data[i].subCategory.Count;
    //                 for (int j = 0; j < count; j++)
    //                 {
    //                  
    //                             objectInstance = Instantiate(buttonTemplate, transform);
    //
    //                             // Payment Icon Refrence Passing
    //                              var paymentTypeIcon = Resources.Load(GameManager.instance.rootModel.data[i].subCategory[j]
    //                                   .paymentType.ToString()) as Texture2D;
    //                                   var paymentSprite = Sprite.Create(paymentTypeIcon, new Rect(0.0f,0.0f,paymentTypeIcon.width,paymentTypeIcon.height), new Vector2(0.5f,0.5f), 100.0f);
    //
    //                                   objectInstance.transform.GetChild(1).GetComponent<Image>().sprite = paymentSprite;
    //                                   
    //
    //                                   //Price In term of Coin & Diamonds
    //                                     objectInstance.transform.GetChild (2).GetComponent <Text> ().text = GameManager.instance.rootModel.data[i].subCategory[j].price.ToString();
    //                                     
    //                                     // Passing Objects references which User will Buy 
    //                                     // Texture2D objectBuyIcon = Resources.Load(GameManager.instance.rootModel.data[i].subCategory[j]
    //                                     //     .items[k].icon.ToString()) as Texture2D; 
    //                                     var objectBuyIcon = Resources.Load(GameManager.instance.rootModel.data[i].subCategory[j]
    //                                         .icon.ToString()) as Texture2D; 
    //                                     // var tex = Resources.Load<Texture2D>("Sprites/transparent");
    //                                     var ObjectBuyIcon = Sprite.Create(objectBuyIcon, new Rect(0.0f,0.0f,objectBuyIcon.width,objectBuyIcon.height), new Vector2(0.5f,0.5f), 100.0f);
    //                                     objectInstance.transform.GetChild(3).GetComponent<Image>().sprite = ObjectBuyIcon;
    //                                     
    //                                     // Nameing the spawning Object In term of Coin  OR Diamond
    //                                     objectInstance.transform.gameObject.name = objectBuyIcon.name;
    //
    //                                     objectInstance.transform.GetChild(0).GetComponent<Image>().enabled = true;
    //
    //                                     objectInstance.transform.GetChild(1).GetComponent<Image>().enabled = true;
    //                                     objectInstance.transform.GetChild(2).GetComponent<Text>().enabled = true;
    //                                     objectInstance.transform.GetChild(3).GetComponent<Image>().enabled = true;
    //                 }
    //             }
    //            Destroy(SpawnGameObject);
    //         }
    //         Destroy(buttonTemplate);
    //     }
    //     spawned = false;
    // } 
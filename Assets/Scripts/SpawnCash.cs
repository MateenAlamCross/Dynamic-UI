using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using UnityEngine.Networking;
using UnityEngine.UI;

public class SpawnCash : MonoBehaviour
{
    public static SpawnCash instance;
    [Header("Is Spawned")]
    public bool spawned ;
    [Header("Payment Spawn")]
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

    // public void SpawnPayment(string name)
    // {
    //     if (spawned == true)
    //     {
    //         
    //         // GameObject newButton = new GameObject("Button");
    //         //
    //         // // add a button component to the game object
    //         // Button buttonComponent = newButton.AddComponent<Button>();
    //         // newButton.AddComponent<Image>();
    //         // newButton.transform.SetParent(GameObject.Find("All Inventory Objects").transform);
    //         GameObject SpawnGameObject = Instantiate(invetoryGameObject, GameObject.Find("All Inventory Objects").transform);
    //         // invetoryGameObject.transform.SetParent(GameObject.Find("All Inventory Objects").transform);
    //         GameObject buttonTemplate = transform.GetChild(0).gameObject;
    //         GameObject objectInstance;
    //             
    //         for (int i = 0; i < GameManager.instance.rootModel.data.Count; i++)
    //         {
    //             if (GameManager.instance.rootModel.data[i].mainCategoryName == name )
    //             // if (GameManager.instance.rootModel.data[i].mainCategoryName == "hotItems" )
    //             {
    //                 int count = GameManager.instance.rootModel.data[i].subCategory.Count;
    //                 for (int j = 0; j < count; j++)
    //                 {
    //                     if (GameManager.instance.rootModel.data[i].hasSubCategory)
    //                         {
    //                             if(GameManager.instance.rootModel.data[i].subCategory[j].subCategoryName == "all")
    //                             {
    //                                 // Debug.Log("Category Name = " + GameManager.instance.rootModel.data[i].subCategory[j].subCategoryName );
    //                                 for (int k = 0; k < GameManager.instance.rootModel.data[i].subCategory[j].items.Count; k++)
    //                                 {
    //
    //                                     objectInstance = Instantiate(buttonTemplate, transform);
    //                                     // Debug.Log("i : "+ i + ", j : "+ j+", K: "+ k);
    //                                     objectInstance.SetActive(true);
    //                                     
    //                                     
    //                                     // Payment Icon Refrence Passing
    //                                   Texture2D paymentTypeIcon = Resources.Load(GameManager.instance.rootModel.data[i].subCategory[j]
    //                                   .items[k].paymentType.ToString()) as Texture2D; 
    //                                   objectInstance.transform.GetChild(0).GetComponent<RawImage>().texture = paymentTypeIcon;
    //                                   
    //
    //                                   //Price In term of Coin & Diamonds
    //                                     objectInstance.transform.GetChild (1).GetComponent <Text> ().text = GameManager.instance.rootModel.data[i].subCategory[j].items[k].price.ToString();
    //                                     
    //                                     // Passing Objects references which User will Buy 
    //                                     Texture2D objectBuyIcon = Resources.Load(GameManager.instance.rootModel.data[i].subCategory[j]
    //                                         .items[k].icon.ToString()) as Texture2D; 
    //                                     objectInstance.transform.GetChild(2).GetComponent<RawImage>().texture = objectBuyIcon;
    //                                     
    //                                     // Nameing the spawning Object In term of Coin  OR Diamond
    //                                     objectInstance.transform.gameObject.name = objectBuyIcon.name;
    //
    //                                     
    //                                     objectInstance.transform.GetChild(0).GetComponent<RawImage>().enabled = true;
    //                                     objectInstance.transform.GetChild(1).GetComponent<Text>().enabled = true;
    //                                     objectInstance.transform.GetChild(2).GetComponent<RawImage>().enabled = true;
    //                                 }
    //                             } 
    //                         }
    //                    
    //                     
    //                 }
    //             }
    //             Destroy(SpawnGameObject);
    //         }
    //         Destroy(buttonTemplate);
    //         // Destroy(GameObject.Find("Payment Container(Clone)"));
    //
    //         //Destroy(invetoryGameObject);
    //     }
    //     spawned = false;
    // }
    public void SpawnPayment(string mainCategory , string subCategory)
    {
    if (spawned)
    {
        
        foreach (var dataItem in GameManager.instance.rootModel.data)
        {
            if (dataItem.mainCategoryName == mainCategory)
            {
                if (dataItem.hasSubCategory)
                {
                    foreach (var subItem in dataItem.subCategory)
                    {
                        if (subItem.subCategoryName == subCategory)
                        {

                            foreach (var item in subItem.items)
                            {
                                GameObject spawnedEntry = Instantiate(invetoryGameObject, GameObject.Find("All Inventory Objects").transform);
                                Texture2D paymentIcon = Resources.Load(item.paymentType.ToString()) as Texture2D;
                                spawnedEntry.transform.GetChild(1).transform.GetComponent<Image>().sprite = Sprite.Create(paymentIcon, new Rect(0.0f,0.0f,paymentIcon.width,paymentIcon.height), new Vector2(0.5f,0.5f), 100.0f);
                                spawnedEntry.transform.GetChild(2).transform.GetComponent<Text>().text = item.price.ToString();
                                Texture2D buyObject = Resources.Load(item.icon.ToString()) as Texture2D;
                                spawnedEntry.transform.GetChild(3).transform.GetComponent<Image>().sprite = Sprite.Create(buyObject, new Rect(0.0f,0.0f,buyObject.width,buyObject.height),new Vector2(0.5f,0.5f), 100.0f);
                        
                            }
                        }
        
                    }
                }
                
            }
            if (dataItem.mainCategoryName == mainCategory && !dataItem.hasSubCategory)
            {
                foreach (var subItem in dataItem.subCategory)
                {
                    Debug.Log(subItem.items);
                    foreach (var item in subItem.items)
                    {
                        Debug.Log(item);
                        GameObject spawnedEntry = Instantiate(invetoryGameObject, GameObject.Find("All Inventory Objects").transform);
                        Texture2D paymentIcon = Resources.Load(item.paymentType.ToString()) as Texture2D;
                        spawnedEntry.transform.GetChild(1).transform.GetComponent<Image>().sprite = Sprite.Create(paymentIcon, new Rect(0.0f,0.0f,paymentIcon.width,paymentIcon.height), new Vector2(0.5f,0.5f), 100.0f);
                        spawnedEntry.transform.GetChild(2).transform.GetComponent<Text>().text = item.price.ToString();
                        Texture2D buyObject = Resources.Load(item.icon.ToString()) as Texture2D;
                        spawnedEntry.transform.GetChild(3).transform.GetComponent<Image>().sprite = Sprite.Create(buyObject, new Rect(0.0f,0.0f,buyObject.width,buyObject.height),new Vector2(0.5f,0.5f), 100.0f);
                        
                    }
                }
            }
            
        }   
    }
        // if (spawned == true)
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
        //                                 // var objectBuyIcon = await GetRemoteTexture(GameManager.instance.rootModel.data[i].subCategory[j].items[k].icon.ToString());
        //
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
        spawned = false;
        Debug.Log(gameObject.GetComponent<GridLayoutGroup>().preferredHeight);
    }

    // IEnumerator GetRemoteTexture(string url)
    // {
    //     UnityWebRequest request = UnityWebRequestTexture.GetTexture(url);
    //     yield return request.SendWebRequest();
    //     if(request.isNetworkError || request.isHttpError) 
    //         Debug.Log(request.error);
    //     else
    //         ((DownloadHandlerTexture) request.downloadHandler).texture;
    //
    //
    // }
    public static async Task<Texture2D> GetRemoteTexture ( string url )
    {
        using( UnityWebRequest www = UnityWebRequestTexture.GetTexture(url) )
        {
            // begin request:
            var asyncOp = www.SendWebRequest();
    
            // await until it's done: 
            while( asyncOp.isDone==false )
                await Task.Delay( 1000/30 );//30 hertz
        
            // read results:
            if( www.isNetworkError || www.isHttpError )
                // if( www.result!=UnityWebRequest.Result.Success )// for Unity >= 2020.1
            {
                // log error:
                #if DEBUG
                                Debug.Log( $"{www.error}, URL:{www.url}" );
                #endif
            
                // nothing to return on error:
                return null;
            }
            else
            {
                // return valid results:
                return DownloadHandlerTexture.GetContent(www);
            }
        }
    }
    public void SpawnAll()
    {
        if (spawned == true)
        {
            

            // add a button component to the game object
            GameObject SpawnGameObject = Instantiate(invetoryGameObject, GameObject.Find("All Inventory Objects").transform);
            
            GameObject buttonTemplate = transform.GetChild(0).gameObject;
            GameObject objectInstance;
                
            for (int i = 0; i < GameManager.instance.rootModel.data.Count; i++)
            {
                if (GameManager.instance.rootModel.data[i].mainCategoryName == "hotItems" )
                // if (GameManager.instance.rootModel.data[i].mainCategoryName == "hotItems" )
                {
                    int count = GameManager.instance.rootModel.data[i].subCategory.Count;
                    for (int j = 0; j < count; j++)
                    {
                        if (GameManager.instance.rootModel.data[i].hasSubCategory)
                            {
                                if(GameManager.instance.rootModel.data[i].subCategory[j].subCategoryName == "all")
                                {
                                    // Debug.Log("Category Name = " + GameManager.instance.rootModel.data[i].subCategory[j].subCategoryName );
                                    for (int k = 0; k < GameManager.instance.rootModel.data[i].subCategory[j].items.Count; k++)
                                    {

                                        objectInstance = Instantiate(buttonTemplate, transform);
                                        // Debug.Log("i : "+ i + ", j : "+ j+", K: "+ k);
                                        
                                        // Debug.Log("all");
                                        
                                        
                                        // Payment Icon Refrence Passing
                                        var paymentTypeIcon = Resources.Load(GameManager.instance.rootModel.data[i].subCategory[j]
                                      .items[k].paymentType.ToString()) as Texture2D;
                                      var paymentSprite = Sprite.Create(paymentTypeIcon, new Rect(0.0f,0.0f,paymentTypeIcon.width,paymentTypeIcon.height), new Vector2(0.5f,0.5f), 100.0f);

                                      objectInstance.transform.GetChild(1).GetComponent<Image>().sprite = paymentSprite;
                                      

                                      //Price In term of Coin & Diamonds
                                        objectInstance.transform.GetChild (2).GetComponent <Text> ().text = GameManager.instance.rootModel.data[i].subCategory[j].items[k].price.ToString();
                                        
                                        // Passing Objects references which User will Buy 
                                        // Texture2D objectBuyIcon = Resources.Load(GameManager.instance.rootModel.data[i].subCategory[j]
                                        //     .items[k].icon.ToString()) as Texture2D; 
                                        var objectBuyIcon = Resources.Load(GameManager.instance.rootModel.data[i].subCategory[j]
                                            .items[k].icon.ToString()) as Texture2D; 
                                        // var tex = Resources.Load<Texture2D>("Sprites/transparent");
                                        var ObjectBuyIcon = Sprite.Create(objectBuyIcon, new Rect(0.0f,0.0f,objectBuyIcon.width,objectBuyIcon.height), new Vector2(0.5f,0.5f), 100.0f);
                                        objectInstance.transform.GetChild(3).GetComponent<Image>().sprite = ObjectBuyIcon;
                                        
                                        // Nameing the spawning Object In term of Coin  OR Diamond
                                        objectInstance.transform.gameObject.name = objectBuyIcon.name;

                                        objectInstance.transform.GetChild(0).GetComponent<Image>().enabled = true;

                                        objectInstance.transform.GetChild(1).GetComponent<Image>().enabled = true;
                                        objectInstance.transform.GetChild(2).GetComponent<Text>().enabled = true;
                                        objectInstance.transform.GetChild(3).GetComponent<Image>().enabled = true;
                                    }
                                } 
                            }
                       
                        
                    }
                }
               Destroy(SpawnGameObject);
            }
            Destroy(buttonTemplate);
        }
        spawned = false;

    }

    public void SpawnShirt()
    {
         if (spawned == true)
        {
            
            GameObject SpawnGameObject = Instantiate(invetoryGameObject, GameObject.Find("All Inventory Objects").transform);

            GameObject buttonTemplate = transform.GetChild(0).gameObject;
            
            GameObject objectInstance;
                
            for (int i = 0; i < GameManager.instance.rootModel.data.Count; i++)
            {
                if (GameManager.instance.rootModel.data[i].mainCategoryName == "shirt" )
                {
                    int count = GameManager.instance.rootModel.data[i].subCategory.Count;
                    for (int j = 0; j < count; j++)
                    {
                        // Debug.Log("Category Name = " + GameManager.instance.rootModel.data[i].subCategory.Count );
                         

                                objectInstance = Instantiate(buttonTemplate, transform);

                                // Payment Icon Refrence Passing
                                var paymentTypeIcon = Resources.Load(GameManager.instance.rootModel.data[i].subCategory[j]
                                      .paymentType.ToString()) as Texture2D;
                                      var paymentSprite = Sprite.Create(paymentTypeIcon, new Rect(0.0f,0.0f,paymentTypeIcon.width,paymentTypeIcon.height), new Vector2(0.5f,0.5f), 100.0f);

                                      objectInstance.transform.GetChild(1).GetComponent<Image>().sprite = paymentSprite;
                                      

                                      //Price In term of Coin & Diamonds
                                        objectInstance.transform.GetChild (2).GetComponent <Text> ().text = GameManager.instance.rootModel.data[i].subCategory[j].price.ToString();
                                        
                                        // Passing Objects references which User will Buy 
                                        // Texture2D objectBuyIcon = Resources.Load(GameManager.instance.rootModel.data[i].subCategory[j]
                                        //     .items[k].icon.ToString()) as Texture2D; 
                                        var objectBuyIcon = Resources.Load(GameManager.instance.rootModel.data[i].subCategory[j]
                                            .icon.ToString()) as Texture2D; 
                                        // var tex = Resources.Load<Texture2D>("Sprites/transparent");
                                        var ObjectBuyIcon = Sprite.Create(objectBuyIcon, new Rect(0.0f,0.0f,objectBuyIcon.width,objectBuyIcon.height), new Vector2(0.5f,0.5f), 100.0f);
                                        objectInstance.transform.GetChild(3).GetComponent<Image>().sprite = ObjectBuyIcon;
                                        
                                        // Nameing the spawning Object In term of Coin  OR Diamond
                                        objectInstance.transform.gameObject.name = objectBuyIcon.name;

                                        objectInstance.transform.GetChild(0).GetComponent<Image>().enabled = true;

                                        objectInstance.transform.GetChild(1).GetComponent<Image>().enabled = true;
                                        objectInstance.transform.GetChild(2).GetComponent<Text>().enabled = true;
                                        objectInstance.transform.GetChild(3).GetComponent<Image>().enabled = true;
                    }
                }
               Destroy(SpawnGameObject);
            }
            Destroy(buttonTemplate);
            
            // Debug.Log(transform.GetChild(0).gameObject);
            // Debug.Log(buttonTemplate);
        }
        spawned = false;
        
        // rectTransform.sizeDelta = new Vector2(rectTransform.sizeDelta.x, rect.height);
      

    }

    public void SpawnDress()
    {
        
    }
    public void SpawnHair()
    {
         if (spawned == true)
        {
            
            // add a button component to the game object
            GameObject SpawnGameObject = Instantiate(invetoryGameObject, GameObject.Find("All Inventory Objects").transform);
            
            GameObject buttonTemplate = transform.GetChild(0).gameObject;
            GameObject objectInstance;
                
            for (int i = 0; i < GameManager.instance.rootModel.data.Count; i++)
            {
                if (GameManager.instance.rootModel.data[i].mainCategoryName == "hotItems" )
                // if (GameManager.instance.rootModel.data[i].mainCategoryName == "hotItems" )
                {
                    int count = GameManager.instance.rootModel.data[i].subCategory.Count;
                    for (int j = 0; j < count; j++)
                    {
                        if (GameManager.instance.rootModel.data[i].hasSubCategory)
                            {
                                if(GameManager.instance.rootModel.data[i].subCategory[j].subCategoryName == "hair")
                                {
                                    // Debug.Log("Category Name = " + GameManager.instance.rootModel.data[i].subCategory[j].subCategoryName );
                                    for (int k = 0; k < GameManager.instance.rootModel.data[i].subCategory[j].items.Count; k++)
                                    {

                                        objectInstance = Instantiate(buttonTemplate, transform);
                                        // Debug.Log("i : "+ i + ", j : "+ j+", K: "+ k);
                                        
                                        // Debug.Log("all");
                                        
                                        
                                        // Payment Icon Refrence Passing
                                         var paymentTypeIcon = Resources.Load(GameManager.instance.rootModel.data[i].subCategory[j]
                                      .items[k].paymentType.ToString()) as Texture2D;
                                      var paymentSprite = Sprite.Create(paymentTypeIcon, new Rect(0.0f,0.0f,paymentTypeIcon.width,paymentTypeIcon.height), new Vector2(0.5f,0.5f), 100.0f);

                                      objectInstance.transform.GetChild(1).GetComponent<Image>().sprite = paymentSprite;
                                      

                                      //Price In term of Coin & Diamonds
                                        objectInstance.transform.GetChild (2).GetComponent <Text> ().text = GameManager.instance.rootModel.data[i].subCategory[j].items[k].price.ToString();
                                        
                                        // Passing Objects references which User will Buy 
                                        // Texture2D objectBuyIcon = Resources.Load(GameManager.instance.rootModel.data[i].subCategory[j]
                                        //     .items[k].icon.ToString()) as Texture2D; 
                                        var objectBuyIcon = Resources.Load(GameManager.instance.rootModel.data[i].subCategory[j]
                                            .items[k].icon.ToString()) as Texture2D; 
                                        // var tex = Resources.Load<Texture2D>("Sprites/transparent");
                                        var ObjectBuyIcon = Sprite.Create(objectBuyIcon, new Rect(0.0f,0.0f,objectBuyIcon.width,objectBuyIcon.height), new Vector2(0.5f,0.5f), 100.0f);
                                        objectInstance.transform.GetChild(3).GetComponent<Image>().sprite = ObjectBuyIcon;
                                        
                                        // Nameing the spawning Object In term of Coin  OR Diamond
                                        objectInstance.transform.gameObject.name = objectBuyIcon.name;

                                        objectInstance.transform.GetChild(0).GetComponent<Image>().enabled = true;

                                        objectInstance.transform.GetChild(1).GetComponent<Image>().enabled = true;
                                        objectInstance.transform.GetChild(2).GetComponent<Text>().enabled = true;
                                        objectInstance.transform.GetChild(3).GetComponent<Image>().enabled = true;
                                    }
                                } 
                            }
                       
                        
                    }
                }
               Destroy(SpawnGameObject);
            }
            Destroy(buttonTemplate);

        }
        spawned = false;
        
    } 
    
    public void SpawnOthers()
    {
         if (spawned == true)
        {
            
            // add a button component to the game object
            GameObject SpawnGameObject = Instantiate(invetoryGameObject, GameObject.Find("All Inventory Objects").transform);
            
            GameObject buttonTemplate = transform.GetChild(0).gameObject;
            GameObject objectInstance;
                
            for (int i = 0; i < GameManager.instance.rootModel.data.Count; i++)
            {
                if (GameManager.instance.rootModel.data[i].mainCategoryName == "hotItems" )
                // if (GameManager.instance.rootModel.data[i].mainCategoryName == "hotItems" )
                {
                    int count = GameManager.instance.rootModel.data[i].subCategory.Count;
                    for (int j = 0; j < count; j++)
                    {
                        if (GameManager.instance.rootModel.data[i].hasSubCategory)
                            {
                                if(GameManager.instance.rootModel.data[i].subCategory[j].subCategoryName == "others")
                                {
                                    // Debug.Log("Category Name = " + GameManager.instance.rootModel.data[i].subCategory[j].subCategoryName );
                                    for (int k = 0; k < GameManager.instance.rootModel.data[i].subCategory[j].items.Count; k++)
                                    {

                                        objectInstance = Instantiate(buttonTemplate, transform);
                                        // Debug.Log("i : "+ i + ", j : "+ j+", K: "+ k);
                                        
                                        // Debug.Log("all");
                                        
                                        
                                        // Payment Icon Refrence Passing
                                         var paymentTypeIcon = Resources.Load(GameManager.instance.rootModel.data[i].subCategory[j]
                                      .items[k].paymentType.ToString()) as Texture2D;
                                      var paymentSprite = Sprite.Create(paymentTypeIcon, new Rect(0.0f,0.0f,paymentTypeIcon.width,paymentTypeIcon.height), new Vector2(0.5f,0.5f), 100.0f);

                                      objectInstance.transform.GetChild(1).GetComponent<Image>().sprite = paymentSprite;
                                      

                                      //Price In term of Coin & Diamonds
                                        objectInstance.transform.GetChild (2).GetComponent <Text> ().text = GameManager.instance.rootModel.data[i].subCategory[j].items[k].price.ToString();
                                        
                                        // Passing Objects references which User will Buy 
                                        // Texture2D objectBuyIcon = Resources.Load(GameManager.instance.rootModel.data[i].subCategory[j]
                                        //     .items[k].icon.ToString()) as Texture2D; 
                                        var objectBuyIcon = Resources.Load(GameManager.instance.rootModel.data[i].subCategory[j]
                                            .items[k].icon.ToString()) as Texture2D; 
                                        // var tex = Resources.Load<Texture2D>("Sprites/transparent");
                                        var ObjectBuyIcon = Sprite.Create(objectBuyIcon, new Rect(0.0f,0.0f,objectBuyIcon.width,objectBuyIcon.height), new Vector2(0.5f,0.5f), 100.0f);
                                        objectInstance.transform.GetChild(3).GetComponent<Image>().sprite = ObjectBuyIcon;
                                        
                                        // Nameing the spawning Object In term of Coin  OR Diamond
                                        objectInstance.transform.gameObject.name = objectBuyIcon.name;

                                        objectInstance.transform.GetChild(0).GetComponent<Image>().enabled = true;

                                        objectInstance.transform.GetChild(1).GetComponent<Image>().enabled = true;
                                        objectInstance.transform.GetChild(2).GetComponent<Text>().enabled = true;
                                        objectInstance.transform.GetChild(3).GetComponent<Image>().enabled = true;
                                    }
                                } 
                            }
                       
                        
                    }
                }
               Destroy(SpawnGameObject);
            }
            Destroy(buttonTemplate);
        }
        spawned = false;
    }

    public void SpawnCoat()
    {
        if (spawned == true)
        {
            
            GameObject SpawnGameObject = Instantiate(invetoryGameObject, GameObject.Find("All Inventory Objects").transform);

            GameObject buttonTemplate = transform.GetChild(0).gameObject;
            
            GameObject objectInstance;
                
            for (int i = 0; i < GameManager.instance.rootModel.data.Count; i++)
            {
                if (GameManager.instance.rootModel.data[i].mainCategoryName == "coat" )
                {
                    int count = GameManager.instance.rootModel.data[i].subCategory.Count;
                    for (int j = 0; j < count; j++)
                    {
                        // Debug.Log("Category Name = " + GameManager.instance.rootModel.data[i].subCategory.Count );
                         

                                objectInstance = Instantiate(buttonTemplate, transform);

                                // Payment Icon Refrence Passing
                                 var paymentTypeIcon = Resources.Load(GameManager.instance.rootModel.data[i].subCategory[j]
                                      .paymentType.ToString()) as Texture2D;
                                      var paymentSprite = Sprite.Create(paymentTypeIcon, new Rect(0.0f,0.0f,paymentTypeIcon.width,paymentTypeIcon.height), new Vector2(0.5f,0.5f), 100.0f);

                                      objectInstance.transform.GetChild(1).GetComponent<Image>().sprite = paymentSprite;
                                      

                                      //Price In term of Coin & Diamonds
                                        objectInstance.transform.GetChild (2).GetComponent <Text> ().text = GameManager.instance.rootModel.data[i].subCategory[j].price.ToString();
                                        
                                        // Passing Objects references which User will Buy 
                                        // Texture2D objectBuyIcon = Resources.Load(GameManager.instance.rootModel.data[i].subCategory[j]
                                        //     .items[k].icon.ToString()) as Texture2D; 
                                        var objectBuyIcon = Resources.Load(GameManager.instance.rootModel.data[i].subCategory[j]
                                            .icon.ToString()) as Texture2D; 
                                        // var tex = Resources.Load<Texture2D>("Sprites/transparent");
                                        var ObjectBuyIcon = Sprite.Create(objectBuyIcon, new Rect(0.0f,0.0f,objectBuyIcon.width,objectBuyIcon.height), new Vector2(0.5f,0.5f), 100.0f);
                                        objectInstance.transform.GetChild(3).GetComponent<Image>().sprite = ObjectBuyIcon;
                                        
                                        // Nameing the spawning Object In term of Coin  OR Diamond
                                        objectInstance.transform.gameObject.name = objectBuyIcon.name;

                                        objectInstance.transform.GetChild(0).GetComponent<Image>().enabled = true;

                                        objectInstance.transform.GetChild(1).GetComponent<Image>().enabled = true;
                                        objectInstance.transform.GetChild(2).GetComponent<Text>().enabled = true;
                                        objectInstance.transform.GetChild(3).GetComponent<Image>().enabled = true;
                    }
                }
               Destroy(SpawnGameObject);
            }
            Destroy(buttonTemplate);
           
        }
        spawned = false;
    } 
    
    public void SpawnNewArrival()
    {
        if (spawned == true)
        {
            
            GameObject SpawnGameObject = Instantiate(invetoryGameObject, GameObject.Find("All Inventory Objects").transform);

            GameObject buttonTemplate = transform.GetChild(0).gameObject;
            
            GameObject objectInstance;
                
            for (int i = 0; i < GameManager.instance.rootModel.data.Count; i++)
            {
                if (GameManager.instance.rootModel.data[i].mainCategoryName == "newArrival" )
                {
                    int count = GameManager.instance.rootModel.data[i].subCategory.Count;
                    for (int j = 0; j < count; j++)
                    {
                         
                                objectInstance = Instantiate(buttonTemplate, transform);

                                // Payment Icon Refrence Passing
                                 var paymentTypeIcon = Resources.Load(GameManager.instance.rootModel.data[i].subCategory[j]
                                      .paymentType.ToString()) as Texture2D;
                                      var paymentSprite = Sprite.Create(paymentTypeIcon, new Rect(0.0f,0.0f,paymentTypeIcon.width,paymentTypeIcon.height), new Vector2(0.5f,0.5f), 100.0f);

                                      objectInstance.transform.GetChild(1).GetComponent<Image>().sprite = paymentSprite;
                                      

                                      //Price In term of Coin & Diamonds
                                        objectInstance.transform.GetChild (2).GetComponent <Text> ().text = GameManager.instance.rootModel.data[i].subCategory[j].price.ToString();
                                        
                                        // Passing Objects references which User will Buy 
                                        // Texture2D objectBuyIcon = Resources.Load(GameManager.instance.rootModel.data[i].subCategory[j]
                                        //     .items[k].icon.ToString()) as Texture2D; 
                                        var objectBuyIcon = Resources.Load(GameManager.instance.rootModel.data[i].subCategory[j]
                                            .icon.ToString()) as Texture2D; 
                                        // var tex = Resources.Load<Texture2D>("Sprites/transparent");
                                        var ObjectBuyIcon = Sprite.Create(objectBuyIcon, new Rect(0.0f,0.0f,objectBuyIcon.width,objectBuyIcon.height), new Vector2(0.5f,0.5f), 100.0f);
                                        objectInstance.transform.GetChild(3).GetComponent<Image>().sprite = ObjectBuyIcon;
                                        
                                        // Nameing the spawning Object In term of Coin  OR Diamond
                                        objectInstance.transform.gameObject.name = objectBuyIcon.name;

                                        objectInstance.transform.GetChild(0).GetComponent<Image>().enabled = true;

                                        objectInstance.transform.GetChild(1).GetComponent<Image>().enabled = true;
                                        objectInstance.transform.GetChild(2).GetComponent<Text>().enabled = true;
                                        objectInstance.transform.GetChild(3).GetComponent<Image>().enabled = true;
                    }
                }
               Destroy(SpawnGameObject);
            }
            Destroy(buttonTemplate);
        }
        spawned = false;
    }

    public void SpawnGlasses()
    {
        if (spawned == true)
        {
            
            GameObject SpawnGameObject = Instantiate(invetoryGameObject, GameObject.Find("All Inventory Objects").transform);

            GameObject buttonTemplate = transform.GetChild(0).gameObject;
            GameObject objectInstance;
                
            for (int i = 0; i < GameManager.instance.rootModel.data.Count; i++)
            {
                if (GameManager.instance.rootModel.data[i].mainCategoryName == "glasses" )
                {
                    int count = GameManager.instance.rootModel.data[i].subCategory.Count;
                    for (int j = 0; j < count; j++)
                    {
                       
                                objectInstance = Instantiate(buttonTemplate, transform);

                                // Payment Icon Refrence Passing
                                 var paymentTypeIcon = Resources.Load(GameManager.instance.rootModel.data[i].subCategory[j]
                                      .paymentType.ToString()) as Texture2D;
                                      var paymentSprite = Sprite.Create(paymentTypeIcon, new Rect(0.0f,0.0f,paymentTypeIcon.width,paymentTypeIcon.height), new Vector2(0.5f,0.5f), 100.0f);

                                      objectInstance.transform.GetChild(1).GetComponent<Image>().sprite = paymentSprite;
                                      

                                      //Price In term of Coin & Diamonds
                                        objectInstance.transform.GetChild (2).GetComponent <Text> ().text = GameManager.instance.rootModel.data[i].subCategory[j].price.ToString();
                                        
                                        // Passing Objects references which User will Buy 
                                        // Texture2D objectBuyIcon = Resources.Load(GameManager.instance.rootModel.data[i].subCategory[j]
                                        //     .items[k].icon.ToString()) as Texture2D; 
                                        var objectBuyIcon = Resources.Load(GameManager.instance.rootModel.data[i].subCategory[j]
                                            .icon.ToString()) as Texture2D; 
                                        // var tex = Resources.Load<Texture2D>("Sprites/transparent");
                                        var ObjectBuyIcon = Sprite.Create(objectBuyIcon, new Rect(0.0f,0.0f,objectBuyIcon.width,objectBuyIcon.height), new Vector2(0.5f,0.5f), 100.0f);
                                        objectInstance.transform.GetChild(3).GetComponent<Image>().sprite = ObjectBuyIcon;
                                        
                                        // Nameing the spawning Object In term of Coin  OR Diamond
                                        objectInstance.transform.gameObject.name = objectBuyIcon.name;

                                        objectInstance.transform.GetChild(0).GetComponent<Image>().enabled = true;

                                        objectInstance.transform.GetChild(1).GetComponent<Image>().enabled = true;
                                        objectInstance.transform.GetChild(2).GetComponent<Text>().enabled = true;
                                        objectInstance.transform.GetChild(3).GetComponent<Image>().enabled = true;
                    }
                }
               Destroy(SpawnGameObject);
            }
            Destroy(buttonTemplate);
        }
        spawned = false;
    }

    public void SpawnJacket()
    {
        if (spawned == true)
        {
            
            GameObject SpawnGameObject = Instantiate(invetoryGameObject, GameObject.Find("All Inventory Objects").transform);

            GameObject buttonTemplate = transform.GetChild(0).gameObject;
            
            GameObject objectInstance;
                
            for (int i = 0; i < GameManager.instance.rootModel.data.Count; i++)
            {
                if (GameManager.instance.rootModel.data[i].mainCategoryName == "jacket" )
                {
                    int count = GameManager.instance.rootModel.data[i].subCategory.Count;
                    for (int j = 0; j < count; j++)
                    {
                     
                                objectInstance = Instantiate(buttonTemplate, transform);

                                // Payment Icon Refrence Passing
                                 var paymentTypeIcon = Resources.Load(GameManager.instance.rootModel.data[i].subCategory[j]
                                      .paymentType.ToString()) as Texture2D;
                                      var paymentSprite = Sprite.Create(paymentTypeIcon, new Rect(0.0f,0.0f,paymentTypeIcon.width,paymentTypeIcon.height), new Vector2(0.5f,0.5f), 100.0f);

                                      objectInstance.transform.GetChild(1).GetComponent<Image>().sprite = paymentSprite;
                                      

                                      //Price In term of Coin & Diamonds
                                        objectInstance.transform.GetChild (2).GetComponent <Text> ().text = GameManager.instance.rootModel.data[i].subCategory[j].price.ToString();
                                        
                                        // Passing Objects references which User will Buy 
                                        // Texture2D objectBuyIcon = Resources.Load(GameManager.instance.rootModel.data[i].subCategory[j]
                                        //     .items[k].icon.ToString()) as Texture2D; 
                                        var objectBuyIcon = Resources.Load(GameManager.instance.rootModel.data[i].subCategory[j]
                                            .icon.ToString()) as Texture2D; 
                                        // var tex = Resources.Load<Texture2D>("Sprites/transparent");
                                        var ObjectBuyIcon = Sprite.Create(objectBuyIcon, new Rect(0.0f,0.0f,objectBuyIcon.width,objectBuyIcon.height), new Vector2(0.5f,0.5f), 100.0f);
                                        objectInstance.transform.GetChild(3).GetComponent<Image>().sprite = ObjectBuyIcon;
                                        
                                        // Nameing the spawning Object In term of Coin  OR Diamond
                                        objectInstance.transform.gameObject.name = objectBuyIcon.name;

                                        objectInstance.transform.GetChild(0).GetComponent<Image>().enabled = true;

                                        objectInstance.transform.GetChild(1).GetComponent<Image>().enabled = true;
                                        objectInstance.transform.GetChild(2).GetComponent<Text>().enabled = true;
                                        objectInstance.transform.GetChild(3).GetComponent<Image>().enabled = true;
                    }
                }
               Destroy(SpawnGameObject);
            }
            Destroy(buttonTemplate);
        }
        spawned = false;
    } 
    public void SpawnFootwear()
    {
         if (spawned == true)
            {
            

                // add a button component to the game object
                GameObject SpawnGameObject = Instantiate(invetoryGameObject, GameObject.Find("All Inventory Objects").transform);
                
                GameObject buttonTemplate = transform.GetChild(0).gameObject;
                GameObject objectInstance;
                    
                for (int i = 0; i < GameManager.instance.rootModel.data.Count; i++)
                {
                    if (GameManager.instance.rootModel.data[i].mainCategoryName == "hotItems" )
                    // if (GameManager.instance.rootModel.data[i].mainCategoryName == "hotItems" )
                    {
                        int count = GameManager.instance.rootModel.data[i].subCategory.Count;
                        for (int j = 0; j < count; j++)
                        {
                            if (GameManager.instance.rootModel.data[i].hasSubCategory)
                                {
                                    if(GameManager.instance.rootModel.data[i].subCategory[j].subCategoryName == "footwear")
                                    {
                                        // Debug.Log("Category Name = " + GameManager.instance.rootModel.data[i].subCategory[j].subCategoryName );
                                        for (int k = 0; k < GameManager.instance.rootModel.data[i].subCategory[j].items.Count; k++)
                                        {

                                            objectInstance = Instantiate(buttonTemplate, transform);
                                            // Debug.Log("i : "+ i + ", j : "+ j+", K: "+ k);
                                            
                                            // Debug.Log("all");
                                            
                                            
                                            // Payment Icon Refrence Passing
                                             var paymentTypeIcon = Resources.Load(GameManager.instance.rootModel.data[i].subCategory[j]
                                      .items[k].paymentType.ToString()) as Texture2D;
                                      var paymentSprite = Sprite.Create(paymentTypeIcon, new Rect(0.0f,0.0f,paymentTypeIcon.width,paymentTypeIcon.height), new Vector2(0.5f,0.5f), 100.0f);

                                      objectInstance.transform.GetChild(1).GetComponent<Image>().sprite = paymentSprite;
                                      

                                      //Price In term of Coin & Diamonds
                                        objectInstance.transform.GetChild (2).GetComponent <Text> ().text = GameManager.instance.rootModel.data[i].subCategory[j].items[k].price.ToString();
                                        
                                        // Passing Objects references which User will Buy 
                                        // Texture2D objectBuyIcon = Resources.Load(GameManager.instance.rootModel.data[i].subCategory[j]
                                        //     .items[k].icon.ToString()) as Texture2D; 
                                        var objectBuyIcon = Resources.Load(GameManager.instance.rootModel.data[i].subCategory[j]
                                            .items[k].icon.ToString()) as Texture2D; 
                                        // var tex = Resources.Load<Texture2D>("Sprites/transparent");
                                        var ObjectBuyIcon = Sprite.Create(objectBuyIcon, new Rect(0.0f,0.0f,objectBuyIcon.width,objectBuyIcon.height), new Vector2(0.5f,0.5f), 100.0f);
                                        objectInstance.transform.GetChild(3).GetComponent<Image>().sprite = ObjectBuyIcon;
                                        
                                        // Nameing the spawning Object In term of Coin  OR Diamond
                                        objectInstance.transform.gameObject.name = objectBuyIcon.name;

                                        objectInstance.transform.GetChild(0).GetComponent<Image>().enabled = true;

                                        objectInstance.transform.GetChild(1).GetComponent<Image>().enabled = true;
                                        objectInstance.transform.GetChild(2).GetComponent<Text>().enabled = true;
                                        objectInstance.transform.GetChild(3).GetComponent<Image>().enabled = true;
                                        }
                                    } 
                                }
                           
                            
                        }
                }
               Destroy(SpawnGameObject);
            } 
            Destroy(buttonTemplate);
        }

        spawned = false;
    }
    public void SpawnClothing()
    {
        if (spawned == true)
        {
            

            // add a button component to the game object
            GameObject SpawnGameObject = Instantiate(invetoryGameObject, GameObject.Find("All Inventory Objects").transform);
            
            GameObject buttonTemplate = transform.GetChild(0).gameObject;
            GameObject objectInstance;
                
            Debug.Log(gameObject.GetComponent<RectTransform>().sizeDelta);
            gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(gameObject.GetComponent<RectTransform>().sizeDelta.x, gameObject.GetComponent<GridLayoutGroup>().preferredHeight); ;

            Debug.Log(gameObject.GetComponent<RectTransform>().sizeDelta);
            for (int i = 0; i < GameManager.instance.rootModel.data.Count; i++)
            {
                if (GameManager.instance.rootModel.data[i].mainCategoryName == "hotItems" )
                // if (GameManager.instance.rootModel.data[i].mainCategoryName == "hotItems" )
                {
                    int count = GameManager.instance.rootModel.data[i].subCategory.Count;
                    for (int j = 0; j < count; j++)
                    {
                        if (GameManager.instance.rootModel.data[i].hasSubCategory)
                            {
                                if(GameManager.instance.rootModel.data[i].subCategory[j].subCategoryName == "clothing")
                                {
                                    // Debug.Log("Category Name = " + GameManager.instance.rootModel.data[i].subCategory[j].subCategoryName );
                                    for (int k = 0; k < GameManager.instance.rootModel.data[i].subCategory[j].items.Count; k++)
                                    {

                                        objectInstance = Instantiate(buttonTemplate, transform);
                                        // Debug.Log("i : "+ i + ", j : "+ j+", K: "+ k);
                                        
                                        // Debug.Log("all");
                                        
                                        
                                        // Payment Icon Refrence Passing
                                                // Payment Icon Refrence Passing
                                             var paymentTypeIcon = Resources.Load(GameManager.instance.rootModel.data[i].subCategory[j]
                                      .items[k].paymentType.ToString()) as Texture2D;
                                      var paymentSprite = Sprite.Create(paymentTypeIcon, new Rect(0.0f,0.0f,paymentTypeIcon.width,paymentTypeIcon.height), new Vector2(0.5f,0.5f), 100.0f);

                                      objectInstance.transform.GetChild(1).GetComponent<Image>().sprite = paymentSprite;
                                      

                                      //Price In term of Coin & Diamonds
                                        objectInstance.transform.GetChild (2).GetComponent <Text> ().text = GameManager.instance.rootModel.data[i].subCategory[j].items[k].price.ToString();
                                        
                                        // Passing Objects references which User will Buy 
                                        // Texture2D objectBuyIcon = Resources.Load(GameManager.instance.rootModel.data[i].subCategory[j]
                                        //     .items[k].icon.ToString()) as Texture2D; 
                                        var objectBuyIcon = Resources.Load(GameManager.instance.rootModel.data[i].subCategory[j]
                                            .items[k].icon.ToString()) as Texture2D; 
                                        // var tex = Resources.Load<Texture2D>("Sprites/transparent");
                                        var ObjectBuyIcon = Sprite.Create(objectBuyIcon, new Rect(0.0f,0.0f,objectBuyIcon.width,objectBuyIcon.height), new Vector2(0.5f,0.5f), 100.0f);
                                        objectInstance.transform.GetChild(3).GetComponent<Image>().sprite = ObjectBuyIcon;
                                        
                                        // Nameing the spawning Object In term of Coin  OR Diamond
                                        objectInstance.transform.gameObject.name = objectBuyIcon.name;

                                        objectInstance.transform.GetChild(0).GetComponent<Image>().enabled = true;

                                        objectInstance.transform.GetChild(1).GetComponent<Image>().enabled = true;
                                        objectInstance.transform.GetChild(2).GetComponent<Text>().enabled = true;
                                        objectInstance.transform.GetChild(3).GetComponent<Image>().enabled = true;
                                    }
                                } 
                            }
                       
                        
                    }
                }
               Destroy(SpawnGameObject);
            }
            Destroy(buttonTemplate);
        }
        spawned = false;
        Debug.Log(gameObject.GetComponent<RectTransform>().sizeDelta);

    }

    IEnumerator RectHeightUpdate()
    {
        yield return new WaitForSeconds(0.5f);
        gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(gameObject.GetComponent<RectTransform>().sizeDelta.x, gameObject.GetComponent<GridLayoutGroup>().preferredHeight); ;

    }

    private void FixedUpdate()
    {
        // gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(gameObject.GetComponent<RectTransform>().sizeDelta.x, gameObject.GetComponent<GridLayoutGroup>().preferredHeight); ;
    }
}

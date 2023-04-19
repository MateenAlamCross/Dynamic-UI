using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnCash : MonoBehaviour
{
    public static SpawnCash instance;
    [Header("Is Spawned")]
    public bool spawned ;
    [Header("Payment Spawn")]
    public GameObject invetoryGameObject;

    public RectTransform content;
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

        Vector3 temp;
        temp.x = GameObject.Find("All Inventory Objects").transform.position.x;
        temp.y = -1120f;
        temp.z = GameObject.Find("All Inventory Objects").transform.position.z;
        
        GameObject.Find("All Inventory Objects").transform.position = temp;
        
        
        // LayoutRebuilder.ForceRebuildLayoutImmediate(content);

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
    public void SpawnPayment(string name)
    {
        if (spawned == true)
        {
            
            // GameObject newButton = new GameObject("Button");
            //
            // // add a button component to the game object
            // Button buttonComponent = newButton.AddComponent<Button>();
            // newButton.AddComponent<Image>();
            // newButton.transform.SetParent(GameObject.Find("All Inventory Objects").transform);
            GameObject SpawnGameObject = Instantiate(invetoryGameObject, GameObject.Find("All Inventory Objects").transform);
            // invetoryGameObject.transform.SetParent(GameObject.Find("All Inventory Objects").transform);
            GameObject buttonTemplate = transform.GetChild(0).gameObject;
            GameObject objectInstance;
                
            for (int i = 0; i < GameManager.instance.rootModel.data.Count; i++)
            {
                if (GameManager.instance.rootModel.data[i].mainCategoryName == name )
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
                                        objectInstance.SetActive(true);
                                        
                                        
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
            // Destroy(GameObject.Find("Payment Container(Clone)"));

            //Destroy(invetoryGameObject);
        }
        spawned = false;
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
            
            // Debug.Log(transform.GetChild(0).gameObject);
            // Debug.Log(buttonTemplate);
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
    }
}

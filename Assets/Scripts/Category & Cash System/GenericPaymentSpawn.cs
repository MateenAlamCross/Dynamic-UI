using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GenericPaymentSpawn : MonoBehaviour
{
   public static GenericPaymentSpawn instance;
   public bool spawned ;

   public GameObject invetoryGameObject;
   //
   // private GenericPaymentSpawn()
   // {
   //     
   // }

   public static GenericPaymentSpawn GetInstance(string mainMenuName, string subMenuName)
   {
       if (instance == null)
       {
           instance = new GenericPaymentSpawn(mainMenuName,subMenuName);
       }

       return instance;
   }
   public static GenericPaymentSpawn GetInstance(string mainMenuName)
   {
       if (instance == null)
       {
           instance = new GenericPaymentSpawn(mainMenuName);
       }

       return instance;
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
   }

   public GenericPaymentSpawn(string mainMenuName, string subMenuName)
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
                if (GameManager.instance.rootModel.data[i].mainCategoryName == mainMenuName )
                // if (GameManager.instance.rootModel.data[i].mainCategoryName == "hotItems" )
                {
                    int count = GameManager.instance.rootModel.data[i].subCategory.Count;
                    for (int j = 0; j < count; j++)
                    {
                        if (GameManager.instance.rootModel.data[i].hasSubCategory)
                            {
                                if(GameManager.instance.rootModel.data[i].subCategory[j].subCategoryName == subMenuName)
                                {
                                    // Debug.Log("Category Name = " + GameManager.instance.rootModel.data[i].subCategory[j].subCategoryName );
                                    for (int k = 0; k < GameManager.instance.rootModel.data[i].subCategory[j].items.Count; k++)
                                    {

                                        objectInstance = Instantiate(buttonTemplate, transform);
                                        // Debug.Log("i : "+ i + ", j : "+ j+", K: "+ k);
                                        objectInstance.SetActive(true);
                                        
                                        
                                        // Payment Icon Refrence Passing
                                      Texture2D paymentTypeIcon = Resources.Load(GameManager.instance.rootModel.data[i].subCategory[j]
                                      .items[k].paymentType.ToString()) as Texture2D; 
                                      objectInstance.transform.GetChild(0).GetComponent<RawImage>().texture = paymentTypeIcon;
                                      

                                      //Price In term of Coin & Diamonds
                                        objectInstance.transform.GetChild (1).GetComponent <Text> ().text = GameManager.instance.rootModel.data[i].subCategory[j].items[k].price.ToString();
                                        
                                        // Passing Objects references which User will Buy 
                                        Texture2D objectBuyIcon = Resources.Load(GameManager.instance.rootModel.data[i].subCategory[j]
                                            .items[k].icon.ToString()) as Texture2D; 
                                        objectInstance.transform.GetChild(2).GetComponent<RawImage>().texture = objectBuyIcon;
                                        
                                        // Nameing the spawning Object In term of Coin  OR Diamond
                                        objectInstance.transform.gameObject.name = objectBuyIcon.name;

                                        
                                        objectInstance.transform.GetChild(0).GetComponent<RawImage>().enabled = true;
                                        objectInstance.transform.GetChild(1).GetComponent<Text>().enabled = true;
                                        objectInstance.transform.GetChild(2).GetComponent<RawImage>().enabled = true;
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

   public GenericPaymentSpawn(string mainMenuName)
   {
         if (spawned == true)
            {
                
                GameObject SpawnGameObject = Instantiate(invetoryGameObject, GameObject.Find("All Inventory Objects").transform);

                GameObject buttonTemplate = transform.GetChild(0).gameObject;
                
                GameObject objectInstance;
                    
                for (int i = 0; i < GameManager.instance.rootModel.data.Count; i++)
                {
                    if (GameManager.instance.rootModel.data[i].mainCategoryName == mainMenuName )
                    {
                        int count = GameManager.instance.rootModel.data[i].subCategory.Count;
                        for (int j = 0; j < count; j++)
                        {
                            // Debug.Log("Category Name = " + GameManager.instance.rootModel.data[i].subCategory.Count );
                             

                                    objectInstance = Instantiate(buttonTemplate, transform);

                                    // Payment Icon Refrence Passing
                                  Texture2D paymentTypeIcon = Resources.Load(GameManager.instance.rootModel.data[i].subCategory[j].paymentType.ToString()) as Texture2D; 
                                  objectInstance.transform.GetChild(0).GetComponent<RawImage>().texture = paymentTypeIcon;

                              
                                  
                                    //Price In term of Coin & Diamonds
                                    objectInstance.transform.GetChild (1).GetComponent <Text> ().text = GameManager.instance.rootModel.data[i].subCategory[j].price.ToString();
                                    // Passing Objects references which User will Buy 
                                    Texture2D objectBuyIcon = Resources.Load(GameManager.instance.rootModel.data[i].subCategory[j].icon.ToString()) as Texture2D; 
                                    objectInstance.transform.GetChild(2).GetComponent<RawImage>().texture = objectBuyIcon;
                                    
                                    // Nameing the spawning Object In term of Coin  OR Diamond
                                    objectInstance.transform.gameObject.name = objectBuyIcon.name;

                                    
                                    objectInstance.transform.GetChild(0).GetComponent<RawImage>().enabled = true;
                                    objectInstance.transform.GetChild(1).GetComponent<Text>().enabled = true;
                                    objectInstance.transform.GetChild(2).GetComponent<RawImage>().enabled = true;
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
   
}

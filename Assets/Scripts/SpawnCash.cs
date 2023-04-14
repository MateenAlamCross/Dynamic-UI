using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnCash : MonoBehaviour
{
    public static SpawnCash instance;
    public bool spawned ;

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

    public void SpawnPayment(string name)
    {
        if (spawned == true)
        {
            
        
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
                        if(GameManager.instance.rootModel.data[i].subCategory[j].subCategoryName == "all")
                        {
                            Debug.Log("Category Name = " + GameManager.instance.rootModel.data[i].subCategory[j].subCategoryName );
                            for (int k = 0; k < GameManager.instance.rootModel.data[i].subCategory[j].items.Count; k++)
                            {

                                objectInstance = Instantiate(buttonTemplate, transform);
                                Debug.Log("i : "+ i + ", j : "+ j+", K: "+ k);
                                
                                
                                
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
            Destroy(buttonTemplate);
        }
        spawned = false;
    }

    public void SpawnShirt()
    {
        
         if (spawned == true)
        {
            GameObject buttonTemplate = transform.GetChild(0).gameObject;
            GameObject objectInstance;
                
            for (int i = 0; i < GameManager.instance.rootModel.data.Count; i++)
            {
                if (GameManager.instance.rootModel.data[i].mainCategoryName == "shirt" )
                {
                    int count = GameManager.instance.rootModel.data[i].subCategory.Count;
                    for (int j = 0; j < count; j++)
                    {
                        Debug.Log("Category Name = " + GameManager.instance.rootModel.data[i].subCategory.Count );
                         

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
               
            }
            Destroy(buttonTemplate);
        }
        spawned = false;
    }

    public void SpawnDress()
    {
        
    }

    public void SpawnCoat()
    {
        if (spawned == true)
        {
            
        
            GameObject buttonTemplate = transform.GetChild(0).gameObject;
            GameObject objectInstance;
                
            for (int i = 0; i < GameManager.instance.rootModel.data.Count; i++)
            {
                if (GameManager.instance.rootModel.data[i].mainCategoryName == "coat" )
                {
                    int count = GameManager.instance.rootModel.data[i].subCategory.Count;
                    for (int j = 0; j < count; j++)
                    {
                        Debug.Log("Category Name = " + GameManager.instance.rootModel.data[i].subCategory.Count );
                         

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
               
            }
            Destroy(buttonTemplate);
        }
        spawned = false;
    }

    public void SpawnGlasses()
    {
        
    }

    public void SpawnJacket()
    {
        
    }
}

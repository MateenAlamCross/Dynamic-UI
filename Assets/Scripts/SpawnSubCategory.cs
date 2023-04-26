using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class SpawnSubCategory : MonoBehaviour
{
    public static SpawnSubCategory instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }


    public void SpawnSubcategory()
    {
        GameObject newButton = new GameObject("Button");

        // add a button component to the game object
        Button buttonComponent = newButton.AddComponent<Button>();
        newButton.AddComponent<Image>();
        newButton.AddComponent<Outline>();
        newButton.transform.SetParent(GameObject.Find("Subcategory").transform);
        // GameObject.Find("Subcategory").SetActive(true);
         GameObject buttonTemplate = transform.GetChild(0).gameObject;
        //buttonTemplate.SetActive(true);
        GameObject objectInstance;
           
        Debug.Log("Sub Category");
        for (int i = 0; i < GameManager.instance.rootModel.data.Count; i++)
        {
           
            if (GameManager.instance.rootModel.data[i].mainCategoryName == "hotItems")
            {
                int count = GameManager.instance.rootModel.data[i].subCategory.Count;
                for (int j = 0; j < count; j++)
                {
                    objectInstance = Instantiate(buttonTemplate, transform);

                    Texture2D myTexture = Resources.Load(GameManager.instance.rootModel.data[i].subCategory[j].subCategoryImage) as Texture2D;
                    // Texture2D myTexture =  DownloadHandlerTexture.GetContent(request) as Texture2D;
                    objectInstance.transform.GetComponent<Image>().sprite = Sprite.Create(myTexture,
                        new Rect(0, 0, myTexture.width, myTexture.height), new Vector2(0.5f, 0.5f));
                    objectInstance.transform.GetComponent<Image>().SetNativeSize();
                    objectInstance.transform.GetComponent<Image>().enabled = true;
                    objectInstance.transform.GetComponent<Button>().enabled = true;
                    objectInstance.transform.gameObject.name = GameManager.instance.rootModel.data[i].subCategory[j].subCategoryName;
                   
                }
            }
        }
        Destroy(buttonTemplate);
        Destroy(newButton);
    }
    public void DestroySubcategorySpawned()
    {
        foreach (Transform child in transform)
        {
            Debug.Log(child.gameObject);
            Destroy(child.gameObject);
        }
        // GameObject.Find("Subcategory").SetActive(false);

    }
}

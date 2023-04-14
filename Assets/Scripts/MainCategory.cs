using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class MainCategory : MonoBehaviour
{
    // public Image Image;
    GameObject hotitems;
    private GameObject clothing;
    public void SpawnCategory()
    {
        GameObject buttonTemplate = transform.GetChild(0).gameObject;
        GameObject objectInstance;
            
        for (int i = 0; i < GameManager.instance.rootModel.data.Count; i++)
        {
            objectInstance = Instantiate(buttonTemplate, transform);
            Texture2D myTexture = Resources.Load(GameManager.instance.rootModel.data[i].mainCategoryImage) as Texture2D;
            
            objectInstance.transform.GetComponent<Image>().sprite = Sprite.Create(myTexture,
                new Rect(0, 0, myTexture.width, myTexture.height), new Vector2(0.5f, 0.5f));
            objectInstance.transform.gameObject.name = GameManager.instance.rootModel.data[i].mainCategoryName;
        }

        Destroy(buttonTemplate);
        hotitems = GameObject.Find("hotItems");
       
        hotitems.GetComponent<Button>().onClick.AddListener(OnPressHotItems);
        clothing = GameObject.Find("coat");
        clothing.GetComponent<Button>().onClick.AddListener(DestroyAllSpawned);
    }



    public void OnPressHotItems()
    { 
        SpawnCash.instance.DestroyAllSpawned();

        SpawnCash.instance.spawned = true;
        SpawnCash.instance.SpawnPayment("hotItems");
    }

    public void DestroyAllSpawned()
    {
        
        SpawnCash.instance.DestroyAllSpawned();
        SpawnCash.instance.spawned = true;

        SpawnCash.instance.SpawnCoat();

    }
    
}





// foreach(GameObject gameObj in GameObject.FindObjectsOfType<GameObject>())
// {
//     if(gameObj.name == "payment")
//     {
//         Destroy(gameObj);
//     }
// }

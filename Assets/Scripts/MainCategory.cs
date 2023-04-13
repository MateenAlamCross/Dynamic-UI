using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class MainCategory : MonoBehaviour
{
    // public Image Image;
    
    public void SpawnCategory()
    {
        GameObject buttonTemplate = transform.GetChild(0).gameObject;
        GameObject objectInstance;
            
        for (int i = 0; i < GameManager.instance.rootModel.data.Count; i++)
        {
            objectInstance = Instantiate(buttonTemplate, transform);
            Texture2D myTexture = Resources.Load(GameManager.instance.rootModel.data[i].mainCategoryImage) as Texture2D;
            // Debug.Log(g.transform);
            // Debug.Log(GameManager.instance.rootModel.data[i].mainCategoryImage);
            objectInstance.transform.GetComponent<Image>().sprite = Sprite.Create(myTexture,
                new Rect(0, 0, myTexture.width, myTexture.height), new Vector2(0.5f, 0.5f));
            objectInstance.transform.gameObject.name = GameManager.instance.rootModel.data[i].mainCategoryName;
        }

        Destroy(buttonTemplate);
    }

   
    
}

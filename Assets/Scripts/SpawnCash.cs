using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnCash : MonoBehaviour
{
    public void SpawnPayment()
    {
        GameObject buttonTemplate = transform.GetChild(0).gameObject;
        GameObject objectInstance;
            
        for (int i = 0; i < GameManager.instance.rootModel.data.Count; i++)
        {
            if (GameManager.instance.rootModel.data[i].mainCategoryName == "hotItems")
            {
                int count = GameManager.instance.rootModel.data[i].subCategory.Count;
                Debug.Log(count);
                for (int j = 0; j < count; j++)
                {
                    if(GameManager.instance.rootModel.data[i].subCategory[j].subCategoryName == "all")
                    {
                        Debug.Log(GameManager.instance.rootModel.data[i].subCategory[j].subCategoryName );
                        for (int k = 0; j < GameManager.instance.rootModel.data[i].subCategory[j].items.Count; k++)
                        {
                            objectInstance = Instantiate(buttonTemplate, transform);
                            Debug.Log(objectInstance.transform.GetChild (0).gameObject);
                            Debug.Log(GameManager.instance.rootModel.data[i].subCategory[j].items.Count);
                            Texture2D myTexture = Resources.Load(GameManager.instance.rootModel.data[i].subCategory[j].items[k].paymentType) as Texture2D;
                            objectInstance.transform.GetChild (0).GetComponent <Image> ().sprite = Sprite.Create(myTexture,
                                new Rect(0, 0, myTexture.width, myTexture.height), new Vector2(0.5f, 0.5f));;
                            objectInstance.transform.GetChild (1).GetComponent <Text> ().text = GameManager.instance.rootModel.data[i].subCategory[j].items[k].price.ToString();
                        }
                    }
                    
                }
       
            }
           
        }

        Destroy(buttonTemplate);
    }
}

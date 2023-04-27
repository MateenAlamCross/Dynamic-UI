using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class MainCategory : MonoBehaviour
{
    public static MainCategory instance;

    public GameObject mainMenuItemPrefab;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        Invoke("SpawnCategory", 3.0f);
    }

    public void SpawnCategory()
    {
        //Spawn All the Main Category Items
        foreach (var mItem in GameManager.instance.rootModel.data)
        {
            GameObject mainMenuItem = Instantiate(mainMenuItemPrefab, GameObject.Find("Main Category").transform);
            Texture2D img = Resources.Load(mItem.mainCategoryImage.ToString()) as Texture2D;
            mainMenuItem.GetComponent<Image>().sprite = Sprite.Create(img, new Rect(0.0f, 0.0f, img.width, img.height),
                new Vector2(0.5f, 0.5f), 100.0f);
            mainMenuItem.gameObject.name = mItem.mainCategoryName;
            mainMenuItem.GetComponent<Image>().SetNativeSize();
            mainMenuItem.GetComponent<Button>().onClick.AddListener((() => OnClickSpawnItem(mItem.mainCategoryName.ToString())));
        }
    }


    public void OnClickSpawnItem(string name)
    {
        foreach (var dataItem in GameManager.instance.rootModel.data)
        {
            if (dataItem.hasSubCategory)
            {
                foreach (var subItem in dataItem.subCategory)
                {
                    GameObject subCategoryItem = Instantiate(mainMenuItemPrefab, GameObject.Find("Subcategory").transform);
                    Texture2D img = Resources.Load(subItem.subCategoryImage.ToString()) as Texture2D;
                    subCategoryItem.GetComponent<Image>().sprite = Sprite.Create(img,new Rect(0.0f, 0.0f, img.width, img.height),
                        new Vector2(0.5f, 0.5f), 100.0f);
                    subCategoryItem.gameObject.name = subItem.subCategoryName;
                    subCategoryItem.GetComponent<Image>().SetNativeSize();
                    subCategoryItem.GetComponent<Button>().onClick.AddListener((() => AddListenerToSubCategory(name.ToString(),subItem.subCategoryName.ToString())));
                }
            }
            
            else
            {
                SpawnCash.instance.DestroyAllSpawned();
                SpawnCash.instance.canBeSpawn = true;
                SpawnCash.instance.SpawnPayment(name);
                SpawnCash.instance.StartCoroutine("SetInventoryViewSize");
            }
        }
    }
    
    public void AddListenerToSubCategory(string MainCategoryName,string SubCategoryName)
    {
        SpawnCash.instance.DestroyAllSpawned();
        Debug.Log(SubCategoryName);
        SpawnCash.instance.canBeSpawn = true;
        SpawnCash.instance.SpawnPayment(MainCategoryName, SubCategoryName);
        SpawnCash.instance.StartCoroutine("SetInventoryViewSize");
        // SpawnCash.instance.StartCoroutine("RectHeightUpdate");
    }
    
}











// //Get The Spawn Buttons
// hotitems = GameObject.Find("hotItems");
// shirt = GameObject.Find("shirt");
// coat = GameObject.Find("coat");
// newArrival = GameObject.Find("newArrival");
// jacket = GameObject.Find("jacket");
//
// //Add Button Component to All
// hotitems.GetComponent<Button>().onClick.AddListener(OnClickSpawnItem("hotItems"));
// shirt.GetComponent<Button>().onClick.AddListener(OnClickSpawnItem("shirt"));
// coat.GetComponent<Button>().onClick.AddListener(OnClickSpawnItem("coat"));
// newArrival.GetComponent<Button>().onClick.AddListener(OnClickSpawnItem("newArrival"));
// jacket.GetComponent<Button>().onClick.AddListener(OnClickSpawnItem("jacket"));


// SpawnCash.instance.SpawnFootwear();

// foreach(GameObject gameObj in GameObject.FindObjectsOfType<GameObject>())
// {
//     if(gameObj.name == "payment")
//     {
//         Destroy(gameObj);
//     }
// }


        
        
// all = GameObject.Find("all");
// all.GetComponent<Button>().onClick.AddListener(AllSpawned);
//
// clothing = GameObject.Find("clothing");
// hair = GameObject.Find("hair");
// footwear = GameObject.Find("footwear");
// others = GameObject.Find("others");
//
// clothing.GetComponent<Button>().onClick.AddListener(ClothingSpawned);
// hair.GetComponent<Button>().onClick.AddListener(HairSpawned);
// footwear.GetComponent<Button>().onClick.AddListener(FootwearSpawned);
// others.GetComponent<Button>().onClick.AddListener(OthersSpawned);


// SpawnCash.instance.DestroyAllSpawned();
// SpawnCash.instance.canBeSpawn = true;
// SpawnCash.instance.SpawnPayment("hotItems", "others");
// SpawnCash.instance.StartCoroutine("RectHeightUpdate");
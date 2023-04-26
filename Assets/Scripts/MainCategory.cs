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
    public static MainCategory instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    [SerializeField] GameObject hotitems;
    GameObject hair;
    GameObject footwear;
    GameObject clothing;
    GameObject shirt;
    GameObject all;
    GameObject coat;
    GameObject others;
    GameObject newArrival;
    GameObject jacket;

    private void Start()
    {
        StartCoroutine("SpawnMainCategory");
        //SpawnCategory();
    }

    IEnumerator SpawnMainCategory()
    {
        yield return new WaitForSeconds(3f);
        SpawnCategory();
    }

    public void SpawnCategory()
    {
        GameObject newButton = new GameObject("Button");

        // add a button component to the game object
        Button buttonComponent = newButton.AddComponent<Button>();
        newButton.AddComponent<Image>();
        newButton.transform.SetParent(GameObject.Find("Main Category").transform);
        GameObject buttonTemplate = transform.GetChild(0).gameObject;
        GameObject objectInstance;

        // Debug.Log(GameManager.instance.rootModel.data.Count);
        for (int i = 0; i < GameManager.instance.rootModel.data.Count; i++)
        {
            objectInstance = Instantiate(buttonTemplate, transform);
            Texture2D myTexture = Resources.Load(GameManager.instance.rootModel.data[i].mainCategoryImage) as Texture2D;

            objectInstance.transform.GetComponent<Image>().sprite = Sprite.Create(myTexture,
                new Rect(0, 0, myTexture.width, myTexture.height), new Vector2(0.5f, 0.5f));
            objectInstance.transform.GetComponent<Image>().SetNativeSize();
            objectInstance.transform.gameObject.name = GameManager.instance.rootModel.data[i].mainCategoryName;
        }

        Destroy(buttonTemplate);
        //Debug.Log(buttonTemplate);
        Destroy(newButton);
        hotitems = GameObject.Find("hotItems");

        shirt = GameObject.Find("shirt");
        coat = GameObject.Find("coat");
        newArrival = GameObject.Find("newArrival");
        jacket = GameObject.Find("jacket");

        hotitems.GetComponent<Button>().onClick.AddListener(OnPressHotItems);
        shirt.GetComponent<Button>().onClick.AddListener(ShirtSpawned);
        coat.GetComponent<Button>().onClick.AddListener(CoatSpawned);
        newArrival.GetComponent<Button>().onClick.AddListener(NewArrivalSpawned);
        jacket.GetComponent<Button>().onClick.AddListener(JacketSpawned);
    }


    public void OthersSpawned()
    {
        SpawnCash.instance.DestroyAllSpawned();
        SpawnCash.instance.spawned = true;
        // SpawnCash.instance.SpawnOthers();
        SpawnCash.instance.SpawnPayment("hotItems", "others");

        SpawnCash.instance.StartCoroutine("RectHeightUpdate");
    }

    public void NewArrivalSpawned()
    {
        SpawnSubCategory.instance.DestroySubcategorySpawned();
        SpawnCash.instance.DestroyAllSpawned();
        SpawnCash.instance.spawned = true;
        SpawnCash.instance.SpawnPayment("newArrival", null);

//        SpawnCash.instance.SpawnNewArrival();
        SpawnCash.instance.StartCoroutine("RectHeightUpdate");

    }

    public void OnPressHotItems()
    {
        SpawnCash.instance.DestroyAllSpawned();

        SpawnCash.instance.spawned = true;
        // SpawnCash.instance.SpawnPayment("hotItems");
        SpawnCash.instance.SpawnPayment("hotItems", "all");

        SpawnSubCategory.instance.DestroySubcategorySpawned();
        SpawnSubCategory.instance.SpawnSubcategory();


        all = GameObject.Find("all");
        all.GetComponent<Button>().onClick.AddListener(AllSpawned);

        clothing = GameObject.Find("clothing");
        hair = GameObject.Find("hair");
        footwear = GameObject.Find("footwear");
        others = GameObject.Find("others");

        clothing.GetComponent<Button>().onClick.AddListener(ClothingSpawned);
        hair.GetComponent<Button>().onClick.AddListener(HairSpawned);
        footwear.GetComponent<Button>().onClick.AddListener(FootwearSpawned);
        others.GetComponent<Button>().onClick.AddListener(OthersSpawned);
        SpawnCash.instance.StartCoroutine("RectHeightUpdate");


    }



    public void CoatSpawned()
    {
        SpawnSubCategory.instance.DestroySubcategorySpawned();
        Debug.Log("Coat is Called");
        SpawnCash.instance.DestroyAllSpawned();
        SpawnCash.instance.spawned = true;
        SpawnCash.instance.SpawnCoat();
        SpawnCash.instance.StartCoroutine("RectHeightUpdate");

        // SpawnCash.instance.SpawnPayment("Coat");
    }

    public void ShirtSpawned()
    {
        SpawnSubCategory.instance.DestroySubcategorySpawned();

        SpawnCash.instance.DestroyAllSpawned();
        SpawnCash.instance.spawned = true;
        SpawnCash.instance.SpawnPayment("shirt", null);

        // SpawnCash.instance.SpawnShirt();
        SpawnCash.instance.StartCoroutine("RectHeightUpdate");

    }

    public void AllSpawned()
    {
        SpawnCash.instance.DestroyAllSpawned();
        // Debug.Log("All is Called");
        SpawnCash.instance.spawned = true;
        // SpawnCash.instance.SpawnAll();
        SpawnCash.instance.SpawnPayment("hotItems", "all");

        SpawnCash.instance.StartCoroutine("RectHeightUpdate");

    }

    public void HairSpawned()
    {
        SpawnCash.instance.DestroyAllSpawned();

        //SpawnSubCategory.instance.DestroySubcategorySpawned();
        SpawnCash.instance.spawned = true;
        // SpawnCash.instance.SpawnHair();
        SpawnCash.instance.SpawnPayment("hotItems", "hair");

        SpawnCash.instance.StartCoroutine("RectHeightUpdate");

    }

    public void GlassesSpawned()
    {
        SpawnCash.instance.DestroyAllSpawned();
        SpawnCash.instance.spawned = true;
        SpawnCash.instance.SpawnGlasses();
        SpawnCash.instance.StartCoroutine("RectHeightUpdate");

    }

    public void JacketSpawned()
    {
        SpawnSubCategory.instance.DestroySubcategorySpawned();

        SpawnCash.instance.DestroyAllSpawned();
        SpawnCash.instance.spawned = true;
        SpawnCash.instance.SpawnPayment("jacket", null);

        // SpawnCash.instance.SpawnJacket();
        SpawnCash.instance.StartCoroutine("RectHeightUpdate");


    }

    public void ClothingSpawned()
    {
        //SpawnSubCategory.instance.DestroySubcategorySpawned();
        SpawnCash.instance.DestroyAllSpawned();
        // Debug.Log("Clothing is Called");
        SpawnCash.instance.spawned = true;
        // SpawnCash.instance.SpawnClothing();
        SpawnCash.instance.SpawnPayment("hotItems", "clothing");

        SpawnCash.instance.StartCoroutine("RectHeightUpdate");


    }

    public void FootwearSpawned()
    {
        //SpawnSubCategory.instance.DestroySubcategorySpawned();
        SpawnCash.instance.DestroyAllSpawned();
        SpawnCash.instance.spawned = true;
        // SpawnCash.instance.SpawnFootwear();
        SpawnCash.instance.SpawnPayment("hotItems", "footwear");

        SpawnCash.instance.StartCoroutine("RectHeightUpdate");

        

    }
    
}















// foreach(GameObject gameObj in GameObject.FindObjectsOfType<GameObject>())
// {
//     if(gameObj.name == "payment")
//     {
//         Destroy(gameObj);
//     }
// }

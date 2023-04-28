using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Item
{
    public string paymentType;
    public int price;
    public string icon;
    public string itemsImage;
}

[System.Serializable]
public class SubCategory
{
    public string subCategory;
    public List<Item> items;
    public string subCategoryName;
    public string subCategoryImage;
    public int? width;
    public int? height;
    public string paymentType;
    public int? price;
    public string icon;
}

[System.Serializable]
public class Datum  //Use Proper Namming
{
    public string mainCategoryName;
    public string mainCategoryImage;
    public int width;
    public int height;
    public bool hasSubCategory;
    public List<SubCategory> subCategory;
}

[System.Serializable]
public class RootModel
{
    public List<Datum> data;
}
// code flow -- must be in order
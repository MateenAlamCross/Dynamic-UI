using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Datum
{
    public string mainCategoryName { get; set; }
    public string mainCategoryImage { get; set; }
    public int width { get; set; }
    public int height { get; set; }
    public bool hasSubCategory { get; set; }
    public List<SubCategory> subCategory { get; set; }
}

[System.Serializable]
public class Item
{
    public string paymentType { get; set; }
    public int price { get; set; }
    public string icon { get; set; }
    public string itemsImage { get; set; }
}

[System.Serializable]
public class RootModel
{
    public List<Datum> data { get; set; }
}
[System.Serializable]
public class SubCategory
{
    public string subCategory { get; set; }
    public List<Item> items { get; set; }
    public string subCategoryName { get; set; }
    public string subCategoryImage { get; set; }
    public int? width { get; set; }
    public int? height { get; set; }
    public string paymentType { get; set; }
    public int? price { get; set; }
    public string icon { get; set; }
}

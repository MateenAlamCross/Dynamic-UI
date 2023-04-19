
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class JSONDataModel 
{
    [System.Serializable]
    public class Item
    {
        public string paymentType;
        public int price;
        public string icon;
    }
    [System.Serializable]
    public class SubCategory
    {
        public string subCategoryName;
        public List<Item> items;
    }
    [System.Serializable]
    public class Data
    {
        public string mainCategoryName;
        public string mainCategoryImage;
        public long width;
        public long height;
        public bool hasSubcategory;
        public List<SubCategory> subCategory;
    }
    [System.Serializable]
    public class RootObject
    {
        public List<Data> data;
        // public Data[] data;
    }
}

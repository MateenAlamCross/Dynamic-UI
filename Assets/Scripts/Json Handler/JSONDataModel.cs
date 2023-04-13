
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JSONDataModel 
{
    public class Item
    {
        public string paymentType;
        public int price;
        public string icon;
    }
    
    public class SubCategory
    {
        public string subCategoryName;
        public List<Item> items;
    }
    
    public class Data
    {
        public string mainCategoryName;
        public string mainCategoryImage;
        public long width;
        public long height;
        public bool hasSubcategory;
        public List<SubCategory> subCategory;
    }
    
    public class RootObject
    {
        public List<Data> data;
        // public Data[] data;
    }
}

using System;
using System.Collections.Generic;

[Serializable]
public class ApiResponse
{
    public Record record;
}

[Serializable]
public class Record
{
    public List<Item> items;
}

[Serializable]
public class Item
{
    public int id;
    public string name;
    public string category;
    public float price;
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    public static int TYPESEED = 1;
    public static int TYPEHOE = 2;
    public string name;
    public string imgUrl;
    public string imgUrl2;
    public int type;
    public float timeToGrow;

    public Item(string name, string imgUrl, string imgUrl2, int type,  float timeToGrow)
    {
        this.name = name;
        this.imgUrl = imgUrl;
        this.imgUrl2 = imgUrl2;
        this.type = type;
        this.timeToGrow = timeToGrow;
    }

}

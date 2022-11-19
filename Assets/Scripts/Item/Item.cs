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
    public int count;
    public int price;
    public int lvlWhenUncloked;
    public float timeToGrow;

    public Item(string name, string imgUrl, string imgUrl2, int type, int count, int price, int lvlWhenUnlocked, float timeToGrow)
    {
        this.name = name;
        this.imgUrl = imgUrl;
        this.imgUrl2 = imgUrl2;
        this.type = type;
        this.count = count;
        this.price = price;
        this.lvlWhenUncloked = lvlWhenUnlocked;
        this.timeToGrow = timeToGrow;
    }

}

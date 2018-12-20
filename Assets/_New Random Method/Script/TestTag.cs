using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestTag : MonoBehaviour {

    public enum Tags {Item_1, Item_2, Item_3, Item_4, Item_5, Item_6, Item_7, Item_8,Item_9 };
    public Tags ItemTag = new Tags();

    private void Start()
    {
        this.gameObject.tag = ItemTag.ToString();
    }
}

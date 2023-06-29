using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GetItem
    {
        public string ItemName;
        public Sprite ItemImage;
        public int weight;

        public GetItem(GetItem getItem)
        {
            this.ItemName = getItem.ItemName;
            this.ItemName = getItem.ItemName;
            this.weight = getItem.weight;
        }
    }

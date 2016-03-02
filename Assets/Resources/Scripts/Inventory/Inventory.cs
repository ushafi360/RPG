using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Inventory {

    private static Inventory _inventory;

    private static List<BaseItem> inventoryItems;
    private static List<int> itemCount;

    public static Inventory _Inventory
    {
        get
        {
            if (_inventory == null)
            {
                _inventory = new Inventory();
            }
            return _inventory;
        }
    }

    public Inventory()
    {
        if(inventoryItems == null)
        {
            inventoryItems = new List<BaseItem>();
        }
        if(itemCount == null)
        {
            itemCount = new List<int>();
        }
    }

    public static List<BaseItem> InventoryItems
    {
        get { return inventoryItems; }
        set { inventoryItems = value; }
    }
    public static List<int> ItemCount
    {
        get { return itemCount; }
        set { itemCount = value; }
    }

    public void AddToInventory(BaseItem item)
    {
        if (InventoryItems.Contains(item))
        {
            AddOldItem(item);
        }
        else
        {
            AddNewItem(item);
        }
    }

    private void AddNewItem(BaseItem item)
    {
        InventoryItems.Add(item);
        ItemCount.Add(1);
    }

    private void AddOldItem(BaseItem item)
    {
        int index = InventoryItems.IndexOf(item);
        ItemCount[index]++;
        Debug.Log("Count of item" + item.ItemName + " incremented");
    }

}

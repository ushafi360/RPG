using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.IO;

public class ItemDatabase {

    private static ItemDatabase _itemDBManager;

    public TextAsset itemInventory;
    public List<BaseItem> dbItems = new List<BaseItem>(); // These will be used by other scripts

    private List<Dictionary<string, string>> inventoryDict = new List<Dictionary<string, string>>();
    private Dictionary<string, string> itemsDict = new Dictionary<string, string>();

    public static ItemDatabase _ItemDBManager
    {
        get
        {
            if (_itemDBManager == null)
            {
                _itemDBManager = new ItemDatabase();
            }
            return _itemDBManager;
        }
    }

    public ItemDatabase()
    {

        itemInventory = (TextAsset)Resources.Load(Constant.Paths.XML_ITEM_DB);

        ReadItemsFromFile();
        for (int i = 0; i < inventoryDict.Count; i++)
        {
            if ((BaseItem.ItemTypes)System.Enum.Parse(typeof(BaseItem.ItemTypes), (inventoryDict[i])["itemType"].ToString()) == BaseItem.ItemTypes.WEAPON)
            {
                dbItems.Add(new BaseWeapon(inventoryDict[i]));
            }
            else if ((BaseItem.ItemTypes)System.Enum.Parse(typeof(BaseItem.ItemTypes), (inventoryDict[i])["itemType"].ToString()) == BaseItem.ItemTypes.EQUIPMENT)
            {
                dbItems.Add(new BaseEquipment(inventoryDict[i]));
            }
            else if ((BaseItem.ItemTypes)System.Enum.Parse(typeof(BaseItem.ItemTypes), (inventoryDict[i])["itemType"].ToString()) == BaseItem.ItemTypes.POTION)
            {
                dbItems.Add(new BasePotion(inventoryDict[i]));
            }
        }
    }


    private void ReadItemsFromFile()
    {
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.LoadXml(itemInventory.text);
        XmlNodeList itemList = xmlDoc.GetElementsByTagName(Constant.ItemDB.Keys.ROOT);

        foreach (XmlNode itemInfo in itemList)
        {
            XmlNodeList itemContent = itemInfo.ChildNodes;
            itemsDict = new Dictionary<string, string>();

            foreach (XmlNode content in itemContent)
            {
                itemsDict.Add(content.Name, content.InnerText);
                // TODO This switch case might not be needed
                switch (content.Name)
                {
                    case Constant.ItemDB.Keys.NAME:
                        //itemDictionary.Add("itemName",content.InnerText);
                        break;
                    case Constant.ItemDB.Keys.ID:
                        //itemDictionary.Add("itemID", content.InnerText);
                        break;
                    case Constant.ItemDB.Keys.TYPE:
                        //itemDictionary.Add("itemType", content.InnerText);
                        break;
                }
            }

            inventoryDict.Add(itemsDict);

        }
    }

    public BaseItem GetRandomItem()
    {
        return dbItems[Mathf.FloorToInt(Random.Range(0, dbItems.Count))];
    }

    public void DumpDatabase()
    {
        foreach(BaseItem item in dbItems)
        {
            Debug.Log(item.ItemName);
            Debug.Log(item.ItemType);
            Debug.Log(item.Rarity);
            Debug.Log("\n\n\n");
        }
    }

}

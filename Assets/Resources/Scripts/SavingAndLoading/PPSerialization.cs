using UnityEngine;
using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

public class PPSerialization {

    public static BinaryFormatter binaryFormatter = new BinaryFormatter();

    public void SaveToFile()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/playerInfo.dat");

        PlayerData data = new PlayerData();
        data.ChDaisy = GameInformation.ChDaisy;
        data.ChHan = GameInformation.ChHan;
        data.ChHarry = GameInformation.ChHarry;
        data.ChJohn = GameInformation.ChJohn;

        bf.Serialize(file, data);
        file.Close();
        Debug.Log("Data Saved to file successfully");
    }

    public void LoadFromFile()
    {
        if(File.Exists(Application.persistentDataPath + "/playerInfo.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/playerInfo.dat", FileMode.Open);
            PlayerData data = (PlayerData)bf.Deserialize(file);

            GameInformation.ChDaisy = data.ChDaisy;
            GameInformation.ChHan = data.ChHan;
            GameInformation.ChHarry = data.ChHarry;
            GameInformation.ChJohn = data.ChJohn;

            Debug.Log("Data Loaded from file successfully");
        }
        else
        {
            Debug.Log("Save file does not exist");
        }
        
    }


    [Serializable]
    private class PlayerData
    {
        public BasePlayer ChJohn { get; set; }
        public BasePlayer ChDaisy { get; set; }
        public BasePlayer ChHan { get; set; }
        public BasePlayer ChHarry { get; set; }
    }

}

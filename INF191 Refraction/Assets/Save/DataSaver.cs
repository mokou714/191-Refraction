using System;
using System.IO;
using UnityEngine;
using Newtonsoft.Json;
public class DataSaver : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    //save data to local drive when quitting
    protected void OnApplicationQuit()
    {
        SaveData();
    }

    private void SaveData()
    {
        Debug.Log("Saving...");
        if (Data.userData == null) return;
        var path = "./Users/" + Data.userData.accountId + "/data.json";
        var fileWriter = new StreamWriter(path);
        var json = JsonConvert.SerializeObject(Data.userData);
        Debug.Log(json);
        fileWriter.WriteLine(json);
        fileWriter.Close();
    }

}

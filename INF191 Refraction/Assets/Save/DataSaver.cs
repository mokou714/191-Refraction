using System.IO;
using UnityEngine;
using Newtonsoft.Json;
public abstract class DataSaver : MonoBehaviour
{
    private bool _isQuitting;
    
    //save data when changing scenes
    private void OnDestroy()
    {
        Debug.Log("Being destroyed...");
        if(!_isQuitting)
            SaveData();
    }

    //save data to local drive when quitting
    protected void OnApplicationQuit()
    {
        Debug.Log("Saving...");
        if (Data.userData == null) return;
        
        var path = "./Users/" + Data.userData.accountId + "/data.json";

        var fileWriter = new StreamWriter(path);

        var json = JsonConvert.SerializeObject(Data.userData);
        Debug.Log(json);
        fileWriter.WriteLine(json);
        fileWriter.Close();
        _isQuitting = true;
    }

    protected abstract void SaveData();

}

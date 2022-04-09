using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class ControlGame : MonoBehaviour
{
    public static ControlGame instance;

    public string namePlayer;
    public string namePlayerBestScore;
    public int bestScore;


    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);

            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);

        LoadGame();
    }

    [System.Serializable]
    class SaveData
    {
        public string namePlayerBestScore;
        public int bestScore;
    }


    public void SaveGame()
    {
        string path = Application.persistentDataPath + "/savebinary.dat";
        FileStream file = File.Create(path);

        SaveData data = new SaveData();
        data.bestScore = bestScore;
        data.namePlayerBestScore = namePlayer;

        BinaryFormatter bf = new BinaryFormatter();
        bf.Serialize(file, data);

        file.Close();
    }


    public void LoadGame()
    {
        string path = Application.persistentDataPath + "/savebinary.dat";

        if (File.Exists(path))
        {
            FileStream file = File.Open(path, FileMode.Open);

            BinaryFormatter bf = new BinaryFormatter();
            SaveData data = (SaveData)bf.Deserialize(file);

            namePlayerBestScore = data.namePlayerBestScore;
            bestScore = data.bestScore;

            file.Close();
        }
    }

}

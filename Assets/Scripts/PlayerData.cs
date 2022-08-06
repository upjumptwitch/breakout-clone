using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class PlayerData : MonoBehaviour
{
    public static PlayerData Instance;
    public string Name;
    public int Score;

    [System.Serializable]
    class SaveData
    {
        public string Name;
        public int Score;
    }
    private void Awake()
    {
        // start of new code
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        // end of new code

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    public void SaveScore()
    {
        SaveData data = new SaveData();
        data.Name = Name;
        data.Score = Score;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            Name = data.Name;
            Score = data.Score;
        }
    }

}

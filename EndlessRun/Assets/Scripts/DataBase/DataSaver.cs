using UnityEngine;
using System;
using Firebase.Database;

[Serializable]
public class dataTosave
{
    public int highscore;
}
public class DataSaver : MonoBehaviour
{
    public dataTosave dataTosave;
    public int highscore;
    DatabaseReference dbRef;

    public void Awake()
    {
        dbRef = FirebaseDatabase.DefaultInstance.RootReference;

    }

    public void SaveDataFn()
    {
        string json = JsonUtility.ToJson(dataTosave);
        dbRef.Child("HighScore").Child(highscore.ToString()).SetRawJsonValueAsync(json);
    }
}

using Firebase.Database;
using UnityEngine;
using UnityEngine.UI;

public class DatabaseManger : MonoBehaviour
{
    public InputField Name;
    public InputField Gold;

    private string userID;
    private DatabaseReference databaseReference;
    void Start()
    {
        userID = SystemInfo.deviceUniqueIdentifier;
        databaseReference = FirebaseDatabase.DefaultInstance.RootReference;
    }

   public void CreateUser()
    {
        User newUser = new User(Name.text, int.Parse(Gold.text));
        string json = JsonUtility.ToJson(newUser);

        databaseReference.Child("users").Child(userID).SetRawJsonValueAsync(json);
    }
}

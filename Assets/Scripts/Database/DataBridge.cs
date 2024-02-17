using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Database;
using System;
using UnityEngine;
//using Firebase.Unity.Editor;

public class DataBridge : MonoBehaviour
{
    private TestDatabasePlayer _data;
    private string DATA_URL = "https://cursova-2023-default-rtdb.europe-west1.firebasedatabase.app/";

    private DatabaseReference _databaseReference;
    private FirebaseDatabase _database;
    private void Start()
    {
        _database = FirebaseDatabase.GetInstance(DATA_URL);
        _databaseReference = _database.RootReference;
        SaveDate();
    }

    public void SaveDate()
    {
        _data = new TestDatabasePlayer("mk2", 101);
        string jsonData = JsonUtility.ToJson(_data);
        _databaseReference.Child("User").SetRawJsonValueAsync(jsonData);
        _data = new TestDatabasePlayer("mk1", 111);
        jsonData = JsonUtility.ToJson(_data);
        _databaseReference.Child("User2").SetRawJsonValueAsync(jsonData);
    }
    public void LoadDate()
    {

    }
}

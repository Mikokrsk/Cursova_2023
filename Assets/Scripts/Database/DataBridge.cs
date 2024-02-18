using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Database;
using System;
using UnityEngine;
using UnityEditor.PackageManager;
using System.Threading.Tasks;
//using Firebase.Unity.Editor;

public class DataBridge : MonoBehaviour
{
    private TestDatabasePlayer _data;
    private string DATA_URL = "https://cursova-2023-default-rtdb.europe-west1.firebasedatabase.app/";
    public static DataBridge Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private DatabaseReference _databaseReference;
    private FirebaseDatabase _database;
    private void Start()
    {
        _database = FirebaseDatabase.GetInstance(DATA_URL);
        _databaseReference = _database.RootReference;
        //  SaveDate();
    }
    /*
        public void SaveDate()
        {
            _data = new TestDatabasePlayer("mk2", 101);
            string jsonData = JsonUtility.ToJson(_data);
            _databaseReference.Child("User").SetRawJsonValueAsync(jsonData);
        }*/
    public void SaveLeaderbordData(List<LeaderbordData> leaderbordData)
    {
        foreach (var player in leaderbordData)
        {
            var data = player;
            string jsonData = JsonUtility.ToJson(data);
            _databaseReference.Child($"User {player.playerPosition}").SetRawJsonValueAsync(jsonData);
        }
    }
    /*    public void LoadDate()
        {
            List<LeaderbordData> leaderbordData;
            var jsonData = _databaseReference.Child("User 1").GetValueAsync();
            jsonData.
                // _databaseReference.Child($"User {1}").GetValueAsync().ToString();
            Debug.Log(jsonData);


                // return leaderbordData;
            }*/


    public async Task<List<LeaderbordData>> LoadLeaderboardData()
    {
        List<LeaderbordData> leaderboardDataList = new List<LeaderbordData>();

        try
        {
            var dataSnapshot = await _databaseReference.GetValueAsync();
            if (dataSnapshot != null && dataSnapshot.Exists)
            {
                foreach (var childSnapshot in dataSnapshot.Children)
                {

                    string jsonData = childSnapshot.GetRawJsonValue();

                    LeaderbordData playerData = JsonUtility.FromJson<LeaderbordData>(jsonData);

                    leaderboardDataList.Add(playerData);
                    Debug.Log(playerData.playerName);
                }
            }
            else
            {
                Debug.LogWarning("Data not found");
            }
        }
        catch (Exception ex)
        {
            Debug.LogError($"Error : {ex.Message}");
        }

        return leaderboardDataList;
    }

}

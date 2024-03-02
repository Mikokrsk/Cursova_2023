using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Database;
using System;
using System.Threading.Tasks;
//using Firebase.Unity.Editor;

public class DataBridge : MonoBehaviour
{
    // private TestDatabasePlayer _data;
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
    }

    public void SaveLeaderboardData(List<LeaderboardData> leaderboardData)
    {
        foreach (var player in leaderboardData)
        {
            var data = player;
            string jsonData = JsonUtility.ToJson(data);
            _databaseReference.Child($"User {player.playerName}").SetRawJsonValueAsync(jsonData);
        }
    }

    public async Task<List<LeaderboardData>> LoadLeaderboardDataAsync()
    {
        List<LeaderboardData> leaderboardDataList = new List<LeaderboardData>();

        try
        {
            var dataSnapshot = await _databaseReference.GetValueAsync();
            if (dataSnapshot != null && dataSnapshot.Exists)
            {
                foreach (var childSnapshot in dataSnapshot.Children)
                {

                    string jsonData = childSnapshot.GetRawJsonValue();

                    LeaderboardData playerData = JsonUtility.FromJson<LeaderboardData>(jsonData);

                    leaderboardDataList.Add(playerData);
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

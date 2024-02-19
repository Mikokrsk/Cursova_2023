using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class LeaderboardManager : MonoBehaviour
{
    private ScrollView _scrollView;
    private List<LeaderboardLabelsObject> LeaderboardLabelsObjectsList = new List<LeaderboardLabelsObject>();
    private List<LeaderboardData> _leaderboardDataList = new List<LeaderboardData>();
    [SerializeField] private string _name;
    [SerializeField] private int _points;
    private void Awake()
    {
        _scrollView = UIHandler.Instance._uiDocument.rootVisualElement.Q<ScrollView>("LeaderbordScrollView");
        UIHandler.Instance._uiDocument.rootVisualElement.Q<Button>("AddNewPlayerButton").clickable.clicked += AddNewPlayer;
        UIHandler.Instance._uiDocument.rootVisualElement.Q<Button>("LoadLeaderboardButton").clickable.clicked += LoadLeaderbordData;
    }
    private void Start()
    {
        LeaderboardLabelsObjectsList.Clear();
        LoadLeaderbordData();
        UpdateList();
    }


    private void AddNewPlayer()
    {
        string name = UIHandler.Instance._uiDocument.rootVisualElement.Q<TextField>("PlayerNameTextFiel").value;
        int points = Int32.Parse(UIHandler.Instance._uiDocument.rootVisualElement.Q<TextField>("PLayerPointsTextField").value);

        if (!FindDublicateByName(name, points))
            LeaderboardLabelsObjectsList.Add(new LeaderboardLabelsObject(name, points));
        SaveLeaderbordData();
        _scrollView.contentContainer.Clear();
        UpdateList();
    }
    private bool FindDublicateByName(string name, int points)
    {
        foreach (var player in LeaderboardLabelsObjectsList)
        {
            if (player.playerName.text == name)
            {
                if (Int32.Parse(player.playerPoints.text) < points)
                {
                    player.playerPoints.text = points.ToString();
                }
                return true;
            }
        }
        return false;
    }
    private void UpdateList()
    {
        _scrollView.contentContainer.Clear();
        int position = 1;
        LeaderboardLabelsObjectsList = LeaderboardLabelsObjectsList.OrderByDescending(x => Int32.Parse(x.playerPoints.text)).ToList();
        foreach (var item in LeaderboardLabelsObjectsList)
        {
            VisualElement player = new VisualElement();
            player.style.flexDirection = FlexDirection.Row;
            player.Add(item.playerName);
            player.Add(item.playerPoints);
            item.playerPosition.text = position.ToString();
            player.Add(item.playerPosition);
            _scrollView.Add(player);
            position += 1;
        }
    }
    private void SaveLeaderbordData()
    {
        foreach (var player in LeaderboardLabelsObjectsList)
        {
            _leaderboardDataList.Add(new LeaderboardData(player.playerName.text, player.playerPoints.text));
        }
        DataBridge.Instance.SaveLeaderboardData(_leaderboardDataList);
    }
    private async void LoadLeaderbordData()
    {
        List<LeaderboardData> list = await DataBridge.Instance.LoadLeaderboardDataAsync();
        LeaderboardLabelsObjectsList.Clear();
        foreach (var player in list)
        {
            LeaderboardLabelsObjectsList.Add(new LeaderboardLabelsObject(player.playerName, Int32.Parse(player.playerPoints)));
        }
        UpdateList();
    }
}

public class LeaderboardLabelsObject
{
    public Label playerName;
    public Label playerPoints;
    public Label playerPosition;

    public LeaderboardLabelsObject(string name, int points)
    {
        playerName = new Label(name);
        playerPoints = new Label(points.ToString());
        playerPosition = new Label();

        playerName.style.flexGrow = 1;
        playerPoints.style.flexGrow = 1;
        playerPosition.style.flexGrow = 1;

        playerName.style.fontSize = 40;
        playerPoints.style.fontSize = 40;
        playerPosition.style.fontSize = 40;

        playerName.style.unityFontStyleAndWeight = FontStyle.Bold;
        playerPoints.style.unityFontStyleAndWeight = FontStyle.Bold;
        playerPosition.style.unityFontStyleAndWeight = FontStyle.Bold;

        playerName.style.unityTextAlign = TextAnchor.MiddleCenter;
        playerPoints.style.unityTextAlign = TextAnchor.MiddleCenter;
        playerPosition.style.unityTextAlign = TextAnchor.MiddleCenter;
    }
}


[Serializable]
public class LeaderboardData
{
    public string playerName;
    public string playerPoints;

    public LeaderboardData(string _playerName, string _playerPoints)
    {
        this.playerName = _playerName;
        this.playerPoints = _playerPoints;
    }
}
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class LeaderbordManager : MonoBehaviour
{
    private ScrollView _scrollView;
    private List<ItemProperty> players = new List<ItemProperty>();
    [SerializeField] private string _name;
    [SerializeField] private int _points;
    [SerializeField] private bool _createNewPlayer;
    private void OnEnable()
    {
        _scrollView = UIHandler.Instance._uiDocument.rootVisualElement.Q<ScrollView>("LeaderbordScrollView");
        if (_createNewPlayer)
            AddNewPlayer(_name, _points);
        UpdateList();
    }
    private void Start()
    {
        players.Clear();
        UpdateList();
    }
    private void AddNewPlayer(string name, int points)
    {
        if (!FindDublicateByName(name, points))
            players.Add(new ItemProperty(name, points));
        UpdateList();
    }
    private bool FindDublicateByName(string name, int points)
    {
        foreach (var player in players)
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
        players = players.OrderByDescending(x => Int32.Parse(x.playerPoints.text)).ToList();
        foreach (var item in players)
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
}

public class ItemProperty
{
    public Label playerName;
    public Label playerPoints;
    public Label playerPosition;

    public ItemProperty(string name, int points)
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

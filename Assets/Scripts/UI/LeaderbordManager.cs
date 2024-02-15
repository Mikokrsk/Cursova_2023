using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class LeaderbordManager : MonoBehaviour
{
    private ScrollView _scrollView;
    private List<ItemProperty> players = new List<ItemProperty>();
    private void OnEnable()
    {
        _scrollView = UIHandler.Instance._uiDocument.rootVisualElement.Q<ScrollView>("LeaderbordScrollView");
        AddNewPlayer("111", 1, 1);
    }
    private void Start()
    {
        players.Clear();
        players.Add(new ItemProperty("111", 1, 1));
        players.Add(new ItemProperty("222", 2, 2));
        players.Add(new ItemProperty("333", 3, 3));
        UpdateList();
    }
    private void AddNewPlayer(string name, int points, int position)
    {
        players.Add(new ItemProperty(name, points, position));
        UpdateList();
    }
    private void UpdateList()
    {
        foreach (var item in players)
        {
            VisualElement player = new VisualElement();
            player.style.flexDirection = FlexDirection.Row;
            player.Add(item.playerName);
            player.Add(item.playerPoints);
            player.Add(item.playerPosition);
            _scrollView.Add(player);
        }
    }
}

public class ItemProperty
{
    public Label playerName;
    public Label playerPoints;
    public Label playerPosition;

    public ItemProperty(string name, int points, int position)
    {
        playerName = new Label(name);
        playerPoints = new Label(points.ToString());
        playerPosition = new Label(position.ToString());

        playerName.style.flexGrow = 1;
        playerPoints.style.flexGrow = 1;
        playerPosition.style.flexGrow = 1;

        playerName.style.fontSize = 40;
        playerPoints.style.fontSize = 40;
        playerPosition.style.fontSize = 40;

        playerName.style.unityFontStyleAndWeight = FontStyle.Bold;
        playerPoints.style.unityFontStyleAndWeight = FontStyle.Bold;
        playerPosition.style.unityFontStyleAndWeight = FontStyle.Bold;
    }
}

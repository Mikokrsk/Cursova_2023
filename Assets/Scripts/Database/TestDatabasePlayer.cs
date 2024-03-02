using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class TestDatabasePlayer : MonoBehaviour
{
    public string username;
    public int points;

    public TestDatabasePlayer() { }


    public TestDatabasePlayer(string _username, int _points)
    {
        username = _username;
        points = _points;
    }

}
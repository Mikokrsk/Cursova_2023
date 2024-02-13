using Save;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //[SerializeField] private GameObject pause;
    // Start is called before the first frame update
    public static GameManager Instance { get; private set; }
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

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(Time.timeScale == 1.0f)
            {
                Time.timeScale = 0.0f;
               // pause.SetActive(true);
            }
            else
            {
                Time .timeScale = 1.0f;
               // pause.SetActive(false);
            }
        }
    }
}

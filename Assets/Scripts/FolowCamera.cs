using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FolowCamera : MonoBehaviour
{
    [SerializeField] private Player player;
    public Camera cam;
    private void Start()
    {
        player = GetComponent<Player>();
        cam = Camera.main;
    }
    private void Update()
    {
        /* if (player.transform.position.y >= 0)
         {
             cam.transform.position = new Vector3(player.transform.position.x, player.transform.position.y,-10);
         }
         else
         {
             cam.transform.position = new Vector3(player.transform.position.x, 0,-10);
         }*/
        cam.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, -10);
    }
}

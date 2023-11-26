using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FolowCamera : MonoBehaviour
{
    [SerializeField] private Player _player;
    public Camera cam;
    private void Start()
    {
        _player = GetComponent<Player>();
        cam = Camera.main;
    }
    private void Update()
    {
        cam.transform.position = new Vector3(_player.transform.position.x, _player.transform.position.y, -10);
    }
}

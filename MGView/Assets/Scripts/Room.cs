using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class Room : MonoBehaviour
{

    [SerializeField] private Timeline roomTimeline;

    public Timeline RoomTimeline
    {
        get => roomTimeline;
    }
    
    [SerializeField] private int roomId;

    public int RoomId
    {
        get => roomId;
    }
    
    [SerializeField] private string roomName;

    public string RoomName
    {
        get => roomName;
    }


    private RoomManager _roomManager;
    
    private void Start()
    {
        _roomManager = RoomManager.Instance;
    }
    
    
}

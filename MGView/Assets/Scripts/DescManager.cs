using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DescManager : MonoBehaviour
{
    private TextMeshProUGUI _descText;

    private RoomManager _roomManager;

    private string _desc;
    
    void Start()
    {
        _descText = GetComponent<TextMeshProUGUI>();
        _roomManager = RoomManager.Instance;
    }

    private void Update()
    {
        _desc = "";
        
        foreach (Room room in _roomManager.Rooms)
        {
            _desc += "" + (room.RoomId + 1) + ". " + room.RoomName + " \n";
        }

        _descText.text = _desc;
    }
}

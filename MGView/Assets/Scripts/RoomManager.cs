
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RoomManager : MonoBehaviour
{
    private Room _currentRoom;

    [SerializeField] private List<Room> rooms;
    [SerializeField] private GameObject nameUI;
    
    [SerializeField] private Image pastView;
    [SerializeField] private Image actualView;
    
    private static RoomManager _instance;

    public static RoomManager Instance
    {
        get => _instance;
    }

    private ViewSwitcher _viewSwitcher;
    
    void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }

        _viewSwitcher = FindObjectOfType<ViewSwitcher>();
    }

    private void Start()
    {
        SwitchToRoom(0);
    }
    

    public void SwitchToRoom(int roomIndex)
    {
        Debug.Log("switch room");
        Room newRoom = GetRoomById(roomIndex);

        nameUI.GetComponent<TextMeshProUGUI>().text = newRoom.RoomName;
        SwitchTimeline(newRoom);

        pastView.sprite = newRoom.RoomTimeline.TimelineView[0];
        actualView.sprite = newRoom.RoomTimeline.TimelineView[1];

        _currentRoom = newRoom;
    }

    private Room GetRoomById(int roomIndex)
    {
        return rooms.FirstOrDefault(room => room.RoomId == roomIndex);
    }

    private void SwitchTimeline(Room newRoom)
    {
        for (float i = 0; i < newRoom.RoomTimeline.TimelinePoints.Count; i++)
        {
            float position = i / (newRoom.RoomTimeline.TimelinePoints.Count - 1);
            RectTransform parent = _viewSwitcher.TimelineParent;

            float beginY = parent.anchoredPosition.y + parent.rect.height / 2;
            float positionY = beginY - (parent.rect.height * position);

            GameObject tl = new GameObject("Timeline " + newRoom.RoomTimeline.TimelinePoints[(int)i]);
            tl.transform.parent = parent.transform;
            RectTransform tlTransform = tl.AddComponent<RectTransform>();

            tlTransform.anchoredPosition = new Vector2(parent.anchoredPosition.x,positionY);

            GameObject tlText = new GameObject("Text");
            tlText.transform.parent = tl.transform;
            RectTransform tlTextTransform = tlText.AddComponent<RectTransform>();
            Text text = tlText.AddComponent<Text>();
            text.text = newRoom.RoomTimeline.TimelinePoints[(int)i].ToString();
            tlTextTransform.anchoredPosition = new Vector2(65, 0);
            text.font = Resources.GetBuiltinResource<Font>("Arial.ttf");
            text.fontSize = 30;
            text.alignment = TextAnchor.MiddleCenter;
        }
    }
}

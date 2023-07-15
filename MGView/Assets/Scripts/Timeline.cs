using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Timeline
{
    [SerializeField] private List<int> timelinePoints;

    public List<int> TimelinePoints
    {
        get => timelinePoints;
    }

    [SerializeField] private List<Sprite> timelineView;

    public List<Sprite> TimelineView
    {
        get => timelineView;
    }

}

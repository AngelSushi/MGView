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
        private set => timelinePoints = value;
    }

    public Timeline(List<int> timelinePoints)
    {
        this.timelinePoints = timelinePoints;
    }
}

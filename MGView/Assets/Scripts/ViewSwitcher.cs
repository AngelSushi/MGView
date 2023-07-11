using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ViewSwitcher : MonoBehaviour
{

    [SerializeField] private Image pastView;
    [SerializeField] private Image actualView;
    [SerializeField] private RectTransform timelineParent;
    
    public Image PastView
    {
        get => pastView;
    }

    public Image ActualView
    {
        get => actualView;
    }

    public RectTransform TimelineParent
    {
        get => timelineParent;
    }

    private Slider _slider;

    private void Start()
    {
        _slider = GetComponent<Slider>() ?? GetComponentInChildren<Slider>();
        ApplyPastAlpha();
    }

    public void ApplyPastAlpha()
    {
        actualView.color = new Color(actualView.color.r, actualView.color.g, actualView.color.b, _slider.value);
    }

}

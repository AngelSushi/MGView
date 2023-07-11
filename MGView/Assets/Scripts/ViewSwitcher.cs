using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ViewSwitcher : MonoBehaviour
{

    [SerializeField] private Image pastView;
    [SerializeField] private Image actualView;

    public Image PastView
    {
        get => pastView;
        set => pastView = value;
    }

    public Image ActualView
    {
        get => actualView;
        set => actualView = value;
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

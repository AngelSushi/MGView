using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{

    [SerializeField] private GameObject mapCanvas;

    public void OpenMap()
    {
        mapCanvas.SetActive(true);
    }

    public void CloseMap()
    {
        mapCanvas.SetActive(false);
    }


}

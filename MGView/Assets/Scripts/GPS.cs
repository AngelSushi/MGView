using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using TMPro;
using UnityEngine;

public class GPS : MonoBehaviour
{


    [SerializeField] private TextMeshProUGUI dataText;
    
    void Start()
    {
        StartCoroutine(StartGPS());
    }

    private IEnumerator StartGPS()
    {
        if (!Input.location.isEnabledByUser)
        {
            Debug.Log("location is disable by user");
            yield break;
        }
        
        Input.location.Start();

        int wait = 20;

        while (Input.location.status == LocationServiceStatus.Initializing && wait > 0)
        {
            yield return new WaitForSeconds(1f);
            wait--;
        }

        if (wait == 0 || Input.location.status == LocationServiceStatus.Failed)
        {
            Debug.Log("Error when initializing GPS");
            yield return null;
        }
        else
        {
            InvokeRepeating("GetGPSData",0.5f,1f);     
        }
    }

    private void GetGPSData()
    {
        Debug.Log("enter here " + Input.location.lastData.latitude + " " + Input.location.lastData.longitude);
        dataText.text = "Latitude: " + Input.location.lastData.latitude + " Longitude: " + Input.location.lastData.longitude;
    }
    
}

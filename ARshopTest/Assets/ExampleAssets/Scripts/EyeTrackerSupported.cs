using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;


public class EyeTrackerSupported : MonoBehaviour
{
    [SerializeField]
    private Text eyeTrackerSupportedText;

    void OnEnable()
    {
        ARFaceManager faceManager = FindObjectOfType<ARFaceManager>();

        if (faceManager != null )
        {
            eyeTrackerSupportedText.text = "Eye Tracking is supported on this device";
        }
        else
        {
            eyeTrackerSupportedText.text = "Eye Tracking is not supported on this device";
        }
    }
}
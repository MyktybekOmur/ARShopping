using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using System;
using UnityEngine.UI;
public class stepManager : MonoBehaviour
{
    //MArker prefab
    [Header("Put your planeMarker here")]
    [SerializeField] private GameObject stepMarkerPrefab;

    private ARRaycastManager ARRaycastManagerScript;

    private Vector2 TouchPosition;
    private GameObject SelectedObject;

    [SerializeField] private Camera ARCamera;
    public int control;

    //Object list
    public int itemIndex1;

    public Button smallBtn, normalBtn, largeBtn;

    [Serializable]
    public struct items
    {
        public int ID;
        public GameObject objectToSpawn;

        public Vector3 small;
        public Vector3 normal;
        public Vector3 large;


    }
    [SerializeField] public items[] item;

    List<ARRaycastHit> hits = new List<ARRaycastHit>();

    void Start()
    {
        ARRaycastManagerScript = FindObjectOfType<ARRaycastManager>();

       



        itemIndex1 = itemSelect.isSelectItem;// get object id
        stepMarkerPrefab.SetActive(false);
        control = 0;

       
    }


    void Update()
    {
        ShowMarkerAndSetItem();
        MoveObject();
    }

    void ShowMarkerAndSetItem()
    {
        List<ARRaycastHit> hits = new List<ARRaycastHit>();

        ARRaycastManagerScript.Raycast(new Vector2(Screen.width / 2, Screen.height / 2), hits, TrackableType.Planes);

        if (hits.Count > 0)
        {
            stepMarkerPrefab.transform.position = hits[0].pose.position;
            stepMarkerPrefab.transform.rotation = hits[0].pose.rotation;

            stepMarkerPrefab.SetActive(true);


        }
        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began && control == 0)
        {
            Instantiate(item[itemIndex1].objectToSpawn, hits[0].pose.position, item[itemIndex1].objectToSpawn.transform.rotation);
            control = 1;

        }
    }
    //Move objects
    void MoveObject()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            TouchPosition = touch.position;
            //select object
            if (touch.phase == TouchPhase.Began)
            {
                Ray ray = ARCamera.ScreenPointToRay(touch.position);
                RaycastHit hitObject;

                if (Physics.Raycast(ray, out hitObject))
                {
                    if (hitObject.collider.CompareTag("UnSelected"))
                    {
                        hitObject.collider.gameObject.tag = "Selected";
                    }
                }
            }
            // Moved
            if (touch.phase == TouchPhase.Moved)
            {
                ARRaycastManagerScript.Raycast(TouchPosition, hits, TrackableType.Planes);
                SelectedObject = GameObject.FindWithTag("Selected");
                SelectedObject.transform.position = hits[0].pose.position;
            }
            //UnSelect
            if (touch.phase == TouchPhase.Ended)
            {
                if (SelectedObject.CompareTag("Selected"))
                {
                    SelectedObject.tag = "UnSelected";
                }
            }

        }
    }
    //scale change
    void TaskOnClick(Vector3 scale)
    {

        Debug.Log(scale);
        item[itemIndex1].objectToSpawn.transform.localScale = scale;
    }
}

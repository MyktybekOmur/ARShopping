using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class deleteObject : MonoBehaviour
{
    private Button button;
    private Vector2 TouchPosition;
    private ProgrammManager ProgrammManagerScript;
    [SerializeField] private Camera ARCamera;
    void Start()
    {
        ProgrammManagerScript = FindObjectOfType<ProgrammManager>();
        button = GetComponent<Button>();
        button.onClick.AddListener(deleteItem);

    }


    void deleteItem()
    {
        Touch touch = Input.GetTouch(0);
        TouchPosition = touch.position;

        if (touch.phase == TouchPhase.Began)
        {
            Ray ray = ARCamera.ScreenPointToRay(touch.position);
            RaycastHit hitObject;

            if (Physics.Raycast(ray, out hitObject))
            {

                Destroy(hitObject.collider.gameObject);
                Debug.Log("Delete " );
            }
        }
    }
}

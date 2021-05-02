using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

[RequireComponent(typeof(ARRaycastManager))]

public class ARTapToPlaceObject : MonoBehaviour
{
    //public GameObject gameObjectToInstantiate;
    private GameObject spawnedObject;
    private ARRaycastManager _arRayCastManager;
    private Vector2 touchPosition;

    static List<ARRaycastHit> hits = new List<ARRaycastHit>();

    // Start is called before the first frame update
    private void Awake()
    {
        _arRayCastManager = GetComponent<ARRaycastManager>();

    }
    
    bool TryGetTouchPosition(out Vector2 touchPositon)
    {
        touchPositon = default;
        if (Input.touchCount > 0)
        {
            touchPosition = Input.GetTouch(0).position;
            return true;
        }
        touchPosition = default;
        return false;
    }

    void Update()
    {
        if (!TryGetTouchPosition(out Vector2 touchPosition))
            return;
        if(_arRayCastManager.Raycast(touchPosition, hits, TrackableType.PlaneWithinPolygon))
        {
            var hitPose = hits[0].pose;

            if(spawnedObject == null)
            {
                spawnedObject = Instantiate(DataHandler.Instance.GetFurniture(), hitPose.position, hitPose.rotation);
            }
            else
            {
                spawnedObject.transform.position = hitPose.position;
            }
        }
    }

    // Update is called once per frame
}

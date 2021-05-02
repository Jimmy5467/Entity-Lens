using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.XR.ARFoundation;

public class InputManager : MonoBehaviour
{
    private List<ARRaycastHit> hits = new List<ARRaycastHit>();
    [SerializeField] private ARRaycastManager _raycastManager;
    [SerializeField] private Camera arCam;
    [SerializeField]private GameObject crosshair;

    // Start is called before the first frame update
    private Pose pose;
    private Touch touch;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


        CrosshairCalculation();
        touch = Input.GetTouch(0);

        if(Input.touchCount < 0 || touch.phase != TouchPhase.Began)
        {
            return;
        }

        if (isPointerOverUI(touch))
            return;
        Instantiate(DataHandler.Instance.GetFurniture(), pose.position, pose.rotation);

    }

    bool isPointerOverUI(Touch touch)
    {
        PointerEventData eventData = new PointerEventData(EventSystem.current);
        eventData.position = new Vector2(touch.position.x, touch.position.y);
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, results);

        return results.Count > 0;
    }

    void CrosshairCalculation()
    {
        Vector3 origin = arCam.ViewportToScreenPoint(new Vector3(0.5f,0.5f, 0));
        Ray ray = arCam.ScreenPointToRay(origin);
        if (_raycastManager.Raycast(ray, hits))
        {
            pose = hits[0].pose;
            crosshair.transform.position = pose.position;
            crosshair.transform.eulerAngles = new Vector3(90, 0, 0);
        }
    }

}

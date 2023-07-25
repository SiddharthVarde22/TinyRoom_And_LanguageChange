using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FocusOnObject : MonoBehaviour , IInteractable
{
    GameObject cameraRefrence;
    bool zoomedIn = false;

    [SerializeField]
    List<Collider> childColiders;
    [SerializeField]
    Vector3 offsetPosition = new Vector3(0, 1, 3);
    [SerializeField]
    Vector3 offsetRotation = new Vector3(10, 180, 0);
    [SerializeField]
    float fieldOfView = 60;

    private void Awake()
    {
        cameraRefrence = Camera.main.gameObject;
    }

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < childColiders.Count;i++)
        {
            childColiders[i].enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(zoomedIn)
        {
            if(Input.GetMouseButtonDown(1))
            {
                CameraMovements cameraMovements = cameraRefrence.GetComponent<CameraMovements>();
                cameraMovements.enabled = true;
                cameraMovements.MoveTheCamera();
                zoomedIn = false;

                for (int i = 0; i < childColiders.Count; i++)
                {
                    childColiders[i].enabled = false;
                }
            }
        }
    }
    public void setCamera(Vector3 offSetPosition, float size)
    {
        //throw new System.NotImplementedException();

        cameraRefrence.transform.position = transform.position + offSetPosition;
        cameraRefrence.transform.rotation = transform.rotation * Quaternion.Euler(offsetRotation);
        cameraRefrence.GetComponent<Camera>().fieldOfView = size;
        cameraRefrence.GetComponent<CameraMovements>().enabled = false;
        zoomedIn = true;

        for(int i = 0; i < childColiders.Count; i++)
        {
            childColiders[i].enabled = true;
        }
    }

    private void OnMouseDown()
    {
        if(Input.GetMouseButtonDown(0))
        {
            setCamera(offsetPosition, fieldOfView);
        }
    }
}

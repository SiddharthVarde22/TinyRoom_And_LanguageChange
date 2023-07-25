using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWalls : MonoBehaviour
{
    CameraMovements cameraMovementsRef;

    float regularYPosition = 15.5f;
    float upperYPosition = 10;
    [SerializeField]
    bool shouldMove = false;

    [SerializeField]
    string[] directionsToBeInvisible;
    [SerializeField]
    float moveSpeed = 10;
    private void Awake()
    {
        cameraMovementsRef = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraMovements>();
        if(cameraMovementsRef != null)
        {
            cameraMovementsRef.onDirectionChanged += MoveTheWall;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        regularYPosition = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if(shouldMove)
        {
            transform.position = Vector3.MoveTowards(transform.position,
                new Vector3(transform.position.x, upperYPosition, transform.position.z), moveSpeed * Time.deltaTime);
            
            /*transform.position = Vector3.Lerp(transform.position,
                new Vector3(transform.position.x, upperYPosition, transform.position.z), moveSpeed * Time.deltaTime);
            */
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position,
                new Vector3(transform.position.x, regularYPosition, transform.position.z), moveSpeed * Time.deltaTime);
            
           /* transform.position = Vector3.Lerp(transform.position,
                new Vector3(transform.position.x, regularYPosition, transform.position.z), moveSpeed * Time.deltaTime);
           */
        }
    }

    void MoveTheWall()
    {

        for (int i = 0; i < directionsToBeInvisible.Length; i++)
        {
            if(directionsToBeInvisible[i] == cameraMovementsRef.directions.ToString())
            {
                shouldMove = true;
                break;
            }
            else
            {
                shouldMove = false;
            }
        }


        /*
        switch(cameraMovementsRef.directions)
        {
            case Directions.North:
                if(gameObject.tag == "WallNorth")
                {
                    transform.position = new Vector3(transform.position.x, upperYPosition, transform.position.z);
                }
                else if(gameObject.tag == "WallWest")
                {
                    transform.position = new Vector3(transform.position.x, upperYPosition, transform.position.z);
                }
                else
                {
                    transform.position = new Vector3(transform.position.x, regularYPosition, transform.position.z);
                }
                break;
            case Directions.West:
                if (gameObject.tag == "WallWest")
                {
                    transform.position = new Vector3(transform.position.x, upperYPosition, transform.position.z);
                }
                else if (gameObject.tag == "WallSouth")
                {
                    transform.position = new Vector3(transform.position.x, upperYPosition, transform.position.z);
                }
                else
                {
                    transform.position = new Vector3(transform.position.x, regularYPosition, transform.position.z);
                }
                break;
            case Directions.South:
                if (gameObject.tag == "WallSouth")
                {
                    transform.position = new Vector3(transform.position.x, upperYPosition, transform.position.z);
                }
                else if (gameObject.tag == "WallEast")
                {
                    transform.position = new Vector3(transform.position.x, upperYPosition, transform.position.z);
                }
                else
                {
                    transform.position = new Vector3(transform.position.x, regularYPosition, transform.position.z);
                }
                break;
            case Directions.East:
                if (gameObject.tag == "WallEast")
                {
                    transform.position = new Vector3(transform.position.x, upperYPosition, transform.position.z);
                }
                else if (gameObject.tag == "WallNorth")
                {
                    transform.position = new Vector3(transform.position.x, upperYPosition, transform.position.z);
                }
                else
                {
                    transform.position = new Vector3(transform.position.x, regularYPosition, transform.position.z);
                }
                break;
        }
        */
    }
}

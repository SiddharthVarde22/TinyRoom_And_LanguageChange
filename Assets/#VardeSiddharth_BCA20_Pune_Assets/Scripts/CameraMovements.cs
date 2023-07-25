using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum Directions
{
    North,
    West,
    South,
    East
};

public class CameraMovements : MonoBehaviour
{
    public delegate void ChangeDirection();
    public event ChangeDirection onDirectionChanged;

    public Directions directions = Directions.North;

    [SerializeField]
    List<Transform> directionObjects;

    private void Awake()
    {
        onDirectionChanged += MoveTheCamera;
    }
    // Start is called before the first frame update
    void Start()
    {
        onDirectionChanged();
    }

    // Update is called once per frame
    void Update()
    {
        OnGetInput();
    }

    public void MoveTheCamera()
    {
        //switch(directions)
        //{
        //    case Directions.North:
        //        this.transform.position = directionObjects[(int)directions].position;
        //        break;
        //    case Directions.West:
        //        break;
        //    case Directions.South:
        //        break;
        //    case Directions.East:
        //        break;
        //}

        this.transform.position = directionObjects[(int)directions].position;
        this.transform.rotation = directionObjects[(int)directions].rotation;

    }

    void OnGetInput()
    {
        if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            directions++;
            if((int)directions >= 4)
            {
                directions = 0;
            }
            onDirectionChanged();

        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            directions--;
            if((int)directions < 0)
            {
                directions = Directions.East;
            }
            onDirectionChanged();

        }

    }
}

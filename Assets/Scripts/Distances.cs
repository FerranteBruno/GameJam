using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Distances : MonoBehaviour
{
    // Start is called before the first frame update

    private enum Distance
    {
        Space,
        XYPlane
    }


    [SerializeField]
    private GameObject obj1;
    [SerializeField]
    private GameObject obj2;
    [SerializeField]
    private Distance distanceType;

    private float distance;

    public LineRenderer lineRenderer;

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        lineRenderer.SetPosition(0, obj1.transform.position);
        lineRenderer.SetPosition(1, obj2.transform.position);

        switch (distanceType)
        {
            case Distance.Space:
                distance = CalculateDistanceInSpace();
                break;
            case Distance.XYPlane:
                distance = CalculateDistancesXYPlane();
                break;
        }


    }

    public float CalculateDistanceInSpace()
    {
        return Vector3.Distance(obj1.transform.position, obj2.transform.position);
    }

    public float CalculateDistancesXYPlane()
    {
        Vector2 v1 = new Vector2(obj1.transform.position.x, obj1.transform.position.y);
        Vector2 v2 = new Vector2(obj2.transform.position.x, obj2.transform.position.y);

        return Vector2.Distance(v1, v2);
    }

}

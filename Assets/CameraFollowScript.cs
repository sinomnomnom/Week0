using System;
using Unity.VisualScripting;
using UnityEditor.PackageManager;
using UnityEngine;

public class CameraFollowScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject followObject;
    public Vector3 offset;
    void Start()
    {
        Vector3 toFollow = followObject.transform.position - transform.position;
        float dist = toFollow.magnitude;
        float theta = (float)Math.Acos(Vector3.Dot(toFollow, transform.forward.normalized) / dist);
        float distFromView = dist * (float)Math.Sin(theta);
        float distForward = dist * (float)Math.Cos(theta);

        Vector3 adjust = toFollow - transform.forward.normalized * distForward;
        transform.position += adjust;


        offset = transform.position - followObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 toFollow = followObject.transform.position - transform.position;

        float dist = toFollow.magnitude;
        float theta = (float)Math.Acos(Vector3.Dot(toFollow, transform.forward.normalized)/dist);
        float distFromView = dist * (float)Math.Sin(theta);
        //Debug.Log("theta: " + theta + ", dist: " + dist + ", dist from view vector: " + distFromView);
        float distForward = dist * (float)Math.Cos(theta);

        Vector3 adjust = toFollow - transform.forward.normalized * distForward;

        Vector3 x = Vector3.Dot(transform.right, adjust)*transform.right;
        Vector3 y = Vector3.Dot(transform.up, adjust)* transform.up;

        if (Math.Abs(x.magnitude) > 8*16f/10f)
        {
            transform.position += (x) * 1.99f;
        }
        if (Math.Abs(y.magnitude) > 8)
        {
            transform.position += (y) * 1.98f;
        }
    }
}

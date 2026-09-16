using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class MovingWalkway : MonoBehaviour
{
    public Collider collider;
    public List<GameObject> movingObjects;
    public float preExp;
    public float postExp;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < movingObjects.Count; i++)
        {
            Vector3 relativePos = movingObjects[i].transform.position - transform.position;
            movingObjects[i].transform.position += Mathf.Exp((relativePos.z/200+.5f)*preExp)*postExp * Time.deltaTime * Vector3.left;
            Debug.Log(relativePos.z / 200 + .5f);
            //Debug.Log(relativePos.z);
            if (movingObjects[i].transform.position.x < - 8f * 16f / 10f * 1.95f * 19f + 4f*16f/10f)
            {
                movingObjects[i].transform.position += new Vector3(2, 0, 0) * (8f * 16f / 10f * 1.95f * 19f + 4f * 16f / 10f);
            }

        }
    }

    private void ResetAllMovingObjects()
    {
        for (int i = 0; i < movingObjects.Count; i++)
        {
            movingObjects[i].transform.position += new Vector3(1000, 0, 0);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("collision!");
        if(collision.collider.gameObject.layer == 3)
        {
            movingObjects.Add(collision.collider.gameObject);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (movingObjects.Contains(collision.collider.gameObject))
        {
            movingObjects.Remove(collision.collider.gameObject);
        }
    }
}

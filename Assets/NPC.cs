using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public List<Sprite> sprites;
    public GameObject dialogGameObject;
    public bool triggered = false;
    float timer = 0;
    float interval = 5;
    int index = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(triggered){
            timer += Time.deltaTime;
            if (timer > interval)
            {
                timer = 0;
                index += 1;
                if (sprites.Count <= index) dialogGameObject.GetComponent<SpriteRenderer>().sprite = null;
                else { dialogGameObject.GetComponent<SpriteRenderer>().sprite = sprites[index]; }
                    
            }
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.collider.gameObject.tag == "Player")
        {
            triggered = true;
            if (sprites.Count <= index) dialogGameObject.GetComponent<SpriteRenderer>().sprite = null;
            else { dialogGameObject.GetComponent<SpriteRenderer>().sprite = sprites[index]; }
        }
    }
}

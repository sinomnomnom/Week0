using UnityEditor.Animations;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Animator animator;
    public AnimatorController controller;
    public float speed;
    Vector2 direction = new Vector2 (1, 1);
    Vector2 facing = new Vector2 (1, 1);
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        direction = new Vector2(0, 0);
        if (Input.GetKey(KeyCode.W)) direction = new Vector2(-1, 1);
        if (Input.GetKey(KeyCode.S)) direction = new Vector2(1, -1);
        if (Input.GetKey(KeyCode.A)) direction = new Vector2(-1, -1);
        if (Input.GetKey(KeyCode.D)) direction = new Vector2(1, 1);

        if (direction != Vector2.zero){
            animator.SetBool("moving", true);
            facing = direction;
        }else{
            animator.SetBool("moving", false);
        }

        animator.SetFloat("y",facing.y);
        animator.SetFloat("x",facing.x);

        transform.position += (new Vector3(direction.x, 0, direction.y*2) * Time.deltaTime * speed);
        if(transform.position.z < -10) transform.position = new Vector3(transform.position.x,transform.position.y,-10);
        if (transform.position.z >150) transform.position = new Vector3(transform.position.x, transform.position.y, 150);
    }
}

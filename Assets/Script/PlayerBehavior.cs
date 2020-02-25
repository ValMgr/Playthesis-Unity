using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{

    private Rigidbody2D rb2D;
    public float MoveSpeed = 5f;
    public float MaxSpeed = 5f;
    private Vector2 VectorHorizontal = new Vector2(1.0f, 0.0f);
    public static int CamCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        rb2D = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Q) && rb2D.velocity.x >= -MaxSpeed)
        {
            rb2D.AddForce(VectorHorizontal * -MoveSpeed);
        }

        if (Input.GetKey(KeyCode.D) && rb2D.velocity.x <= MaxSpeed)
        {
            rb2D.AddForce(VectorHorizontal * MoveSpeed);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "CameraTrigger")
        {
            CamCount++;
        }
    }
}

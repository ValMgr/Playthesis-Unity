using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    private Rigidbody2D rb2D;
    public static Vector2 CameraPos;
    // Start is called before the first frame update
    void Start()
    {
        rb2D = gameObject.GetComponent<Rigidbody2D>();
        rb2D.freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(0, transform.position.y, -10);
        CameraPos = transform.position;
    }
}

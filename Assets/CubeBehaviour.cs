using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CubeBehaviour : MonoBehaviour
{
    public Vector3 size;
    public Vector3 max;
    public Vector3 min;
    public bool isColliding;

    private MeshFilter meshFilter;
    private Bounds bounds;

    public Vector3 velocity = new Vector3(0.0f, 0.0f, 0.0f);
    public Vector3 acceleration = new Vector3(0.0f, 0.0f, 0.0f);

    // Start is called before the first frame update
    void Start()
    {
        meshFilter = GetComponent<MeshFilter>();

        bounds = meshFilter.mesh.bounds;
        size = bounds.size;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + velocity;
        velocity = velocity + acceleration;

        if(transform.position.y < 3)
        {
            transform.position = new Vector3(transform.position.x, 3, transform.position.z);
            velocity.y = 0;
            acceleration.y = 0;
        }

        //Wall/Floor Collision

        if (transform.position.x < -45)
        {
            transform.position = new Vector3(-45.0f, transform.position.y, transform.position.z);
            velocity.x = velocity.x * 0.0f;
        }
        else if (transform.position.x > 45)
        {
            transform.position = new Vector3(45.0f, transform.position.y, transform.position.z);
            velocity.x = velocity.x * 0.0f;
        }
        if (transform.position.y < 3)
        {
            transform.position = new Vector3(transform.position.x, 3, transform.position.z);
            velocity.y = 0;
            acceleration.y = 0;
        }
        else if (transform.position.y > 95)
        {
            transform.position = new Vector3(transform.position.x, 95.0f, transform.position.z);
            velocity.y = velocity.y * 0.0f;
        }
        if (transform.position.z < -45)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -45.0f);
            velocity.z = velocity.z * 0.0f;
        }
        else if (transform.position.z > 45)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, 45.0f);
            velocity.z = velocity.z * 0.0f;
        }


        max = Vector3.Scale(bounds.max, transform.localScale) + transform.position;
        min = Vector3.Scale(bounds.min, transform.localScale) + transform.position;
    }
}

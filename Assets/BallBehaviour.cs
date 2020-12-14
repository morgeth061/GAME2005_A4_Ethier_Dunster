using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BallBehaviour : MonoBehaviour
{
    System.Random rand = new System.Random();


    public bool isActive = true;
    private bool isInitialized = false;
    private float ballMass = 50;

    private int update = 0;

    public Vector3 size;
    public Vector3 max;
    public Vector3 min;
    public bool isColliding;

    public GameObject currentBall;

    public Vector3 position = new Vector3(0.0f,6.0f,-40.0f);
    public Vector3 velocity;
    public Vector3 acceleration = new Vector3(0.0f, -0.0981f, 0.0f);

    public float objectVelocity = 0.0f;


    private Vector3 initVelocity = new Vector3(1.0f, 2.0f, 2.0f);

    private MeshFilter meshFilter;
    private Bounds bounds;

    public List<CubeBehaviour> contacts;

    // Start is called before the first frame update
    void Start()
    {
        meshFilter = GetComponent<MeshFilter>();

        bounds = meshFilter.mesh.bounds;
        size = bounds.size;

        this.currentBall = gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        update++;

        if(update == 30)
        {
            if (isActive == true)
            {
                if(isInitialized == false)
                {
                    int temp = rand.Next(-5, 5);

                    print(temp);

                    velocity.x = velocity.x * temp;


                    transform.position = position;
                    velocity = initVelocity;
                    isInitialized = true;
                }

                //Wall/Floor Collision

                if(transform.position.x < -50)
                {
                    transform.position = new Vector3(-50.0f, transform.position.y, transform.position.z);
                    velocity.x = velocity.x * -0.8f;
                }
                else if (transform.position.x > 50)
                {
                    transform.position = new Vector3(50.0f, transform.position.y, transform.position.z);
                    velocity.x = velocity.x * -0.8f;
                }
                if (transform.position.y < 3)
                {
                    transform.position = new Vector3(transform.position.x, 3.0f, transform.position.z);
                    velocity.y = velocity.y * -0.8f;
                }
                else if (transform.position.y > 100)
                {
                    transform.position = new Vector3(transform.position.x, 100.0f, transform.position.z);
                    velocity.y = velocity.y * -0.8f;
                }
                if (transform.position.z < -50)
                {
                    transform.position = new Vector3(transform.position.x, transform.position.y, -50.0f);
                    velocity.z = velocity.z * -0.8f;
                }
                else if(transform.position.z > 50)
                {
                    transform.position = new Vector3(transform.position.x, transform.position.y, 50.0f);
                    velocity.z = velocity.z * -0.8f;
                }
                transform.position = transform.position + velocity;
                velocity = velocity + acceleration;

                if (velocity.y < 0.001f && velocity.y > -0.001f)
                {
                    isActive = false;
                    isInitialized = false;
                    transform.position = new Vector3(0, -5, 0);
                    print("Ball Despawned");
                }

            }
            else
            {
                transform.position = new Vector3(0, -5, 0);
            }
            update = 0;

            if (isColliding == true)
            {
                for(int i = 0; i < contacts.Count; i++)
                {
                    print("COLLISION WITH " + i);
                    contacts[i].velocity = new Vector3(velocity.x * 0.5f, velocity.y * 0.5f, velocity.z * 0.5f);
                    contacts[i].acceleration = acceleration;
                    isActive = false;
                    isInitialized = false;
                    transform.position = new Vector3(0, -5, 0);
                    print("Ball Despawned");
                }
            }
                    
        }

        

        max = Vector3.Scale(bounds.max, transform.localScale) + transform.position;
        min = Vector3.Scale(bounds.min, transform.localScale) + transform.position;

    }
}

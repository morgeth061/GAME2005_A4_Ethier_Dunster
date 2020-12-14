using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CollisionManager : MonoBehaviour
{
    public BallBehaviour[] actors;
    public CubeBehaviour[] cubeActors;


    // Start is called before the first frame update
    void Start()
    {
        actors = FindObjectsOfType<BallBehaviour>();
        cubeActors = FindObjectsOfType<CubeBehaviour>();
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < actors.Length; i++)
            {
            for (int j = 0; j < cubeActors.Length; j++)
            {
                if (i != j)
                {
                    CheckAABBs(actors[i], cubeActors[j]);
                }
            }
        }
    }

    public static void CheckAABBs(BallBehaviour a, CubeBehaviour b)
    {
        if ((a.min.x <= b.max.x && a.max.x >= b.min.x) &&
            (a.min.y <= b.max.y && a.max.y >= b.min.y) &&
            (a.min.z <= b.max.z && a.max.z >= b.min.z))
        {
            if (!a.contacts.Contains(b))
            {
                a.contacts.Add(b);
                a.isColliding = true;
                b.isColliding = true;
                print("COLLIDE");
            }
        }
        else
        {
            if (a.contacts.Contains(b))
            {
                a.contacts.Remove(b);
                a.isColliding = false;
                b.isColliding = false;
            }

        }
    }
}

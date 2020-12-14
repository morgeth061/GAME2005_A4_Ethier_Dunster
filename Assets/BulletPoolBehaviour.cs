using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BulletPoolBehaviour : MonoBehaviour
{

    public BallBehaviour[] actors;

    // Start is called before the first frame update
    void Start()
    {
        actors = FindObjectsOfType<BallBehaviour>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            print("Spawn Ball");
            for (int i = 0; i < actors.Length; i++)
            {
                if (actors[i].isActive == false)
                {
                    actors[i].isActive = true;
                    print(i);
                    break;
                }
            }
            
            
        }

        
    }
}

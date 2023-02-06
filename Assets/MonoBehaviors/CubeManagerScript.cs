using Assets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeManagerScript : MonoBehaviour
{
    List<SquareInstance> _cubeInstances = new List<SquareInstance>();
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 5; i++)
        {
            var cubeInstance = new SquareInstance();
            cubeInstance.GameObject.transform.position = new Vector2(i, 0);
            _cubeInstances.Add(cubeInstance);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

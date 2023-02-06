using Assets;
using Assets.Utils.GameObjectWrapper;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestLol : MonoBehaviour
{
    UGICollectionEditor<SquareInstance, CubeAccessScript> Squares = new();
    [SerializeField] private float _speed;
    void Start()
    {
        Squares.Add(new SquareInstance());
        Squares.Add(new SquareInstance());
        Squares.Add(new SquareInstance());
        Squares.Add(new SquareInstance());
    }

    // Update is called once per frame
    void Update()
    {
        foreach (var square in Squares.Instances)
        {
            square.GameObject.MoveTowards(new Vector2(100,0), Time.deltaTime * _speed);
        }
    }
}

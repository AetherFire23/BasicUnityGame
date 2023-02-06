using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccessScript<T> : MonoBehaviour where T :AccessScript<T>
{
    public InstanceHelper<T> Wrapper;
}

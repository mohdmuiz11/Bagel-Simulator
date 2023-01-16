using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutofBounds : MonoBehaviour
{
    private void Update()
    {
        if(transform.position.z < 0)
        {
            Destroy(gameObject);
        }
    }
}

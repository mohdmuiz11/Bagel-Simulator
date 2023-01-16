using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spinny : MonoBehaviour
{
    private float timer = 0;
    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        transform.Rotate(0, 2, 0);
        transform.localPosition = new Vector3(0, 0.08f + Mathf.Sin(timer*2)*0.1f, 0);
    }
}

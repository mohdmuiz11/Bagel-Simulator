using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Inspector mode
    [SerializeField] private float _backSpeed;

    // public vars
    public float backSpeed { get { return _backSpeed; } }

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}

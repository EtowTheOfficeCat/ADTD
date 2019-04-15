using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
   [SerializeField] private float speed = 20.5f;

    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            this.transform.Translate(new Vector3(0, speed * Time.deltaTime, 0));
        }

        else if (Input.GetKey(KeyCode.S))
        {
            this.transform.Translate(new Vector3(0, -speed * Time.deltaTime, 0));
        }
    }
}

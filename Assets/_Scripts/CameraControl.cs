using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public int speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            if (transform.position.x > 5.98)
            {
                return;
            }
            transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (transform.position.x < -8.10)
            {
                return;
            }
            transform.Translate(new Vector3(-speed * Time.deltaTime, 0, 0));
        }

    }
}

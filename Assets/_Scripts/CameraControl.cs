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
        // if (Input.GetAxis("Mouse X")>0)
        // {
        //     if (transform.position.x > 5.28)
        //     {
        //         transform.Translate(new Vector3(-speed * Time.deltaTime, 0, 0));
        //     }
        //     transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
        // }
        // if (Input.GetAxis("Mouse X")<0)
        // {
        //     if (transform.position.x < -7.3)
        //     {
        //         transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
        //     }
        //     transform.Translate(new Vector3(-speed * Time.deltaTime, 0, 0));
        // }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            if (transform.position.x > 5.28)
            {
                transform.Translate(new Vector3(-speed * Time.deltaTime, 0, 0));
            }
            transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (transform.position.x < -7.3)
            {
                transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
            }
            transform.Translate(new Vector3(-speed * Time.deltaTime, 0, 0));
        }
    }
}

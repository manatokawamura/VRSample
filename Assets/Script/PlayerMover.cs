using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    bool isMoved = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(!isMoved)
            {
            transform.position = new Vector3(20, 1, -10);
            isMoved = true;
            }
            else
            {
            transform.position = new Vector3(0, 1, -10);
            isMoved = false;
            }
        }
    }
}

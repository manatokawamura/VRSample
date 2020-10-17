using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField, Header("カメラ移動速度")] private float speed = 1f;
    private Transform playerTransform; 

    [SerializeField] private bool interval = false;
    [SerializeField] private float time = 0f;
    [SerializeField] private float maxTime = 1f;

    void Start()
    {
        playerTransform = transform.parent;
        #if UNITY_EDITOR
        #else
        Input.gyro.enabled = true;
        #endif
    }
	
	void Update()
    {
        if(interval)
        {
            MoveCamera();
        }
        if(time >= maxTime)
        {
            interval = true;
        }
        else
        {
            time += Time.deltaTime;            
        }
    }

    private void MoveCamera()
    {
        #if UNITY_EDITOR
        //クリック中は動作しない
        if(Input.GetMouseButton(0))
        {
            return;
        }
        float xRotate = Input.GetAxis("Mouse X") * speed;
        float yRotate = Input.GetAxis("Mouse Y") * speed;
        // 見づらくなるので回転軸を分ける
        playerTransform.transform.Rotate(0, xRotate, 0);
        transform.Rotate(-yRotate, 0, 0);
        #else
        transform.rotation = Quaternion.AngleAxis(90.0f,Vector3.right)*Input.gyro.attitude*Quaternion.AngleAxis(180.0f,Vector3.forward);
        #endif
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetEvent : MonoBehaviour
{
    [SerializeField, Header("反応までの時間")] private float maxTime = 5f;
    private float time = 0f;
    private bool isWatching = false;
    public bool IsWatching
    {
        set{ isWatching = value; }
        get{ return isWatching; }
    }

    private Renderer renderer;
    private TargetUIManager uiManager;

    [SerializeField] private GameObject player;
    [SerializeField, Header("移動量(球の半径)")] private float distance = 50f;
    private bool isMoved = false;

    void Start()
    {
        renderer = GetComponent<Renderer>();
        renderer.material.color = Color.blue;
        uiManager = GetComponent<TargetUIManager>();
    }

    void Update()
    {
        if(isWatching)
        {
            renderer.material.color = Color.red;
            if(uiManager.UIShow(time, maxTime))
            {
                //メータが満たされたとき
                if(!isMoved)
                {
                    MovePlayer();
                }
            }
            time += Time.deltaTime;  
        }
        else
        {
            isMoved = false;
            renderer.material.color = Color.blue;
            uiManager.UIHide();
            time = 0f;
        }        
    }

    ///<summary>
    ///指定秒数Rayが当たると呼び出される
    ///</summary>
    private void MovePlayer()
    {
        Vector3 pos = player.transform.position;
        Vector3 diff = transform.position - pos;        
        if(diff.z > 0)
        {
            player.transform.position = new Vector3(pos.x, pos.y, pos.z + distance);
        }
        if(diff.z < 0)
        {
            player.transform.position = new Vector3(pos.x, pos.y, pos.z - distance);
        }
        if(diff.x > 0)
        {
            player.transform.position = new Vector3(pos.x + distance, pos.y, pos.z);
        }
        if(diff.x < 0)
        {
            player.transform.position = new Vector3(pos.x - distance, pos.y, pos.z);
        }
        isMoved = true;
    }
}

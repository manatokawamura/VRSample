using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particle : MonoBehaviour
{
    private ParticleSystem particle;
    
    void Start()
    {
        particle = this.GetComponent<ParticleSystem>();
    }
 
    void Update()
    {
        if (particle.isStopped) //パーティクルが終了したか判別
        {
            Destroy(this.gameObject);//パーティクル用ゲームオブジェクトを削除
        }
    }

    public void SetPos(Vector3 pos)
    {
        this.transform.position = pos;
    }
}

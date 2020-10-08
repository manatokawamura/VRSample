using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sphere : MonoBehaviour
{
    [SerializeField, Header("初期位置")] private Vector3 startPos = new Vector3(0, 5, 0);
    [SerializeField, Header("リセット回数")] private int count = 0;
    [SerializeField] private Text text;
    [SerializeField] private GameObject particle;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    ///<summary>
    ///ボタンから呼び出し
    ///</summary>
    public void ResetPos()
    {
        this.transform.position = startPos;
        count++;
        SetText(count.ToString());
    }

    public void SetText(string txt)
    {
        if(text != null)
        {
            text.text = "リセット回数：" + txt;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Ground")
        {
            Debug.Log("Hit");
            Instantiate(particle, this.transform);
            Particle ptc = particle.GetComponent<Particle>();
            ptc.SetPos(this.transform.position);
        }
    }
}

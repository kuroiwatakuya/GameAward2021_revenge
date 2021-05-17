using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestroy : MonoBehaviour
{
    ParticleSystem Effcet;          //パーティクル

    // Start is called before the first frame update
    void Start()
    {
        //エフェクト情報の取得
        Effcet = this.gameObject.GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        //エフェクトが止まったら消します
        if(Effcet.isStopped)
        {
            Destroy(this.gameObject);
        }
    }
}

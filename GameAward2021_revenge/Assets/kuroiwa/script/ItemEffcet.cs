using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//エフェクト出現
public class ItemEffcet : MonoBehaviour
{
    [SerializeField] GameObject Effectobj = null;     //生成するエフェクト
    private Transform pool;     //オブジェクトを保存する空オブジェクトのtransform
    private bool Playerhit = false;

    // Start is called before the first frame update
    void Start()
    {
        pool = new GameObject("Effect").transform;
    }

    void Update()
    {
        if(Playerhit)
        {
            GetObject(transform.position, transform.rotation);
        }
        
    }

    void GetObject(Vector3 effectpos,Quaternion effectqua)
    {
        foreach(Transform trans in pool)
        {
            //オブジェクトが非アクティブなら使いまわし
            if(!trans.gameObject.activeSelf)
            {
                trans.SetPositionAndRotation(effectpos, effectqua);
                trans.gameObject.SetActive(true);       //位置と回転を設定した後にアクティブ
                return;
            }
        }
        Instantiate(Effectobj, effectpos, effectqua, pool);   //生成と同時に親をpoolに設定
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Playerhit = true;
        }
    }
}

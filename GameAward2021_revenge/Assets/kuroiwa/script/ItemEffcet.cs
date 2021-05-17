using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�G�t�F�N�g�o��
public class ItemEffcet : MonoBehaviour
{
    [SerializeField] GameObject Effectobj = null;     //��������G�t�F�N�g
    private Transform pool;     //�I�u�W�F�N�g��ۑ������I�u�W�F�N�g��transform
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
            //�I�u�W�F�N�g����A�N�e�B�u�Ȃ�g���܂킵
            if(!trans.gameObject.activeSelf)
            {
                trans.SetPositionAndRotation(effectpos, effectqua);
                trans.gameObject.SetActive(true);       //�ʒu�Ɖ�]��ݒ肵����ɃA�N�e�B�u
                return;
            }
        }
        Instantiate(Effectobj, effectpos, effectqua, pool);   //�����Ɠ����ɐe��pool�ɐݒ�
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Playerhit = true;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestroy : MonoBehaviour
{
    ParticleSystem Effcet;          //�p�[�e�B�N��

    // Start is called before the first frame update
    void Start()
    {
        //�G�t�F�N�g���̎擾
        Effcet = this.gameObject.GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        //�G�t�F�N�g���~�܂���������܂�
        if(Effcet.isStopped)
        {
            Destroy(this.gameObject);
        }
    }
}

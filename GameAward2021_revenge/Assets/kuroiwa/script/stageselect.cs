using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//---------------------------
//�X�e�[�W�I��
//---------------------------
public class stageselect : MonoBehaviour
{
    private float speed = 10.0f;
    private Vector3 move;
    private int count;

    private Vector3[] Setpos = new Vector3[]{
        new Vector3(0.0f,0.0f,0.0f),        //�X�e�[�W1
        new Vector3(0.0f,5.0f,0.0f),        //�X�e�[�W2
        new Vector3(0.0f,10.0f,0.0f),      //�X�e�[�W3
        new Vector3(0.0f,13.0f,0.0f),      //�X�e�[�W4
        new Vector3(0.0f,14.0f,0.0f),      //�X�e�[�W5
        new Vector3(0.0f,15.0f,0.0f),      //�X�e�[�W6
        new Vector3(0.0f,16.0f,0.0f),      //�X�e�[�W7
        new Vector3(0.0f,18.0f,0.0f),      //�X�e�[�W8
        new Vector3(0.0f,20.0f,0.0f)       //�X�e�[�W9
    };

    private GameObject player;
    private int playernum;
    private Vector3 playerpos;

    // Start is called before the first frame update
    void Start()
    {
        //�v���C���[�̈ʒu���̎擾
        player = GameObject.FindWithTag("Player");
        playernum = 0;
    }

    // Update is called once per frame
    void Update()
    {
        movepos();
        playerpos = player.transform.position;
    }

    private void movepos()
    {
        Vector3 nextpos;
        Vector3 keeppos;
        if(count > speed)
        {
            count = 0;
            move = new Vector3(0.0f, 0.0f, 0.0f);
            playernum += 1;
        }
        if (Input.GetKey(KeyCode.Q))
        {
            nextpos = Setpos[playernum + 1];    //���̂��
            keeppos = nextpos - Setpos[playernum];  //����
            move = keeppos / speed;     //�ω���
        }
        if(move.magnitude > 0)
        {
            count++;
        }
        player.transform.Translate(move);
    }
}

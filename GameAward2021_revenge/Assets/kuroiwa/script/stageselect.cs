using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//---------------------------
//ステージ選択
//---------------------------
public class stageselect : MonoBehaviour
{
    private float speed = 10.0f;
    private Vector3 move;
    private int count;

    private Vector3[] Setpos = new Vector3[]{
        new Vector3(0.0f,0.0f,0.0f),        //ステージ1
        new Vector3(0.0f,5.0f,0.0f),        //ステージ2
        new Vector3(0.0f,10.0f,0.0f),      //ステージ3
        new Vector3(0.0f,13.0f,0.0f),      //ステージ4
        new Vector3(0.0f,14.0f,0.0f),      //ステージ5
        new Vector3(0.0f,15.0f,0.0f),      //ステージ6
        new Vector3(0.0f,16.0f,0.0f),      //ステージ7
        new Vector3(0.0f,18.0f,0.0f),      //ステージ8
        new Vector3(0.0f,20.0f,0.0f)       //ステージ9
    };

    private GameObject player;
    private int playernum;
    private Vector3 playerpos;

    // Start is called before the first frame update
    void Start()
    {
        //プレイヤーの位置情報の取得
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
            nextpos = Setpos[playernum + 1];    //次のやつ
            keeppos = nextpos - Setpos[playernum];  //差分
            move = keeppos / speed;     //変化量
        }
        if(move.magnitude > 0)
        {
            count++;
        }
        player.transform.Translate(move);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//---------------------------
//ステージ選択
//---------------------------
public class stageselect : MonoBehaviour
{
    private float speed = 0.5f;
    private Vector3 move;
    private int count;

    private bool MoveFlag = false;

    private Vector3 nextpos;
    private Vector3 keeppos;

    [SerializeField] private GameObject[] stagepos; 

    private GameObject player;
    private int playernum;
    private Vector3 playerpos;
    private float blend;

    public Terrain terrain;

    //現在のフレームの値を格納  1フレーム前の値を格納
    private float nowHorizontal;//横軸
    private float beforeHorizontal;
    private float nowVertical;//縦軸
    private float beforeVertical;

    //ステージ数 最初と最後
    private const int Start_Stage = 0;
    private const int Max_Stage = 9;

    // Start is called before the first frame update
    void Start()
    {
        Terrain terrain = Terrain.activeTerrain;

        //プレイヤーの位置情報の取得
        player = GameObject.FindWithTag("Player");
        playernum = Start_Stage;
    }

    // Update is called once per frame
    void Update()
    {
        nowHorizontal = Input.GetAxis("Horizontal");
        nowVertical = Input.GetAxis("Vertical");

        playerpos = player.transform.position;
        
        if ((Input.GetKeyDown(KeyCode.LeftArrow) || (nowHorizontal < 0 && beforeHorizontal == 0.0f)) && !MoveFlag)
        {
            if (playernum < Max_Stage)
            {
                MoveFlag = true;
                nextpos = stagepos[playernum + 1].transform.position;
                keeppos = stagepos[playernum].transform.position;
                playernum++;
            }
        }
        if ((Input.GetKeyDown(KeyCode.RightArrow) || (nowHorizontal > 0 && beforeHorizontal == 0.0f)) && !MoveFlag)
        {
            if (playernum > Start_Stage)
            {
                MoveFlag = true;
                nextpos = stagepos[playernum - 1].transform.position;
                keeppos = stagepos[playernum].transform.position;
                playernum--;
            }
        }

        movepos();

        beforeHorizontal = nowHorizontal;
        beforeVertical = nowVertical;
    }

    private void movepos()
    {
        if (MoveFlag)
        {

            blend += speed * Time.deltaTime;
            player.transform.position = Vector3.Lerp(keeppos, nextpos, blend);

            Vector3 ppos = player.transform.position;
            ppos.y = terrain.SampleHeight(ppos) + 1.0f;
            player.transform.position = ppos;


            if (blend > 1)
            {
                blend = 0;
                MoveFlag = false;
            }
        }
    }

    public bool GetMoveFlag()
    {
        return MoveFlag;
    }
}

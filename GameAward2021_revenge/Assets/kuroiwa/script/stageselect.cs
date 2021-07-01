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

    // Start is called before the first frame update
    void Start()
    {
        Terrain terrain = Terrain.activeTerrain;

        //プレイヤーの位置情報の取得
        player = GameObject.FindWithTag("Player");
        playernum = 0;
    }

    // Update is called once per frame
    void Update()
    {
        playerpos = player.transform.position;
        movepos();

        nextpos = stagepos[playernum + 1].transform.position;
        keeppos = stagepos[playernum].transform.position;

    }

    private void movepos()
    {

        if (Input.GetKeyDown(KeyCode.Q) && !MoveFlag)
        {
            MoveFlag = true;
        }

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
                playernum++;
            }
        }
    }
}

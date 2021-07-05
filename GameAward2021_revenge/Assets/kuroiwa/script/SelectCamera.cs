using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//=============================
//セレクト画面のカメラ
//=============================
public class SelectCamera : MonoBehaviour
{
    //ステージの中心座標
    public float stagepos_X;
    public float stagepos_Z;

    [SerializeField] private GameObject Player;
    //[SerializeField] private GameObject StageSelect;
    public Transform Target;
    private Vector3 Offset;     //カメラの相対距離
    
    public GameObject[] StageSelectPos;
    private int SelectPosNum;
    private Vector3 angle;
    private Vector3 nextpos;
    private Vector3 keeppos;

    // Start is called before the first frame update
    void Start()
    {
        //カメラとターゲットの相対距離
        Offset = GetComponent<Transform>().position - Target.transform.position;
        SelectPosNum = 0;

    }

    // Update is called once per frame
    void Update()
    {
        //プレイヤーをカメラの注視点とする
        this.gameObject.transform.LookAt(new Vector3(Player.transform.position.x, Player.transform.position.y, Player.transform.position.z));
        
        GetComponent<Transform>().position = Target.transform.position + Offset;
    }
}

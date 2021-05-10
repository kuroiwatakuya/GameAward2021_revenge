using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectText : MonoBehaviour
{
    public GameObject score_object = null;
    private GameObject SelectObject;
    private SelectManager SelectManagerScript;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // オブジェクトからTextコンポーネントを取得
        Text score_text = score_object.GetComponent<Text>();


        SelectObject = GameObject.FindWithTag("GameManager");
        SelectManagerScript = SelectObject.GetComponent<SelectManager>();

        // テキストの表示を入れ替える
        score_text.text = "ステージ" + SelectManagerScript.GetSelectingStage();
    }
}

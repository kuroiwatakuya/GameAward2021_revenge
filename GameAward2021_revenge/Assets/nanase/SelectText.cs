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
        // �I�u�W�F�N�g����Text�R���|�[�l���g���擾
        Text score_text = score_object.GetComponent<Text>();


        SelectObject = GameObject.FindWithTag("GameManager");
        SelectManagerScript = SelectObject.GetComponent<SelectManager>();

        // �e�L�X�g�̕\�������ւ���
        score_text.text = "�X�e�[�W" + SelectManagerScript.GetSelectingStage();
    }
}

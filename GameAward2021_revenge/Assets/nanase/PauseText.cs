using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseText : MonoBehaviour
{
    public GameObject pause_object = null;
    private GameObject PauseObject;
    private PauseManager PauseManagerScript;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // �I�u�W�F�N�g����Text�R���|�[�l���g���擾
        Text pause_text = pause_object.GetComponent<Text>();


        PauseObject = GameObject.FindWithTag("GameManager");
        PauseManagerScript = PauseObject.GetComponent<PauseManager>();

        // �e�L�X�g�̕\�������ւ���
        if (PauseManagerScript.GetSelectingScene() == 0)
        {
            pause_text.text = "�^�C�g���ɖ߂�";
        }
        if (PauseManagerScript.GetSelectingScene() == 1)
        {
            pause_text.text = "���X�^�[�g";
        }
        if (PauseManagerScript.GetSelectingScene() == 2)
        {
            pause_text.text = "�Z���N�g�ɖ߂�";
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    private int SaveNum;

    // Start is called before the first frame update
    void Start()
    {
        SaveNum = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Return))
        {
            Load();
        }
    }

    public void Save(int savenum)
    {

        PlayerPrefs.SetInt("�Z�[�u�|�C���g��", savenum);
        PlayerPrefs.Save();
        Debug.Log("�Z�[�u�����" + savenum);
    }

    public void Load()
    {
        Debug.Log("���[�h�����");
        SaveNum = PlayerPrefs.GetInt("�Z�[�u�|�C���g", 0);
        Debug.Log("�Z�[�u�|�C���g��" + SaveNum);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeManager : MonoBehaviour
{
    private float alfa;//�A���t�@�l�ۑ��p
    private float speed = 0.35f;//�ω����x
    private float red, green, blue;//RGB�l�ۑ��p
    private int isFade;//0�ŉ����N���Ȃ��@1�Ńt�F�[�h�C���J�n�@-1�Ńt�F�[�h�A�E�g�J�n
    public Image Panel;

    // Start is called before the first frame update
    void Start()
    {
        red = Panel.color.r;
        green = Panel.color.g;
        blue = Panel.color.b;
    }

    // Update is called once per frame
    void Update()
    {
        if(isFade > 0)
        {
            FadeIn();
        }
        if(isFade < 0)
        {
            FadeOut();
        }
    }

    //�t�F�[�h�C���E�t�F�[�h�A�E�g���]�X�C�b�`
    public void ChangeFade()
    {
        isFade *= -1;
        if (isFade > 0)
        {
            alfa = 0;
        }
        if (isFade < 0)
        {
            alfa = 1.0f;
        }
    }
    //�t�F�[�h�C���X�C�b�`
    public void OnFadeIn()
    {
        alfa = 0;
        isFade = 1;
    }
    //�t�F�[�h�A�E�g�X�C�b�`
    public void OnFadeOut()
    {
        alfa = 1.0f;
        isFade = -1;
    }

    //�t�F�[�h�̏�Ԏ擾�@0�ŉ����N���Ȃ��@1�Ńt�F�[�h�C���J�n�@-1�Ńt�F�[�h�A�E�g�J�n
    public int GetIsFade()
    {
        return isFade;
    }
    //�A���t�@�l���擾
    public float GetAlfa()
    {
        return alfa;
    }

    //�t�F�[�h�C��
    public void FadeIn()
    {
        Panel.color = new Color(red, green, blue, alfa);
        alfa += speed * Time.deltaTime;
    }

    //�t�F�[�h�A�E�g
    public void FadeOut()
    {
        Panel.color = new Color(red, green, blue, alfa);
        alfa -= speed * Time.deltaTime;
    }
}

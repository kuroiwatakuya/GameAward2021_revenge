using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeManager : MonoBehaviour
{
    [SerializeField] private float alfa;//アルファ値保存用
    public float speed;//変化速度
    private float red, green, blue;//RGB値保存用
    [SerializeField] private int isFade;//0で何も起きない　1でフェードイン開始　-1でフェードアウト開始
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
        if(isFade>0)
        {
            FadeIn();
        }
        if(isFade<0)
        {
            FadeOut();
        }
    }

    //フェードイン・フェードアウト反転スイッチ
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
    //フェードインスイッチ
    public void OnFadeIn()
    {
        alfa = 0;
        isFade = 1;
    }
    //フェードアウトスイッチ
    public void OnFadeOut()
    {
        alfa = 1.0f;
        isFade = -1;
    }

    //フェードイン
    public void FadeIn()
    {
        Panel.color = new Color(red, green, blue, alfa);
        alfa += speed * Time.deltaTime;
    }

    //フェードアウト
    public void FadeOut()
    {
        Panel.color = new Color(red, green, blue, alfa);
        alfa -= speed * Time.deltaTime;
    }
}

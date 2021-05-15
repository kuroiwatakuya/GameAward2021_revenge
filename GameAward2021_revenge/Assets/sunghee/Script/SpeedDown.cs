using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedDown : MonoBehaviour
{
    GameObject ChildWall;
    // Start is called before the first frame update
    void Start()
    {
        ChildWall = transform.Find("Wall").gameObject;
        ChildWall.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            ChildWall.SetActive(true);
        }
    }
}

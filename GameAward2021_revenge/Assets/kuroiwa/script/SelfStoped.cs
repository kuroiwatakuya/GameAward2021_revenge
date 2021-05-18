using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfStoped : MonoBehaviour
{
    private void OnParticleSystemStopped()
    {
        this.gameObject.SetActive(false);
    }
}

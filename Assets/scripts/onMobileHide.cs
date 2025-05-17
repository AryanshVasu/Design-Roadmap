using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onMobileHide : MonoBehaviour
{
    void Start(){
        gameObject.SetActive(!Application.isMobilePlatform);
    }
}

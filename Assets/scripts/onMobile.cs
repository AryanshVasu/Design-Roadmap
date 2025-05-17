using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onMobile : MonoBehaviour
{
    void Start(){
        gameObject.SetActive(Application.isMobilePlatform);
    }
}

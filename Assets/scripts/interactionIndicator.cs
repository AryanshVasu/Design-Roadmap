using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interactionIndicator : MonoBehaviour
{
    Transform player;
    GameObject highlight;

    void Start(){
        player = GameObject.Find("player").transform;
        highlight = transform.GetChild(0).gameObject;
    }

    void Update(){
        float dist = (player.position - transform.position).sqrMagnitude;
        if (dist < 20){
            highlight.SetActive(true);
        }else{
            highlight.SetActive(false);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCinteractionIndicator : MonoBehaviour
{
    Transform player;
    GameObject highlight;
    GameObject interact;
    [SerializeField] LayerMask interactable;
    bool interacted;
    PlayerControl control;

    void Start(){
        control = new PlayerControl();
        control.player.Enable();
        player = GameObject.Find("player").transform;
        highlight = transform.GetChild(0).gameObject;
        interact = transform.GetChild(2).gameObject;
        // interact = Application.isMobilePlatform ? transform.GetChild(1).gameObject : transform.GetChild(2).gameObject;
    }

    void Update(){
        float dist = (player.position - transform.position).sqrMagnitude;
        if (dist < 20){
            highlight.SetActive(false);
            if (!interacted){
                interact.SetActive(true);
            }
            if (Physics2D.OverlapCircle(transform.position,4f,interactable)){
                if (control.player.interact.WasPerformedThisFrame()){
                    interacted = true;
                    interact.SetActive(false);
                }
            }
            // bool interact = 
        }else{
            highlight.SetActive(true);
            interact.SetActive(false);
        }
    }
}

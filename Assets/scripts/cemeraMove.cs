using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cemeraMove : MonoBehaviour
{
    public GameObject player;

    void Start(){
        print ("start");
        // Screen.SetResolution(1920,1080,true);
    }
    void Update(){
        float x=Mathf.Clamp(player.transform.position.x,-45f+pixToDist(Screen.width/2),44f-pixToDist(Screen.width/2));
        float y=Mathf.Clamp(player.transform.position.y,-37.8f+pixToDist(Screen.height/2),23f-pixToDist(Screen.height/2));
        print ($"{-37.8f+pixToDist(Screen.height/2)}, {23f-pixToDist(Screen.height/2)}, {y}");
        transform.position=new Vector3(x,y,-10);
    }

    float pixToDist(int p){
        return (p*2*14/Screen.height);
    }
}


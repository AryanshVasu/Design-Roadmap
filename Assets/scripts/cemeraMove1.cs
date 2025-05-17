using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cemeraMove1 : MonoBehaviour
{
    public GameObject player;
    float fixedWidth;

    void Start(){
        Screen.SetResolution(1920,1080,true);
        fixedWidth = Application.isMobilePlatform ? 60 : 45;
    }
    void Update(){
        float x=Mathf.Clamp(player.transform.position.x,-45f+pixToDist(Screen.width/2),44f-pixToDist(Screen.width/2));
        float y=Mathf.Clamp(player.transform.position.y,-36.6f+pixToDist(Screen.height/2),23f-pixToDist(Screen.height/2));
        if (Application.isMobilePlatform){
            y += 1.8f;
        }
        transform.position=new Vector3(x,y,-10);

        UpdateCameraSize();
    }

    float pixToDist(int p){
        return (p*2*14/Screen.height);
    }

    void UpdateCameraSize(){
        Camera mainCamera = Camera.main;

        // Calculate orthographic size based on screen aspect ratio
        float aspectRatio = (float)Screen.width / Screen.height;
        mainCamera.orthographicSize = fixedWidth / (2f * aspectRatio);
    }
}


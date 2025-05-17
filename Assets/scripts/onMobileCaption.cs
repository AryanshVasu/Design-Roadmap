using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onMobileCaption : MonoBehaviour
{
    void Update(){
        RectTransform uiElement = GetComponent<RectTransform>();

        if (Application.isMobilePlatform){
            // float halfScreenHeight = Screen.height / 2f;

            Vector2 newPosition = uiElement.anchoredPosition;
            newPosition.y = (Screen.height)*1920/Screen.width-180; 
            uiElement.anchoredPosition = newPosition;
        }
    }

}

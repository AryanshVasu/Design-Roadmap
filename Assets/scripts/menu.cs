using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class menu : MonoBehaviour
{
    [SerializeField] GameObject mainMenu;
    [SerializeField] GameObject htpMenu;
    [SerializeField] GameObject startgameButton;
    [SerializeField] GameObject htpButton;
    [SerializeField] GameObject backButton;

    Animator anim;


    void Awake(){
        anim = gameObject.GetComponent<Animator>();
        EventSystem.current.SetSelectedGameObject(startgameButton);
        mainMenu.SetActive(true);
        htpMenu.SetActive(false);
    }

    public void StartGame(){
        StartCoroutine(startTransition());
    }

    public void HowToPlay(){
        anim.SetBool("tutOn",true);
        mainMenu.SetActive(false);
        htpMenu.SetActive(true);
        EventSystem.current.SetSelectedGameObject(backButton);
    }

    public void back(){
        anim.SetBool("tutOn",false);
        htpMenu.SetActive(false);
        mainMenu.SetActive(true);
        EventSystem.current.SetSelectedGameObject(htpButton);
    }

    void OnGUI(){
        Color col = Color.white;
        col.a = alpha;
        GUI.color = col;
        GUI.DrawTexture(new Rect(0,0,Screen.width,Screen.height),Texture2D.whiteTexture);
    }

    float alpha = 0;

    IEnumerator startTransition(){
        yield return null;
        float timeElapsed = 0;
        float transitionTime = 1;

        while (timeElapsed <= transitionTime){
            alpha = Mathf.Lerp(0,1,timeElapsed/transitionTime);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        gameObject.SetActive(false);
        playerMove1.GameOn = true;
    }
}

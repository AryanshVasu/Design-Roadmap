using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using TMPro;

public class playerMove1 : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void downloadPDF();

    [DllImport("__Internal")]
    private static extern void downloadPDF1();
    
    [DllImport("__Internal")]
    private static extern void downloadPDF2();
    
    [DllImport("__Internal")]
    private static extern void downloadPDF3();
    
    [DllImport("__Internal")]
    private static extern void downloadPDF4();
    
    [DllImport("__Internal")]
    private static extern void downloadPDF5();
//physics
    [SerializeField] Rigidbody2D rb;
    [SerializeField] private float speed;
    [SerializeField] LayerMask interactable;
//graphics
    public GameObject mcSprite;
    Animator animator;
    public GameObject book;
    public GameObject progress;
    bookUI bookui;
    public Canvas dialogueBox;
    public TMP_Text dialogueText;
    public GameObject arrow;
    public GUIStyle capStyle;
    public GUIStyle capShadowStyle;
    public float textSpeed = 0.05f;
//audio
    [Header("audio")]
    public AudioSource audiosrc;
    public AudioSource audiosrc1;
    public AudioSource audiosrc2;
    public AudioClip theme;
    public AudioClip uiInteraction;
    public AudioClip wander;
    public AudioClip learn;
    public AudioClip typing;
//dependancies
    bool bookOn=false;
    public static bool GameOn;
    bool tut=false;
    bool isInteracting;
    int tutStep=0;
    [System.NonSerialized] 
    public int[] destCheckList;
    Collider2D col;

    PlayerControl control;

    void Awake(){
        GameOn = false;


        //PlayerPrefs.DeleteAll();
        book.SetActive(bookOn);
        dialogueBox.enabled=false;
        destCheckList= new int[6];
        Load();

        animator=mcSprite.GetComponent<Animator>();
        bookui=book.GetComponent<bookUI>();
        audiosrc1.clip=theme;
        audiosrc1.Play();
        // StartCoroutine(playMusic());
//        StartCoroutine(tutorial());

        control = new PlayerControl();
        control.player.Enable();
        control.player.book.performed += bookInput;
        // control.player.interact.performed += interact;

    }

    void Update()
    {
        if (GameOn){
            Move(control.player.move.ReadValue<Vector2>());
        }else{
            rb.velocity=Vector3.zero;
        }

        isInteracting = control.player.interact.WasPerformedThisFrame();

        interact();
    }

    public void bookInput(InputAction.CallbackContext context){
        if (GameOn || bookOn){
            openbook();
        }
    }

    void Move(Vector2 move){
        // float movex=Input.GetAxis("Horizontal");
        // float movey=Input.GetAxis("Vertical");
        // Vector2 move=Vector2.ClampMagnitude(new Vector3(movex,movey),1);
        // move.Normalize();
        rb.velocity= move*speed;

        if (rb.velocity.x <=-0.1f){
            transform.localScale = new Vector3(-1,1,1);
        } else if (rb.velocity.x>=0.1f){
            transform.localScale=new Vector3(1,1,1);
        }

        animator.SetBool("walk",(Mathf.Abs(move[0])+Mathf.Abs(move[1])!=0));
    }

    void OnGUI(){
        float wd = Screen.width;
        float ht = Screen.height;
        // if (col){
        //     Rect capRect = new Rect(0,0.8f*ht,wd,0.2f*ht);
        //     if(visited(col)){
        //         GUI.Label(capRect,"CONGRATULATION! YOU HAVE LEARNED THIS SKILL",capStyle);
        //         return;
        //         // GUI.Label(new Rect(Screen.width/2-400,Screen.height*0.9f,800,50),"CONGRATULATION! YOU HAVE LEARNED THIS SKILL",caption);
        //     }else{
        //         print("not visited");
        //         GUI.Label(capRect,"PRESS Z TO DOWNLOAD CONTENT",capShadowStyle);
        //         GUI.Label(capRect,"PRESS Z TO DOWNLOAD CONTENT",capStyle);
        //         return;
        //         // GUI.Label(new Rect(Screen.width/2-250,Screen.height*0.9f,550,50),"PRESS Z TO DONWLOAD CONTENT",caption);
        //     }
        // }

        Color col = Color.black;
        col.a = alpha;
        GUI.color = col;
        GUI.DrawTexture(new Rect(0,0,wd,ht),Texture2D.whiteTexture);
    }

    bool visited(Collider2D col){
        switch(col.name){
            case "station1":
                return (destCheckList[0]==1);
            case "station2":
                return (destCheckList[1]==1);
            case "station3":
                return (destCheckList[2]==1);
            case "station4":
                return (destCheckList[3]==1);
            case "station5":
                return (destCheckList[4]==1);
            case "station6":
                return (destCheckList[5]==1);
            default:
                return false;
        }
    }

    void interact(){
        if (col=Physics2D.OverlapCircle(transform.position,4f,interactable)){
            if (isInteracting){
                switch(col.name)
                {
                    case "station1":
                        destCheckList[0]=1;
                        openbook(0);
                        downloadPDF();
                        playLearn();
                        break;
                    case "station2":
                        destCheckList[1]=1;
                        openbook(1);
                        downloadPDF1();
                        playLearn();
                        break;
                    case "station3":
                        destCheckList[2]=1;
                        openbook(2);
                        downloadPDF2();             
                        playLearn();
                        break;
                    case "station4":
                        destCheckList[3]=1;
                        openbook(3);
                        downloadPDF3();
                        playLearn();
                        break;
                    case "station5":
                        destCheckList[4]=1;
                        openbook(4);
                        downloadPDF4();
                        playLearn();
                        break;
                    case "station6":
                        destCheckList[5]=1;
                        openbook(5);
                        downloadPDF5();
                        playLearn();
                        break;
                    case "NPCsprite":
                        Transform NPC = GameObject.Find("NPC").transform;
                        NPC.GetChild(0).gameObject.SetActive(false);
                        NPC.GetChild(1).gameObject.SetActive(false);
                        NPC.GetChild(2).gameObject.SetActive(false);
                        if (!tutStarted) StartCoroutine(tutorial());
                        break;
                    default:
                        break;
                }
                Save();
            }
        }
    }

    void Save(){
        PlayerPrefs.SetInt("station1",destCheckList[0]);
        PlayerPrefs.SetInt("station2",destCheckList[1]);
        PlayerPrefs.SetInt("station3",destCheckList[2]);
        PlayerPrefs.SetInt("station4",destCheckList[3]);
        PlayerPrefs.SetInt("station5",destCheckList[4]);
        PlayerPrefs.SetInt("station6",destCheckList[5]);    
        PlayerPrefs.Save();    
    }
    void Load(){
        destCheckList[0]=PlayerPrefs.GetInt("station1");
        destCheckList[1]=PlayerPrefs.GetInt("station2");
        destCheckList[2]=PlayerPrefs.GetInt("station3");
        destCheckList[3]=PlayerPrefs.GetInt("station4");
        destCheckList[4]=PlayerPrefs.GetInt("station5");
        destCheckList[5]=PlayerPrefs.GetInt("station6");
    }

    void openbook(int pageNo=0){
        bookOn=!bookOn;
        GameOn=!GameOn;
        book.SetActive(bookOn);
        bookui.PageNo=pageNo; 
        audiosrc.PlayOneShot(uiInteraction,0.4f);
    }

    void playLearn(){
        audiosrc.volume=0.1f;
        audiosrc.PlayOneShot(learn,0.3f);
        audiosrc.volume=0.5f;
    }

    bool tutStarted = false;
    float alpha = 0;

    IEnumerator tutorial(){
        tutStarted = true;
        GameOn = false;

        // GameObject NPC =GameObject.Find("NPC")

 
        yield return StartCoroutine(dispDialogue("Jin: Greetings Designer!   \nI see you have chosen to explore to fields of design."));
        while (!isInteracting){
            yield return null;
        }
        yield return StartCoroutine(dispDialogue("Jin: Try to learn all of the fields of design across this world."));
        while (!isInteracting){
            yield return null;
        }
        yield return StartCoroutine(dispDialogue("Jin: You'll need a journal to keep track of your learnings. Here take this journal."));
        while (!isInteracting){
            yield return null;
        }
        yield return StartCoroutine(dispDialogue("*You recieved the journal. Press X at anytime to open or close journal."));
        while (!isInteracting){
            yield return null;
        }
        yield return StartCoroutine(dispDialogue("Jin: Kuro will accompany you in your journey and guide you."));
        while (!isInteracting){
            yield return null;
        }
        yield return StartCoroutine(dispDialogue("Kuro: woof!!"));
        while (!isInteracting){
            yield return null;
        }
        yield return StartCoroutine(dispDialogue("Jin: Good luck exploring."));
        while (!isInteracting){
            yield return null;
        }

        dialogueBox.enabled = false;

        float smoothTime=2;
        float timeElapsed=0f;
        while (timeElapsed<=smoothTime){
            audiosrc1.volume = Mathf.Lerp(1,0,timeElapsed/smoothTime);
            alpha = Mathf.Lerp(0,1,timeElapsed/smoothTime);
            timeElapsed+=Time.deltaTime*2;
            yield return null;
        }
        audiosrc1.Stop();
        GameObject.Destroy(GameObject.Find("NPC"));
        GameObject kuro = GameObject.Find("doggo");
        kuro.transform.localScale = new Vector3(1,1,1);
        kuro.transform.position -= new Vector3(2.5f,0,0);

        audiosrc.clip=wander;
        audiosrc.Play();
        while (timeElapsed>=0){
            alpha = Mathf.Lerp(0,1,timeElapsed/smoothTime);
            timeElapsed-=Time.deltaTime;
            yield return null;
        }
        GameOn=true;
        yield return new WaitForSeconds(0.3f);

        kuro.GetComponent<doggoMove1>().enabled = true;
    }

    bool dialogueStarted = false;

    // void startDispCaption(string dialogue){
    //     if (!dialogueStarted){
    //         dialogueStarted = true;
    //         StartCoroutine(dispCaption(dialogue));
    //     }
    // }
    IEnumerator dispDialogue(string dialogue){
        WaitForSeconds wait = new WaitForSeconds(textSpeed);
        dialogueBox.enabled=true;
        arrow.SetActive(false);
        dialogueText.text="";
        yield return null;
        for (int i=0; i<dialogue.Length; i++){
            float delayTime = 0;
            bool flag=false;
            while (delayTime<=textSpeed){
                if (isInteracting){
                    dialogueText.text = dialogue;
                    flag = true;
                    break;
                }
                delayTime += Time.deltaTime;

                yield return null;
            }
            if (flag) break;
            
            dialogueText.text += dialogue[i];

            if (dialogue[i] != ' '){
                audiosrc2.pitch = UnityEngine.Random.Range(0.85f,1.0f);
                audiosrc2.PlayOneShot(typing,0.3f);
            }
            // yield return wait;
        }

        arrow.SetActive(true);
        yield return null;
        
    }
}
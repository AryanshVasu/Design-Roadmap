using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class bookUI : MonoBehaviour
{
    public GameObject player;
    playerMove1 pm;
    public Image page1;
    public Image page2;
    // public Texture flipForward;
    // public Texture flipBack;
    public GUIStyle buttonStyle;
    public Sprite[] pages;                   //change it through editor
    public int PageNo =0;

    public AudioSource audioSource;
    public AudioClip paper;

    // string[] p1={"Lorem ipsum dolor sit amet, consectetur adipiscing elit. Mauris eget arcu ornare ex posuere blandit eu eget neque. Praesent egestas lacus eu malesuada lacinia. Aliquam cursus gravida tortor nec pretium. Phasellus vulputate in nisi sit amet dapibus. Etiam imperdiet a ligula a rhoncus. Curabitur porttitor tempus nunc, id viverra risus posuere dapibus. Aenean aliquam, massa imperdiet convallis vulputate, turpis justo facilisis augue, sed semper neque nisl id orci. Duis tellus justo, sagittis eget placerat suscipit, dictum a eros. Fusce ac tempus nisi. Nam rhoncus in enim eu accumsan. Donec mauris dolor, bibendum eget lacus eu, auctor facilisis neque. Curabitur sollicitudin pellentesque massa ac luctus. Donec molestie libero porttitor lorem tempor mattis. Mauris elementum odio quis leo feugiat, vel finibus tortor commodo. Integer a felis lacinia, bibendum mi eu, convallis lectus.",
    // "Curabitur quis mi nunc. Aenean mollis consequat ante sit amet placerat. Aenean a dictum nisl. Vestibulum luctus est at nisi gravida tempor. Nunc et imperdiet sem. Vivamus semper faucibus urna, quis lobortis lorem mollis tempor. Vestibulum sit amet malesuada purus. Vestibulum viverra finibus ligula, sit amet vestibulum justo faucibus vel. Aenean molestie non lectus sed ornare. Praesent congue diam quis nunc aliquam sagittis. Vivamus ut interdum est, id posuere mauris. Nullam sollicitudin risus ligula, quis rhoncus dolor ultricies et. Morbi quam ligula, fermentum eget tempor in, imperdiet at quam. Mauris ut viverra lorem. Nam mi neque, cursus a convallis non, euismod at ante. Etiam in sapien sed enim feugiat viverra."};
    // string[] p2={"In elementum, dui sit amet luctus pellentesque, metus orci sollicitudin eros, non rhoncus dui mi quis tellus. Suspendisse pretium ante ut turpis sagittis rhoncus at sed eros. Suspendisse nec placerat dolor. Vivamus ut aliquet turpis, at accumsan eros. Nullam ultrices risus a molestie vulputate. Donec eget faucibus orci. Nam dictum et ex ac dictum. Pellentesque fermentum viverra metus in rutrum.",
    // "Morbi auctor eu erat consectetur ultrices. Curabitur sed odio sed arcu placerat pulvinar. In hendrerit sapien pharetra tortor venenatis, nec tempor ipsum tincidunt. Fusce consectetur eros nisl, nec scelerisque nunc interdum vitae. Nam nulla arcu, consequat eget magna eget, lobortis bibendum dui. Pellentesque pretium egestas sem ac venenatis. Fusce a nibh justo. Fusce rhoncus, ipsum eu vestibulum aliquet, nisi est egestas neque, vel eleifend neque sapien ac est."};
    // string[] p3={"Lorem ipsum dolor sit amet, consectetur adipiscing elit. Phasellus leo justo, elementum in pretium in, sodales et felis. Donec id mi dolor. Vestibulum feugiat neque in purus accumsan efficitur. Vivamus laoreet augue quis ultrices semper. Integer in lacus diam. Nulla posuere felis nisl, et iaculis nisi posuere nec. Suspendisse et mi eu velit iaculis aliquet.",
    // "Aliquam commodo leo ac massa lobortis, eget egestas purus aliquam. Maecenas ipsum sem, auctor congue leo quis, lacinia facilisis sem. Suspendisse tincidunt mollis felis, eget pharetra metus tincidunt quis. Cras ornare et quam finibus porttitor. Nulla eleifend urna nisi, sed fringilla justo sollicitudin ac. Etiam nulla sapien, gravida a orci vel, dapibus tristique nisi. Donec condimentum sit amet velit sed feugiat. Suspendisse mollis tortor quis urna cursus, et pharetra odio placerat. Sed accumsan a augue ut eleifend. In sollicitudin facilisis leo nec elementum. Orci varius natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Curabitur non pretium odio."};
    // string[] p4={"Phasellus lacinia imperdiet augue, pulvinar cursus ipsum elementum et. Fusce ac ligula ut urna fringilla ullamcorper. Duis mattis, risus vitae elementum placerat, augue nulla volutpat ipsum, at suscipit tortor augue vel velit. In facilisis justo lectus, nec varius neque iaculis at. Aliquam laoreet mi a pharetra viverra. Vestibulum interdum et massa a posuere. Sed euismod leo dolor, fermentum fermentum ligula maximus quis. Aenean quis vestibulum mauris. Aliquam posuere sem eget eleifend feugiat. Suspendisse sit amet libero eleifend, maximus turpis ac, consequat urna. Fusce libero turpis, convallis sit amet viverra a, bibendum quis velit. Duis bibendum ut nunc a facilisis. Maecenas pretium egestas augue, eget scelerisque enim sollicitudin at. Mauris hendrerit sollicitudin libero sollicitudin congue. Cras consectetur aliquam vehicula. Mauris quis sagittis tellus.",
    // "Aenean accumsan lorem eget ipsum faucibus, ac porta dolor malesuada. Donec malesuada, nulla eu hendrerit interdum, eros lectus bibendum arcu, vel lacinia lorem lectus sed ipsum. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Ut blandit ipsum ac hendrerit interdum. Morbi accumsan feugiat ante, facilisis dignissim lectus. Ut at enim ut justo pellentesque faucibus. Maecenas dolor eros, aliquet vel nunc non, pulvinar placerat augue. Proin laoreet lorem non sagittis luctus. Morbi dignissim nec orci quis efficitur. Mauris porta metus vitae metus congue placerat. In vitae elit metus. Etiam eget fringilla mauris. Maecenas et ante aliquam, pharetra ex vitae, semper tortor. Nunc non facilisis turpis. Donec consectetur metus vel turpis faucibus, ac rhoncus ipsum vulputate."};
    // string[] p5={"Lorem ipsum dolor sit amet, consectetur adipiscing elit. Quisque laoreet nisl vel accumsan lacinia. Fusce suscipit eu magna quis consequat. Proin elementum viverra lorem. Maecenas tempor rutrum sapien, nec suscipit nulla euismod eu. Donec eget ultricies leo, non congue orci. Curabitur tellus lacus, dictum nec aliquam in, maximus at mi. Cras consequat placerat nunc nec elementum. In commodo eu erat ac gravida. Duis ac ullamcorper nulla, sed auctor lacus. Suspendisse ac mi nibh.",
    // "Sed at eros sit amet ex blandit tempor. Morbi congue fringilla turpis, sed luctus ex gravida id. Curabitur accumsan libero eu augue elementum tincidunt. Nulla nec venenatis mi. Donec consequat dapibus aliquam. In viverra accumsan dapibus. Ut in nisi ut magna convallis bibendum. Morbi at auctor ante."};

    


    void Start(){
        pm = player.GetComponent<playerMove1>();
        // content[0]=p1;
        // content[1]=p2;
        // content[2]=p3;
        // content[3]=p4;
        // content[4]=p5;
        DisplayPage();
    }
    
//     void OnGUI(){
//         if(GUI.Button(new Rect(295+Screen.width/2,Screen.height/2-25,50,50),flipForward,buttonStyle)&&pageNo<4){
//             pageNo++;
//             DisplayPage();
//         }
//         if (GUI.Button(new Rect(-345+Screen.width/2,Screen.height/2-25,50,50),flipBack,buttonStyle)&&pageNo>0){
//             pageNo--;
//             DisplayPage();
//         }
//     }
    public void DisplayPage(){
        if (pm.destCheckList[PageNo]==1){
            page1.GetComponent<Image>().sprite=pages[2*PageNo];
            page2.GetComponent<Image>().sprite=pages[2*PageNo+1];
            // para1.text= content[PageNo][0];
            // para2.text=content[PageNo][1];            
        }else{
            page1.GetComponent<Image>().sprite=pages[12];
            page2.GetComponent<Image>().sprite=pages[13];
        }
    }

    void Update(){
        if(Input.GetKeyDown("right")&&PageNo<5){
            PageNo++;
            audioSource.pitch = UnityEngine.Random.Range(0.8f,0.9f);
            audioSource.PlayOneShot(paper,0.5f);
        }
        if (Input.GetKeyDown("left")&&PageNo>0){
            PageNo--;
            audioSource.pitch = UnityEngine.Random.Range(0.8f,0.9f);
            audioSource.PlayOneShot(paper,0.5f);
        }
        DisplayPage();
    }
}

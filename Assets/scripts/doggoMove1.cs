using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class doggoMove1 : MonoBehaviour
{
    public Rigidbody2D rb;
    public Seeker seeker;
    Transform target;

    [SerializeField] float speed=200f;
    public float nextWaypoinDistance = 3f;

    public Transform[] targetpoints;
    public Transform player;
    playerMove1 pm;

    Path path;
    int currentWaypoint = 0;
    bool reachedEndOfPath=false;

    bool targetsDone=false;
    float playerDist;

    void Start(){
        target=targetpoints[0]; 
        pm=player.GetComponent<playerMove1>();
        StartCoroutine(UpdatePath());
    }

    IEnumerator UpdatePath(){
        while(true){
            if (seeker.IsDone()){
                seeker.StartPath(rb.position, target.position, OnPathComplete); 
            }
            yield return new WaitForSeconds(0.15f);
        }
    }
    void OnPathComplete(Path p){
        if (!p.error){
            path=p;
            currentWaypoint = 0;
        }
    }
    
    void FixedUpdate(){
        if (path==null){
            return;
        }
        if (currentWaypoint >=path.vectorPath.Count-1){
            reachedEndOfPath = true;
            return;
        } else{
            reachedEndOfPath = false;
        }
        float distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);
        if (distance < nextWaypoinDistance){
            currentWaypoint++;
        }

        Vector2 direction= ((Vector2)path.vectorPath[currentWaypoint]-rb.position).normalized;
        rb.velocity=(direction*speed);

        if (direction.x <=-0.1f){
            transform.localScale = new Vector3(-1,1,1);
        } else if (direction.x>=0.1f){
            transform.localScale=new Vector3(1,1,1);
        }
    }

    void Update(){
        // if (seeker.IsDone()){
        //     seeker.StartPath(rb.position, target.position, OnPathComplete); 
        // }
        playerDist=(transform.position-player.position).magnitude;
        targetSelect();
    }

    void targetSelect(){
        int outerRadi=14;
        int midRadi=12;
        int inRadi=4;

        if (targetsDone){
            if(playerDist<=inRadi){
                target=transform;
                return;
            }
            target=player;
            return;
        }

        if (playerDist<=inRadi){
            int i;
            for(i=0;i<6;i++){
                if (pm.destCheckList[i]==0){
                    break;
                }
            }
            if (i==6){
                targetsDone=true;
                return;
            }
            target=targetpoints[i];
            return;
        }
        if (playerDist>=outerRadi){
            target=player;
            return;
        }
        if (playerDist>=midRadi){
            if (target!=player){target=transform;}
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


public class HookBehaviour : MonoBehaviour{
    
    private bool hasTarget;
    [SerializeField]
    [Range(0f, 20f)]
    private float targetArea;
    private Transform[] Fishs;
    private bool onWater;
    private RodBehaviour RodBehaviour;
    private bool catching = false;
    private IEnumerator co;
    private AudioController Audio;
    private Transform Target;
    private ScoreManager score;
                                  

    private void Start(){
        RodBehaviour = GameObject.Find("Rod").GetComponent<RodBehaviour>();
        Audio = GameObject.Find("AudioController").GetComponent<AudioController>();
        score = GameObject.Find("Score").GetComponent<ScoreManager>();
    }

    private void Update(){

        // Delete Gameobject if throw failed       
        if (transform.position.y < -20){
            Destroy(gameObject);
        }

        // If hook ready, start looking for target
        if(!hasTarget && onWater){
            FindTarget();
        }   


        // Input to catch fish
        // call end coroutines with a "succes" arguments
        if(catching && Input.GetKeyDown(KeyCode.S)){
                StopCoroutine(co);
                StartCoroutine(ResetHook(true));

        }

    }


    // Waiting for target
    // Looking distance with each fish, if one is in the hook area he become target
    private void FindTarget(){
        GetFish();
        for(int i=0;i<Fishs.Length;i++){
            float dist = Vector3.Distance(Fishs[i].position, transform.position);
            if(dist < targetArea){
                Fishs[i].GetComponent<FishBehaviour>().Baited(this.transform.position);
                hasTarget = true;
                Target = Fishs[i];
            }
        }
    }


    // Get All fish positions
    private void GetFish(){
        Fishs = GameObject.Find("FishManager").GetComponentsInChildren<Transform>().Where(c => c.gameObject.tag == "Fish").ToArray();
    }

    // Detect when hook hit water and set ready state to up
    private void OnTriggerEnter(Collider other) {
       if(other.name == "Water"){
           onWater = true;
            Audio.PlaySound(Audio.HookInWater);

       }
    }

    // Public method call by FishBehaviour and start needed coroutines
    public void Fishing(){
        co = BaitFish();
        StartCoroutine(co);
    }

    // Coroutines when a fish has been hook
    // 5s Timer before call end coroutines with a "failed" argument
    // and change rod light to blue
    private IEnumerator BaitFish(){

        catching = true;
        foreach (var item in RodBehaviour.LightPart){
            item.material = RodBehaviour.LightMat[1];
        }

        yield return new WaitForSeconds(5);
        StartCoroutine(ResetHook(false));
        

    }

    // Coroutines to reset hook 
    // Display status color corresponding then delete hook / fish, or release fish if status is failed
    // changing rod light to green if succes or red if failed
    private IEnumerator ResetHook(bool succes){

        if(!succes){
            foreach (var item in RodBehaviour.LightPart){
                item.material = RodBehaviour.LightMat[3];
            }

            yield return new WaitForSeconds(1);
            RodBehaviour.ResetHook();
            catching = false;
            Target.GetComponent<FishBehaviour>().ReleaseFish(); 

        }
        else{
            foreach (var item in RodBehaviour.LightPart){
                item.material = RodBehaviour.LightMat[2];
            }

            yield return new WaitForSeconds(1);
            RodBehaviour.ResetHook();
            catching = false;
            score.AddScore(Target.GetComponent<FishBehaviour>().value);
            Destroy(Target.gameObject);
        }
    }

}

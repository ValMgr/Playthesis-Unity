using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


namespace FishHub {
public class HookBehaviour : MonoBehaviour{
    
   
    // Group: Variables
    [SerializeField]
    [Range(0f, 20f)]
    private float targetArea;
    private IEnumerator co;


    // Group: State Variables
    private bool onWater;
    private bool hasTarget;
    private bool catching = false;

    // Group: GameObject Variables
    private Transform[] Fishs;
    private RodBehaviour RodBehaviour;
    private AudioController Audio;
    private Transform Target;
    private ScoreManager score;
                                  
    // Group: Functions
    private void Start(){
        RodBehaviour = GameObject.Find("Rod").GetComponent<RodBehaviour>();
        Audio = GameObject.Find("AudioController").GetComponent<AudioController>();
        score = GameObject.Find("Score").GetComponent<ScoreManager>();
    }

     /* Function: Update

        If Z pressed, call <ResetHook> with "sucess" arguments.
     */
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
        if(catching && Input.GetKeyDown(KeyCode.Z)){
                StopCoroutine(co);
                StartCoroutine(ResetHook(true));

        }

    }


      /* Function: FindTarget

        Bait closest fish.

     */
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


     /* Function: GetFish

        Get all Fish gameobjects in scene.

        LINQ:
        --- Code
        GetComponentsInChildren<Transform>().Where(c => c.gameObject.tag == "Fish").ToArray();
        ---
        See Also: <System.Linq: https://unity3d.college/2017/07/01/linq-unity-developers/>

     */
    private void GetFish(){
        Fishs = GameObject.Find("FishManager").GetComponentsInChildren<Transform>().Where(c => c.gameObject.tag == "Fish").ToArray();
    }

    /* Function: OnTriggerEnter

        Detect when hook hit water and set ready state to up

     */
    private void OnTriggerEnter(Collider other) {
       if(other.name == "Water"){
           onWater = true;
            Audio.PlaySound(Audio.HookInWater);

       }
    }

     /* Function: Fishing

        Public method call by FishBehaviour and start needed coroutines

     */
    public void Fishing(){
        co = BaitFish();
        StartCoroutine(co);
    }

      /* Function: BaitFish

        Basic coroutines when a fish has been hook.
        If timer end, call <ResetHook> with "failed" arguments.
        
        - Change rod light to blue.
     */
   
    private IEnumerator BaitFish(){

        catching = true;
        foreach (var item in RodBehaviour.LightPart){
            item.material = RodBehaviour.LightMat[1];
        }

        yield return new WaitForSeconds(Target.GetComponent<FishBehaviour>().fTime);
        StartCoroutine(ResetHook(false));
        

    }


    /* Function: ResetHook

        Basic coroutines to reset hook if a fish has been catched or missed.

        Change rod light :

            - Green: Succes
            - Red: Fail

        Parameters:

        succes - Boolean
     */
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
}

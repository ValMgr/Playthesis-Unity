using UnityEngine;

namespace FishHub {
public class FishLine : MonoBehaviour {
    

    private GameObject Rod;
    private GameObject Hook;
    public LineRenderer lineRenderer;


    private RodBehaviour RodBehaviour;
    private void Awake() {
        RodBehaviour = GameObject.Find("Rod").GetComponent<RodBehaviour>();
        Rod = GameObject.Find("RodTop");
        lineRenderer.SetPosition(0, Rod.transform.position);
    }
    
    /*  Function: Update
    
        Set lineRenderer's position 0 at Hook's position
        and position 1 at top of the fish rod
    */
    private void Update() {
        if(RodBehaviour.BaitState){
            lineRenderer.SetPosition(0, Rod.transform.position);
            lineRenderer.SetPosition(1, Hook.transform.position);
        }
        else{
            lineRenderer.SetPosition(0, Rod.transform.position);
            lineRenderer.SetPosition(1, Rod.transform.position);
        }
    }


    /*  Function: SetHook
    
        Find Hook gameobject
    */
    public void SetHook(){
        Hook = GameObject.Find("TopTorus");
    }

}

}
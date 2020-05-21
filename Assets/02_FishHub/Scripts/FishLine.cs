using UnityEngine;

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
    
    // Give start & end position of fish line then draw it
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

    public void SetHook(){
        Hook = GameObject.Find("TopTorus");
    }

}
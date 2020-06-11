using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace FishHub {

public class RodBehaviour : MonoBehaviour{

    // Group: State Variables
    public static bool BaitState {get; private set;} = false;

    // Group: Rod Settings
    [SerializeField]
    [Range(0f, 10f)]
    private float ThrowingStrength;
    [SerializeField]
    [Range(0f, 15f)]
    private int MaxBaitTime;
    [SerializeField]
    [Range(0f, 10f)]
    private float RodSpeed;
    [SerializeField]
    [Range(0f, 2f)]          
    private float LeftLimit;
    [SerializeField]
    [Range(0f, 2f)]
    private float RightLimit;

    [SerializeField]

    // Group: GameObjects Variables
    private GameObject Hook;

    // Rod's target managing position (Rod looking at the gameobject and we're moving this gameobject)          
    private GameObject PointTo;             
    private AudioController Audio;

    // Group: Light Management
    public Renderer[] LightPart;
    public Material[] LightMat;



    // Group: Functions
    private void Awake(){
        PointTo = GameObject.Find("PointTo");
        Audio = GameObject.Find("AudioController").GetComponent<AudioController>();
        LightPart = transform.GetComponentsInChildren<MeshRenderer>().Where(c => c.gameObject.tag == "LightRod").ToArray();

    }

    private void Update(){

        MoveRod();


        // Keyboard input to launch & reset hook
        if (Input.GetKey(KeyCode.Z)){
            if (!BaitState){
                ThrowHook();
            }
        }
        if (Input.GetKey(KeyCode.X)){
            ResetHook();
        }



    }

    /* Function: ThrowHook

        Throw hook from fishrod.
        Get rod's extremity to calculate direction and instantiate new hook.

        Then create a <fish line: FishLine> between rod and hook and play sound corresponding.
       
     */
    private void ThrowHook(){
        // Get rod's higher point => Position from where the hook is launched
        Vector3 TopPosition = GameObject.Find("RodTop").transform.position;
        Vector3 BottomPosition = GameObject.Find("Crystal").transform.position;
        Vector3 Direction = TopPosition - BottomPosition;
        GameObject _hook = Instantiate(Hook, TopPosition, new Quaternion(0,0,0,0), this.transform.parent);
        _hook.name = "Hook";
        _hook.GetComponent<Rigidbody>().AddForce(ThrowingStrength * Vector3.forward + Direction, ForceMode.Impulse);
        GameObject.Find("FishLine").GetComponent<FishLine>().SetHook();
        BaitState = true;
        Audio.PlaySound(Audio.HookThrow);
    }

    
    /* Function: MoveRod

        Mooving rod on Horizontal axis.
        Mooving PoinTo gameObject and rod looking at it.
    */
    private void MoveRod(){

        if (Input.GetAxis("Horizontal") > 0 && PointTo.transform.position.x < RightLimit){
            PointTo.transform.position = PointTo.transform.position + Vector3.right * RodSpeed * Time.deltaTime;
        }
        if (Input.GetAxis("Horizontal") < 0 && PointTo.transform.position.x > -LeftLimit){
            PointTo.transform.position = PointTo.transform.position + Vector3.left * RodSpeed * Time.deltaTime;
        }

        this.transform.rotation = Quaternion.LookRotation(PointTo.transform.position - this.transform.position);
    }

    /* Function: ResetHook

        Delete hook, play sound correspondig then reset rod's light
    */
    public void ResetHook(){
        BaitState = false;
        Audio.PlaySound(Audio.OutOfWater);
        Destroy(GameObject.Find("Hook"));
        foreach (var item in LightPart){
            item.material = LightMat[0];
        }
    }


}

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldGen : MonoBehaviour
{

    //Each "Ground" Object is a prefab. This prefab is set in the Inspector

    public GameObject Ground1;
    public GameObject Ground2;
    public GameObject Ground3;

    public float SpaceBwFloor = 3.2f; //The Space there is between each floor
    private int NbFloor = 0; //Count the number of floor. Always a multiple of 10

    private List<int> FloorUsed = new List<int>(); //List all the floor which have been used for generation


    // Start is called before the first frame update
    void Start()
    {
        Gen(); 
    }


    // Update is called once per frame
    private void Update()
    {

        //If the floor the player is on haven't been used for generation
        //And we are at the 6th floor after the last generation, generate the floor

        if (PlayerBehavior.CamCount % 10 - 6 == 0 && !FloorUsed.Contains(PlayerBehavior.CamCount)) 
        {
            Gen();
        }
    }



    //Script responsible for the random generation of the world
    
    void Gen()
    {

        FloorUsed.Add(PlayerBehavior.CamCount);     //Add the actual floor to the floor used for generation

        for (int i = -8; i < 2; i++)
        {

            int RmNumber = Random.Range(1, 4); //Random Number who choose which "Ground" Prefab to use.

            if(RmNumber == 1)
            {
                Instantiate(Ground1, new Vector3(Random.Range(-2.2f, 2.2f), SpaceBwFloor * (i - NbFloor), 0), Quaternion.identity);
            }
            else if(RmNumber == 2)
            {
                Instantiate(Ground2, new Vector3(Random.Range(-2.2f, 2.2f), SpaceBwFloor * (i - NbFloor), 0), Quaternion.identity);
            }
            else if (RmNumber == 3)
            {
                Instantiate(Ground3, new Vector3(Random.Range(-2.2f, 2.2f), SpaceBwFloor * (i - NbFloor), 0), Quaternion.identity);
            }
        }
            
        NbFloor += 10;
    }
}
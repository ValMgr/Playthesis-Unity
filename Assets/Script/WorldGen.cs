using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldGen : MonoBehaviour
{
    public GameObject Ground1;
    public GameObject Ground2;
    public GameObject Ground3;
    public float SpaceBwFloor = 3.2f;
    private int NbFloor = 0;
    private List<int> FloorUsed = new List<int>();
    // Start is called before the first frame update
    void Start()
    {
        Gen();
    }

    private void Update()
    {
        if (PlayerBehavior.CamCount % 10 - 6 == 0 && !FloorUsed.Contains(PlayerBehavior.CamCount))
        {
            Gen();
        }
    }
    // Update is called once per frame
    void Gen()
    {
        FloorUsed.Add(PlayerBehavior.CamCount);
        for (int i = -8; i < 2; i++)
        {
            int RmNumber = Random.Range(1, 4);
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
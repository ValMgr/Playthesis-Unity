using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldGen : MonoBehaviour
{
    public GameObject Ground;
    private int NbFloor = 0;
    private List<int> FloorUsed = new List<int>();
    // Start is called before the first frame update
    void Start()
    {
        Gen();
    }

    private void Update()
    {
        if(PlayerBehavior.CamCount % 10 - 6 == 0 && !FloorUsed.Contains(PlayerBehavior.CamCount))
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
            Instantiate(Ground, new Vector3(Random.Range(-2.2f , 2.2f), 2*(i - NbFloor) , 0), Quaternion.identity);
        }
        NbFloor += 10;
    }
}

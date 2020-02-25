using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldGen : MonoBehaviour
{
    public GameObject Ground;
    private int NbRow = 0;
    // Start is called before the first frame update
    void Start()
    {
        Gen();
    }

    private void Update()
    {
        if(PlayerBehavior.CamCount % 10 - 7 == 0)
        {
            Gen();
        }
    }
    // Update is called once per frame
    void Gen()
    {
        for (int i = -8; i < 2; i++)
        {
            Instantiate(Ground, new Vector3(Random.Range(-2.2f , 2.2f), 2*i + NbRow , 0), Quaternion.identity);
        }
        NbRow += 10;
    }
}

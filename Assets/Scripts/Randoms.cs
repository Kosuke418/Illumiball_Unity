using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Randoms : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(Random.Range(-4.0f,4.0f),0, Random.Range(-8.0f, 8.0f));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

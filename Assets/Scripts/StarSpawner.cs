using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarSpawner : MonoBehaviour
{
    public Transform star;
    public GameObject parentToSet;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i< 1500; i++)
        {
            var temp = ( Instantiate(star, new Vector3(Random.Range(0, 300), Random.Range(0, 300), Random.Range(0, 300)), Quaternion.identity));
            temp.transform.parent = parentToSet.transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

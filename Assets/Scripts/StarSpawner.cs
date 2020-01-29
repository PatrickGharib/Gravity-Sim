using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarSpawner : MonoBehaviour
{
    public Transform star;
    public GameObject parentToSet;
    public Rigidbody rb;
    private float MIN_MASS = 5000;
    private float MAX_MASS = 99999999999;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i< 1500; i++)
        {
            //Debug.Log(i);
            Transform temp =  Instantiate(star, new Vector3(Random.Range(0, 300), Random.Range(0, 300), Random.Range(0, 300)), Quaternion.identity,parentToSet.transform);
            temp.localScale = temp.localScale
            rb = temp.gameObject.GetComponent<Rigidbody>();
            rb.mass = Random.Range(MIN_MASS, MAX_MASS);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
}

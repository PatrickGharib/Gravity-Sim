using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stars : MonoBehaviour
{
    public float mass;
    public float acceleration;
    private float MASS_MIN = 10000000;
    private float MASS_MAX = 9999999999999999999;

    
    // Start is called before the first frame update
    void Awake()
    {
        mass = Random.Range( MASS_MIN, MASS_MAX);
        float starScale = Random.RandomRange(1, 7);
        transform.localScale = new Vector3(starScale, starScale,starScale);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}

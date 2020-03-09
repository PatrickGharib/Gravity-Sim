using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarSpawner : MonoBehaviour
{
    public int NumStarsToSpawn;
    public Transform star;
    public Transform OrbitPoint;
    private List<Transform> ChildrenStars = new List<Transform>();
    private float GRAVITATIONAL_CONSTANT = 0.00000000067408f;
    private Rigidbody OrbitRb;
    public bool AngularVelocity = false;


    // Start is called before the first frame update
    void Start()
    {
        OrbitRb = OrbitPoint.GetComponent<Rigidbody>();
        for (int i = 0; i< NumStarsToSpawn; i++)
        {
            var temp = ( Instantiate(star, new Vector3(Random.Range(-100,100), Random.Range(-100,100), Random.Range(-100, 100)), Quaternion.identity));
            temp.GetComponent<Rigidbody>().mass = Random.RandomRange(99999,9999999);
            temp.transform.parent = transform;
            ChildrenStars.Add(temp);
            
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        foreach (Transform childStar in ChildrenStars)
        {
            Rigidbody childRb = childStar.GetComponent<Rigidbody>();
            var dist = OrbitPoint.position - childStar.position;
            var direction = dist.normalized;
            var radiusSquared = dist.magnitude * dist.magnitude;
            var massProduct = OrbitRb.mass * childRb.mass;

            var resultingForce = (GRAVITATIONAL_CONSTANT * massProduct) / radiusSquared;
            if (AngularVelocity) childRb.AddForce(transform.forward/2, ForceMode.Acceleration);

            childRb.AddForce(resultingForce*direction, ForceMode.Acceleration);
            
        }
    }


    private Vector3 DivideByVector(float num, Vector3 vector)
    {
        return new Vector3(num / vector.x, num / vector.y, num / vector.z);
    }
}

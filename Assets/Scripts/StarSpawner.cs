using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarSpawner : MonoBehaviour
{
    public Transform star;
    public GameObject parentToSet;
    public Rigidbody rb;
    public Rigidbody rb2;
    private float MIN_MASS = 5000;
    private float MAX_MASS = 99999999999;
    [Range(0, 10000)]
    public int starsToSpawn = 300;
    [Range(0, 100)]
    public int snakesToSpawn = 10;
    [Range(0, 10000)]
    public float moveSpeed;
    [Range(0,500)]
    public int maxSpeed;

    private List<List<GameObject>> starList = new List<List<GameObject>>();
    IEnumerator ChangeSpeed()
    {
        while (true)
        {
            moveSpeed = (moveSpeed*1.01f) % maxSpeed +1;
           
            yield return  new WaitForSeconds(.1f);
        }
    }

    void Start()
            {
                 StartCoroutine(ChangeSpeed());

                MakeMyStars();

            }
    // Start is called before the first frame update
    public void MakeMyStars() {
        
        for (int i = 0; i< snakesToSpawn; i++)
        { List<GameObject> temp = new List<GameObject>();
            for (int j = 0; j < starsToSpawn; j++)
            {
               
                //Debug.Log(i);
                temp.Add(Instantiate(star, new Vector3(Random.Range(0, 300), Random.Range(0, 300), Random.Range(0, 300)), Quaternion.identity, this.transform).gameObject);
                // temp.localScale = temp.localScale ;
                //rb = temp[i].GetComponent<Rigidbody>();
                //rb.mass = Random.Range(MIN_MASS, MAX_MASS);
               
            }
             starList.Add(temp);

        }
       
    }
    void orbit()
    {
        for (int i = 0; i < starList.Count; i++)
        {
            List<GameObject> list = starList[i];
            for (int j = 0; j < list.Count -1; j++)
            {
                GameObject currentStar = list[j];
                rb = currentStar.GetComponent<Rigidbody>();
                GameObject attractorStar = list[j+1];

                if (j == list.Count - 1)
                {
                    attractorStar = list[0];
                }
                else
                {
                    attractorStar = list[j + 1];

                }
                currentStar.transform.position = Vector3.MoveTowards(currentStar.transform.position, attractorStar.transform.position, moveSpeed * Time.deltaTime);
                //attractorStar.transform.position = Vector3.MoveTowards(attractorStar.transform.position, currentStar.transform.position, moveSpeed * Time.deltaTime);
                //currentStar.transform.position = currentStar.transform.position + new Vector3(.1f, 0f, 0f);
            }
            
        }
    }
    private void FixedUpdate()
    {
        orbit();
    }
}
   


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwanSwim : MonoBehaviour
{
    Rigidbody rb;
    public List<GameObject> patrolPoint;
    public int current_num;
    public GameObject current_point;
    public float speed;
    public float pointRadius = 1;

    private void Start()
    {
        current_point = patrolPoint[0];
    }

    private void Update()
    {
        if (Vector3.Distance(patrolPoint[current_num].transform.position, transform.position) < pointRadius)
        {
            current_num++;
            if (current_num >= patrolPoint.Count)
            {
                current_num = 0;
            }
        }
        this.transform.LookAt(patrolPoint[current_num].transform.position);
        this.transform.position = Vector3.MoveTowards(transform.position, patrolPoint[current_num].transform.position, Time.deltaTime * speed);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionColor : MonoBehaviour
{
    float duration = 3f;
    float transition = 0f;
    RaycastHit hit;
    Renderer rend;
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        //StartCoroutine(ChangeColor());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                StartCoroutine(ChangeColor());
            }
        }
    }

    IEnumerator ChangeColor()
    {
        //float t = 0;
        
        while (rend.material.GetFloat("_TransitionValue") < 1.1)
        {
            //t += Time.deltaTime;
            transition = transition + 0.01f;
            rend.material.SetFloat("_TransitionValue", transition);
            yield return null;
        }
    }
}

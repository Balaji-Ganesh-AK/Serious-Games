using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickToChange : MonoBehaviour
{
    float duration = 3f;
    float transition = -0.1f;
    RaycastHit hit;
    Renderer rend;
    Material mat;
    // Start is called before the first frame update
    void Start()
    {
        //rend = GetComponent<Renderer>();
        //StartCoroutine(ChangeColor());
    }

    // Update is called once per frame
    //void Update()
    //{
    //    if (Input.GetMouseButtonDown(0))
    //    {
    //        RaycastHit hit;
    //        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    //        if (Physics.Raycast(ray, out hit))
    //        {
    //            mat = hit.transform.gameObject.GetComponent<Renderer>().material;
    //            StartCoroutine(ChangeColor(mat));
    //        }
    //    }
    //}

    public void StartChangeColor(Material mat, Material i_mat)
    {
        //Material mat_instance = new Material(Shader.Find(""))
        mat.SetColor("_NewColor", i_mat.color);
        StartCoroutine(ChangeColor(mat));
        
    }

    IEnumerator ChangeColor(Material mat)
    {
        //float t = 0;
        transition = -0.1f;
        while (mat.GetFloat("_TransitionValue") < 1.1f)
        {
            //t += Time.deltaTime;
            transition = transition + 0.01f;
            mat.SetFloat("_TransitionValue", transition);
            yield return null;
        }
        Color col = mat.GetColor("_NewColor");
        mat.SetColor("_CurrentColor", col);
        
        mat.SetFloat("_TransitionValue", -0.1f);
        print("Changed");
    }
}

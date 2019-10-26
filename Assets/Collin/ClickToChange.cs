using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickToChange : MonoBehaviour
{
    public int counter;
    float duration = 3f;
    float transition = -0.1f;
    RaycastHit hit;
    Renderer rend;
    Material mat;
    bool isChanging = false;
    // Start is called before the first frame update
    void Start()
    {
        counter = 0;
        //rend = GetComponent<Renderer>();
        //StartCoroutine(ChangeColor());
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {

                //if(hit.transform.gameObject.GetComponent<SwapChildColor>())
                //{
                //    hit.transform.gameObject.GetComponent<SwapChildColor>().ChangeChildColor(mat);
                //}
                foreach (Material mat in hit.transform.GetComponent<Renderer>().materials)
                {
                    StartCoroutine(ChangeColor(mat));
                }
                //mat = hit.transform.gameObject.GetComponent<Renderer>().material;
                //StartCoroutine(ChangeColor(mat));
            }
        }
    }

    public void StartChangeColor(Material mat, Material i_mat)
    {
        //Material mat_instance = new Material(Shader.Find(""))
        mat.SetColor("_NewColor", i_mat.color);
        StartCoroutine(ChangeColor(mat));
    }
    public void StartChangeColor(Material mat, Color i_color)
    {
        //Material mat_instance = new Material(Shader.Find(""))
        mat.SetColor("_NewColor", i_color);
        StartCoroutine(ChangeColor(mat));
    }
    //public void ChangeObjectColor(Material mat, Material i_mat)
    //{
    //    mat.SetColor("_NewColor", i_mat.color);
    //    transition = 0f;
    //    float duration = 5f; //seconds
    //    float timer = 0f;
    //    while(timer <= duration)
    //    {
    //        transition *= timer / duration;
    //        mat.SetFloat("_TransitionValue", transition);
    //        timer += Time.deltaTime;
    //    }
    //    Color col = mat.GetColor("_NewColor");
    //    mat.SetColor("_CurrentColor", col);

    //    mat.SetFloat("_TransitionValue", 0f);
    //}

    IEnumerator ChangeColor(Material mat)
    {
        Debug.Log(mat.name);
        //if(!isChanging)
        {
            isChanging = true;
            transition = -0.1f;
            while (mat.GetFloat("_TransitionValue") < 1.1f)
            {
                //t += Time.deltaTime;
                transition = transition + 0.03f;
                mat.SetFloat("_TransitionValue", transition);
                yield return null;
            }
            Color col = mat.GetColor("_NewColor");
            mat.SetColor("_CurrentColor", col);

            mat.SetFloat("_TransitionValue", -0.1f);
            print("Changed");
            isChanging = false;
        }
    }
}

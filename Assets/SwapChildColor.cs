using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapChildColor : MonoBehaviour
{
    public Material default_material;
    private ClickToChange colChanger;

    private void Start()
    {
        colChanger = GameObject.Find("ColorChanger").GetComponent<ClickToChange>();
    }

    private void Awake()
    {
        InitChildColor(default_material);
    }

    private void InitChildColor(Material i_material)
    {
        if (this.transform.GetComponent<Renderer>())
            this.transform.GetComponent<Renderer>().material = i_material;
        foreach (Transform child in this.transform)
        {
            if (child.GetComponent<Renderer>())
                child.GetComponent<Renderer>().material = i_material;
            foreach (Transform subChild in child.transform)
            {
                if(subChild.GetComponent<Renderer>())
                {
                    subChild.GetComponent<Renderer>().material = i_material;
                }
            }
        }
    }

    public void ChangeChildColor(Material i_material)
    {
        if (this.GetComponent<Renderer>())
        {
            colChanger.StartChangeColor(this.GetComponent<Renderer>().material, i_material);
        }
            //colChanger.StartChangeColor(this.GetComponent<Renderer>().material, i_material);
        foreach(var child in this.GetComponentsInChildren<Renderer>())
        {
            colChanger.StartChangeColor(child.material, i_material);
        }
        //if (this.transform.GetComponent<Renderer>())
        //{
        //    colChanger.StartChangeColor(this.transform.GetComponent<Renderer>().material, i_material);
        //}
        //foreach (Transform child in this.transform)
        //{
        //    if (child.transform.GetComponent<Renderer>())
        //    {
        //        colChanger.StartChangeColor(child.transform.GetComponent<Renderer>().material, i_material);
        //    }
        //    foreach (Transform subChild in child.transform)
        //    {
        //        if (subChild.transform.GetComponent<Renderer>())
        //        {
        //            colChanger.StartChangeColor(subChild.transform.GetComponent<Renderer>().material, i_material);
        //        }
        //    }
        //}
    }

    public void ChangeChildColor(Color i_color)
    {
        if (this.GetComponent<Renderer>())
        {
            colChanger.StartChangeColor(this.GetComponent<Renderer>().material, i_color);
        }
        //colChanger.StartChangeColor(this.GetComponent<Renderer>().material, i_material);
        foreach (var child in this.GetComponentsInChildren<Renderer>())
        {
            colChanger.StartChangeColor(child.material, i_color);
        }
        //if (this.transform.GetComponent<Renderer>())
        //{
        //    colChanger.StartChangeColor(this.transform.GetComponent<Renderer>().material, i_color);
        //}
        //foreach (Transform child in this.transform)
        //{
        //    if (child.transform.GetComponent<Renderer>())
        //    {
        //        colChanger.StartChangeColor(child.transform.GetComponent<Renderer>().material, i_color);
        //    }
        //    foreach (Transform subChild in child.transform)
        //    {
        //        if (subChild.transform.GetComponent<Renderer>())
        //        {
        //            colChanger.StartChangeColor(subChild.transform.GetComponent<Renderer>().material, i_color);
        //        }
        //    }
        //}
    }
}

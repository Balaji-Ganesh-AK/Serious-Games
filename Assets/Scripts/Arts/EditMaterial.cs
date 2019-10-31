using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EditMaterial : MonoBehaviour
{
    Renderer rend;
    private GameObject go;
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        rend.material.SetColor("_NewColor", Color.blue);
    }
   


}

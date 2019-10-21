using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Valve.VR.InteractionSystem.Sample
{
    public class SwapMaterial : MonoBehaviour
    {
        // Blends between two materials
        public SceneHandler sceneHandler;
        public List<Material> materials;
        public Material m_material;
        public float lerpSpeed;
        public float lerp;
        public Texture m_albedo;
        [SerializeField] private Material targetMaterial;
        [SerializeField] private bool isLerping;

        //float duration = 2.0f;
        Renderer rend;

        void Start()
        {
            lerp = 0f;
            isLerping = false;
            rend = GetComponent<Renderer>();
            //targetMaterial = materials[0];
            //// At start, use the first material
            //rend.material = materials[0];
            //rend.material.EnableKeyword("_DETAIL_MULX2");
            ////Debug.Log(rend.material.GetTexture());
            //rend.material.SetTexture("_MainTex", m_albedo);
        }

        void Update()
        {
            //if(Input.GetKeyDown(KeyCode.Alpha1))
            //{
            //    SetTargetMaterial("Red");
            //}
            //if (Input.GetKeyDown(KeyCode.Alpha2))
            //{
            //    SetTargetMaterial("Green");
            //}
            //if (Input.GetKeyDown(KeyCode.Alpha3))
            //{
            //    SetTargetMaterial("Blue");
            //}
            //// ping-pong between the materials over the duration
            //if (lerp <= 1 && isLerping)
            //{
            //    SwapNextMaterial();
            //}
            //else
            //    isLerping = false;

        }

        public void SwapNextMaterial()
        {
            lerp += lerpSpeed * Time.deltaTime;
            rend.material.Lerp(rend.material, targetMaterial, lerp);
        }
        private void SetTargetMaterial(string m_name)
        {
            int i = 0;
            foreach (Material m in materials)
            {
                if (m.name == m_name)
                {
                    Debug.Log("found " + m_name);
                    break;
                }
                i++;
            }
            targetMaterial = materials[i];
            lerp = 0;
            isLerping = true;
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.transform.CompareTag("Colorable"))
            {
                Debug.Log("hit colorable");
                collision.transform.GetComponent<Renderer>().material = m_material;
                Destroy(this.gameObject);
            }
        }

        private void OnDetachedFromHand(Hand hand)
        {
            Debug.Log(hand.transform.forward);
            GetComponent<Rigidbody>().AddForce(hand.transform.forward * 100f);
        }
    }
}



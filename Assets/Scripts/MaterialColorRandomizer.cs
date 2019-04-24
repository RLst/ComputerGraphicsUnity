using System.Collections.Generic;
using UnityEngine;

namespace ComputerGraphics
{
    public class MaterialColorRandomizer : MonoBehaviour
    {
        [SerializeField] float heightRandomizeFactor = 0.25f;
        [SerializeField] Material[] colors;
        List<Transform> objectsToColor;

        void Start()
        {
            objectsToColor = new List<Transform>();
            for (int i = 0; i < transform.childCount; i++)
            {
                //Grab all child objects 
                objectsToColor.Add(transform.GetChild(i));

                //Set with a random colour
                if (colors.Length > 0)
                {
                    objectsToColor[i].GetComponent<MeshRenderer>().material.color = colors[Random.Range(0, colors.Length - 1)].color;
                }

                //Randomly scale the y axis to get rid of z clipping artifact
                var temp = objectsToColor[i].localScale;
                temp.y *= 1f + Random.Range(0f, heightRandomizeFactor);
                objectsToColor[i].localScale = temp;
            }
        }

        void Update()
        {

        }
    }
}
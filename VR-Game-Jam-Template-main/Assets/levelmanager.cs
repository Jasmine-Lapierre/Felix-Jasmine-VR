using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.XR.Content.Interaction;

public class levelmanager : MonoBehaviour
{

    public GameObject fenetre;
    public XRKnob roue;
    private float FramePrecedent;
    /*
    public Material[] materialArray;
    Renderer r;
    public Texture2D texture;
    public Vector2 textureSize = new Vector2(2048, 2048);*/


    // Start is called before the first frame update
    /*
    private void Start()
    {
        GameObject poterie = GameObject.FindWithTag("Poterie");
        if (poterie) { 
            r = poterie.GetComponent<Renderer>();
        r.enabled = true;
        r.sharedMaterial = materialArray[0];
        }
        
    } */
    // Update is called once per frame
    void Update()
    {

        if (roue.value ==1&roue.value != FramePrecedent){
            GameObject poterie = GameObject.FindWithTag("Poterie");
            if (poterie){
            poterie.tag = "Paintable";
          /*  r.sharedMaterial = materialArray[1];
                var rend = poterie.GetComponent<Renderer>();
                texture = new Texture2D((int)textureSize.x, (int)textureSize.y);
                rend.material.mainTexture = texture; */
            }
            Debug.Log("Aok AOSKDOPASKDOPASKDOPKASPDKASKDOPAKSDKAOSPDKOASKDASDPOAKSDOPs");
        }
        FramePrecedent = roue.value;
       fenetre.transform.position = new Vector3(10.95f,(roue.value*2.2f),6.05f);
    }
}

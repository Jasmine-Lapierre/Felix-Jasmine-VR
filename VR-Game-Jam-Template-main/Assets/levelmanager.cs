using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Content.Interaction;

public class levelmanager : MonoBehaviour
{

    public GameObject fenetre;
    public XRKnob roue;
    private float FramePrecedent;
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {

        if (roue.value ==1&roue.value != FramePrecedent){
          GameObject poterie = GameObject.FindWithTag("Poterie");
          if(poterie){
            poterie.tag = "Paintable";

          }
            Debug.Log("Aok AOSKDOPASKDOPASKDOPKASPDKASKDOPAKSDKAOSPDKOASKDASDPOAKSDOPs");
        }
        FramePrecedent = roue.value;
       fenetre.transform.position = new Vector3(10.95f,(roue.value*2.2f),6.05f);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mesh_controler : MonoBehaviour
{
[Range(1.5f,5f)]
    public float radius = 2f;
    [Range(1.5f,5f)]

    public float deformationStrength = 2f;
    private Mesh mesh;
    private Vector3[] verticies, modifiedVerts;

    // Start is called before the first frame update
    void Start()
    {
        mesh = GetComponentInChildren<MeshFilter>().mesh;
        verticies = mesh.vertices;
        modifiedVerts = new Vector3[verticies.Length];
    }
void RecalculateMesh(){
    mesh.vertices = modifiedVerts;
    //GetComponentInChildren<MeshCollider>().sharedMesh = mesh;
    mesh.RecalculateNormals();
}
    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray,out hit,Mathf.Infinity)){
            for(int v = 0; v<modifiedVerts.Length;v++){
                Vector3 distance = modifiedVerts[v] - hit.point;
                float smoothingfactor = 2f;
                float force = deformationStrength/(1f+hit.point.sqrMagnitude);
                if(distance.sqrMagnitude < radius){
                    if(Input.GetMouseButton(0)){
                       modifiedVerts[v] = modifiedVerts[v]+(Vector3.up*force) /smoothingfactor;

                    }
                }
            }
        }
            RecalculateMesh();

    }
}

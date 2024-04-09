using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshDeformerInput : MonoBehaviour {
    public float force = 10f;
    public float forceOffset = 0.1f;
    public float forceDuration = 1f; // Duration for which the force is applied
    private float elapsedTime = 0f; // Time elapsed since force application

    void Update () {
        if (Input.GetMouseButton(0)) {
            HandleInput();
        }
    }

    void HandleInput () {
        elapsedTime += Time.deltaTime;

        Ray inputRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(inputRay, out hit)) {
            MeshDeformer deformer = hit.collider.GetComponent<MeshDeformer>();
            if (deformer) {
                Vector3 point = hit.point;
                point += hit.normal * forceOffset;
                deformer.AddDeformingForce(point, force);

                if (elapsedTime >= forceDuration) {
                    // Reset the timer and stop applying force
                    elapsedTime = 0f;
                    // Optionally, you can reset the deforming forces applied to the mesh here
                    // deformer.ResetDeformingForces();
                }
            }
        }
    }
}

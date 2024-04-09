using UnityEngine;

public class SculptingTool : MonoBehaviour {

    public float force = 10f;

    void OnCollisionStay(Collision collision) {
        Debug.Log("Allo");
        foreach (ContactPoint contact in collision.contacts) {
            MeshDeformer deformer = contact.otherCollider.GetComponent<MeshDeformer>();
            if (deformer) {
                deformer.AddDeformingForce(contact.point, force);
            }
        }
    }
}

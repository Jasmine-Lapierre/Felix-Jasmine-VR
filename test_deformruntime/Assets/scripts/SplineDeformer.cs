using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Dreamteck.Splines;

public class SplineDeformer : MonoBehaviour
{
    public float shrinkAmount; // Montant de réduction du rayon du spline
    public SplineComputer splineComputer; // Référence au composant SplineComputer du spline
    public GameObject doigt;
    public GameObject zoneGrandir;
    float heightGrowthAmount = 0.00015f;

    void Start()
    {
        Debug.Log(shrinkAmount);
        if (splineComputer == null)
        {
            Debug.LogError("Aucun composant SplineComputer trouvé sur cet objet.");
            enabled = false; // Désactiver ce script s'il n'y a pas de composant SplineComputer attaché à l'objet
        }
    }

    void OnTriggerStay(Collider other)
    {
            SplinePoint[] points = splineComputer.GetPoints();
        if (other.tag=="ZoneGrandir"){

                    for (int i = 1; i < splineComputer.pointCount; i++){
                       points[i].position.y += heightGrowthAmount*i;
                        zoneGrandir.transform.position += new Vector3 (0,heightGrowthAmount,0);

                     //   heightGrowthAmount+=Mathf.Pow(heightGrowthAmount,i);
                        Debug.Log(i + "  " +points[i].position.y);

                    }
        zoneGrandir.transform.position += new Vector3 (0,heightGrowthAmount,0);
               splineComputer.SetPoints(points);

        }
        else if(other.tag=="Poterie"){
 // Project() permet d'obtenir la position, la rotation et le pourcentage du point spline le plus proche d'une coordonnées world
            double positionSplinePercent = splineComputer.Project(doigt.transform.position).percent;
            int closestPointIndex = FindClosestPointIndex(positionSplinePercent);
            SplinePoint closestPoint = splineComputer.GetPoint(closestPointIndex);
          /*  if (closestPoint.size<3f){
            splineComputer.SetPointSize(closestPointIndex, closestPoint.size + shrinkAmount);
            return;

            }*/
            if(closestPoint.size>0.2f){
                Debug.Log("Size of the point: "+closestPoint.size);
                Debug.Log("Shrink Amount: "+shrinkAmount);

            splineComputer.SetPointSize(closestPointIndex, closestPoint.size - shrinkAmount);

            return;
            }
                           splineComputer.SetPoints(points);

        }

    }
// Méthode qui permet de trouver l'index du point le plus proche en partant d'un pourcentage.
    int FindClosestPointIndex(double targetPercent)
    {
        double minDistance = double.MaxValue;
        int closestIndex = 0;
// Boucle sur chacun des points du spline et compare les pourcentage au pourcentage entré en input pour trouver le plus proche

        for (int i = 0; i < splineComputer.pointCount; i++)
        {
            double distance = Mathf.Abs((float)splineComputer.GetPointPercent(i) - (float)targetPercent);
            if (distance < minDistance)
            {
                minDistance = distance;
                closestIndex = i;
            }
        }

        return closestIndex;
    }
}
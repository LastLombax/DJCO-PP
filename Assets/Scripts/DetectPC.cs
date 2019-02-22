using UnityEngine;

public class DetectPC : MonoBehaviour
{

    public GameObject map;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Pressed left click, casting ray.");
            CastRay();
        }
    }

    void CastRay()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100))
        {
            Debug.DrawLine(ray.origin, hit.point);
            string obj = hit.collider.gameObject.name;
            Debug.Log("Hit object: " + hit.collider.gameObject.name);
            if (obj.Equals("PC"))
                map.GetComponent<MapScript>().ShowMap();
        }
    }
}

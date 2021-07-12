using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI; //for NavMeshAgent;

public class Player : MonoBehaviour
{
    public Camera cam = null;
    public NavMeshAgent nma = null;
    public GameObject prefabClick = null;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) == true)
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit) == true)
            {
                nma.SetDestination(hit.point);

                GameObject obj = Instantiate(prefabClick);
                obj.transform.position = hit.point;
                obj.transform.Translate(Vector3.up * 1.0f);
                obj.GetComponent<Click>().PlayEffect();
            }
        }
    }
}

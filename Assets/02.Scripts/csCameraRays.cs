using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class csCameraRays : MonoBehaviour
{
    private Camera camera;
    private RaycastHit rayHit;
    private Ray ray;

    // Start is called before the first frame update
    void Start()
    {
        camera = Camera.main.GetComponent<Camera>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        int layerMask = (-1) - (1 << LayerMask.NameToLayer("Player"));
        ray = camera.ViewportPointToRay(new Vector3(0.5f, 0.5f, -1f));

        if(Physics.Raycast(ray, out rayHit, Mathf.Infinity, layerMask))
        {
            //Debug.Log(rayHit.transform.name);
            if (rayHit.transform.gameObject.tag == "Item")
            {
                if (Input.GetMouseButtonDown(0))
                {
                    csItemManager.instance.item_list.Add(rayHit.transform.name);
                    Destroy(rayHit.transform.gameObject);
                }
            }
            //Debug.DrawLine(ray.origin, rayHit.point, Color.green);

        }
        else
        {
            //Debug.DrawRay(ray.origin, ray.direction * 100, Color.red);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchSpawn : MonoBehaviour
{
    public GameObject particlesSpawn;
    //public ParticleSystem particle;
    //public List<GameObject> particles = new List<GameObject>();

    void WhackMole()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                // If I hit a mole
                if (hit.collider.gameObject)
                {
                    Instantiate(particlesSpawn, hit.point, Quaternion.identity);
                }
            }
        }
    }

    void Update()
    {
        WhackMole();
    }

    GameObject SpawnObjects()
    {
        Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10);
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(mousePos);
        return Instantiate(particlesSpawn, worldPos, particlesSpawn.transform.rotation);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class VolkanoExplosion : MonoBehaviour
{
    public GameObject volcanoprefab;
    public float explosionPower, explosionRaduis, explosionRange, explosionTimer;
    public Camera fpsCam;
    GameObject volcanoInstantiation;
    bool volcanoIsPrimed;
    public ParticleSystem explosionparticles, explosionprefab;
    
    // Start is called before the first frame update
    void Start()
    {
        volcanoIsPrimed = false;
        explosionTimer = 5f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && GameObject.Find("volcano") == null)
        {
            Debug.Log("Spawning volcano");
            RaycastHit hit;
            if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, explosionRange))
            {
                volcanoInstantiation = GameObject.Instantiate(volcanoprefab, new Vector3(hit.point.x, hit.point.y + 1, hit.point.z), fpsCam.transform.rotation);
                volcanoInstantiation.name = "volcano";
                volcanoIsPrimed = true;
            }
        }
        if (volcanoIsPrimed == true)
        {
            explosionTimer -= Time.deltaTime;
            volcanoInstantiation.transform.Find("Timer Text").GetComponent<TextMeshPro>().text = "TIMER: 00.0" + (explosionTimer).ToString("F2");
        }
        if (Input.GetButtonDown("Fire2") || explosionTimer <= 0f)
        {
            Collider [] hitcolliders = Physics.OverlapSphere(volcanoInstantiation.transform.position, explosionRaduis);
            foreach (  var hitcollider in hitcolliders)
            {
                if (hitcollider.transform.GetComponent<Rigidbody>() != null)
                {

                    hitcollider.transform.GetComponent<Rigidbody>().AddForce(hitcollider.transform.position - volcanoInstantiation.transform.position) * explosionPower + hitcollider.transform.up * explosionPower * 2f);
                }
            }
            explosionparticles = ParticleSystem.Instantiate(explosionprefab, volcanoInstantiation.transform.position, Quaternion.identity);
            explosionparticles.Play();
            Destroy(volcanoInstantiation);
            volcanoIsPrimed = false;
        }
    }
}

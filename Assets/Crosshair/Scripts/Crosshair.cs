using UnityEngine;

public class Crosshair : MonoBehaviour {

    public Camera _cam;
    public float distance = 100f;
    public float force = 5f;

	// Use this for initialization
	void Start () {
		if(_cam == null)
        {
            _cam = Camera.main;
        }
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetMouseButtonDown(0))
        {
            Vector3 rayOrigin = _cam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0));

            RaycastHit hit;

            if (Physics.Raycast(rayOrigin, _cam.transform.forward, out hit, distance) && hit.transform.GetComponent<Rigidbody>())
            {
                Debug.LogFormat("Hit!: {0} Tag: {1} Distance: {2} Point: {3}", hit.collider.name, hit.collider.tag, hit.distance, hit.point);

                Vector3 direction = hit.transform.position - _cam.transform.position;

                hit.transform.GetComponent<Rigidbody>().AddForce(direction * force,ForceMode.Force);


            }
        }

        

    }



}

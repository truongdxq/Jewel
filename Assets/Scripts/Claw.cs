using UnityEngine;
using System.Collections;

public class Claw : MonoBehaviour {
    public Gun gun;
    public Transform origin;
    public float speed = 4.0f;
    public ScoreManager scoremanager;

    private Vector3 target;
    private int jewelValue = 100;
    private GameObject childObject;
    private LineRenderer lineRenderer;
    private bool hitJewel;
    private bool retracting;
	// Use this for initialization
	void Awake () {
        lineRenderer = GetComponent<LineRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target, step);
        lineRenderer.SetPosition(0, origin.position);
        lineRenderer.SetPosition(1, transform.position);
        if (transform.position == origin.transform.position && retracting)
        {
            gun.CollectedObject();
            if (hitJewel)
            {
                scoremanager.AddPoint(jewelValue);
                hitJewel = false;
            }
            Destroy(childObject);
            gameObject.SetActive(false);
        }
            
	}

    public void ClawTarget(Vector3 pos)
    {
        target = pos;
    }

    public void OnTriggerEnter(Collider other)
    {
        retracting = true;
        target = origin.position;
        if (other.gameObject.CompareTag("jewel"))
        {
            hitJewel = true;
            childObject = other.gameObject;
            other.transform.SetParent(gameObject.transform);
        }
        else if (other.gameObject.CompareTag("rock"))
        {
            childObject = other.gameObject;
            other.transform.SetParent(gameObject.transform);
        }
    }
}

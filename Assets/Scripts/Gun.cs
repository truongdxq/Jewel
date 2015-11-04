using UnityEngine;
using System.Collections;

public class Gun : MonoBehaviour {
    public GameObject claw;
    public bool isShooting;
    public Animator minerAnimator;
    public Claw clawScrip;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Fire1") && !isShooting)
        {
            LauchClaw();
        }

	}
    private void LauchClaw()
    {
        isShooting = true;
        minerAnimator.speed = 0;
        RaycastHit hit;
        Vector3 down = transform.TransformDirection(Vector3.down);
        if (Physics.Raycast(transform.position, down, out hit, 200))
        {
            claw.SetActive(true);
            clawScrip.ClawTarget(hit.point);
        }
    }
    public void CollectedObject()
    {
        isShooting = false;
        minerAnimator.speed = 1;
    }

}

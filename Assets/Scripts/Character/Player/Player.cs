using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof (PlayerController))]
[RequireComponent(typeof(GunController))]
public class Player : LivingEntity {

    public float movespeed = 5f;
    PlayerController controller;
    GunController gunContorller;

    public Crosshairs crosshairs;

    Ray ray;
    public Camera viewCamera;
    Vector3 moveInput,moveVelocity;
    private SpriteRenderer spriteRenderer;
    private void Awake()
    {
        controller = GetComponent<PlayerController>();
        gunContorller = GetComponent<GunController>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        viewCamera = Camera.main;
        FindObjectOfType<Spawner>().OnNewWave += OnNewWave;
    }

    // Use this for initialization
    protected override void Start () {
        base.Start();
    }
	
    public void OnNewWave(int WaveNumber)
    {
        health = startingHealth;
        gunContorller.EquipGun(WaveNumber - 1);
    }

	// Update is called once per frame
	void Update () {
        //Move input
        moveInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        moveVelocity = moveInput.normalized * movespeed;
        controller.Move(moveVelocity);
        ray = viewCamera.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.up*gunContorller.GunHeight);

        if (moveInput.x < 0)             
            spriteRenderer.flipX = true;       
        else if (moveInput.x > 0)
            spriteRenderer.flipX = false;
        //LookAt input
        float rayDistance;
        if(groundPlane.Raycast(ray,out rayDistance))
        {
            Vector3 point = ray.GetPoint(rayDistance);
            // controller.LookAt(point);
            crosshairs.transform.position = point;
            crosshairs.DetectTargets(ray);
            if((new Vector2(point.x, point.z) - new Vector2(transform.position.x, transform.position.z)).magnitude>1){
                gunContorller.Aim(point);
            }
        }

        //Weapon input
        if (Input.GetMouseButton(0))
        {
            gunContorller.OnTriggerHold();
        }
        if (Input.GetMouseButtonUp(0))
        {
            gunContorller.OnTriggerRelease();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            gunContorller.Reload();
        }
        if (transform.position.y < -10f)
        {
            TakeDamage(health);
        }
	}
    public override void Die()
    {
        // AudioManager.instance.PlaySound("Player Death", transform.position);
        base.Die();
    }
}

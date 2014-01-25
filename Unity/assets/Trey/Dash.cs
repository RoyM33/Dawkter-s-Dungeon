﻿using UnityEngine;
using System.Collections;

public class Dash : MonoBehaviour
{

    public bool DisableChaseOnDash = true;
    public Character Target;
    public float DashRange = 12;
    public float BeginDashRange = 6;
    public float DelayBeforeDashInSeconds = .5f;
    public float DashSpeed = 5f;

    private NavMeshAgent _agent;
    private bool DashStarted;
    private bool DashCharging;
    private Vector3 DashLocation;
    private float DashTimeElapsed;

    // Use this for initialization
    void Start()
    {

        _agent = this.GetComponent<NavMeshAgent>();

        if (Target == null)
            Target = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerCharacter>();
    }

    // Update is called once per frame
    void Update()
    {
        if (DashCharging)
        {
            DashTimeElapsed += Time.deltaTime;

            if (DashTimeElapsed > DelayBeforeDashInSeconds)
            {
                DashStarted = true;
                DashCharging = false;


                //_agent.enabled = true;
                //_agent.destination = Target.transform.position + Target.transform.position.normalized * DashRange;
                //_agent.speed = 500;
                //_agent.acceleration = 500;
                //_agent.angularSpeed = 500;
                //_agent.obstacleAvoidanceType = ObstacleAvoidanceType.NoObstacleAvoidance;
            }
        }
        else if (DashStarted)
        {
            DashTimeElapsed += Time.deltaTime;

            this.transform.position = Vector3.Lerp(this.transform.position, DashLocation, Time.deltaTime * DashSpeed);

            if (DashTimeElapsed > 2f)
            {
                Destroy(this.gameObject);
            }
        }
        else
        {
            if (Vector3.Distance(Target.transform.position, this.transform.position) < BeginDashRange)
            {
                DashCharging = true;

                DashLocation = transform.position + (Target.transform.position - transform.position).normalized * DashRange;

                if (DisableChaseOnDash)
                    this.GetComponent<Chase>().enabled = false;

                _agent.enabled = false;
            }
        }

        //_agent.destination = Target.transform.position;	    
    }
}

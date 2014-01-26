using UnityEngine;
using System.Collections;

public class Dash : MonoBehaviour
{

    public bool DisableChaseOnDash = true;
    public Character Target;
    public float DashRange = 12;
    public float BeginDashRange = 6;
    public float DelayBeforeDashInSeconds = .5f;
    public float DashSpeed = 5f;

    public DashState DashState = DashState.NotCloseEnoughToDash;

    private NavMeshAgent _agent;
    private DashState _dashState = DashState.NotCloseEnoughToDash;
    private Vector3 DashLocation;
    private float DashTimeElapsed;

    private static AudioClip _onDashSound;

    // Use this for initialization
    void Start()
    {
        _agent = this.GetComponent<NavMeshAgent>();

        if (Target == null)
            Target = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerCharacter>();
        
        if (_onDashSound == null)
        {
            _onDashSound = Resources.Load<AudioClip>("Sounds/onDash");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (_dashState != DashState.NotCloseEnoughToDash)
            DashTimeElapsed += Time.deltaTime;

        switch (_dashState)
        {
            case DashState.NotCloseEnoughToDash:
                if (Vector3.Distance(Target.transform.position, this.transform.position) < BeginDashRange)
                {
                    DashLocation = transform.position + (Target.transform.position - transform.position).normalized * DashRange;

                    if (DisableChaseOnDash)
                        this.GetComponent<Chase>().enabled = false;

                    _agent.enabled = false;

                    _dashState = DashState.ChargingDash;
                }
                break;


            case DashState.ChargingDash:
                if (DashTimeElapsed > DelayBeforeDashInSeconds)
                {
                    _dashState = DashState.Dashing;
                    audio.PlayOneShot(_onDashSound);
                }
                break;


            case DashState.Dashing:
                this.transform.position = Vector3.Lerp(this.transform.position, DashLocation, Time.deltaTime * DashSpeed);

                if (Vector3.Distance(this.transform.position, DashLocation) < 1f)
                {
                    _dashState = DashState.Dashed;
                    DashTimeElapsed = 0f;
                }
                break;


            case DashState.Dashed:
                if (DashTimeElapsed > .5f)
                {
                    this.gameObject.SetActive(false);
                    Destroy(this.gameObject);
                }
                break;
        }
    }
}

public enum DashState
{
    NotCloseEnoughToDash,
    ChargingDash,
    Dashing,
    Dashed
}
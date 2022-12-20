using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class MoveCheesecake : MonoBehaviour
{
    [SerializeField] private InputActionAsset actionAsset;
    [SerializeField] private XRRayInteractor rayInteractor;
    [SerializeField] private GameObject cheese;
    private NavMeshAgent _nav;
    private bool _isActive;
    private InputAction _activate;

    private void Start()
    {
        _nav = cheese.GetComponent<NavMeshAgent>();
        rayInteractor.enabled = false;
        
        _activate = actionAsset.FindActionMap("XRI RightHand").FindAction("Move");
        _activate.Enable();
        _activate.performed += OnMoveButton;
    }
    private void Update()
    {
        if (!_isActive)
            return;
        
        if (!rayInteractor.TryGetCurrent3DRaycastHit(out RaycastHit hit))
        {
            rayInteractor.enabled = false;
            _isActive = false;
            return;
        }
        Debug.DrawRay(transform.position, transform.forward, Color.green);
        _nav.SetDestination(hit.point);

        rayInteractor.enabled = false;
        _isActive = false;
    }
    
    private void OnDestroy()
    {
        _activate.performed -= OnMoveButton;
    }
    private void OnMoveButton(InputAction.CallbackContext context)
    {
        rayInteractor.enabled = true;
        _isActive = true;
    }
}

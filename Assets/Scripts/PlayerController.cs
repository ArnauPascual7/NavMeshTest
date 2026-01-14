using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(PlayerInputs), typeof(NavMeshAgent))]
public class PlayerController : MonoBehaviour
{
    private Camera _camera;
    private NavMeshAgent _navAgent;
    private PlayerInputs _playerInputs;

    private void Awake()
    {
        _camera = Camera.main;
        _playerInputs = GetComponent<PlayerInputs>();
        _navAgent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (_playerInputs.ClickPressed)
        {
            Ray ray = _camera.ScreenPointToRay(_playerInputs.MousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                _navAgent.SetDestination(hit.point);
            }
        }
    }
}
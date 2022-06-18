using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Mirror;

public class VehiclesMovementController : NetworkBehaviour 
{
    private NavMeshAgent navAgent;
    private NavMeshAgent NavAgent
    {
        get
        {
            if (navAgent == null)
                navAgent = GetComponent<NavMeshAgent>();
            return navAgent;
        }
    }

    #region Commands To Server
    [Command]
    private void CmdMoveMeToPosIfValid(Vector3 targetPos)
    {
        Debug.Log("CMD");
        NavAgent.SamplePathPosition(NavMesh.AllAreas, 1.0F, out NavMeshHit meshHit);
        NavAgent.SetDestination(targetPos);
    }
    #endregion

    [ClientCallback]
    private void Update()
    {
        if (!hasAuthority)
            return;

        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("mouse down");
            Ray ray = SingletonLinker.Instance.GetCamera.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray,out RaycastHit hit, Mathf.Infinity))
            {
                CmdMoveMeToPosIfValid(hit.point);
            }
        }
    }
}

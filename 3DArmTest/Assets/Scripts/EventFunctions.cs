using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventFunctions : MonoBehaviour
{
    private ArmBehaviour armBehaviour;

    private void Awake()
    {
        armBehaviour = transform.GetComponentInParent<ArmBehaviour>();
    }

    public void StartFirstStage()
    {
        armBehaviour.TriggerMoveStageOne();
    }

    public void StartSecondStage()
    {
        armBehaviour.TriggerMoveStageTwo();
    }

    public void StartThirdStage()
    {
        armBehaviour.TriggerMoveStageThree();
    }

    public void GrabAndRelease()
    {
        armBehaviour.GrabAndRelease();
    }
}

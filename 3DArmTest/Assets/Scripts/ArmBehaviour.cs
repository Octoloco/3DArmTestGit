using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmBehaviour : MonoBehaviour
{
    [SerializeField]
    private bool testButton = false;

    [SerializeField]
    private bool armActive = false;
    [SerializeField]
    private Animator firstJointAnimator;
    [SerializeField]
    private Animator secondJointAnimator;
    [SerializeField]
    private Animator thirdJointAnimator;
    [SerializeField]
    private Animator palmAnimator;
    [SerializeField]
    private Animator fingersAnimator;
    [SerializeField]
    private Animator firstKnuckleAnimator;
    [SerializeField]
    private Animator secondKnuckleAnimator;
    [SerializeField]
    private Animator wristAnimator;
    [SerializeField]
    private Animator finger1Animator;
    [SerializeField]
    private Animator finger2Animator;
    [SerializeField]
    private Animator finger3Animator;
    [SerializeField]
    private Transform palmAnchor;
    [SerializeField]
    private Toyspawner toyspawner;

    private Transform grabbedObject;

    private void Update()
    {
        if (testButton)
        {
            testButton = false;
            ArmActiveSwitch();
        }
    }

    public void TriggerMoveStageOne()
    {
        firstJointAnimator.SetTrigger("move");
        secondJointAnimator.SetTrigger("move");
        thirdJointAnimator.SetTrigger("move");
        palmAnimator.SetTrigger("move");
        fingersAnimator.SetTrigger("move");
    }

    public void TriggerMoveStageTwo()
    {
        firstKnuckleAnimator.SetTrigger("move");
        secondKnuckleAnimator.SetTrigger("move");
        wristAnimator.SetTrigger("move");
    }

    public void TriggerMoveStageThree()
    {
        finger1Animator.SetTrigger("move");
        finger2Animator.SetTrigger("move");
        finger3Animator.SetTrigger("move");
    }

    public void ArmActiveSwitch()
    {
        if (!armActive)
        {
            armActive = true;
            firstJointAnimator.SetBool("armActive", true);
            secondJointAnimator.SetBool("armActive", true);
            thirdJointAnimator.SetBool("armActive", true);
            palmAnimator.SetBool("armActive", true);
            fingersAnimator.SetBool("armActive", true);
        }
        else
        {
            armActive = false;

            firstJointAnimator.SetBool("armActive", false);
            secondJointAnimator.SetBool("armActive", false);
            thirdJointAnimator.SetBool("armActive", false);
            palmAnimator.SetBool("armActive", false);
            fingersAnimator.SetBool("armActive", false);
        }
    }

    public void GrabAndRelease()
    {
        if (grabbedObject != null)
        {
            grabbedObject.SetParent(null);
            grabbedObject.GetComponent<Rigidbody>().useGravity = true;
            grabbedObject = null;
        }
        else
        {
            Collider[] grabbedObjects = Physics.OverlapSphere(palmAnchor.transform.position, .5f);
            foreach (Collider c in grabbedObjects)
            {
                if (c.CompareTag("Toy"))
                {
                    grabbedObject = c.transform;
                    grabbedObject.GetComponent<Rigidbody>().useGravity = false;
                    grabbedObject.SetParent(palmAnchor);
                }
            }
        }
    }

    public void SpawnNewToy()
    {
        toyspawner.PositionRandomToy();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmBehaviour : MonoBehaviour
{
    [SerializeField]
    private Material onMaterial;
    [SerializeField]
    private Material offMaterial;
    [SerializeField]
    private Renderer buttonRenderer;
    [SerializeField]
    private Renderer screenRenderer;
    [SerializeField]
    private AudioSource buttonSound;
    [SerializeField]
    private AudioSource armSound;

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

    [SerializeField]
    private Transform grabbedObject;

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
            buttonSound.Play();
            buttonRenderer.material = offMaterial;
            screenRenderer.material = onMaterial;
            armActive = true;
            firstJointAnimator.SetBool("armActive", true);
            secondJointAnimator.SetBool("armActive", true);
            thirdJointAnimator.SetBool("armActive", true);
            palmAnimator.SetBool("armActive", true);
            fingersAnimator.SetBool("armActive", true);
        }
        else
        {
            buttonSound.Play();
            buttonRenderer.material = onMaterial;
            screenRenderer.material = offMaterial;
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
            grabbedObject.GetComponent<Rigidbody>().isKinematic = false;
            grabbedObject = null;
        }
        else
        {
           
            Collider[] grabbedObjects = Physics.OverlapSphere(palmAnchor.transform.position, 1f);
            foreach (Collider c in grabbedObjects)
            {
                if (c.CompareTag("Toy"))
                {
                    
                    grabbedObject = c.transform;
                    grabbedObject.GetComponent<Rigidbody>().isKinematic = true;
                    grabbedObject.SetParent(palmAnchor);
                }
            }
        }
    }

    public void SpawnNewToy()
    {
        toyspawner.PositionRandomToy();
    }

    public void PlayArmSound()
    {
        armSound.Play();
    }
}

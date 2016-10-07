using UnityEngine;
using System.Collections;

public class DoorActivator : MonoBehaviour
{
  public Animator[] lights;
  private Animator animator;

  void Awake()
  {
    print("waking up");
    animator = gameObject.GetComponent<Animator>();
    print(animator);
  }

  void OnMouseEnter()
  {
    print(animator);
    animator.SetBool("Open", true);
    foreach (var light in lights)
    {
      light.SetTrigger("Activate");
    }
  }

  void OnMouseExit()
  {
    animator.SetBool("Open", false);
  }
}

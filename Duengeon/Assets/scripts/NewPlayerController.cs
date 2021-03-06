using UnityEngine;
using System.Collections;

public class NewPlayerController : MonoBehaviour
{
    public Animator animator;
    public CharacterController controller;


	public float speed = 3f;
	public float rotateSpeed = 180f;
    private Vector3 offset;
    

    // Use this for initialization
    void Start()
	{
         Vector3 offset = Vector3.zero;
	}

    //Update is called once per frame

    void Update()
	{
		float v = Input.GetAxis("Vertical");
		float h = Input.GetAxis("Horizontal");
		
	
		

		if (controller.isGrounded)
		{
			if (v != 0)
			{
				offset = transform.forward * v * speed * Time.deltaTime;
                animator.SetBool("walk", true);
            }
			else
			{
                animator.SetBool("walk", false);
            }
			
			
		
			
		}
		offset += Physics.gravity * Time.deltaTime;
		
		controller.Move(offset);
		
	}

	void damage()
	{
		//TODO
	}
}

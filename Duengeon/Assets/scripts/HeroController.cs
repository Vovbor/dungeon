
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class HeroController : MonoBehaviour
{

	public CharacterController controller;
	
	
	public float speed = 50f;
	public float wait = 10f;
	public float rotateSpeed = 180f;
	public float minY = -90f;
	public float maxY = 80f;
	private float currentY;
	public Camera cam;
	public Rigidbody rb;
	public Animator an;

	
	// Use this for initialization
	void Start()
	{
		currentY = cam.transform.rotation.eulerAngles.x;
	


	}

	// Update is called once per frame
	void Update()
	{
		

		float v = Input.GetAxis("Vertical");
		float h = Input.GetAxis("Horizontal");
		float x = Input.GetAxis("Mouse X");
		float y = Input.GetAxis("Mouse Y");
		Vector3 offset = Vector3.zero;
		Vector3 offset2 = Vector3.zero;


		RaycastHit hit;
		Ray ray = cam.ScreenPointToRay(Input.mousePosition);

		if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit))
		{
			if (hit.collider.tag == "Enemy")
			{
				hit.transform.gameObject.SendMessage("hit");
			}
		}



		if (controller.isGrounded)
		{
			if (v != 0)
			{
				offset = transform.forward * v * speed * Time.deltaTime;

			}
			if (h != 0)
			{
				offset2 = transform.right * h * speed * Time.deltaTime;

			}
			if (x != 0)
			{
				transform.Rotate(transform.up * x * rotateSpeed * Time.deltaTime);
			}
			if (y != 0)
			{
				currentY = Mathf.Clamp(currentY - y * rotateSpeed * Time.deltaTime, minY, maxY);
				Vector3 camRot = cam.transform.rotation.eulerAngles;
				cam.transform.rotation = Quaternion.Euler(currentY, camRot.y, camRot.z);
			}
			


		}
   //     if (Input.GetMouseButton(0))
   //     {
			//an.SetBool("attack", true);
			//Invoke("attack", 0.3f);
   //     }
		
		offset += Physics.gravity * Time.deltaTime;
		offset2 += Physics.gravity * Time.deltaTime;
		controller.Move(offset);
		controller.Move(offset2);
		
	}
	private void OnCollisionEnter(Collision other)
	{
		
	}
	//void attack()
 //   {
	//	an.SetBool("attack", false);
	//}
	void OnTriggerStay(Collider other)
	{

		if (other.gameObject.tag == "Ground")
		{
			SceneManager.LoadScene("1");
			
		}
	}

}
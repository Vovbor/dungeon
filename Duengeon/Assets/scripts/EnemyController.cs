using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class EnemyController : MonoBehaviour
{
	public bool selected = false; 
	public UnityEngine.AI.NavMeshAgent agent;
	public Animator animator;
	private Transform player;
		public Material[] material;
	public Renderer[] rend;

	// Use this for initialization
	void Start()
	{
		player = GameObject.FindGameObjectWithTag("Player").transform;
		//go_list[i].GetComponent<EnemyController>().Send();
		StartCoroutine(findPath());
		StartCoroutine(detectPlayer());

        for (int i = 0; i < 17; i++)
        {
           rend[i].enabled = true;
		   rend[i].sharedMaterial = material[0];
        }
		
        
		
	}
	
	IEnumerator detectPlayer()
	{
		while (true)
		{
			if (player == null) break;
			if (Vector3.Distance(transform.position, player.position) < 1f)
			{
				attack();
				break;
				
			}
			yield return new WaitForSeconds(.5f);
		}
	}

	IEnumerator findPath()
	{
		while (true)
		{
			if (player != null)
				agent.SetDestination(player.position);
			else break;
			yield return new WaitForSeconds(2f);
		}
            
	}

	public void damage()
	{
        animator.SetTrigger("dead");
        Destroy(gameObject, 0.5f);
        enabled = false; 
    }

	void attack()
	{
		animator.SetBool("attack", true);
		player.gameObject.BroadcastMessage("damage");
	}
	void hit()
    {
		EnemyController[] enemy_controller_list = FindObjectsOfType<EnemyController>();

        foreach (EnemyController ec in enemy_controller_list)
        {
			ec.selected = false;
		}

        if (selected)
        {
            for (int i = 0; i < 17; i++)
            {
             rend[i].sharedMaterial = material[1];
            }
           
        }
		if (Vector3.Distance(transform.position, player.position) < 13f)
		{
			selected = true;
		}
		
		
        

    }
	void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
			GameObject[] Monsters = GameObject.FindGameObjectsWithTag("Enemy");
            foreach (GameObject go in Monsters)
            {
				go.SendMessage("SwordHit");

			}
		}
       

		if (!selected)
		{
			for (int i = 0; i < 17; i++)
			{
				rend[i].sharedMaterial = material[0];
			}
		}
		else
		{
			for (int i = 0; i < 17; i++)
			{
				rend[i].sharedMaterial = material[1];
			}
		}
		if (Vector3.Distance(transform.position, player.position) > 14f)
		  {
			for (int i = 0; i < 17; i++)
			{
				rend[i].sharedMaterial = material[0];
			}
			selected = false;
		  }
       
		
    }
	void SwordHit()
    {
        if (selected)
        {
			damage();
        }
    }




}
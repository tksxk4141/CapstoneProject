using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SojaExiles

{

	public class Drawer_Pull_X : MonoBehaviour
	{
		public Animator pull_01;
		public bool open;
		//public Transform Player;
		public Transform[] Players = new Transform[2];
		void Start()
		{
			open = false;
		}
		void Update()
		{
			Players[0] = GameObject.Find("SceneManager").GetComponent<cshSceneManager>().Player[0].transform;
			Players[1] = GameObject.Find("SceneManager").GetComponent<cshSceneManager>().Player[1].transform;
		}
		void OnMouseOver()
		{
			{
				for (int i = 0; i < Players.Length; i++)
				{
					if (Players[i])
					{
						float dist = Vector3.Distance(Players[i].position, transform.position);
						if (dist < 10)
						{
							print("object name");
							if (open == false)
							{
								if (Input.GetMouseButtonDown(0))
								{
									StartCoroutine(opening());
								}
							}
							else
							{
								if (open == true)
								{
									if (Input.GetMouseButtonDown(0))
									{
										StartCoroutine(closing());
									}
								}
							}
						}
					}
				}
			}
		}

		IEnumerator opening()
		{
			print("you are opening the door");
			pull_01.Play("openpull_01");
			open = true;
			yield return new WaitForSeconds(.5f);
		}

		IEnumerator closing()
		{
			print("you are closing the door");
			pull_01.Play("closepush_01");
			open = false;
			yield return new WaitForSeconds(.5f);
		}


	}
}
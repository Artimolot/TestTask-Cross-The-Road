using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
	public GameObject prefab;
	public  Queue<Enemy> enemys = new Queue<Enemy>();
	private int countEnemys = 20;
	private float line =  2;
	private float distance = 2;


	private void Start()
	{
		for(int i = 0; i < countEnemys; i++)
		{
			GameObject obj;
			if (line % 2 == 0)
			{
				obj = Instantiate(prefab, new Vector3(transform.position.x + distance, transform.position.y, Random.Range(15, 30)), Quaternion.identity);
				obj.GetComponent<Enemy>().onRight = true;
				line++;
			}
			else
			{
				obj = Instantiate(prefab, new Vector3(transform.position.x + distance, transform.position.y, Random.Range(-15, -30)), Quaternion.identity);
				obj.GetComponent<Enemy>().onRight = false;
				line++;
			}
			distance += 2;
			enemys.Enqueue(obj.GetComponent<Enemy>());
		}
	}

	private void Update()
	{
		if (!enemys.Peek().GetComponent<Renderer>().IsVisibleFrom(Camera.main) && Camera.main.transform.position.x > enemys.Peek().transform.position.x + 5f)
		{
			ResetObject(enemys.Dequeue());
		}
		foreach (Enemy enemy in enemys)
		{
			if(enemy.GetComponent<Enemy>().onRight == true)
			{
				enemy.transform.position = new Vector3(enemy.transform.position.x, enemy.transform.position.y, enemy.transform.position.z + enemy.GetComponent<Enemy>().speed * Time.deltaTime);
				if (enemy.transform.position.z < -10)
				{
					ResetLineObject(enemy);
				}
			}
			else
			{ 
				enemy.transform.position = new Vector3(enemy.transform.position.x, enemy.transform.position.y, enemy.transform.position.z - enemy.GetComponent<Enemy>().speed * Time.deltaTime);
				if (enemy.transform.position.z > 20)
				{
					ResetLineObject(enemy);
				}
			}
		}
	}

	private void ResetObject(Enemy obj)
	{
		if(obj.GetComponent<Enemy>().onRight == true)
		{
			obj.transform.position = new Vector3(obj.transform.position.x + distance, obj.transform.position.y, Random.Range(15, 30));
		}
		else
		{
			obj.transform.position = new Vector3(obj.transform.position.x + distance, obj.transform.position.y, Random.Range(-15, -30));
		}
		obj.GetComponent<Enemy>().speed -= 5f;
		enemys.Enqueue(obj);
		line++;
		distance += 2;
	}

	private void ResetLineObject(Enemy obj)
	{
		if(obj.GetComponent<Enemy>().onRight == true)
		{
			obj.transform.position = new Vector3(obj.transform.position.x, obj.transform.position.y, Random.Range(15, 30));
		}
		else
		{
			obj.transform.position = new Vector3(obj.transform.position.x, obj.transform.position.y, Random.Range(-15, -30));
		}
	}
}

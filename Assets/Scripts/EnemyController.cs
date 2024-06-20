using System.Collections;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float health;
    public float absorbSpeed = 3f;
    public GameObject player;
    public Transform myBody;

    private void OnEnable()
    {
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }
    }

    private void OnDisable()
    {
        health = 100;
    }

    public void TakeDamage(int damageValue)
    {
        if(health > 0)
        {
            health -= damageValue;
        }
        else
        {
            transform.position += Vector3.up * 4;
            GetComponent<Collider>().isTrigger = true;
            StartCoroutine(AbsorbByPlayer());  
        }
    }

    public IEnumerator AbsorbByPlayer()
    {
        while (Vector3.Distance(myBody.position, player.transform.position) > 0.2f)
        {
            Vector3 moveDirection = (player.transform.position - myBody.position).normalized;
            transform.position += moveDirection * absorbSpeed * Time.deltaTime;
            
            if (Vector3.Distance(myBody.position, player.transform.position) <= 0.2f)
            {
                gameObject.SetActive(false);
            }
            yield return null;
        }   
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    private float damage;
    public GameObject effectPrefab;

    public void SetDamage(float damage_)
    {
        damage = damage_;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            GameObject effect = Instantiate(effectPrefab, transform.position, Quaternion.identity);
            Destroy(effect, 0.35f);
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "Enemy")
        {
            GameObject effect = Instantiate(effectPrefab, transform.position, Quaternion.identity);
            Destroy(effect, 0.35f);
            collision.gameObject.GetComponent<EnemyController>().ReduceHealth(damage);
            Destroy(gameObject);
        }
    }
}

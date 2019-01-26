using UnityEngine;
using UnityEngine.UI;

public class FortController : MonoBehaviour
{
    public int Health = 1000;
    private GameObject slider;
    // Start is called before the first frame update
    void Start()
    {
        slider = GameObject.Find("HealthSlider");
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            var damage = collision.gameObject.GetComponent<EnemyController>().Damage;
            Health -= damage;
            slider.GetComponent<Slider>().value = Health;
        }
    }
}

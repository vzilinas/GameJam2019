using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FortController : MonoBehaviour
{
    public int Health = 250;
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

        if (Health <= 0)
        {
            // LoseScene
            SceneManager.LoadScene(2);
        }
    }
}

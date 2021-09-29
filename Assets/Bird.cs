using UnityEngine;
using UnityEngine.SceneManagement;

public class Bird : MonoBehaviour {

    Vector3 _initialPosition;
    [SerializeField] private float _launchscale =500 ;

    private bool _birdWasLaunch;
    private float timeSittingAround;

    private void Awake () {
        _initialPosition = transform.position;

    }

    private void Update()
    {
        GetComponent<LineRenderer>().SetPosition(1, _initialPosition);
        GetComponent<LineRenderer>().SetPosition(0, transform.position);


        if (_birdWasLaunch && 
            GetComponent<Rigidbody2D>().velocity.magnitude <=0.1)
        {
            timeSittingAround += Time.deltaTime;
        }
        if (transform.position.y > 10 || transform.position.x > 14 || transform.position.y < -10 || transform.position.x < -20 || timeSittingAround > 3)
        {   

            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    private void OnMouseDown () {
        GetComponent<SpriteRenderer> ().color = Color.red;
        GetComponent<LineRenderer>().enabled = true;
    }

    private void OnMouseUp () {
        GetComponent<SpriteRenderer> ().color = Color.white;
        Vector2 directonToInitialPosition = _initialPosition - transform.position;
        GetComponent<Rigidbody2D>().AddForce(directonToInitialPosition * _launchscale);
        GetComponent<Rigidbody2D>().gravityScale = 1;
        _birdWasLaunch = true;
        GetComponent<LineRenderer>().enabled = false;


    }

    private void OnMouseDrag () {
        Vector3 newPosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);
        transform.position = new Vector3 (newPosition.x, newPosition.y);
    }

}
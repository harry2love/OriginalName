using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public Material upMat;
    public Material baseMat;
    public Material abilityActiveMat;

    private Rigidbody player;

    private float boundry = 80;
    private float yBoundry = 10;
    private float force = 8;
    private float reducedForce = 4;
    private float upwardForce = 20;

    private bool isGrounded = true;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D) && isGrounded)
        {
            player.AddForce(new Vector3(force, 0, 0));
        }
        if (Input.GetKey(KeyCode.Q) && isGrounded)
        {
            player.AddForce(new Vector3(-force, 0, 0));
        }
        if (Input.GetKey(KeyCode.Z) && isGrounded)
        {
            player.AddForce(new Vector3(0, 0, force));
        }
        if (Input.GetKey(KeyCode.S) && isGrounded)
        {
            player.AddForce(new Vector3(0, 0, -force));
        }
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            player.AddForce(new Vector3(0, upwardForce, 0), ForceMode.Impulse);
            isGrounded = false;
        }

        if (Input.GetKey(KeyCode.D) && !isGrounded)
        {
            player.AddForce(new Vector3(reducedForce, 0, 0));
        }
        if (Input.GetKey(KeyCode.Q) && !isGrounded)
        {
            player.AddForce(new Vector3(-reducedForce, 0, 0));
        }
        if (Input.GetKey(KeyCode.Z) && !isGrounded)
        {
            player.AddForce(new Vector3(0, 0, reducedForce));
        }
        if (Input.GetKey(KeyCode.S) && !isGrounded)
        {
            player.AddForce(new Vector3(0, 0, -reducedForce));
        }

        if(player.transform.position.y < -yBoundry || player.transform.position.x > boundry || player.transform.position.x < -boundry || player.transform.position.z > boundry || player.transform.position.z < -boundry)
        {
            SceneManager.LoadScene("Scene1");
        }


        if (isGrounded && !gameObject.GetComponent<PlayerAbilities>().abilityIsActive)
        {
            GameObject.Find("Player").GetComponent<MeshRenderer>().material = baseMat;
        }
        else if(!isGrounded && !gameObject.GetComponent<PlayerAbilities>().abilityIsActive)
        {
            GameObject.Find("Player").GetComponent<MeshRenderer>().material = upMat;
        }
        else if (!isGrounded && gameObject.GetComponent<PlayerAbilities>().abilityIsActive || isGrounded && gameObject.GetComponent<PlayerAbilities>().abilityIsActive)
        {
            player.GetComponent<MeshRenderer>().material = abilityActiveMat;
        }
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Floor")
        {
            isGrounded = true;
        }
        if(collision.gameObject.tag == "enemy")
        {
            GameObject.Find("GameManager").GetComponent<ScoreManager>().DeductScore(10);
        }
    }
}

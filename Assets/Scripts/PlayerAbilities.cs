using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAbilities : MonoBehaviour
{

    private Vector3 worldPos;
    private Rigidbody player;

    public GameObject ability1;
    public GameObject ability2;
    public GameObject ability2Marker;
    public GameObject ability3;

    private float cooldown = 8;
    private float cooldown2 = 4;
    public float ability2Wait = 2;

    private float cooldown3 = 10;
    private float activeTime3 = 3;
    private float cooldown4 = 5;
    private float activeTime4 = 5;

    public int health = 5;

    private bool isOnCooldown = false;
    private bool isOnCooldown2 = false;
    private bool isOnCooldown3 = false;
    private bool isOnCooldown4 = false;

    public bool disableHits = false;
    public bool abilityIsActive = false;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Mouse0) && !abilityIsActive && !isOnCooldown)
        {
            Instantiate(ability1, new Vector3(transform.position.x, 0.5f, transform.position.z), transform.rotation);
            abilityIsActive = true;
            isOnCooldown = true;
            StartCoroutine(AbilityActivity());
        }

        if(Input.GetKeyDown(KeyCode.Mouse1) && !isOnCooldown2)
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = Camera.main.transform.position.y;
            worldPos = Camera.main.ScreenToWorldPoint(mousePos);
            Instantiate(ability2Marker, new Vector3(worldPos.x, 0.5f, worldPos.z), transform.rotation);
            isOnCooldown2 = true;
            StartCoroutine(AbilityActivity2());
        }

        if (Input.GetKeyDown(KeyCode.LeftShift) && !abilityIsActive && !isOnCooldown3)
        {
            isOnCooldown3 = true;
            StartCoroutine(AbilityActivity3());
        }

        if(Input.GetKeyDown(KeyCode.E) && !isOnCooldown4)
        {
            isOnCooldown4 = true;
            StartCoroutine(AbilityActivity4());
        }



    }

    public void CooldownRemover()
    {
        abilityIsActive = false;
    }

    IEnumerator AbilityActivity()
    {
        GameObject.Find("GameManager").GetComponent<ScoreManager>().DeclareAbility(ScoreManager.activeAbility.Spin);
        yield return new WaitForSeconds(cooldown);
        isOnCooldown = false;
    }

    IEnumerator AbilityActivity2()
    {
        GameObject.Find("GameManager").GetComponent<ScoreManager>().DeclareBomb();
        yield return new WaitForSeconds(ability2Wait);
        Instantiate(ability2, new Vector3(worldPos.x, 0.5f, worldPos.z), transform.rotation);
        yield return new WaitForSeconds(cooldown2);
        isOnCooldown2 = false;
    }
    
    IEnumerator AbilityActivity3()
    {
        GameObject.Find("GameManager").GetComponent<ScoreManager>().DeclareAbility(ScoreManager.activeAbility.Explosion);
        player.constraints = RigidbodyConstraints.FreezeAll;
        yield return new WaitForSeconds(activeTime3);
        Instantiate(ability3, transform.position, transform.rotation);
        yield return new WaitForSeconds(activeTime3);
        player.constraints = ~RigidbodyConstraints.FreezePosition;
        yield return new WaitForSeconds(cooldown3);
        isOnCooldown = false;
    }

    IEnumerator AbilityActivity4()
    {
        GameObject.Find("GameManager").GetComponent<ScoreManager>().DeclareFortify();
        disableHits = true;
        yield return new WaitForSeconds(activeTime4);
        GameObject.Find("GameManager").GetComponent<ScoreManager>().RemoveFortify();
        disableHits = false;
        yield return new WaitForSeconds(cooldown4);
        isOnCooldown4 = false;
    }
}
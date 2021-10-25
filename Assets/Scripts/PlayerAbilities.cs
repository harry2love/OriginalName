using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAbilities : MonoBehaviour
{
    private Rigidbody player;

    public GameObject ability1;
    public GameObject ability2;

    private float cooldown = 8;
    private float cooldown2 = 4;
    private float cooldown3 = 10;
    private float activeTime3 = 5;

    private bool isOnCooldown = false;
    private bool isOnCooldown2 = false;
    private bool isOnCooldown3 = false;
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

        if(Input.GetKeyDown(KeyCode.Mouse1) && !abilityIsActive && !isOnCooldown2)
        {
            Instantiate(ability2, new Vector3(transform.position.x, 0.5f, transform.position.z), transform.rotation);
            abilityIsActive = true;
            isOnCooldown2 = true;
            StartCoroutine(AbilityActivity2());
        }

        if (Input.GetKeyDown(KeyCode.LeftShift) && !isOnCooldown3)
        {

            isOnCooldown3 = true;
            StartCoroutine(AbilityActivity3());
        }

        
    }

    public void CooldownRemover()
    {
        abilityIsActive = false;
    }

    IEnumerator AbilityActivity()
    {
        yield return new WaitForSeconds(cooldown);
        isOnCooldown = false;
    }

    IEnumerator AbilityActivity2()
    {
        yield return new WaitForSeconds(cooldown2);
        isOnCooldown2 = false;
    }
    
    IEnumerator AbilityActivity3()
    {
        player.constraints = RigidbodyConstraints.FreezeAll;
        yield return new WaitForSeconds(activeTime3);
        player.constraints = ~RigidbodyConstraints.FreezePosition;
        yield return new WaitForSeconds(cooldown3);
        isOnCooldown = false;
    }
}

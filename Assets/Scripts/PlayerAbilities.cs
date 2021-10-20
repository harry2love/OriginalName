using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAbilities : MonoBehaviour
{
    public GameObject ability1;
    public GameObject ability2;

    private float cooldown = 8;
    private float cooldown2 = 4;

    private bool isOnCooldown = false;
    private bool isOnCooldown2 = false;
    private bool isOnCooldown3 = false;
    private bool abilityIsActive = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && !abilityIsActive && !isOnCooldown)
        {
            Instantiate(ability1, transform.position, transform.rotation);
            abilityIsActive = true;
            isOnCooldown = true;
            StartCoroutine(AbilityActivity());
        }

        if(Input.GetKeyDown(KeyCode.Mouse1) && !abilityIsActive && !isOnCooldown2)
        {
            Instantiate(ability2, transform.position, transform.rotation);
            abilityIsActive = true;
            isOnCooldown2 = true;
            StartCoroutine(AbilityActivity2());
        }

        if (Input.GetKeyDown(KeyCode.F))
        {

            isOnCooldown3 = true;
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
}

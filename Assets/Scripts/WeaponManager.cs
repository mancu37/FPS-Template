using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour {

    public int selectedWeapon = 0;
    public int previousSelectedWeapon;

    public Animator animator;
    public float weaponNextFireRate = 0f;
    public float weaponFireRate = 15f;
    public ParticleSystem muzzeflash;

    [SerializeField]
    public Weapon[] weapons;

    // Use this for initialization
    void Start () {
        SelectWeapon();
	}

    private void SelectWeapon()
    {
        int i = 0;
        foreach (Transform weapon in transform)
        {
            if (i == selectedWeapon)
            {
                weapon.gameObject.SetActive(true);
                animator = weapon.GetComponent<Animator>();
            }
            else
            {
                weapon.gameObject.SetActive(false);
            }

            i++;
        }
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetButton("Fire2"))
        {
            
            animator.SetBool("Aim", true);
        }
        else
        {
            animator.SetBool("Aim", false);
        }

        if (Input.GetButton("Fire1") && weapons[selectedWeapon].Type == Weapon.TypeEnum.Automatic)
        {

            animator.SetBool("Shoot", true);

            if (Time.time >= weapons[selectedWeapon].WeaponNextFireRate)
            {
                

                weapons[selectedWeapon].WeaponNextFireRate = Time.time + 1f / weapons[selectedWeapon].WeaponFireRate;

                weapons[selectedWeapon].Muzzeflash.Play();

                
            }
        }

        if (Input.GetButtonDown("Fire1") && weapons[selectedWeapon].Type == Weapon.TypeEnum.Manual)
        {

            

            if (Time.time >= weapons[selectedWeapon].WeaponNextFireRate)
            {
                animator.SetBool("Shoot", true);

                weapons[selectedWeapon].WeaponNextFireRate = Time.time + weapons[selectedWeapon].WeaponFireRate;

                weapons[selectedWeapon].Muzzeflash.Play();


            }
        }

        if (!Input.GetButton("Fire1") || !Input.GetButtonDown("Fire1"))
        {
            animator.SetBool("Shoot", false);
        }


        previousSelectedWeapon = selectedWeapon;

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            selectedWeapon = 0;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            selectedWeapon = 1;
        }

        if (previousSelectedWeapon != selectedWeapon)
            SelectWeapon();
    }
}

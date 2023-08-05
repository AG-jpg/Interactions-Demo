using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animations : MonoBehaviour
{
    private Animator anim;
    private Movement pm;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        pm = GetComponent<Movement>();
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    void Update()
    {
        if (pm.Moving)
        {
            anim.SetFloat("X", pm.DireccionMovimiento.x);
            anim.SetFloat("Y", pm.DireccionMovimiento.y);
        }
    }
}

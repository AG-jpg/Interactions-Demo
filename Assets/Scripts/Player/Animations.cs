using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animations : MonoBehaviour
{
    [SerializeField] private string layerIdle;
    [SerializeField] private string layerWalk;

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
        UpdateLayer();
        
        if (pm.Moving)
        {
            anim.SetFloat("X", pm.DireccionMovimiento.x);
            anim.SetFloat("Y", pm.DireccionMovimiento.y);
        }
    }

    private void ActiveLayer(string layerName)
    {
        for (int i = 0; i < anim.layerCount; i++)
        {
            anim.SetLayerWeight(i, 0);
        }

        anim.SetLayerWeight(anim.GetLayerIndex(layerName), 1);
    }

    private void UpdateLayer()
    {
        if(pm.Moving)
        {
            ActiveLayer(layerWalk);
        }
        else
        {
            ActiveLayer(layerIdle);
        }
    }
}

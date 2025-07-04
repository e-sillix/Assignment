using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurgerInstance : MonoBehaviour
{
    [SerializeField] private GameObject AnimationBurger;
    public void BugerConsumed()
    {
        Instantiate(AnimationBurger, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}

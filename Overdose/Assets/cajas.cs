using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cajas : MonoBehaviour
{
    private bool empujaIdle, empujaMov, push, pull;
    public bool trig;
    private BoxCollider2D boxCollider2d;
    private Transform obj;
    private Rigidbody2D rb2d;
    public float pushSpeed;

    private void Start()
    {
        trig = false;
        obj = GetComponent<Transform>();
        rb2d = transform.GetComponent<Rigidbody2D>();
        boxCollider2d = transform.GetComponent<BoxCollider2D>();
    }
    

    void chooseSide(Collision2D p)
    {

        float High = boxCollider2d.size.y / 2;
        float CenterY = boxCollider2d.transform.position.y;
        float pies = CenterY - High;
        float pYMax = p.transform.position.y + p.collider.bounds.size.y / 2.2f;

        float CenterX = boxCollider2d.transform.position.x;

        if ((CenterX > p.collider.transform.position.x)) //&& p.collider.CompareTag("caja")
        {
            if (Input.GetKey(KeyCode.D)) { pull = true; push = false; }

            else if (Input.GetKey(KeyCode.A)) { pull = false; push = true; }

            else { pull = false; push = false; }

        }
        else if ((CenterX < p.collider.transform.position.x)) // && p.collider.CompareTag("caja")
        {
            if (Input.GetKey(KeyCode.D)) { pull = false; push = true; }

            else if (Input.GetKey(KeyCode.A)) { pull = true; push = false; }

            else { pull = false; push = false; }

        }
        else { pull = false; push = false; }

    }

    private void OnTriggerExit2D(Collider2D obj)
    {

        if (obj.CompareTag("caja"))
        {
            empujaIdle = false;
            empujaMov = false;
            push = false;
            pull = false;
            obj.attachedRigidbody.velocity = new Vector2(0f, obj.attachedRigidbody.velocity.y);
            trig = false;

        }
    }


    private void OnCollisionStay2D(Collision2D obj)
    {
        float Center = boxCollider2d.transform.position.y;
        float High = boxCollider2d.size.y / 2;
        float Foots = Center - High + 2;

        float platformMiddle = obj.collider.transform.position.y;
        float platformMidTop = obj.collider.bounds.size.y / 2;
        float platformTop = platformMiddle + platformMidTop - 2;

        if (platformTop > Foots)
        {
            if (obj.collider.CompareTag("caja"))
            {
                chooseSide(obj);    //Desde donde estas interactuando con el objeto
                if (Input.GetKeyDown(KeyCode.E) && !empujaIdle)
                {
                    empujaIdle = true;
                }
                else if (Input.GetKeyDown(KeyCode.E) && empujaIdle)
                {
                    empujaIdle = false;
                }

                //Empujar//
                if (Input.GetKey(KeyCode.D) && empujaIdle)
                {
                    empujaMov = true;

                    obj.rigidbody.velocity = new Vector2(pushSpeed, obj.rigidbody.velocity.y);
                   
                }
                //Tirar//
                else if (Input.GetKey(KeyCode.A) && empujaIdle)
                {
                    empujaMov = true;

                    obj.rigidbody.velocity = new Vector2(-pushSpeed, obj.rigidbody.velocity.y);
                    //push = true;
                }
                //Ninguna de las dos
                else { obj.rigidbody.velocity = new Vector2(0f, obj.rigidbody.velocity.y); empujaMov = false; }
            }
            else //Frenar objeto en X al separarte de el
            {
                obj.rigidbody.velocity = new Vector2(0f, obj.rigidbody.velocity.y);
            }
        }



    }
}


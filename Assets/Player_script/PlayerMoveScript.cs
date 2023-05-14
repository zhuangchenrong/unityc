using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerMoveScript : MonoBehaviour
{

    public float speed = 5f;

    private float angle;

    public Rigidbody2D rb;

    public GameObject weapon_gob;

    public GameObject bullet_object;

    public GameObject muzzle_gob;

    public Camera cam;

    Vector2 player_position; // Value obtained from keyboard

    Vector2 mouse_position; // The world coordinate position of the mouse

    Vector2 look_At; // The vector pointed by the player towards the mouse
    Vector2 weapon_position;

    void Update()
    {
        PlayerMoveGetdateU();// character movement code
        WeaponRotationVectorGetdateU();// weapon tatation vector acquisition
        BulletGenerationU();// Bullet Generation
    }
    private void FixedUpdate()
    {

        PlayerMoveFU();// character movement code
        WeaponRotationFU();// weapon rotation
        test();// Debug²âÊÔ´úÂë
    }

    private void PlayerMoveGetdateU()
    {
        player_position.x = Input.GetAxisRaw("Horizontal");
        player_position.y = Input.GetAxisRaw("Vertical");

    }
    private void PlayerMoveFU()
    {
        rb.MovePosition(rb.position + player_position * speed * Time.fixedDeltaTime); // Character Movement
    }

    private void WeaponRotationVectorGetdateU()
    {
        mouse_position = cam.ScreenToWorldPoint(Input.mousePosition);
    }

    private void WeaponRotationFU()
    {
        weapon_position = new Vector2(weapon_gob.transform.position.x, weapon_gob.transform.position.y);
        #region
        // look_At = mouse_position - player_position;
        // pe Errors caused by using keyboard position as player position
        // look_At = mouse_position - weapon_rb.position;
        // I want to use the position of the weapon's rigid body
        // todetermine the direction,but the rigidbody cannot be modified
        // through the parent object .
        #endregion //error vector
        look_At = mouse_position - weapon_position; // Find the vector of the character facing the mouse

        angle = Mathf.Atan2(look_At.y, look_At.x) * Mathf.Rad2Deg;  // Transforming a vector onto an axis intoan angle
        #region
        /*float angle2 = Vector2.Angle(look_At, Vector2.up);* Debug.Log(angle2);*/
        #endregion
        if (transform.position.x > mouse_position.x && weapon_gob.transform.localScale.y > 0)
        {
            WeaponScale(180);
        }
        else if (transform.position.x < mouse_position.x && weapon_gob.transform.localScale.y < 0)
        {
            WeaponScale(0);
        } // Reverse the image after determining the rotation direction of the weapon

        weapon_gob.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle)); // Assign rotaion angle to weapon
    }

    private void WeaponScale(float x)// Weapon scaling changes direction
    {
        transform.localRotation = Quaternion.Euler(0, x, 0);
        weapon_gob.transform.localScale = new Vector3(weapon_gob.transform.localScale.x, -weapon_gob.transform.localScale.y, weapon_gob.transform.localScale.z);
    }

    private void BulletGenerationU()// Bullet Generation
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject bullet_P = Instantiate(bullet_object, muzzle_gob.transform.position, Quaternion.Euler(0, 0, angle));
            bullet_P.GetComponent<BulletScript>().SetSpeed(look_At.normalized);
        }
    }

    private void test()
    {
        Debug.Log(angle);
        Debug.Log(mouse_position);
        Debug.Log(rb.position);
    }
}

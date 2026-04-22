using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatMovement : MonoBehaviour
{
    public GameObject cam;
    public int hp = 100;
    CharacterController controller;
    Animator animator;
    public float speed = 5;
    bool isRolling = false;
    public Vector3 direction = Vector3.zero;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }
    IEnumerator Roll( float rollDuration = 0.3f)
    {
        isRolling = true;
        float s = speed;
        speed *= 2f;
        animator.SetTrigger("Roll");
        yield return new WaitForSeconds(rollDuration);
        speed = s;
        isRolling = false;
    }
    
    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        
        animator.SetBool("Move", x != 0 || y != 0);
        // vertical is multiplied by radian of camera angle to equalize both directions
        Vector3 move = new Vector3(x, 0, y * 2.217f);
        direction = Vector3.Normalize(move);
        controller.Move(-transform.up+(cam.transform.forward*move.z + cam.transform.right * move.x) * (speed+ PlayerPrefs.GetFloat("SPD")*1f) *Time.deltaTime);

        if(Input.GetKeyDown(KeyCode.Space)&&!isRolling)
        {
            StartCoroutine(Roll());
        }
    }



    public void TakeDamage(int damage)
    {
        hp -= damage;
        Debug.Log("PlayerCharacter hp = " + hp);
    }
}

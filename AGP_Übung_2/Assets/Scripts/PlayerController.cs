using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	
	private Rigidbody2D rigidbodyPlayer;

	private Animator playerAnimator;

	[SerializeField]
	private float speed;

	private bool facingRightDirection;

	[SerializeField]
	private Transform[] groundPoints;

	[SerializeField]
	private float groundSize;

	[SerializeField]
	private LayerMask whatIsGround;

	private bool isGrounded;

	private bool isJumping;

	//private bool inAir;

	[SerializeField]
	private float jumpPower;

	// Use this for initialization
	void Start () {
		facingRightDirection = true;
		rigidbodyPlayer = GetComponent<Rigidbody2D>();
		playerAnimator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	//FixedUpdate when dealing with different fps
	void Update () {
		float horizontal = Input.GetAxis("Horizontal"); //control via InputManager -> multiple control possibilities
		//horizontal values from -1 to 1
		//Debug.Log(horizontal);
		Movement(horizontal);
		ChangeDirection(horizontal);

		isGrounded = IsGrounded();
	//	inAir = false;
	}

	private void Movement(float horizontal){
	//	rigidbodyPlayer.velocity = Vector2.left; //.left = x = -1, y = 0;
	
		rigidbodyPlayer.velocity = new Vector2(horizontal * speed, rigidbodyPlayer.velocity.y);

		playerAnimator.SetFloat("moveSpeed", Mathf.Abs(horizontal));
		
	
		if (Input.GetKeyDown(KeyCode.Space)){
			isJumping = true;
		//	inAir = true;
		}

		if (isGrounded && isJumping){
			isGrounded = false;
			rigidbodyPlayer.AddForce(new Vector2(0, jumpPower));
		}

		isJumping = false;
		//inAir = false;
	}



	private void ChangeDirection(float horizontal){
		if(horizontal > 0 && !facingRightDirection || horizontal < 0 && facingRightDirection){
			facingRightDirection = !facingRightDirection;

			Vector3 playerScale = transform.localScale;

			//only works when scale x set to -1 at start?? -> solved its the if-condition
			playerScale.x *= -1;

			transform.localScale = playerScale;
		}
	}

	private bool IsGrounded(){
		if(rigidbodyPlayer.velocity.y <= 0){
			foreach (Transform point in groundPoints)
			{
				Collider2D[] colliders = Physics2D.OverlapCircleAll(point.position, groundSize, whatIsGround);

				for(int i = 0; i < colliders.Length;i++){
					//need to check if the current collider is the player-> player box is always there
					if(colliders[i].gameObject != gameObject){
						return true;
					}
				}
				
			}

		}
		return false;
	}
}

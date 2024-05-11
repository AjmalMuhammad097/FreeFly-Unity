using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PadBehaviour : MonoBehaviour {

	public float jumpForce = 10f;

	private void OnCollisionEnter2D(Collision2D other){
		if(other.relativeVelocity.y <= 0){
			if( other.collider.TryGetComponent<Rigidbody2D>(out var rb)) {
				rb.velocity = new Vector2(0,jumpForce);
			}
		}
	} 
}

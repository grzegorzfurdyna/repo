#pragma strict

var MoveRight : KeyCode; ///Zmienna ruchu w prawo
var MoveLeft : KeyCode; ///Zmienna ruchu w lewo
var Shift : KeyCode; /// Zmienna biegania
var Jump : KeyCode; /// zmienna skakania
var jumpable : boolean = true; /// zmienna decydująca czy sakaknie jest możliwe
var jumpForce : float  = 100f;	/// siła skakania
var Speed : float = 10; /// Szybkość biegania
var runR : Sprite; /// Sprite ruchu w prawo
var runL : Sprite; /// Sprite ruchu w lewo
var Nrun : Sprite; /// Sprite podstawowy
var end : Transform; /// Obiekt konczacy poziom
function OnTriggerEnter(end){
Application.LoadLevel(1);
}
function Update () { 
	if (Input.GetKey(MoveRight)){ //// Ruszanie się w prawo
	rigidbody2D.velocity.x = Speed; /// Określenie szybkosci ruchu i osi ruchu
	 GetComponent(SpriteRenderer).sprite = runR;
	 //// Zmienny sprite ruchu w prawo
	}
	else if (Input.GetKey(MoveLeft)){ /// Ruszanie sie w lewo
	rigidbody2D.velocity.x = Speed *-1; //// Określenie szybkości i osi ruchu
	 GetComponent(SpriteRenderer).sprite = runL; ///Sprite ruchu w lewo
	}
	else{ /// Nie ryszanie się 
	 GetComponent(SpriteRenderer).sprite = Nrun; /// Sprite stania
	rigidbody2D.velocity.x = 0;
	
	}
	if(Input.GetKey(Shift)){ /// Bieganie
	Speed = 50; /// Szybkości przy bieganiu
	}
	else{
	Speed = 30; /// szybkosć początkowa
	}
	
	if(Input.GetKey(Jump)){ ///Skakanie 
 	if(jumpable == true) /// Jesli można skakać to...
		{
		jumpable = false;//// Nie można skakać
			
			next(); /// Funkcja "next"
		}
	}
	
}

function next(){ /// Rozwinięcie funkcji "next"
rigidbody2D.AddForce(new Vector2(0f, jumpForce)); /// Określenie siły skoku
yield WaitForSeconds (0.5);/// blokada następnego skoku
	jumpable = true;//// Można skakać
	}



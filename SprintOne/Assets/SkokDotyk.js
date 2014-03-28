var jumpable : boolean = true; /// zmienna decydująca czy sakaknie jest możliwe
var jumpForce : float  = 100f;	/// siła skakania
	function Update () {
		for (var i = 0; i < Input.touchCount; ++i) {
			if (Input.GetTouch(i).phase == TouchPhase.Began) {
					
 	  if(jumpable == true) /// Jesli można skakać to...
		{
		jumpable = false;//// Nie można skakać
			
			next(); /// Funkcja "next"
		}
	}
			}
		}
	

function next(){ /// Rozwinięcie funkcji "next"
rigidbody2D.AddForce(new Vector2(0f, jumpForce)); /// Określenie siły skoku
yield WaitForSeconds (0.5);/// blokada następnego skoku
	jumpable = true;//// Można skakać
	}
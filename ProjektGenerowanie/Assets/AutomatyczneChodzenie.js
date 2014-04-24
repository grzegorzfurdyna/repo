

var Speed : float = 10; /// Szybkość biegania
GetComponent(Transform).position.x = 63;
GetComponent(Transform).position.y = -7.213;
function Update () { 
rigidbody2D.velocity.x = (-1) * Speed;
}
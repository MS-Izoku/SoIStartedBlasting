# Screwhead Gun System

The gun system here is meant to be a scriptable-object based system with some variance between both physics and ray-cast methods of shooting.


## Programming Bits

### The GunObject class (Monobehavior)
GunObject is the container class for the scriptable objects.  It contains the main functionality as 


## The Basic Gun
The base gun class will come with a compatable scriptableObject

* Name: Name of the Gun
* Description: Description of the Gun
* Ammo Count: Total ammo in the gun
* ClipSize: Size of a single clip in the gun
* Use Recoil: Should the gun use recoil? (NYI)
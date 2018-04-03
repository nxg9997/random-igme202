Nathan Glick
Cascioli
IGME 202-02
Random Project

Description:
	This project is a demonstration of how randomness can be used in games. The terrain is generated using perlin noise, the heights of the zombies is determined by a gaussian distribution, the density of the zombie horde is determined by a nonuniform distribution, and the trees are (uniform) randomly placed in the scene. There is also a FPS component, so in first person mode, the player can shoot and destroy both zombies and trees for points (which are displayed in the top left GUI box).

User Responsibilities/Functionality:
	The game contains one scene and five cameras. Each camera shows a different perspective of the scene to display the different uses of random in the game. The user can cycle through the cameras by pressing the 'c' key. In first person mode, the user can freely move around with WASD (although invisible walls prevent the user from walking off the edge), and they can shoot bullets by clicking the left mouse button.

Above and Beyond:
	The game is now a mini-FPS game, where the player can run around and shoot both the zombies and trees to rack up points. Shooting a bullet causes a gunshot sound effect to play. Hitting a tree causes the tree to explode (both a custom particle system, as well as a sound effect play), and hitting a zombie causes blood to spurt out (custom particle system). Hitting either a tree or zombie will destroy it. Also, a thin reticle is placed in the center of the screen to assist aiming (it's pretty accurate).

Known Issues:
	Collisions between the bullet and zombies/trees are not always detected (maybe the bullet is going to fast and "phases" through the hitbox?).

Notes:
	1. Zombie model and textures from: https://free3d.com/3d-model/dead-space-3-slasher-61944.html
	2. Explosion particle from: https://t7.rbxcdn.com/bbd46fc8bcdcec9dbb4b53f7f153f910
	3. Tree explosion sound effect from: https://www.freesoundeffects.com/free-sounds/explosion-10070/
	4. Gun sound effect from: https://www.soundjay.com/gun-sound-effect.html
	5. Dirt texture from: https://hhh316.deviantart.com/art/Seamless-dirt-texture-163426021
	6. Bullet (metal) texture from: http://flickriver.com/photos/dyrkwyst/tags/freetexture/
	7. Grass texture from inside Unity standard assets
	8. Tree prefab is from Unity standard assets
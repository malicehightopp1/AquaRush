# AquaRush

* Engine Confirguration
AquaRush is a subway surfers clone/inspired game with the twist of instead of people as your character its boats in water! AquaRush, being a clone of subways surfers deals with alot of the same systems. Inluding the infinite generation of path and coins. Along with that a save system for coins and the players boat that they have selected! 

Basic Gameplay - Game auto generates the paths with the player staying still and the paths moving so the game doesnt have to load a far transform. Auto generates coins and objects for the player to interact with along the path. Player has basic right and left controls
**will be changed to paths that the player can move through** - currently working on reworking player movement so its more stable and feels smoother. Along with this player can choose and save the boat 
that there are using and currently have a complete game loop just needs polishing

Core classes - SSectionSpawnManager - class that manages section spawning and moving. SCoinManager - Manages all coin actions along with spawning the coins along the path. The last important class is the SPlayer - manages the distance tracking, Player health **hitsToTake**
, animations for player, and will either have it manage player saving or move that to its own script.

still to implment - overall polishing of environment, Overhaul of playermovement focusing on smoothness and overall better feel to player movement, Coin shop implementation, the rest of the save system you can save your boat selection but not the score or highscore. 
Win lose state needs to be implemented. 

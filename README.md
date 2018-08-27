# Spaceship Battle Gama v.0.00001
 Team name: Team 5 (Gagarin team)
 
 Team members:
 * martin.kaerski
 * fb_10209785793276429
 * Stoychev92

Project purpose: Develop a console game featuring a spaceship battle.

There are 2 types of ships: Futuristic and Dross Mashup. Each ship type has different elements which it can use: Engines, Armours and Weapons. 
The game ends when one of the players reaches 0 health.

Repository: https://gitlab.com/MartinKaerski/SpaceshipBattle.git

The initial version of the project encountered the following problems:
- Methods and classes that didn't have single responsibility and were not Open/Closed
- Repeatable code
- A lot of static classes and methods
- Did not comply with Dependency Inversion Principle
- The factories of the entities were not Open/Closed

The implemented design patterns are Dependency Injection and Factory Pattern.
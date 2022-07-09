# Data-Persistance-Project

This was a final test on Data Persistance topic.

I received a working arkanoid clone. My job was to implement Data persistance between scenes and between sessions.

* Player name (saving data between scenes):
  * I made a new Start Menu scene for the game with a text entry field prompting the user to enter their name, and a Start/Exit buttons.
  * When the user clicks the Start button, the Main game scene is loaded and their name is displayed next to the score. 
    
    (Please check StartMenu script)
  
* High score (saving data between sessions):
  * As the user plays, the current high score is displayed on the screen alongside the player name who created the score.
  * If the high score is beaten, the new score and player name will be displayed instead.
  * The highest score is saved between sessions, so that if the player closes and reopens the application, the high score and player name are retained.
    
    (That is handled by MainManager script)
  
![menu](https://user-images.githubusercontent.com/94176489/178108931-3b47aa74-99a8-40d9-aab6-f8ed32939030.jpg)![game](https://user-images.githubusercontent.com/94176489/178108948-753a31e2-573d-4ab6-aa07-bb7e76c27dc2.jpg)

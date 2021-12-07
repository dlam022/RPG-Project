# RPG Project
 
 ## Authors:  
 > Zachhary Ruiz (https://github.com/Sterberino)                         
 > Derick Lam (https://github.com/dlam022)                     
 > Ronny Gorani (https://github.com/ronnygorani)      
 > Winnie Yee (https://github.com/wyee007)    

## Project Description

 ### Importance and Interests   
 
 > * This project is interesting to us because we all grew up playing and enjoying games but never had the chance to actually make one ourselves.  

 ### Language and Tools     
 
 > * The language we will be using is C++ and C# and the tools we will be using is Git, Github, Unity, and visual studio.

### Inputs and Outputs  

> * Our project will feature audio of the game world, a world exploration, combat system.   
> * Inputs: keyboard controls 
> * Outputs: character's movement/combat              

## Class Diagram

>  ----------------------------------------------Singleton Pattern---------------------------------------------------<br/>
> ![image](https://user-images.githubusercontent.com/91449029/141990718-78a9d843-7112-4f2d-b2d7-698442eecdae.png) <br/>
> * We chose the Singleton Pattern because it is constantly used in the game industry and it helps the game run one object at a time so that the codes do not clash. The objects all share one instance, it becomes easier to access of a class. Here we want to write a code where it will return a bool, isPaused so that the game state would not be ruined. This allowes the program to make sure it runs smoothly persistently. This helps us write a better code because we would not have to worry about other teammates code until the end.<br/>


> ----------------------------------------------Strategy Pattern---------------------------------------------------<br/>
> ![image](https://user-images.githubusercontent.com/82008415/142005136-aa9a964d-8a9a-48ca-825f-59d44fa09375.png) <br/>
> * For the movement and attacking of the characters and the enemy, we implemented a Strategy Pattern. Since Unity the usage of C# can change the way the files of code look in comparison to what we're used to, we wanted to use the strategy pattern to simplify the the features and functions of each of classes and what it contains. In an RPG like ours, where combat and movement of several entities are involved, it was clear we had to implement a strategy pattern in order to make our code more efficient. Since the user wasn't the only thing moving and attacking, we will use an abstract class and use subclasses for each of the characters involved in the game.
 
 >  !!!!!!!!!!!!!!!!!!!!!!!!!!!!!! * An updated class diagram that reflects the design patterns you used. You may combine multiple design patterns into one diagram if you'd like, but it needs to be clear which portion of the diagram represents which design pattern (either in the diagram or in the description).
 > ## Final deliverable
 > !!!!!!!!!!!!!!!!!!!!!!!!!!!!
 > Before the demo, you should do the following:
 > * Complete the sections below (i.e. Screenshots, Installation/Usage, Testing)
 > * Plan one more sprint (that you will not necessarily complete before the end of the quarter). Your In-progress and In-testing columns should be empty (you are not doing more work currently) but your TODO column should have a full sprint plan in it as you have done before. This should include any known bugs (there should be some) or new features you would like to add. These should appear as issues/cards on your Project board.
 
 ## Screenshots
 -----------------------------------------MAP DESIGN-------------------------------------------------------------------------------- <br/>
 >![unknown (1)](https://user-images.githubusercontent.com/91449029/145005670-b75d530a-c608-4775-8178-f931f00e479b.png) <br/>
 >* This is Unity where we create the 2d coded game. This isn't where the actual code is but this is where the code from another IDE(in our case Visual Studio) becomes visual and where the user shall interact when playing with the outcome. This is also the space to create the map, the character orientation, settings, etc. Let us take a closer look at the map we have created here (below) : <br/>
 > ![unknown](https://user-images.githubusercontent.com/91449029/145005015-cc082565-23cf-4490-99ee-e42ad7992ea5.png) <br/>
 > * Here we have the full map of the game where we were able to use Unity to create it. Unity allows us to edit the map to make sure it functions like one, for example, we have objects that are animated so that the character is not able to run through the object. Instead the character will run into the object and not be able to proceed unless they go another way. A future idea could be to add if the character were to run into a door then they would enter a new "map" which would be inside whatever door they run in to. <br/>
------------------------------------------CHARACTER AND INTERACTION DESIGN---------------------------------------------------------- <br/>
 >![armor](https://user-images.githubusercontent.com/91449029/145091466-7a640c48-c441-4049-8beb-419ae8467a42.png) <br/>
 >* Here we have some interactive items to upgrade the character protection. When user is playing and they use the armor, they will gain some protection and have a less of a chance of dying to a zombie. <br/>
 >![potion](https://user-images.githubusercontent.com/91449029/145091998-dc1262bf-837b-4ed1-a559-73ea87eeea57.png) <br/>
 >* Here we have another interactive item to heal the character. The potion has the idea as the interactive item "armor" but instead if used, user will gain 25 health. <br/>
 >![interaction](https://user-images.githubusercontent.com/91449029/145092709-e67c6c7e-924c-4086-a8a0-ecc1cad73cc3.png) <br/>
 >* Next we have a villager interaction where they first ask about if the user need any help. Then the user is able to respond back to them with the few lines that we have given to be chosen from. <br/>
 >![interaction2](https://user-images.githubusercontent.com/91449029/145093242-915ff9ef-f669-4212-b1ec-f091e431dcd2.png) <br/>
 >* Here we have the responses the user can pick from, and in response to whatever they pick, the villager is programmed a certain response as well. <br/>
 >![interaction4](https://user-images.githubusercontent.com/91449029/145093276-da488a86-30f9-4dfc-ab0b-d655a0231239.png) <br/>
 >* Zombie interaction, the main idea of the game is to defeat zombies. These zombies have a health bar (HP) and when you attack them, it will go down. The user also has an health bar so they would have to watch out as well. <br/>
 >![interaction3](https://user-images.githubusercontent.com/91449029/145093521-b997d89d-606d-4a39-9fa6-348cbec2ae5b.png) <br/>
 >* Here we see the user attacking the zombie and the health bar has gone down compared to the previous picture. The red indicates the zombie is very close to death. <br/>




 
 ## Installation/Usage
 
 >  Link #1: https://visualstudio.microsoft/downloads/ <br/>
 >  Link #2: https://unity3d.com/get-unity/download/archive <br/>
 >  Link #3: https://unity3d.com/get-unity/download <br/>

> * Step #1: Downloading visual studio <br/>
   -Click on Link #1 <br/>
   -We specfically downloaded Visual Studio 2019 (picking the free download option) <br/>
   -After download, there should be a window where you will have to download more to work with unity. <br/>
   -You specifically want an individual component called "Visual Studio Tools for Unity" to be installed along with Visual Studio 2019. <br/>
   -You can pull the code from github when you open visual studio. <br/>


> * Step #2: Next Download: Unity <br/>
    -Click on Link #2 <br/>
    -The version we chose to download was Unity 2019.4.26 <br/>
    -You will need to download both the Unity Hub and the Unity application itself. <br/>
     -If the button for Unity Hub is not working, you can search up Unity Hub Installation on Google (first link that appears) or you can press on Link #3 up above. <br/>
    -After installation, when you open Unity itself, the hub will appear first where you can upload a project(pull this project) or create a new project.  <br/>


>* Specific Settings we used <br/>
   -Project Settings: <br/>
    -Graphics: <br/>
     -Custom Axis: x = 0, y = 1, z = 0 <br/>
   -Preferences: <br/>
    -External Tools:  <br/>
     -External Script Editor: Visual Studio 2019 (should be selected or found through folders) <br/>


 ## Testing
 
 >* Everything that has to do with testing and memory allocations are all built in through unity where as when we code we will have everything done for us when it comes to testing and what they call the "garabage collection". For that feature they detect whatever is not auto tracked then they will figure out where to put it for you so you don't have to do it manually.
 

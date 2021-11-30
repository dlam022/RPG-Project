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

> * ----------------------------------------------Singleton Pattern---------------------------------------------------<br/>
 ![image](https://user-images.githubusercontent.com/91449029/141990718-78a9d843-7112-4f2d-b2d7-698442eecdae.png)
> * We chose the Singleton Pattern because it is constantly used in the game industry and it helps the game run one object at a time so that the codes do not clash. The objects all share one instance, it becomes easier to access of a class. Here we want to write a code where it will return a bool, isPaused so that the game state would not be ruined. This allowes the program to make sure it runs smoothly persistently. This helps us write a better code because we would not have to worry about other teammates code until the end.


> * ----------------------------------------------Strategy Pattern---------------------------------------------------
* ![image](https://user-images.githubusercontent.com/82008415/142005136-aa9a964d-8a9a-48ca-825f-59d44fa09375.png)
> * For the movement and attacking of the characters and the enemy, we implemented a Strategy Pattern. Since Unity the usage of C# can change the way the files of code look in comparison to what we're used to, we wanted to use the strategy pattern to simplify the the features and functions of each of classes and what it contains. In an RPG like ours, where combat and movement of several entities are involved, it was clear we had to implement a strategy pattern in order to make our code more efficient. Since the user wasn't the only thing moving and attacking, we will use an abstract class and use subclasses for each of the characters involved in the game.
 
 >  !!!!!!!!!!!!!!!!!!!!!!!!!!!!!! * An updated class diagram that reflects the design patterns you used. You may combine multiple design patterns into one diagram if you'd like, but it needs to be clear which portion of the diagram represents which design pattern (either in the diagram or in the description).
 > ## Final deliverable
 > All group members will give a demo to the TA during lab time. The TA will check the demo and the project GitHub repository and ask a few questions to all the team members. 
 > Before the demo, you should do the following:
 > * Complete the sections below (i.e. Screenshots, Installation/Usage, Testing)
 > * Plan one more sprint (that you will not necessarily complete before the end of the quarter). Your In-progress and In-testing columns should be empty (you are not doing more work currently) but your TODO column should have a full sprint plan in it as you have done before. This should include any known bugs (there should be some) or new features you would like to add. These should appear as issues/cards on your Project board.
 > * Make sure your README file and Project board are up-to-date reflecting the current status of your project (e.g. any changes that you have made during the project such as changes to your class diagram). Previous versions should still be visible through your commit history. 
 
 ## Screenshots
 
 > !!!!!!!!!!!!!!!!!!!!!!!!!!!!!Screenshots of the input/output after running your application
 
 ## Installation/Usage
 
 > * Link #1: https://visualstudio.microsoft/downloads/
 > * Link #2: https://unity3d.com/get-unity/download/archive
 > * Link #3: https://unity3d.com/get-unity/download

 >* Step #1: Downloading visual studio <br/>
   > Click on Link #1
   > We specfically downloaded Visual Studio 2019 (picking the free download option)
   > After download, there should be a window where you will have to download more to work with unity. 
   > You specifically want an individual component called "Visual Studio Tools for Unity" to be installed along with Visual Studio 2019.
   > You can pull the code from github when you open visual studio.
 > * Step #2: Next Download: Unity
   >* Click on Link #2
   >* The version we chose to download was Unity 2019.4.26
   >* You will need to download both the Unity Hub and the Unity application itself.
     >* If the button for Unity Hub is not working, you can search up Unity Hub Installation on Google (first link that appears) or you can press on Link #3 up above.
   >*After installation, when you open Unity itself, the hub will appear first where you can upload a project(pull this project) or create a new project. 
 >* Specific Settings we used
   >* Project Settings:
     >* Graphics: 
       >* Custom Axis: x = 0, y = 1, z = 0
   >* Preferences:
     >* External Tools: 
       >* External Script Editor: Visual Studio 2019 (should be selected or found through folders) 


 ## Testing
 
 >!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!! How was your project tested/validated? If you used CI, you should have a "build passing" badge in this README.
 

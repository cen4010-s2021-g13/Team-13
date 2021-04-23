# Cover Page

## CEN 4010 Principles of Software Engineering Spring 2021
## Milestone 5 Final Project Portfolio
## Project name: Overtake
## Team 13
## Rosalba Monterrosas (Scrum Master): rmonterrosas2015@fau.edu
## Brandon Basdeo (Develop Team): bbasdeo@fau.edu
## Ruth Betancourt (Develop Team): rbetancourt2003@fau.edu
## Michael Hollinger (Develop Team): mhollinger2020@fau.edu
## Lionel Munoz (Develop Team): lionelmunoz2018@fau.edu
## Luiz Zullino Junior (Product Owner): lzullinojuni2020@fau.edu
## 04/18/2021
## Project URL: https://cen4010-s2021-g13.github.io/
## History Table
Version 0.00 - 04/18/21 - Added template of document, Project Summary, Milestone Documents, Post-Project Analysis

Version 0.01 - 04/19/21 - Added Team Members' Contribution

Version 0.02 - 04/19/21 - Added Team Member's Contribution

# Project Summary

Our product called “Overtake” is an original game developed in the Unity game engine and playable using a modern web browser. Overtake is a single-player 2D platform game aimed at people wanting to take a short break, and features simple controls and interface. Users will go through the game level by running and jumping, and when the game is over their score will be saved. Users of the game will be able to compare their scores with others by sharing their usernames with each other and checking the high score leaderboard. The game can be marketed through users who wish to share their score using social media, and having them invite others to beat their score. During the times of Covid-19, the game is also a way for people to connect while maintaining social distancing.

## Major Committed Functions
* Users will be able to register for an account using an email address, username, and password
* Users will be able to log in with a username and password
* Users will be able to play the game after logging in
* Users will be able to change the color of their game character
* Users will have their score saved to a leaderboard under their username
* Users will be able to look up the high score leaderboard

## Unique Features
* The game is free and has no ads

## URL
https://cen4010-s2021-g13.github.io/

# Milestone Documents

## Milestone 3

# CEN 4010 Principles of Software Engineering Spring 2021
# Milestone 1 Project Proposal: An online multiplayer 2-D game where players navigate through obstacles
# Team name and project name: Team 13
# Team 13
# Rosalba Monterrosas: rmonterrosas2015@fau.edu
# Brandon Basdeo: bbasdeo@fau.edu
# Ruth Betancourt: rbetancourt2003@fau.edu
# Michael Hollinger: mhollinger2020@fau.edu
# Lionel Munoz: lionelmunoz2018@fau.edu
# Luiz Zullino Junior: lzullinojuni2020@fau.edu
# 02/12/2020
# History Table
Version 0.00 - 2/12/21 - Added template

Version 0.01 - 2/15/21 - Added executive summary

Version 0.02 - 2/15/21 - Added competitive analysis

Version 0.03 - 2/16/21 - Added High-Level System Architecture, Team, Data Definition

Version 0.04 - 2/16/21 - Added Non-functional Requirements, Data Definition

Version 0.05 - 2/16/21 - Added Overview, scenarios and use cases

Version 0.06 - 2/16/21 - Added High-level Functional Requirements

Version 0.07 - 2/26/21 - Edited executive summary

Version 0.08 - 03/03/21 - Edited High-Level System Architecture

Version 0.09 - 03/05/21 - Edited High-level Functional Requirements and Data Definition

Version 0.10 - 04/05/21 - Added priorities to Functional Requirements, updated Data Definition, added UML class diagrams, added UML Component and Deployment Diagrams

Version 0.11 - 04/05/21 - Added Key Risks

## Executive Summary
Team 13 will be designing an original multiplayer game, with the goal of connecting people during times of social distancing. The game will be playable in a browser and users will be able to choose who they connect to. The system for allowing users to find each other will be a short randomized code, which can be shared using outside means like text or video communications. Players can maintain privacy by only sharing their code with people they choose. Only the usernames of players will be shared with other players, and all other information will be kept private. 

The main function of the game will be players competing against each other in a two dimensional obstacle course. Using user friendly interface, simple movement, and easy to understand controls, players will move from start to finish and compete to see who can finish first. The games will be short, a few minutes long, so people will not need to allocate a large amount of time to play. During times of social distancing, our game aims to provide a means of connecting with other people for a short moment of fun, before continuing with the rest of their day. 

## Competitive Analysis
Key Features: Competitor vs Team 13
|Competitor (Fall Guys)|	Team 13|
|---|---|
|Online Multiplayer	|Code Based Lobby|
|3D-Graphics|	2D-Graphics|
|Third Person|	Side-View|
|Winner Take all|	Point System|
|Customizable Avatars|	Customizable Avatars|

One of the major competitors that came to mind when coming up with our idea was the fame Fall Guys. When people think of online obstacle game, they think of Fall Guys. The first key difference will be how the multiplayer works. Fall Guys requires around a 50-person lobby which means there is no way to play solely with your friends. Our idea is to use a code invite system and have the games on a smaller scale so that games can take place between friends. Fall Guys takes place in a 3D environment, while our game will be in 2D. In this day and age, a games success has little to do with the dimensions of the game and more to do with how it makes use of the space. Only being in 2D will allow us to spend more time making the physics work well and give the user more control over their avatar. Our game will be using a side-view perspective which will allow the user to have precise control over the two dimensions they can move in. Fall Guys’ movement is much less focused on precision and more on situational awareness which allows are game to fill a difference niche. The point system between the two games will also be different. Fall Guys utilizes a winner take all when it comes to receiving rewards from playing. Our game will have a point system that will allow even those who come in second or third to earn rewards and have a sense of progression. Finally, you need a way to spend these points and this is where the two games will behave the same. The points players earn through their accomplishments will be used to buy customizable items to personalizer their avatars.

## Data Definition

**LAMP Server**: Linux Apache MySQL PHP [LAMP] server, provided by FAU, provides access to Linux (via SSH access) ), Apache (for web based development via PHP or CGI-BIN), MySQL (for database development), PHP (for web based development, and Tomcat (for java based web development).

**Unity**: American video game software development company used for the development of the game.

**OS**: The operational system

**Frame Rate**: The frequency of images (called frames) being displayed on the screen. Measured in frames per second (fps)

**Netcode**: The syncronization between the client and server side of the game.

**Bugs or Glitches**: Issues or problems that happen when the game do things that it was not supposed to do.

**Player**: User playing the game.

**Host**: User that starts a game and can share a code with other users so that these users can join the host's game.

**Code**: A string composed of 6 random letters and numbers that a user must enter to join a game.

**Main lobby**: A screen where a logged-in user can start or join a game.

**User Account**: Account information for a user.


## Overview, Scenarios and Use Cases

### Scenario One
     
   * David is a freshman at Florida Atlantic University. He would like to partake in a game that will help him meet new friends since all of his classes are online due to the pandemic. He meets someone named Paul through a Discussion post on Canvas. David invites Paul to play a game. He shares a procedurally-generated code with Paul, which allows him to join a session.
   
### Scenario Two
     
   * Sofia primarily uses a mobile device to access media. She is a fairly novice gamer and wants to use gaming to feel more connected with her online classmates. She installs the game and invites a few classmates to play.
   
### Scenario Three
     
   * Max has a new computer. He would like to utilize the computer to play a game, not necessarily as a benchmark, in order to "break it in" with some friends that he has not seen in a while due to the pandemic. He sends some of his friends an invite code and they join a session together.


### Use Case 1: User Login
1. The user opens the game.
2. The user enters their username.
3. The user enters their password.
4. The user clicks on the "Login" button.


### Use Case 2: User Signs Up for an Account
1. The user opens the game.
2. The user clicks on the "Sign Up" link.
3. The user enters their email.
4. The user enters a unique username.
5. The user enters a password.
6. The user confirms their password.
7. The user clicks on "Sign Up."

### Use Case 3: User Hosts a Game
1. The user logs in successfully.
2. The user clicks on the "Host Game" button.
3. The user enters the room name and shares the given code with their friends.
4. The user clicks on the "Create Room" button.

### Use Case 4: User Joins a Game
1. The user logs in successfully.
2. The user clicks on the "Join Game" button.
3. The user enters the code that was shared with them by the host.
4. The user clicks on the "Join Game" button.

### Use Case 5: User Plays a Game
1. The user successfully hosts or joins a game.
2. The user chooses the color of their character.
3. The user waits for other players to join the game.
4. The user votes for the level that they prefer.
5. The user begins playing the game when the host clicks on the "Play" button.
6. The user sees the ranking of each player's score at the end of the game.
7. The user can play the game again if the host clicks on the "Restart" button.
   

## High-level Functional Requirements

| Unique Identifier |                                                                                                                    Requirement                                                                                                                   | Priority |
|:-----------------:|:------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------:|:--------:|
|        FR01       |                                                                                              A user should be able to register for a unique account.                                                                                             |     1    |
|        FR02       |                                                                                           A user should be able to login and arrive at the main lobby.                                                                                           |     1    |
|        FR03       |                                                                         A user should be able to join a host's game using a specific code that the host shared with them.                                                                        |     2    |
|        FR04       |                                                    A user should be able to become a host by starting a game and sharing a code with other users so that these users can join the host's game.                                                   |     2    |
|        FR05       |                                                                                       A user should not be able to start or join a game without logging in.                                                                                      |     1    |
|        FR06       |                                                                                A user should not be able to join a host's game without entering the correct code.                                                                                |     2    |
|        FR07       |                                                     A host should be able to wait for other users to join their game or start playing the game if at least one other player joined the game.                                                     |     2    |
|        FR08       |                                                                                           A user should be able to choose the color of their character.                                                                                          |     1    |
|        FR09       |                                                                                     A user should be able to move up, down, jump and duck to avoid obstacles.                                                                                    |     1    |
|        FR10       |                                                                          A user loses the game if they lose all 3 of their lives and can spectate the rest of the game.                                                                          |     2    |
|        FR11       |                                                                                      A user wins the game if they are the last player remaining in the game.                                                                                     |     2    |
|        FR12       |                                                                                                 A user gains points for each obstacle they avoid.                                                                                                |     1    |
|        FR13       |                                                                                      A user sees the ranking of the players' points at the end of the game.                                                                                      |     1    |
|        FR14       | A host should be able to choose whether to restart the game or not when the game ends. If the host restarts the game, the players do not have to re-enter the code again. If the host does not restart the game, users return to the main lobby. |     2    |
|        FR15       |                                                                                 A user should be able to quit the game at any time and return to the main lobby.                                                                                 |     2    |
|        FR16       |                                                                                    Other users that are not a host do not have the authority to start a game.                                                                                    |     2    |
|        FR17       |                                                                                           A user should be able to vote for the level that they prefer.                                                                                          |     3    |
|        FR18       |                                                                                                A user loses a life if they crash into an obstacle.                                                                                               |     1    |

<br></br>

## Non-functional Requirements
1. Graphics performance
   * The game needs to run with a frame rate of at least 30fps on average. The optimal frame rate range is between 30fps and 60fps.
1. Ease of use
   * The game and the game menu needs to be simple to use.
1. Response time
   * The game needs a near realtime response on average for the inputs of less than 30ms.
1. Client Resources
   * The game will run on a webpage so that it can be accessed by any OS.
   * The game needs to be lightweight with no more than 300MB of size.
   * The game needs to be able to run with a minimum of 1024MB of memory.
1. Server Resources
   * The server needs to run the OS Windows 10
   * The sever instance needs to have less than 1024MB of size.
   * The server instance needs to run with a minimum of 2048MB of memory.
1. Netcode
   * The response time between the client and server needs to be on average below 60ms.
1. Maintainability
   * The code for the game needs to be written in a way that it can be maintaned and updated in case of bugs/glitches are found or if the game needs to be expanded.

## High-Level System Architecture

### Database

1. Will use SQLite integration with the Unity engine. The database will store the players’ login information (unique username and hashed password), game data, and their highest score.
   * Thus far, the database will be comprised of two tables: "players", and "session". "Players" will be comprised of 3 fields: name, ID (which will be procedurally generated), and High Score (which will keep track of the player's high score). "Session" will, likewise, be comprised of 3 fields: host_ID (which will serve as a foreign key from Players), stage, and winner. This is tentative, as technical demands may require a more complex database architecture.
   * All images and video will be stored in drives as opposed to the database, as the game primarily uses assets. The only information stored by the database will be the information listed above.
   * For the time being, linear search will be implemented to retrieve and update player scores, as the database usage is not estimated to be particularly high.
   * Linear search is an efficient way of implementing a simple method of researching player scores and comparing them to the score that was attained in any given round. When a high score is surpassed, updating the aforementioned record will be comprised of a single "Update" query in SQLite, which will be implemented in conjunction with multiplayer functionality.

### Server
Use our group’s LAMP server provided by the university.

### Client-Server Relationship

* Client-side: JavaScript
* Server-side: C#

### API’s

* Last.fm API: Allows the exploring of the entire collection of the website’s music data resources, such as artists and playlists.
https://english.api.rakuten.net/dimashirokov/api/LastFm

### Supported Browsers
* Google Chrome
* Firefox

### GUI

Unity for developing a 2-D game 
https://docs.unity3d.com/Manual/Unity2D.html

### Development

Unity for developing a 2-D game 
https://docs.unity3d.com/Manual/Unity2D.html


## Team

* Scrum Master: Rosalba Monterrosas
* Product Owner: Luiz Zullino Junior
* Development Team: Brandon Basdeo, Lionel Munoz, Michael Hollinger, Ruth Betancourt


## High-Level UML Diagrams
### UML Class Diagrams
![Class Diagrams](assets/class_diagram.png)
<br></br>
### UML Component and Deployment Diagrams
![Component and Deployment Diagrams](assets/component_deployment_diagram.png)

## Key Risks
   The individuals in our team have provided a diverse skill set that has allowed as to avoid most skill or knowledge-based risks. One risk that has been plaguing our group from the beginning is scheduling. Our goal was to have daily, brief, scrum meetings to coordinate and keep track of progress.  Having all members of the group daily has been a struggle but we have been bolstering our communication through instant messaging and keeping detailed minutes of meetings to share with members who miss meetings. A risk that might affect us in the future has to do with the LAMP server. We plan to host our video game on the lamp server to allow multiplayer function. The strength of the lamp server is unknown to us and may cause issues and may limit the number of players who can play at once or limit the complexity of our game. The sooner we can begin beta testing on the server, the sooner we will understand our limitations, if there are any.

## Checklist

a)  Team decided on basic means of communications: DONE

b)  Team found a time slot to meet outside of the class: DONE

c)  Front and back end team leads chosen: DONE

d)  Github master chosen: DONE

e)  Team ready and able to use the chosen back and front-end frameworks: DONE

f)  Skills of each team member defined and known to all: DONE

g)  Team lead ensured that all team members read the final M1 and agree/understand it before submission: DONE

## Instructor's Feedback

### Milestone 3

* In terms of our team's progress, the instructor mentioned that we have good progress.
* The instructor noted that for the final presentation, our team needs to ensure that we should not only show us playing the game, but we must also  emphasize all of the functions that we have developed.

### Milestone 4

* The insructor commented that our team did a good job.
* The instructor also stated that our team needs to ensure that a non-logged in user cannot join a game.
* For the security checks, the instructor mentioned that our team needs to povide proof that the password is encrypted.

## Screenshots of Actual Final Product as Shown in the Demo

## Google Analytics Plot for Your Website
Google Analytics is a tool used by companies and creators to measure and organize data surrounding their websites or applications. Google Analytics is setup to monitor many important metrics revolving around a successful website. Site traffic is displayed in real time and can be formatted to display data over days, weeks, months, or years. It is also possible to break down site traffic by geographic location. This is important because if you are a business looking to serve a specific area or even a world-wide market, it helps to know that your website is reaching those whom you are looking to work with. Another important feature of Google Analytics is how it monitors monetization and marketing. In the past, websites were generally used as a form of marketing for a business. With online stores, and bill payments becoming more popular, it is also important to keep track of how your website is helping you to make money. When it comes to marketing, Google Analytics has features to show how well your online/social media marketing campaigns are at bringing people to your website or application. This is useful when your company is first starting, and it is important that every penny you spend is being used efficiently.

Team 13 has made use of Google Analytics by having it monitor the host website for our game Overtake. Our website does not have monetization features and we have not started any marketing campaigns, so these are not metrics that are currently useful. What our team is interested in is analyzing the traffic on our websites. It shows us information such as, how many people have come to the website over a period, from that group of people is it their first time on the website, and how long they are on it. This is crucial information for us because it lets us know if the news of our game is being spread, and if people are enjoying it. 

Now because we do not have access to the html file of the website that is hosting our game, we are using Google Analytics through another Google platform known as Firebase. Our game was coded using Unity which does not support data base structures which is why we needed to implement Firebase in the first place. Among other things Firebase allowed us to be able to monitor the metrics of our site using Google Analytics.

![Google Analytics Plot](assets/Google_Analytic.png)

## Team Members' Contribution

### Team Members' Contribution to the Project

|         Name        | Points |
|:-------------------:|:------:|
| Rosalba Monterrosas |  50/3  |
|    Brandon Basdeo   |  50/3  |
|   Ruth Betancourt   |  50/3  |
|  Michael Hollinger  |  50/3  |
|     Lionel Munoz    |  50/3  |
| Luiz Zullino Junior |  50/3  |

### Team Members' Contribution to Teamwork

* Rosalba Monterrosas
    * Set up GitHub organization and team repo
    * Set up the templates for the Milestone documents
    * Documentation
    * Worked on PowerPoint slides and voice recordings for presentation
    * Send detailed meeting notes of daily scrum meetings to team members
    * Allocated tasks among team members
    * Managed JIRA issues
    * Set up daily scrum meetings
    * Scrum Master
* Ruth Betancourt
    * Documentation
* Brandon Basdeo
    * Documentation
    * Worked on PowerPoint slides and voice recordings for presentation
    * Game development 
* Lionel Munoz
    * Documentation
    * Created and Organized PowerPoint
    * Setup Google Analytics account

### GitHub Team Development Branch

|         Name        | Number of Submissions |
|:-------------------:|:---------------------:|
| Rosalba Monterrosas |           38          |
|    Brandon Basdeo   |           7           |
|   Ruth Betancourt   |           2           |
|  Michael Hollinger  |           6           |
|     Lionel Munoz    |           7           |
| Luiz Zullino Junior |           19          |


## Post-Project Analysis

### Main Challenges

#### Scheduling

One of our team's main challenges is scheduling and coordinating the daily scrum meetings. Our team's goal was to have daily, brief, scrum meetings to coordinate and keep track of progress. At the beginning of the semester, the team agreed to have scrum on Mondays at 9am and Tuesdays - Fridays at 7pm. However, as we progressed through the semester, the schedules of some our team members changed, so we had to agree on a different schedule for scrum. Our new scrum schedule was Mondays - Fridays at 7pm. Nonetheless, after some more time elapsed, our team members' schedule changed again, so our scrum schedule changed to Mondays - Fridays at 6:40pm. 

After realizing the difficulty of scheduling the daily scrum meetings so that all team members can be present for the daily scrum, Rosalba, our team's Scrum Master, decided to begin keeping notes of the detailed minutes of the scrum meetings in order to address this scheduling challenge. Rosalba would send these detailed meeting minutes to the rest of the team in order to keep bolstering our communication and update the team members who could not make it to the scrum meeting.

What our team could do better next time to address our scheduling challenge is to begin taking notes of the detailed minutes of the scrum meetings since the beginning of the semester. This way, the communication among our team members could have been a lot smoother since the beginning of the semester.

#### Allocation of Tasks Among Team Members

Another main challenge that our team has experienced throughout the semester is allocating the tasks to be completed among the members of our team for each sprint. Since the individuals in our team have provided a diverse skill set, it is difficult to get to really know and understand the exact skills that each team member offers due to the limited amount of time we have to work on the project. For example, some team members do not have any web development skills, while the expertise of other team members is web development. In addition, some team members are better at writing and formatting documentation, others are better at designing and creative tasks, while other team members are better at developing the game. Therefore, during the first few sprints, it was challenging to figure out the skills of each team member and to assign an appropriate task to each individual. 

In order to address this challenge of dividing up the work among the team members, the individuals in our team began discussing what their strengths are and what tasks they would like to complete. Thus, instead of assigning each team member a random task, each team member would vocalize what work they would like to complete based on the skills that they realized they had. For instance, some team members stated that they would like to handle the database since they had previous experience dealing with databases.

What our team could do better next time to address this particular challenge is to have a discussion at the beginning of the semester where each team member discusses what skills they can offer and any previous experience that can be helpful for completing the project. This way, the productivity of our team can be greatly increased.

### Finished Features

* Users will be able to register for an account using an email address, username, and password
* Users will be able to log in with a username and password
* Users will be able to play the game after logging in
* Users will be able to change the color of their game character
* Users will have their score saved to a leaderboard under their username
* Users will be able to look up the high score leaderboard

### Features Not Finished

* Our team would have liked to finish the live multiplayer functionality of the game but we were not able to finish this feature due to the limited amount of time we had to complete the product and the fact that none of our team members had previous experience with implementing multiplayer functionality into a game. Consequently, our team did not have time to learn how to incorporate the live multiplayer functionality. Thus, instead of having live mulitplayer included in the game, our team agreed that it was more manageable to include a multiplayer leaderboard that shows the username and points of all the people who have played the game. This way, the game still involves a multiplayer functionality to connect different people.

* Since our team was not able to complete the live multiplayer functionality of the game, our team also decided that it was better to not include the Room Code feature into the product. Without having the live multiplayer functionality of the game, it did not make sense to include the Room Code because the purpose of the Room Code was to connect multiple people together to play together live in the same game.

### Knowledge Gained and Lessons Learned

An important lesson that our team learned from our project and teamwork is how to better manage scheduling of the scrum meetings. It is critical to take notes of the detailed minutes of all the scrum meetings. Taking these notes and sending them to all of the team members will greatly improve the communication among our team members so that all team members can get updated with the most recent information.

Another important lesson that the members of our team learned is to openly discuss among all the team members what each individual's strengths are and in what ways they can help contribute to the product most effectively. Having this friendly and open discussion will help each other understand which tasks they should work on, which will highly improve the team's productivity.

Other knowledge that our team has gained is that it is extremely difficult to complete all of the features and requirements that were first proposed. We now have a better understanding as to why most software engineering projects do not finish on time.

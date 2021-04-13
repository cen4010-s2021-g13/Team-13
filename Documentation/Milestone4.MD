# Title Page

## CEN 4010 Principles of Software Engineering Spring 2021
## Milestone 4 Beta Launch and Reviews
## Project name: Overtake
## Team 13
## Rosalba Monterrosas (Scrum Master): rmonterrosas2015@fau.edu
## Brandon Basdeo (Develop Team): bbasdeo@fau.edu
## Ruth Betancourt (Develop Team): rbetancourt2003@fau.edu
## Michael Hollinger (Develop Team): mhollinger2020@fau.edu
## Lionel Munoz (Develop Team): lionelmunoz2018@fau.edu
## Luiz Zullino Junior (Product Owner): lzullinojuni2020@fau.edu
## 04/11/2021
## History Table
Version 0.00 - 04/11/21 - Added template, Usability Test Plan, and Self-Check: Adherence to Original Non-Functional Specs

Version 0.01 - 04/13/21 - Added product summary

# Product Summary
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
https://lamp.eng.fau.edu/~cen4010_s21_g13/Overtake/

# Usability Test Plan

## Test Objectives

The usability test objectives is to assess how easily the game can be played and used by the end users. This measure can be evaluated based on the time and level of skill required to learn how to play the game. Also, the objectives of the test is to examine the user's attitudes towards playing the game, ensuring that the users can complete the main actions that they need to, and have an efficient experience. Thus, the test will help reveal areas of confusion and identify any usability issues that are present in the game so that they can be resolved before the final delivery of the game.

Specifically, the objective of the "System Setup" tests is to make sure that the game can be accessed using the requirements listed in the test cases, such as hardware, OS, browsers, and Wi-Fi. The objective of the "Starting Point" tests is to ensure that the players experience the correct starting point for playing the game. The starting point should include the correct amount of lives and points, and the correct location of the character on the map. The objective of the "Task to be Accomplished" tests is to make sure that the player can fulfill the main tasks of the game, such as movement and earning points. The objective of the "Who is the Intended User" test is to examine whether the proposed intended user is a correct fit for the game. The objective of the "Completion Criteria" test is to assess whether the game successfully ends when there are no more lives remaining. The objective of "The URL of the System to be Tested" test is to evaluate whether the game can be accessed with the URL provided.

## Test Plan

### System Setup

| Test Case Number | Test Title |                             Test Description                             | Test Results |
|:----------------:|:----------:|:------------------------------------------------------------------------:|:------------:|
|         1        |  Hardware  | The only hardware setup required to play the game is to have a computer. |              |
|         2        |     OS     |                    The game can be accessed by an OS.                    |              |
|         3        |   Browser  |        The game is supported by Google Chrome and Mozilla Firefox.       |              |
|         4        |    Wi-Fi   |                   Wi-Fi is required to access the game.                  |              |

<br></br>

### Starting Point

| Test Case Number |     Test Title     |                                    Test Description                                    | Test Results |
|:----------------:|:------------------:|:--------------------------------------------------------------------------------------:|:------------:|
|         1        |     Game Screen    | The starting point of the major function is the game screen when the game fist begins. |              |
|         2        | Character Location |            The player sees their character at the initial point of the map.            |              |
|         3        |   Player's Lives   |                    The player should have all three of their lives.                    |              |
|         4        |       Points       |                         The player should start with 0 points.                         |              |

<br></br>

### Task to be Accomplished

| Test Case Number |   Test Title   |                                            Test Description                                            | Test Results |
|:----------------:|:--------------:|:------------------------------------------------------------------------------------------------------:|:------------:|
|         1        |    Movement    |                          The player can move left, right, and jump vertically.                         |              |
|         2        |  Losing Lives  | The player's task is to avoid the obstacles and not fall off the map in order to not lose thier lives. |              |
|         3        | Earning Points |                             The player earns points by avoiding obstacles.                             |              |
|         4        |      Goal      |                      The player's goal is to earn more points than their friends.                      |              |

<br></br>

### Who is the Intended User

| Test Case Number |   Test Title  |                                                    Test Description                                                   | Test Results |
|:----------------:|:-------------:|:---------------------------------------------------------------------------------------------------------------------:|:------------:|
|         1        | Intended User | The intended user is a college student who wants to connect more with their friends while keeping safe from COVID-19. |              |

<br></br>

### Completion Criteria

| Test Case Number |      Test Title     |                        Test Description                       | Test Results |
|:----------------:|:-------------------:|:-------------------------------------------------------------:|:------------:|
|         1        | Completion Criteria | The game ends when the player loses all three of their lives. |              |

<br></br>

### The URL of the System to be Tested

| Test Case Number |             Test Title             |                                    Test Description                                    | Test Results |
|:----------------:|:----------------------------------:|:--------------------------------------------------------------------------------------:|:------------:|
|         1        | The URL of the System to be Tested | The URL of the system to be tested: https://lamp.cse.fau.edu/~cen4010_s21_g13/overtake |              |

<br></br>

## Questionnaire Form

Please check the column that best represents how you feel about your game playing experience for each statement.

|                                                                     | Strongly Disagree | Disagree | Neutral | Agree | Strongly Agree |
|---------------------------------------------------------------------|:-----------------:|:--------:|:-------:|:-----:|:--------------:|
| 1. It is easy to learn how to play the game.                        |                   |          |         |       |                |
| 2. I did not encounter any technical issues while playing the game. |                   |          |         |       |                |
| 3. It was an enjoyable experience playing the game.                 |                   |          |         |       |                |

<br></br>

# QA Test Plan

# Code Review

# Self-Check on Best Practices for Security

## Major Assets we are protecting

* The user's password
* The user's email

## Password Encryption

The user's password is encrypted in the database using the following steps:

1. Create a random salt value.
2. Append the salt to the user's password.
3. Hash the combined salt and password.
4. Append the salt to the resultant hash.
5. Store the result in the database.

## Input Data Validation

* Valid username and password when the user is logging in.

```
SELECT 1 FROM userDB WHERE username=Username AND password=Password
```

* Valid email address when the user is registering for an account.

```
bool IsValidEmail(string email)
{
    try {
        var addr = new System.Net.Mail.MailAddress(email);
        return addr.Address == email;
    }
    catch {
        return false;
    }
}
```

* Confirm Password input is the same as the Password input when the user is registering for an account.

```
bool IsValidConfirmPassword(string confirmPassword, string Password)
{
    try {
        return confirmPassword == Password;
    }
    catch {
        return false;
    }
}
```

* Username does not already exist when the user is registering for an account.

```
SELECT 1 FROM userDB WHERE username=Username
```

* When the user is registering for an account, there are no empty input fields.

```
string.IsNullOrEmpty(TextBox.Text)
```

# Self-Check: Adherence to Original Non-Functional Specs

|         Topic        |                                                                      Non-Functional Requirements                                                                     | Status |
|:--------------------:|:--------------------------------------------------------------------------------------------------------------------------------------------------------------------:|:------:|
| Graphics performance | 1. The game needs to run with a frame rate of at least 30fps on average. The optimal frame rate range is between 30fps and 60fps.                                    |  DONE  |
| Ease of use          | 2. The game and the game menu needs to be simple to use.                                                                                                             |  DONE  |
| Response time        | 3. The game needs a near realtime response on average for the inputs of less than 30ms.                                                                              |  DONE  |
| Client Resources     | 4. The game will run on a webpage so that it can be accessed by any OS.                                                                                              |  DONE  |
| Client Resources     | 5. The game needs to be lightweight with no more than 300MB of size.                                                                                                 |  DONE  |
| Client Resources     | 6. The game needs to be able to run with a minimum of 1024MB of memory.                                                                                              |  DONE  |
| Server Resources     | 7. The server needs to run the OS Windows 10.                                                                                                                        |  DONE  |
| Server Resources     | 8. The sever instance needs to have less than 1024MB of size.                                                                                                        |  DONE  |
| Server Resources     | 9. The server instance needs to run with a minimum of 2048MB of memory.                                                                                              |  DONE  |
| Netcode              | 10. The response time between the client and server needs to be on average below 60ms.                                                                               |  DONE  |
| Maintainability      | 11. The code for the game needs to be written in a way that it can be maintained and updated in case of bugs/glitches are found or if the game needs to be expanded. |  DONE  |

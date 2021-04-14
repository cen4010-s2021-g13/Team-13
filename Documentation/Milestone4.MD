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
https://cen4010-s2021-g13.github.io/

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
## Test Objectives:
During the usability test phase our goal is to see how easy or intuitive, accessing and playing the level is. During the Quality Assurance phase, we will be looking to see if the game is working as intended. The strategy that we will intend to use when testing the ability of the games function to work as intended, we will stick to testing the edge parameters of our cases.

## Hardware and Software Setup:
The hardware required to test the functionality while in the game are a computer with access to the internet, a monitor to display the game, a mouse to navigate the user interface of the operating system and browser, and a keyboard to operate the character withing the game. The software required for testing are Mozilla Firefox and Google Chrome, there is no installation required for the game because it is hosted on the FAU LAMP server.
	
## Feature to be tested:
The feature we will be testing is the playable level of Overtake. The tests we will be performing will be conducted on two browsers, Google Chrome, and Mozilla Firefox. Being limited to only three test cases, we will look to test the three core functions of the game design: platforming, winning, and loosing. With platforming we will look to test movement and collision. When concerned with winning we will test that there is only one victory condition, reaching the end of the level, and that it works. Finally, we will test that only the appropriate objects or terrain cause the loosing condition of death.

## Test Cases:

| Test Case Number |     Test Title     |         Test Description       |               Input             |                 Output                  |Pass or Fail
|:----------------:|:------------------:|:------------------------------:|:-------------------------------:|:---------------------------------------:|:-----------:|
|         1        |     Platforming    | Testing Movement and Collision |     Keyboard movement keys      |   Character moves, objects stop them    |    Pass     |
|         2        |       Winning      |   Testing Victory Condition    |      Crossing finish line       |     Victory message is displayed        |    Pass     |
|         3        |       Losing      |    Testing Loss Condition      |Hitting spikes or falling of edge|     Defeat message is displayed         |    Pass     |

## Results:
As seen in the table above, our product was able to pass every single test case on both Google Chrome and Mozilla Firefox. During test one, we were able to successfully navigate all terrain and all the obstacles and platforms provided collision to interact with. One concern that did come up was travelling across the inclined area. There was a slight graphical issue if you jumped on the incline and continued moving. While we will investigate this in the future, it does not impact the playability or functioning of the game. For test two, we were able to confirm that the coin at the end of the level provided the win condition of the game and displayed the victory message. No other terrain or space could recreate this, which is expected. Finally for case three, we were able to test that only the spikes, saws, and lower boundary of the map could cause a defeat condition and display the defeat message.
# Code Review
The vast majority of this project uses standard object-oriented C# practices, in addition to the LAMP stack coding practices used to develop the team's website. Commentary on the code is written below, which mainly comments on the various programming paradigms that were used in development. Most physics-related behavior is based on standard collision detection within the Unity API (e.g. onCollisionEnter2D), and all other physical constants were implemented with the standard Unity API as well (e.g. gravity). 

# PlayerMovement Class

## Variables to define movement
```
//Global variables are well-defined here.

public float speed = 40f;
float horizontalMove = 0f;

bool jump = false;
bool isDead = false;
bool isFinished = false;
```

## Collision Check to see if player hit obstacles or the end coin
```
//A simple boolean collision detection function.
void OnCollisionEnter2D(Collision2D collision)
{
    //Check collision with Obstacles
    if (collision.gameObject.name == "Obstacles")
    {
        isDead = true;
        OnDeath.Invoke();
    }

    //the animator class was used with care here, on account of the absolute value of the horizontal motion being taken in as a parameter.
    //Check collision with Coin for winning/finish line
    if (collision.gameObject.name == "Coin")
    {
        horizontalMove = 0;
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        collision.gameObject.SetActive(false);
        isFinished = true;
        OnFinish.Invoke();
    }
}
```

## Update function called every tick. Used to update controller inputs and if the player fell out of the screen
```
void Update()
{
    //Check if player fell off the screen
    if (circleCollider.bounds.center.y < deathBoundary)
    {
        isDead = true;
        OnDeath.Invoke();
    }

    //negates deltaTime value but works due to speed constant and GetAxisRaw
    if (!isDead && !isFinished)
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * speed;

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        //Jump
        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            animator.SetBool("isJumping", true);
        }
    }
    //See further commentary, but this works
    //Check if player is grounded to reset animation
    if (IsGrounded())
    {
        animator.SetBool("isJumping", false);
    }
}
```
## Function to check if the player is on the ground
```
//could be optimized with: function IsGrounded(): boolean {
//   return Physics.Raycast(transform.position, -Vector3.up, distToGround + 0.1);
// } or a comparable function.
private bool IsGrounded()
{
    float extraHeight = -0.01f;
    RaycastHit2D raycastHit = Physics2D.Raycast(circleCollider.bounds.center, Vector2.down, circleCollider.radius + extraHeight, layerMask);
    Color rayColor;
    if (raycastHit.collider != null)
    {
        rayColor = Color.green;
    }
    else
    {
        rayColor = Color.red;
    }
    Debug.DrawRay(circleCollider.bounds.center, Vector2.down * (circleCollider.radius + extraHeight));
    return raycastHit.collider != null;
}
```

## FixedUpdate function updates every frame to move the player
```
void FixedUpdate()
{
    //used fixedDeltaTime to account for the fact that movement is calculated on a frame-by-frame basis.
    //Move player
    controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
    jump = false;
}
```
# CameraMovement Class

## Class is used to move the camera according to player position
```
public class CameraMovement : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;

    void Update()
    {
    	//the z-axis is only taken as a parameter out of formality here; the offset values apply to the only axes ingame.
        transform.position = new Vector3(player.position.x + offset.x, player.position.y + offset.y, offset.z);
    }
}
```

# SceneLoader Class

## Class is used to change the current scene
```
public class SceneLoader : MonoBehaviour
{
	//Load Main Menu
	public void LoadMenu()
    {
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
	}
	//Load Next Level
	public void LoadGame()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}
	//Reload Current Level
	public void ReloadGame()
    {
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);		
	}
	//Quit Game
	public void QuitGame()
	{
		Application.Quit();
		Debug.Log("Quitting Game");
	}
}
```

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

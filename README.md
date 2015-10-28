# Shortcut Device

This project is based on the [_Huddle Lamp_](https://github.com/huddlelamp/) which was mainly developed and implemented by [_M.Sc. Roman Rädle_](https://github.com/raedle) and [_Dr. Hans-Christian Jetter_](https://github.com/hcjetter). _Shortcut Device_ is implemented within the bachelor thesis in order to achieve the B.Sc. at the University of Applied Sciences Austria.

## Table of contents
- [**Information about the _Huddle Lamp_**](#information)
	- [**Huddle Engine**](#engine)
	- [**JavaScript API**](#api)
	- [**Huddle Orbiter**](#orbiter)
	- [**Demos**](#demos)
- [**Installation**](#installation)
- [**Usage**](#usage)
- [**Shortcut Device**](#device)
	- [**Shortcut Server**](#server)
	- [**ShortcutJs**](#js)
- [**Creator & Tutor**](#creator)

<a name="information"></a>
## Information about the _Huddle Lamp_

> The _Huddle Lamp_ - combining both a desk lamp and a camera - is the attempt to create a new way of interaction between the user and computers such as PCs and mobile devices.  

The built in RGB-D camera precisely tracks smartphones and tablets located within a limited area on a table. Moreover _Huddle Lamp_ observes movements of hands that allows developers to make use of cross-device interaction. Due to a web-based pairing approach users simply have to place a device below the camera and open a URL. This URL forwards them to webpage which uses _Huddle Lamps_ JavaScript API in order to make use of the the new interaction.

<a name="#install_intro"></a>
In order to work with the _Huddle Lamp_ you need to run the _Huddle Engine_ on any server and interact with it through the included JavaScript-API. To be more precise, you run any service that uses JavaScript on either a server or your PC. Next, you connect to the server that runs the _Huddle Engine_ using a JavaScript-API. To get more information about the _Huddle Project_ check out the following links. If you want to get more insight on setting up the environment check out [_Installation_](#installation) and the [_Software-Architecture_](#architecture). I also recommend taking a look at the [_Huddle Engine_](#engine) and the [_Javascript API_](#api)

**More in-depth information about the _Huddle Lamp_:**

- [_Huddle Lamp_ Website](http://huddlelamp.org/)
- [Abstract about _Huddle Lamp_](http://huddlelamp.org/wp-content/uploads/2014/09/HuddleLamp_ITS2014.pdf#viewer.action=download)

---
<a name="engine"></a>
### Huddle Engine

The _Huddle Engine_, running on the _Huddle Vision Server ([_Software-Architecture_](#architecture), is implemented in C# and uses the Windows Presentation Foundation to provide a _User-Interface_. It features different Pipelines allowing the user to adjust the settings of tracking. Furhtermore, it shows different views of the tracked area (i.e. the camera vison) which is quite usefule since different settings can lead to smaller cutouts of the inital tracked area. This of course implicates a more exact tracking of mobile devices. 

Due to the RGB-D camera being a _Time of light camera_, it sends infrared rays to the table. Therefore it is able to track devices because of different reflection of the infrared rays compared to the table. 


**More in-depth information about the engine:**

- [Huddle-Engine](https://github.com/huddlelamp/huddle-engine)

<br/>

---
<a name="api"></a>
### JavaScript API

TODO: Explain what this API is made for and write about its features

**More in-depth information about the API:**

- [Huddle JavaScript API](https://github.com/raedle/meteor-huddle)

<br/>

---
<a name="orbiter"></a>
### Huddle Orbiter

TODO: Write about the Orbiter and the advantages

**More in-depth information about the Huddle Orbiter:**

- [Huddle Orbiter](https://github.com/huddlelamp/huddle-orbiter)

<br/>

---
<a name="demos"></a>
### Demos

Currently there are 2 different demos publicly available. Both of the can be found following the links in the section below.

First off, _Where is Waldo_, implemented according to the books in which readers have to look for Waldo within a detailed double-üage illustrations. The demo features the same function. But in order to find Waldo, the user needs to move the device to be able to look around the illustration.

The second demo functions quite similar to _Where is Waldo_. The user is able to look through a whole map with moving his device.

**More in-depth information about the demos:**

- [Where is Waldo](https://github.com/huddlelamp/where-is-waldo)
- [Map](https://github.com/huddlelamp/demo-app)

<br/>

---
<a name="installation"></a>
## Installation

Check out the [_installation intro_](#install_intro) before continuing reading.

1. Set up the camera
2. Set up the Huddle Engine: In order to do that execute the Visual Studio project that you can get [_here_](https://github.com/huddlelamp/huddle-engine)
2. Change the Engines settings in order to get the best result: This can be achieved through changing different threshholds in the _USer-Interface_ of the Engine
3. Set up your personal webserver: I used Meteor for this purpose
4. Host the webpage on the webserver
5. Start the Key Emulator program (this launches the _User-Interface_ and starts the _Websocket_)
6. Assing open programs (processes) to the 4 different areas  
7. Place your device inside the tracked area and open the URL to your webpage (on your webserver)
8. Use the program ([_Usage_](#usage))

TODO: Include picture "how to assign"

<a name="usage"></a>
## Usage

1. (Re-)Assign programs to the 4 areas
2. Place the phone inside the area that you have assigned to the program, which you want to emulate shortcuts on 
3. If the program is recognized a preset of buttons will be loaded allowing you to increase your efficiency. (e.g. you are listening to youtube; a button f5 will be shown on the device allowing you to refresh the page; [_clue_](#clue))
4. Use the buttons on your device to trigger an Shortcut that will be executed on your computer
5. Move your device to the left to focus the assigned program
6. Move your device to the right to close the assigned program

<a name="clue"></a>
The clue behind that is, that you are able to control programs that are currently not focused, meaning you are  for example working with MsOfffice at the moment although you are controlling the webbrowser and therefore youtube with your device.

TODO: Include picture "how to use"

<a name="device"></a>
## Shortcut Device

<a name="architecture"></a>
![software architecture](/diagram/img/architecture/softwareArchitecture.png)

The _Shortcut Device_ - in this case a tablet - loads the website from the _Huddle Server_. This can be achieved through any built-in browser but 
keep in mind that not every browser may support all of the _JavaScript Features_ used.

TODO: Extend this section
TODO: Explain software-architecture
TODO: Write about the actual project. Provide diagrams, architectures and code

<a name="server"></a>
### Shortcut Server

TODO: Detailed information about the server

<a name="js"></a>
### ShortcutJs

TODO: Detailed information about the web-part of the project

<a name="creator"></a>
## Creator & Tutor

The _Huddle Lamp_ project and its implementation belongs to the creators and owners. The project _Shortcut Device_, using the _Huddle Project_, only includes the webpage, the User-Interface and the Backend (Key-Emulator, Websocket).  I don't claim any rights on both the _Huddle Lamp Project_ and _Meteor_.

**David Magoc**<br/>
I'm currently enrolled at the University of Applied Sciences Upper Austria - Campus Hagenberg. Studying Software Engineering, my main goal is to create user-friendly and efficient software for different needs. I spend my leasure time doing sports, reading and listening to a lot of music.

**Hans Christian Jetter**<br/>
-defaut text-
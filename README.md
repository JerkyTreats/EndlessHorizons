# EndlessHorizons
Endless Horizons is a Unity3D game that allows you to build the interior of a spaceship. Think LEGO meets FTL. 

The player drag and drops _Ship Components_ onto a grid, you build the shape of your Spaceship. 

Endless Horizons is a prototype in very early stages of development- meaning it doesn't get updated all that often, and can be a bit ugly. 

## Features

The following links to some of the various features developed for Endless Horizons. The list is roughly ordered by how recently devleopment work has gone into it. Each link contains a short description of the feature, its path in the codebase, and any interesting technical notes related to the feature.
  
- [Ship Blueprints](https://github.com/JerkyTreats/EndlessHorizons/wiki/Blueprints)
- [Ship Components](https://github.com/JerkyTreats/EndlessHorizons/wiki/Ship-Components)
- [UI](https://github.com/JerkyTreats/EndlessHorizons/wiki/UI) 
- [Grid](https://github.com/JerkyTreats/EndlessHorizons/wiki/Grid)

## Code Structure

The primary design pattern for Endless Horizons is to follow a MVC design pattern. The unity `Game Obect` represents the View, the added `MonoBehavior` acts as the Controller, which accesses and manipulates data contained in a Model class. The intent is to allow for unit tests on the Models, and eventually integration tests for the Controller. That's the intent, anyways. 

You can see this code structure in practice in `Assets/Workshop/Grid`:
- `Grid` : A `MonoBehavior` that acts as the controller. 
  - Holds a private reference to a `GridData` Model. 
  - Has public methods for outside objects to interact with the Grid. Outside objects should rarely interact with the Model itself.
  - Usually has an `Initialize` function. Monobehaviors do not have a constructor, and the `Start()` function does not allow parameters. This function acts as parameterized `Start()` function
- `GridData` : A pure C# object representing the Model for the Grid object. 
  - **Note**: The naming convention has been changed. Instead of `GridData`, it should be `Grids`, and contained in a `Models` folder.
  - Often has JSON de/serialization code to convert class data into JSON and vice-versa. 
- `Grid.json` : Magic numbers and configurable data is stored in a JSON object. This is to allow for eventual CMS integration.
- `GridFactory` : Static class to create the Grid object. 
  - This is especially important since Monobehaviours don't have parameterized startup functionality. 
  - The Factory class will assign, arrange, and return properly the properly configured Game Object. 

The root folder for game code is in `ShipDesigner/Assets`. The following will explain the various folders found in root.

### Engine

Engine contains core code, utility/helpers that can be used anywhere in the code, and data management stuff. Not to be confused with `UnityEngine`

- `GameInitializer` : Game Object component that acts as an entry point for the entire game. Constructs all necessary inital game objects and state.
- `GameData` : Singleton object containing global game data. This includes:
  - `Grid` : The grid object the player drops components on
  - `Canvas` : The UI Canvas object (all UI elements are a child of the Canvas object)   
  - `Blueprint` : The _Ship_ the user is currently working on 
- `DataRepository` : Contains game specific data models. Many data models store data on disk as JSON files. Some Models may have a folder containing several JSON files representing instances of a single Model. Those files are read once, converted into it's Model class, then added as a DataRepository object. 
- `Utility` : Helpers and common tasks abstracted into a Utility class

### Game

Contains gameplay specific code.

- `Company` and `Planet` are considered placeholder code at this time
- `Ships` : Contains all components required to build and save the Ship Interior
  - Visit the [Components Wiki](https://github.com/JerkyTreats/EndlessHorizons/wiki/Ship-Components)
  - Visit the [Blueprints Wiki](https://github.com/JerkyTreats/EndlessHorizons/wiki/Blueprints)

### Resources

Resources is a special folder recognized by the UnityEngine. It allows for easy access to various files. For Endless Horizons, it contains Sprite data and Prefabs.

### View

Contains Camera components and related data. 

### Workshop 

Contains the Grid and the tools to manipulate the Ship. 

- `Grid` : The grid that the player drops ship components onto
- `UI` : Contains UI elements for the Workshop tools.
  - `Inventory` : A UI panel holding Ship Components to drag and drop onto the Grid. 
    - **NOTE**: This only contains what the Panel looks like and how the UI elements should behave. The actual component data is driven from the `Game/Ships/Components` code.


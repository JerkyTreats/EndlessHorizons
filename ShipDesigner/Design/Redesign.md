
# Tech Redesign

- Continue ECS Training
- Rework current tech to be ECS Compliant
- Rework current tech to make some sense

## Ship Tech Redesign

The Tile logic is a mess. Need to rework into something more easily managed.

To this end:

- Top Level is Ship
- Ship contains Decks
- Decks contains Floor<Tile> and Walls<Wall> and Furniture<ShipItems>
- Move to a Layering strategy
  - Walls drive design of Deck
  - Floor is generated based on Walls
  - Walls are drawn on top of Floor, with slight offset

# Components

## Walls

Walls have Sections. Default wall section length defined by Tile Length/Width

### Wall Section

- Length
- Width
- RenderComponent
- CollisionBox?
- ConnectedTiles
  - List of Refs to Tiles
  - Tiles which have a connection to this Wall Section
  - Exterior WallSections have only one connected Tile
  - All WallSections need at least one Tile connected

### Wall

- WallSections HashMap
  - Key: WallSectionID
  - Value: Array of WallSectionID
- Corners?

## Tiles

Tiles make up a floor

- Length
- Width
- RenderComponent
- Edges (HashMap)
  - Tiles have 4 edges
    - Each Edge is Key
  - Each edge can have Ref attached as Value:
    - Walls
    - Neighboring Tiles
    - RoomItems

# Systems 

## Expand Room(?)

Design Requirement: When you select a WallSection, cycle through Walls attached, from Shortest to Longest. 

## Find WallSection Neighbors

Returns data necessary to create a Wall
Input: WallSection

1. Get Associated Tiles for Input
    1. Handle Interior Wall?
2. Get Neighbor Tiles from Associated Tiles
3. Foreach Neighboring Tile, Get attached WallSections
4. If WallSection is on same edge as Input WallSection, add to Returning Object
5. Return WallSections along same Axis. Either as a Wall or object to turn into a Wall .
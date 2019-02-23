# Tiles and Rooms

A room contains a collection of Tiles; Components; And Manipulation Tools/Widgets

## Tiles have Edges

- Each Edge can have an object
  - Internal/External Wall
  - Door
  - Window
- Tile has a render component
- Tile locations can be saved to disk

## Room

- A room instantiates with a number of Tiles. 4x4 to start.
- Starter Rooms appear in the Inventory UI widget, can be drag and dropped onto the world.
- A room has a Manipulation Widget
  - Drag to resize the Room
  - Stop along Axis if collides with another room
- Components can be dragged onto a Room
  - Interior Components such as chairs/etc.
  - Wall components such Windows/Doors
  - Components will Snap to Appropriate Componenet Area
    - A door will snap to Walls during placement
- Components can be modified
  - Can move a Door or other object after placement

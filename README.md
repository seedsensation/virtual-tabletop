# Virtual Tabletop Project

The idea of the project is to create a virtual tabletop - in the vein of Foundry, Alchemy, Roll20, etc. - with the ability to create new systems with ease.
To do so, we will create a system creator in Godot - allowing you to create custom character sheets, and set the overarching dice system.

## Requirements
- [ ] System Class
    - [ ] Character Sheet Class
    - [ ] Data Storage
- [ ] Character Sheet Editor
- [ ] Dice Rolling
    - [X] Basic rolling functionality
    - [ ] Custom DX functionality
    - [ ] Custom + and - from total roll
    - [ ] Multiple dice systems available
    - [ ] Make it look pretty
- [ ] UI that makes everything accessible

## Storage System
- Folders for systems (including character sheet templates and additional system data), and for worlds (individual games, with specific tokens and character sheets)
- Sheets (templates and character sheets) stored as JSON data 
- Sheets stored using IDs rather than names

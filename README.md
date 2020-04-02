# MapsNavigation

Calculates how many blocks away a destination is given certain directions

Problem description: 
You're airdropped near Headquarters in a city somewhere. "Near", unfortunately, is as close as you can get - the instructions on you map start here. The Document indicates that you should start at the given coordinates (where you just landed) and face North. Then, follow the provided sequence: either turn left (L) or right (R) 90 degrees, then walk forward the given number of blocks, ending at a new intersection. There's no time to follow such ridiculous instructions on foot, though, so you take a moment and work out the destination. Given that you can only walk on the street grid of the city, how far is the shortest path to the destination? For example: Following R2, L3 leaves you 2 blocks East and 3 blocks North, or 5 blocks away. R2, R2, R2 leaves you 2 blocks due South of your starting position, which is 2 blocks away. R5, L5, R5, R3 leaves you 12 blocks away. How many blocks away is HQ?

Domain: Maps Navigation<br/>
Platform: .NET<br/>
Interface: Native GUI (WPF)<br/>
Backend: C#

User inputs a comma deliminated string for directions and then clicks the button.<br/>App will then calculate the total distance, and how many blocks north/south and east/west you have to go.

All directions must be formatted the following way:<br/>
First character has to be one of (L, R, N, E, S, W), this indicates the direction.<br/>N E S W indicate the cardinal directions and will move that way,<br/>L and R indicate relative directions and will be either a (L)eft or (R)ight turn from the current direction you are facing.

After the first character the remainder of the string must be an integer, this integer indicates distance you will travel in that direction.

Examples Directions:<br/>
L10 = Turn left and go 10 blocks forward<br/>
N3 = Turn north and go 3 blocks forward<br/>
W-21 = Turn west and go 21 blocks backward<br/>

Example Inputs with Output:<br/>
R2, L3<br/>
Total Distance: 5<br/>
Blocks North: 3<br/>
Blocks East: 2<br/>
Last Facing: North

R2, R2, R2<br/>
Total Distance: 2<br/>
Blocks North: -2<br/>
Blocks East: 2<br/>
Last Facing: West<br/>

R5, L5, R5, R3<br/>
Total Distance: 12<br/>
Blocks North: 2<br/>
Blocks East: 10<br/>
Last Facing: South<br/>

L3, R2, L5, R1, L1, L2<br/>
Total Distance: 10<br/>
Blocks North: 1<br/>
Blocks East: -9<br/>
Last Facing: South

E0, R10, S3, R5, W3, W-2, L2, L1<br/>
Total Distance: 20<br/>
Blocks North: -15<br/>
Blocks East: -5<br/>
Last Facing: East

L3, R2, L5, R1, L1, L2, L2, R1, R5, R1, L1, L2, R2, R4, L4, L3, L3, R5, L1, R3, L5, L2, R4, L5, R4, R2, L2, L1, R1, L3, L3, R2, R1, L4, L1, L1, R4, R5, R1, L2, L1, R188, R4, L3, R54, L4, R4, R74, R2, L4, R185, R1, R3, R5, L2, L3, R1, L1, L3, R3, R2, L3, L4, R1, L3, L5, L2, R2, L1, R2, R1, L4, R5, R4, L5, L5, L4, R5, R4, L5, L3, R4, R1, L5, L4, L3, R5, L5, L2, L4, R4, R4, R2, L1, L3, L2, R5, R4, L5, R1, R2, R5, L2, R4, R5, L2, L3, R3, L4, R3, L2, R1, R4, L5, R1, L5, L3, R4, L2, L2, L5, L5, R5, R2, L5, R1, L3, L2, L2, R3, L3, L4, R2, R3, L1, R2, L5, L3, R4, L4, R4, R3, L3, R1, L3, R5, L5, R1, R5, R3, L1<br/>
Total Distance: 209<br/>
Blocks North: 78<br/>
Blocks East: -131<br/>
Last Facing: West

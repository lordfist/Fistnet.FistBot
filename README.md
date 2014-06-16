# FistBot - Robocode bot based on Genetic Algorithm in .NET

** FistBot ** is genetic algorithm based bot builder written for .NET, it is unfortunatly quite slow but does the job :)

Usage:

1. Download Robocode + Robocode .net from http://robocode.sourceforge.net/
2. Constants change in code
  - Navigate to FistBot.cs file and find this (in FistBot project):
```
public const string ROBOT_DATA_FILE = "H:\\Robocode\\robots\\.data\\Fistnet\\FistBot\\active.txt";
```
  - change the H:\Robocode\ to folder you installed Robocode
  - Navigate to Util.cs (in StrategyBuilder project root) and find this: 
```
 public const string ROBOCODE_FOLER = "H:\\Robocode";
```
  - change the H:\Robocode\ to folder you installed Robocode 
  - rebuild solution (you will have to do the first one because of restrictions that Robocode has, robots cannot read .config files, the second one is my lazyness ;) )
 
3. Copy FistBot binaries to ../robocode/robots
4. Copy bin/debug (or release) of StrategyBuilder to ../robocode/libs (this is important, for some unknown reason you cannot run the RobocodeEngine even with defined paths if your .exe file is not in robocode/libs)
5. Create database from FistBotDB.txt
6. Update Fistnet.FistBot.StrategyBuilder.exe.config with correct connection string
7. Run Fistnet.FistBot.StrategyBuilder.exe 
8. Click "Load robots"
9. Pick robots you wish to fight against, also remember to set GA stuff (generation count - number of generations to run, population count - number of battles/different bots to run per generation and rounds per battle)
10. Click "Run battles" :)
11. Profit! (after few days hehe)

Note that one battle takes some time, this has nothing to do with bot optimization as fas as I know but rather with loading java RobocodeEngie from .NET
**Also note that this might have bugs in it :), since I am *not* a good bot writer :) **

EXTERNAL DrinkRecieved(drinkNum)

-> bartender_menu

=== bartender_menu ===
What would you like to drink?

+ [I want a Green Hallucination]
    ~DrinkRecieved(3)
    -> Green
+ [I want a Directory bourbon]
     ~DrinkRecieved(2)
    -> Direct
+ [I want a Cerebral Zip Bomb]
    ~DrinkRecieved(0)  
    -> Zip
+ [I want one Automation Blues]
    ~DrinkRecieved(1)  
    -> Blue
    
=== Green ===
Here's your Green Hallucination.
-> END
=== Direct ===
Here's your Directory bourbon.
-> END
=== Zip ===
Here's your Cerebral Zip Bomb.
-> END
=== Blue ===
Here's your Automation Blues.
-> END
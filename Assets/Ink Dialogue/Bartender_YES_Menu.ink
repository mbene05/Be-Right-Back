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
+ [Can I use your employee keycard?]
    -> keycard_answer
+ [I don't want anything to drink]
    -> leave_answer
    
=== Green ===
Here's your Green Hallucination, sir.
-> END
=== Direct ===
Here's your Directory bourbon, sir.
-> END
=== Zip ===
Here's your Cerebral Zip Bomb, sir.
-> END
=== Blue ===
Here's your Automation Blues, sir.
-> END
=== keycard_answer ===
I don't have one available for you, sir.
Maybe the chef will let you use his.
-> END

=== leave_answer ===
Have a good evening sir.
-> END
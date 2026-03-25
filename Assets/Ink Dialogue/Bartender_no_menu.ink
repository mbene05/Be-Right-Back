-> bartender_nomenu

=== bartender_nomenu ===
What would you like to drink?

+ [I don't know, what do you have?]
    -> menu_answer

+ [Can I use your employee keycard?]
    -> keycard_answer
    
+ [I don't want anything to drink]
    -> leave_answer
    
=== menu_answer ===
The available drinks are in the drink menu at your table, sir.
-> END

=== keycard_answer ===
I don't have one available for you, sir.
Maybe the chef will let you use his.
-> END

=== leave_answer ===
Have a good evening sir.
-> END
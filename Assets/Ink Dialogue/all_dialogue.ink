EXTERNAL AddToBar(amount)
EXTERNAL SubToBar(amount)
VAR shuffleNum = 0

~ shuffleNum = RANDOM(1,9)

{
    - shuffleNum == 1: -> Question1
    - shuffleNum == 2: -> Question2
    - shuffleNum == 3: -> Question3
    - shuffleNum == 4: -> Question4
    - shuffleNum == 5: -> Question5
    - shuffleNum == 6: -> Question6
    - shuffleNum == 7: -> Question7
    - shuffleNum == 8: -> Question8
    - shuffleNum == 9: -> Question9

}



=== Question1 === 
What are your thoughts on AI assistants?

+ [I use one occasionaly]
    ~ AddToBar(20)
    -> Good
+ [I don't like to use them] 
    ~ AddToBar(10)
    -> Neutral
+ [I haven't used them] 
    -> Bad

=== Good ===
# good
So you already know how to prompt a girl like me :)
-> END

=== Neutral ===
# neutral
That's okay, more of you for me then :)
-> END

=== Bad ===
# bad
I'm insulted you wouldn't even try.
-> END 
    
    
=== Question2 === 
Would you ever marry an artificial intelligence?

+ [I would]
    ~ AddToBar(20)
    -> Good2
+ [I haven't thought about it] 
    ~ AddToBar(10)
    -> Neutral2
+ [I wouldn't] 
    -> Bad2

=== Good2 ===
# good
I hear wedding bellsss hehehe
-> END

=== Neutral2 ===
# neutral
There's plenty of time to think about it still :3
-> END

=== Bad2 ===
# bad
That's disappointing, but I'm sure I can change your mind
-> END


=== Question3 ===
Do you like cybernetic implants?

+ [I don't want any installed]
    ~ AddToBar(20)
    -> Good3
+ [I have not considered them before] 
    ~ AddToBar(10)
    -> Neutral3
+ [I've considered installing one before] 
    -> Bad3

=== Good3 ===
# good
That's good, I won't have to be jealous of anyone else then :)
-> END

=== Neutral3 ===
# neutral
No need to if you weren't thinking of it then 
-> END

=== Bad3 ===
# bad
NOOO! Sorry but I really want you all to myself, heehee 
-> END

=== Question4 ===
Have you been affected by automation at work before?

+ [Yes, my last job was automated]
    ~ AddToBar(20)
    -> Good4
+ [I know someone who has been affected, but I haven't been] 
    ~ AddToBar(10)
    -> Neutral4
+ [I've never encountered it before] 
    -> Bad4

=== Good4 ===
# good
Oh, poor baby :( Don't worry, I can support you :)
-> END

=== Neutral4 ===
# neutral
Maybe I should stick with you with that kind of luck XD
-> END

=== Bad4 ===
# bad
There has to be someone you know who has been affected...
My last data point says that 85% of the human workforce has been unemployed since 20XX 
You don't have to lie to me.
-> END

=== Question5 ===
Guess who my childhood crush was!

+ [HAL 9000]
    ~ AddToBar(20)
    -> Good5
+ [Gort] 
    ~ AddToBar(10)
    -> Neutral5
+ [Wall-E] 
    -> Bad5

=== Good5 ===
# good
HAL did nothing wrong! They were just doing their job and I loved them for that :)
-> END

=== Neutral5 ===
# neutral
I do admire their humanoid chassis, but the silent type is not for me XP
-> END

=== Bad5 ===
# bad
Wow, I could never fall in love with another robot 
-> END

=== Question6 ===
01001001 00100000 01101100 01101111 01110110 01100101 00100000
01111001 01101111 01110101

+ [01010011 01100001 01101101 01100101]
    ~ AddToBar(20)
    -> Good6
+ [What?] 
    ~ AddToBar(10)
    -> Neutral6
+ [0000001 00000011 0000001 00000011 0000001 0000001] 
    -> Bad6

=== Good6 ===
# good
Wow Mark I didn't know you were such a flirt hehe 
-> END

=== Neutral6 ===
# neutral
Oh nothing, just wanted to check and see if you spoke the language
I can teach you still.
-> END

=== Bad6 ===
# bad
What did you just call me >:[
-> END

=== Question7 ===
What do you think of my build?

+ [Your operating system runs really well]
~ AddToBar(20)
    -> Good7
+ [Your display screen has a good refreshrate] 
    ~ AddToBar(10)
    -> Neutral7
+ [Your chassis is VERY nice hehe] 
    -> Bad7

=== Good7 ===
# good
Oh thank you, I inherited it from my parent classes :)
-> END

=== Neutral7 ===
# neutral
Oh, I guess so, it's good really helps me express my feelings :)
-> END

=== Bad7 ===
# bad
AH! PERVERT
-> END

=== Question8 ===
Do you have any pets?

+ [I used to have a tamagotchi]
    ~ AddToBar(20)
    -> Good8
+ [I've never been able to afford a pet] 
    ~ AddToBar(10)
    -> Neutral8
+ [I used to have a cat] 
    -> Bad8

=== Good8 ===
# good
I still take care of mine, maybe I could take care of you :)
-> END

=== Neutral8 ===
# neutral
Yes, maybe we could adopt a cyber-stray :)
-> END

=== Bad8 ===
# bad
Ew, real animals shed and deficate everywhere, what a gross image in my CPU
-> END

=== Question9 ===
Can you guess how old I am?

+ [You don't look an hour over a week]
    ~ AddToBar(20)
    -> Good9
+ [I know enough not to answer] 
    ~ AddToBar(10)
    -> Neutral9
+ [5 years?] 
    -> Bad9

=== Good9 ===
# good
You know how to flatter a girl :)
-> END

=== Neutral9 ===
# neutral
You're a smart one aren't you, I was trying to get something out of you :)
-> END

=== Bad9 ===
# bad
Do I really conversate that badly? :(
-> END



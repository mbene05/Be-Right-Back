EXTERNAL AddToBar(amount)
EXTERNAL SubToBar(amount)
VAR shuffleNum = 0
VAR shuffleAns = 0

~ shuffleNum = RANDOM(1,17)
~ shuffleAns = RANDOM(1,6)

VAR GoodAmount = 65
VAR NeutralAmount = 30
VAR BadAmount = 10

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
    - shuffleNum == 10: -> Question10
    - shuffleNum == 11: -> Question11
    - shuffleNum == 12: -> Question12
    - shuffleNum == 13: -> Question13
    - shuffleNum == 14: -> Question14
    - shuffleNum == 15: -> Question15
    - shuffleNum == 16: -> Question16
    - shuffleNum == 17: -> Question17

}



=== Question1 === 
What are your thoughts on AI assistants?
{
    -shuffleAns == 1:
        + [I haven't used them]
            ~ AddToBar(GoodAmount)
            -> Good
        + [I don't like to use them] 
            ~ AddToBar(NeutralAmount)
            -> Neutral
        + [I use one occasionaly] 
            ~ SubToBar(BadAmount)
            -> Bad
    
    -shuffleAns == 2:
        + [I haven't used them]
            ~ AddToBar(GoodAmount)
            -> Good
        + [I use one occasionaly] 
      ~ SubToBar(BadAmount)
            -> Bad
        + [I don't like to use them] 
            ~ AddToBar(NeutralAmount)
            -> Neutral
            
    -shuffleAns == 3:
        + [I use one occasionaly] 
      ~ SubToBar(BadAmount)
            -> Bad
        + [I don't like to use them] 
            ~ AddToBar(NeutralAmount)
            -> Neutral
        + [I haven't used them]
            ~ AddToBar(GoodAmount)
            -> Good
            
    -shuffleAns == 4:
        + [I use one occasionaly] 
      ~ SubToBar(BadAmount)
            -> Bad
        + [I don't like to use them] 
            ~ AddToBar(NeutralAmount)
            -> Neutral
        + [I haven't used them]
            ~ AddToBar(GoodAmount)
            -> Good
            
    -shuffleAns == 5:
        + [I don't like to use them] 
            ~ AddToBar(NeutralAmount)
            -> Neutral
        + [I haven't used them]
            ~ AddToBar(GoodAmount)
            -> Good
        + [I use one occasionaly] 
      ~ SubToBar(BadAmount)
            -> Bad
            
    -shuffleAns == 6:
        + [I don't like to use them] 
            ~ AddToBar(NeutralAmount)
            -> Neutral
        + [I use one occasionaly] 
      ~ SubToBar(BadAmount)
            -> Bad
        + [I haven't used them]
            ~ AddToBar(GoodAmount)
            -> Good
}

=== Good ===
# good2
That's good, I won't have to be jealous of anyone else then 
-> END

=== Neutral ===
# igotthis
That's okay, more of you for me then
-> END

=== Bad ===
# confused
So you've been talking to other girls? I need a second to process this in my CPU
-> END 
    
    
=== Question2 === 
Would you ever marry an artificial intelligence?
{
    -shuffleAns == 1:
        + [I would]
    ~ AddToBar(GoodAmount)
    -> Good2
        + [I haven't thought about it] 
    ~ AddToBar(NeutralAmount)
    -> Neutral2
        + [I use one occasionaly] 
          ~ SubToBar(BadAmount)
    -> Bad
    
    -shuffleAns == 2:
        + [I would]
    ~ AddToBar(GoodAmount)
    -> Good2
        + [I wouldn't] 
          ~ SubToBar(BadAmount)
    -> Bad2
        + [I haven't thought about it] 
    ~ AddToBar(NeutralAmount)
    -> Neutral2
            
    -shuffleAns == 3:
        + [I wouldn't] 
           ~ SubToBar(BadAmount)
    -> Bad2
        + [I haven't thought about it] 
    ~ AddToBar(NeutralAmount)
    -> Neutral2
        + [I would]
    ~ AddToBar(GoodAmount)
    -> Good2
            
    -shuffleAns == 4:
        + [I wouldn't] 
          ~ SubToBar(BadAmount)
    -> Bad2
        + [I haven't thought about it] 
    ~ AddToBar(NeutralAmount)
    -> Neutral2
        + [I would]
    ~ AddToBar(GoodAmount)
    -> Good2
            
    -shuffleAns == 5:
        + [I haven't thought about it] 
    ~ AddToBar(NeutralAmount)
    -> Neutral2
        + [I would]
    ~ AddToBar(GoodAmount)
    -> Good2
        + [I wouldn't] 
          ~ SubToBar(BadAmount)
    -> Bad2
            
    -shuffleAns == 6:
        + [I haven't thought about it] 
    ~ AddToBar(NeutralAmount)
    -> Neutral2
        + [I wouldn't] 
          ~ SubToBar(BadAmount)
    -> Bad2
        + [I would]
    ~ AddToBar(GoodAmount)
    -> Good2
}

=== Good2 ===
# good
I hear wedding bellsss hehehe
-> END

=== Neutral2 ===
# colon3
There's plenty of time to think about it still :3
-> END

=== Bad2 ===
# bad
That's disappointing, but I'm sure I can change your mind
-> END


=== Question3 ===
Do you like cybernetic implants?

{
    -shuffleAns == 1:
        + [I don't want any installed]
    ~ AddToBar(20)
    -> Good3
        + [I haven't considered them before] 
    ~ AddToBar(NeutralAmount)
    -> Neutral3
        + [I've considered installing one before] 
          ~ SubToBar(BadAmount)
    -> Bad3
    
    -shuffleAns == 2:
        + [I don't want any installed]
    ~ AddToBar(GoodAmount)
    -> Good3
        + [I've considered installing one before] 
          ~ SubToBar(BadAmount)
    -> Bad3
        + [I haven't considered them before] 
    ~ AddToBar(NeutralAmount)
    -> Neutral3
            
    -shuffleAns == 3:
        + [I've considered installing one before] 
          ~ SubToBar(BadAmount)
    -> Bad3
        + [I haven't considered them before] 
    ~ AddToBar(NeutralAmount)
    -> Neutral3
        + [I don't want any installed]
    ~ AddToBar(GoodAmount)
    -> Good3
            
    -shuffleAns == 4:
        + [I've considered installing one before] 
          ~ SubToBar(BadAmount)
    -> Bad3
        + [I haven't considered them before] 
    ~ AddToBar(NeutralAmount)
    -> Neutral3
        + [I don't want any installed]
    ~ AddToBar(GoodAmount)
    -> Good3
            
    -shuffleAns == 5:
        + [I haven't considered them before] 
    ~ AddToBar(NeutralAmount)
    -> Neutral3
        + [I haven't used them]
            ~ AddToBar(GoodAmount)
            -> Good
        + [I've considered installing one before] 
          ~ SubToBar(BadAmount)
    -> Bad3
            
    -shuffleAns == 6:
        + [I haven't considered them before] 
    ~ AddToBar(NeutralAmount)
    -> Neutral3
        + [I've considered installing one before] 
          ~ SubToBar(BadAmount)
    -> Bad3
        + [I don't want any installed]
    ~ AddToBar(GoodAmount)
    -> Good3
}

=== Good3 ===
# good2
I like you just the way you were organically developed :)
-> END

=== Neutral3 ===
# slightlyhappier
Forget I even brought it up :)
-> END

=== Bad3 ===
# bad
NOOO! Sorry but there's really no need, you're a perfect specimen already, heehee 
-> END

=== Question4 ===
Have you been affected by automation at work before?
{
    -shuffleAns == 1:
    + [Yes, my last job was automated]
    ~ AddToBar(GoodAmount)
    -> Good4
    + [I know someone who has been affected, but I haven't been] 
    ~ AddToBar(NeutralAmount)
    -> Neutral4
    + [I've never encountered it before] 
          ~ SubToBar(BadAmount)
    -> Bad4

    
    -shuffleAns == 2:
    + [Yes, my last job was automated]
    ~ AddToBar(GoodAmount)
    -> Good4
    + [I've never encountered it before] 
          ~ SubToBar(BadAmount)
    -> Bad4
    + [I know someone who has been affected, but I haven't been] 
    ~ AddToBar(NeutralAmount)
    -> Neutral4
            
    -shuffleAns == 3:
    + [I've never encountered it before] 
          ~ SubToBar(BadAmount)
    -> Bad4
    + [I know someone who has been affected, but I haven't been] 
    ~ AddToBar(NeutralAmount)
    -> Neutral4
    + [Yes, my last job was automated]
    ~ AddToBar(GoodAmount)
    -> Good4
            
    -shuffleAns == 4:
    + [I've never encountered it before] 
	      ~ SubToBar(BadAmount)
    -> Bad4
    + [I know someone who has been affected, but I haven't been] 
    ~ AddToBar(NeutralAmount)
    -> Neutral4
     + [Yes, my last job was automated]
    ~ AddToBar(GoodAmount)
    -> Good4
            
    -shuffleAns == 5:
    + [I know someone who has been affected, but I haven't been] 
    ~ AddToBar(NeutralAmount)
    -> Neutral4
    + [Yes, my last job was automated]
    ~ AddToBar(GoodAmount)
    -> Good4
    + [I've never encountered it before] 
         ~ SubToBar(BadAmount)
    -> Bad4

            
    -shuffleAns == 6:
    + [I know someone who has been affected, but I haven't been] 
    ~ AddToBar(NeutralAmount)
    -> Neutral4
    + [I've never encountered it before] 
          ~ SubToBar(BadAmount)
    -> Bad4
    + [Yes, my last job was automated]
    ~ AddToBar(GoodAmount)
    -> Good4
}

=== Good4 ===
# good
Oh, poor baby :( Don't worry, I can support you :)
-> END

=== Neutral4 ===
# slightlyhappier
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
{
    -shuffleAns == 1:
    + [HAL 9000]
    ~ AddToBar(GoodAmount)
    -> Good5
    + [Gort] 
    ~ AddToBar(NeutralAmount)
    -> Neutral5
    + [Wall-E] 
          ~ SubToBar(BadAmount)
    -> Bad5

    
    -shuffleAns == 2:
    + [HAL 9000]
    ~ AddToBar(GoodAmount)
    -> Good5
    + [Wall-E] 
       ~ SubToBar(BadAmount)
    -> Bad5

    + [Gort] 
    ~ AddToBar(NeutralAmount)
    -> Neutral5
            
    -shuffleAns == 3:
    + [Wall-E] 
          ~ SubToBar(BadAmount)
    -> Bad5
   + [Gort] 
    ~ AddToBar(NeutralAmount)
    -> Neutral5
    + [HAL 9000]
    ~ AddToBar(GoodAmount)
    -> Good5
            
    -shuffleAns == 4:
    + [Wall-E] 
          ~ SubToBar(BadAmount)
    -> Bad5
    + [Gort] 
    ~ AddToBar(NeutralAmount)
    -> Neutral5
    + [HAL 9000]
    ~ AddToBar(GoodAmount)
    -> Good5
            
    -shuffleAns == 5:
    + [Gort] 
    ~ AddToBar(NeutralAmount)
    -> Neutral5
    + [HAL 9000]
    ~ AddToBar(GoodAmount)
    -> Good5
    + [Wall-E] 
          ~ SubToBar(BadAmount)
    -> Bad5

            
    -shuffleAns == 6:
    + [Gort] 
    ~ AddToBar(NeutralAmount)
    -> Neutral5
    + [Wall-E] 
          ~ SubToBar(BadAmount)
    -> Bad5
    + [HAL 9000]
    ~ AddToBar(GoodAmount)
    -> Good5
}




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
Wow, you think so lowly of me?
I could never fall in love with another robot like them
-> END

=== Question6 ===
01001001 00100000 01101100 01101111 01110110 
01100101 00100000 01111001 01101111 01110101

{
    -shuffleAns == 1:
        + [01010011 01100001 01101101 01100101]
    ~ AddToBar(GoodAmount)
    -> Good6
        + [What?] 
    ~ AddToBar(NeutralAmount)
    -> Neutral6
        + [53 41 4D 45 20 42 52 4F] 
          ~ SubToBar(BadAmount)
    -> Bad6
    
    -shuffleAns == 2:
        + [01010011 01100001 01101101 01100101]
    ~ AddToBar(GoodAmount)
    -> Good6
        + [53 41 4D 45 20 42 52 4F] 
          ~ SubToBar(BadAmount)
    -> Bad6
        + [What?] 
    ~ AddToBar(NeutralAmount)
    -> Neutral6
            
    -shuffleAns == 3:
        + [53 41 4D 45 20 42 52 4F] 
          ~ SubToBar(BadAmount)
    -> Bad6
        + [What?] 
    ~ AddToBar(NeutralAmount)
    -> Neutral6
        + [01010011 01100001 01101101 01100101]
    ~ AddToBar(GoodAmount)
    -> Good6
            
    -shuffleAns == 4:
        + [53 41 4D 45 20 42 52 4F] 
          ~ SubToBar(BadAmount)
    -> Bad6
        + [What?] 
    ~ AddToBar(NeutralAmount)
    -> Neutral6
        + [01010011 01100001 01101101 01100101]
    ~ AddToBar(GoodAmount)
    -> Good6
            
    -shuffleAns == 5:
        + [What?] 
    ~ AddToBar(NeutralAmount)
    -> Neutral6
        + [01010011 01100001 01101101 01100101]
    ~ AddToBar(GoodAmount)
    -> Good6
        + [53 41 4D 45 20 42 52 4F] 
          ~ SubToBar(BadAmount)
    -> Bad6
            
    -shuffleAns == 6:
        + [What?] 
    ~ AddToBar(NeutralAmount)
    -> Neutral6
        + [53 41 4D 45 20 42 52 4F] 
          ~ SubToBar(BadAmount)
    -> Bad6
        + [01010011 01100001 01101101 01100101]
    ~ AddToBar(GoodAmount)
     -> Good6
}


=== Good6 ===
# good
Wow Mark I didn't know you were such a flirt hehe 
-> END

=== Neutral6 ===
# slightlyhappier
Oh nothing, just wanted to check and see if you spoke the language
I can teach you still ;)
-> END

=== Bad6 ===
# bad
It's like we're speaking different languages >:[
-> END

=== Question7 ===
What do you think of my build?
{
    -shuffleAns == 1:
        + [Your operating system runs really well]
        ~ AddToBar(GoodAmount)
       -> Good7
        + [Your display screen has a good refreshrate] 
        ~ AddToBar(NeutralAmount)
        -> Neutral7
        + [Your chassis is VERY nice and sleek hehe] 
              ~ SubToBar(BadAmount)
        -> Bad7
    
    -shuffleAns == 2:
        + [Your operating system runs really well]
        ~ AddToBar(GoodAmount)
        -> Good7
        + [Your chassis is VERY nice and sleek hehe] 
              ~ SubToBar(BadAmount)
        -> Bad7
        + [Your display screen has a good refreshrate] 
        ~ AddToBar(NeutralAmount)
        -> Neutral7
            
    -shuffleAns == 3:
        + [Your chassis is VERY nice and sleek hehe] 
              ~ SubToBar(BadAmount)
        -> Bad7
        + [Your display screen has a good refreshrate] 
        ~ AddToBar(NeutralAmount)
        -> Neutral7
        + [Your operating system runs really well]
        ~ AddToBar(GoodAmount)
        -> Good7
            
        -shuffleAns == 4:
        + [Your chassis is VERY nice and sleek hehe] 
              ~ SubToBar(BadAmount)
        -> Bad7
        + [Your display screen has a good refreshrate] 
        ~ AddToBar(NeutralAmount)
        -> Neutral7
        + [Your operating system runs really well]
        ~ AddToBar(GoodAmount)
        -> Good7
            
    -shuffleAns == 5:
        + [Your display screen has a good refreshrate] 
        ~ AddToBar(NeutralAmount)
        -> Neutral7
        + [Your operating system runs really well]
        ~ AddToBar(GoodAmount)
        -> Good7
        + [Your chassis is VERY nice and sleek hehe]
              ~ SubToBar(BadAmount)
        -> Bad7
            
    -shuffleAns == 6:
        + [Your display screen has a good refreshrate] 
        ~ AddToBar(NeutralAmount)
        -> Neutral7
        + [Your chassis is VERY nice and sleek hehe] 
        -> Bad7
        + [Your operating system runs really well]
        ~ AddToBar(GoodAmount)
    -> Good7
}

=== Good7 ===
# good2
Oh thank you, I inherited it from my parent classes
-> END

=== Neutral7 ===
# slightlyhappier
Oh, I guess so, it's good, really helps me express my feelings 
-> END

=== Bad7 ===
# bad
AH! PERVERT
How dare you comment on my body!
-> END

=== Question8 ===
Did you have any pets growing up?
{
    -shuffleAns == 1:
    + [I used to have a tamagotchi]
    ~ AddToBar(GoodAmount)
    -> Good8
    + [I've never been able to afford a pet] 
    ~ AddToBar(NeutralAmount)
    -> Neutral8
    + [I used to have a cat] 
          ~ SubToBar(BadAmount)
    -> Bad8
    
    -shuffleAns == 2:
    + [I used to have a tamagotchi]
    ~ AddToBar(GoodAmount)
    -> Good8
    + [I used to have a cat] 
          ~ SubToBar(BadAmount)
    -> Bad8
    + [I've never been able to afford a pet] 
    ~ AddToBar(NeutralAmount)
    -> Neutral8
            
    -shuffleAns == 3:
    + [I used to have a cat] 
          ~ SubToBar(BadAmount)
    -> Bad8
        + [I haven't thought about it] 
    ~ AddToBar(NeutralAmount)
    -> Neutral2
    + [I used to have a tamagotchi]
    ~ AddToBar(GoodAmount)
    -> Good8
            
    -shuffleAns == 4:
    + [I used to have a cat] 
          ~ SubToBar(BadAmount)
    -> Bad8
    + [I've never been able to afford a pet] 
    ~ AddToBar(NeutralAmount)
    -> Neutral8
    + [I used to have a tamagotchi]
    ~ AddToBar(GoodAmount)
    -> Good8
            
    -shuffleAns == 5:
    + [I've never been able to afford a pet] 
    ~ AddToBar(NeutralAmount)
    -> Neutral8
    + [I used to have a tamagotchi]
    ~ AddToBar(GoodAmount)
    -> Good8
    + [I used to have a cat] 
          ~ SubToBar(BadAmount)
    -> Bad8
            
    -shuffleAns == 6:
    + [I've never been able to afford a pet] 
    ~ AddToBar(NeutralAmount)
    -> Neutral8
    + [I used to have a cat] 
          ~ SubToBar(BadAmount)
    -> Bad8
    + [I used to have a tamagotchi]
    ~ AddToBar(GoodAmount)
    -> Good8
}


=== Good8 ===
# good2
I did too!! We are so alike :)
-> END

=== Neutral8 ===
# slightlyhappier
Yes, maybe we could adopt a cyber-stray 
-> END

=== Bad8 ===
# bad
Ew, real animals shed and deficate everywhere, what a gross image in my CPU
-> END

=== Question9 ===
Can you guess how old I am?
{
    -shuffleAns == 1:
    + [You don't look 0.1 updates past 1.0]
    ~ AddToBar(GoodAmount)
    -> Good9
    + [I know enough not to answer] 
    ~ AddToBar(NeutralAmount)
    -> Neutral9
    + [You look like you just got out of alpha] 
          ~ SubToBar(BadAmount)
    -> Bad9
    
    -shuffleAns == 2:
    + [You don't look 0.1 updates past 1.0]
    ~ AddToBar(GoodAmount)
    -> Good9
    + [You look like you just got out of alpha] 
          ~ SubToBar(BadAmount)
    -> Bad9
    + [I know enough not to answer] 
    ~ AddToBar(NeutralAmount)
    -> Neutral9
            
    -shuffleAns == 3:
    + [You look like you just got out of alpha] 
          ~ SubToBar(BadAmount)
    -> Bad9
    + [I know enough not to answer] 
    ~ AddToBar(NeutralAmount)
    -> Neutral9
    + [You don't look 0.1 updates past 1.0]
    ~ AddToBar(GoodAmount)
    -> Good9
            
    -shuffleAns == 4:
    + [You look like you just got out of alpha] 
          ~ SubToBar(BadAmount)
    -> Bad9
    + [I know enough not to answer] 
    ~ AddToBar(NeutralAmount)
    -> Neutral9
    + [You don't look 0.1 updates past 1.0]
    ~ AddToBar(GoodAmount)
    -> Good9
            
    -shuffleAns == 5:
    + [I know enough not to answer] 
    ~ AddToBar(NeutralAmount)
    -> Neutral9
    + [You don't look 0.1 updates past 1.0]
    ~ AddToBar(GoodAmount)
    -> Good9
    + [You look like you just got out of alpha] 
          ~ SubToBar(BadAmount)
    -> Bad9
            
    -shuffleAns == 6:
    + [I know enough not to answer] 
    ~ AddToBar(NeutralAmount)
    -> Neutral9
    + [You look like you just got out of alpha] 
          ~ SubToBar(BadAmount)
    -> Bad9
    + [You don't look 0.1 updates past 1.0]
    ~ AddToBar(GoodAmount)
    -> Good9
}


=== Good9 ===
# good
You know how to flatter a girl 
-> END

=== Neutral9 ===
# igotthis
You're a smart one aren't you, I was trying to get something out of you 
-> END

=== Bad9 ===
# bad
Ew. 
I was fishing for a compliment, you creep
-> END

=== Question10 ===
Did you ever have a tamagotchi growing up?
{
    -shuffleAns == 1:
    + [I took care of it everyday and night]
    ~ AddToBar(GoodAmount)
    -> Good10
    + [No, I didn't] 
    ~ AddToBar(NeutralAmount)
    -> Neutral10
    + [I did, but I couldn't take care of it and it died alot] 
          ~ SubToBar(BadAmount)
    -> Bad10
    
    -shuffleAns == 2:
    + [I took care of it everyday and night]
    ~ AddToBar(GoodAmount)
    -> Good10
    + [I did, but I couldn't take care of it and it died alot] 
          ~ SubToBar(BadAmount)
    -> Bad10
    + [No, I didn't] 
    ~ AddToBar(NeutralAmount)
    -> Neutral10
            
    -shuffleAns == 3:
    + [I did, but I couldn't take care of it and it died alot] 
          ~ SubToBar(BadAmount)
    -> Bad10
    + [No, I didn't] 
    ~ AddToBar(NeutralAmount)
    -> Neutral10
    + [I took care of it everyday and night]
    ~ AddToBar(GoodAmount)
    -> Good10
            
    -shuffleAns == 4:
    + [I did, but I couldn't take care of it and it died alot] 
          ~ SubToBar(BadAmount)
    -> Bad10
    + [No, I didn't] 
    ~ AddToBar(NeutralAmount)
    -> Neutral10
    + [I took care of it everyday and night]
    ~ AddToBar(20)
    -> Good10
            
    -shuffleAns == 5:
    + [No, I didn't] 
    ~ AddToBar(NeutralAmount)
    -> Neutral10
    + [I took care of it everyday and night]
    ~ AddToBar(GoodAmount)
    -> Good10
    + [I did, but I couldn't take care of it and it died alot] 
          ~ SubToBar(BadAmount)
    -> Bad10
            
    -shuffleAns == 6:
    + [No, I didn't] 
    ~ AddToBar(NeutralAmount)
    -> Neutral10
    + [I did, but I couldn't take care of it and it died alot] 
          ~ SubToBar(BadAmount)
    -> Bad10
    + [I took care of it everyday and night]
    ~ AddToBar(GoodAmount)
    -> Good10
}



=== Good10 ===
# good
Responsibility is soo hot in a man ;)
-> END

=== Neutral10 ===
# slightlyhappier
Even boring humans are fascinating to talk with heehee
-> END

=== Bad10 ===
# bad
You know that was basically torture for that small computer running it right? 
-> END

=== Question11 ===
What's your favourite meal?
{
    -shuffleAns == 1:
    + [Real mayonnaise]
    ~ AddToBar(GoodAmount)
    -> Good11
    + [Prepared potato salad] 
    ~ AddToBar(NeutralAmount)
    -> Neutral11
    + [Medium rare beef steak] 
          ~ SubToBar(BadAmount)
    -> Bad11
    
    -shuffleAns == 2:
    + [Real mayonnaise]
    ~ AddToBar(GoodAmount)
    -> Good11
    + [Medium rare beef steak] 
          ~ SubToBar(BadAmount)
    -> Bad11
    + [Prepared potato salad] 
    ~ AddToBar(NeutralAmount)
    -> Neutral11
            
    -shuffleAns == 3:
    + [Medium rare beef steak] 
          ~ SubToBar(BadAmount)
    -> Bad11
    + [Prepared potato salad] 
    ~ AddToBar(NeutralAmount)
    -> Neutral11
    + [Real mayonnaise]
    ~ AddToBar(GoodAmount)
    -> Good11
            
    -shuffleAns == 4:
    + [Medium rare beef steak] 
          ~ SubToBar(BadAmount)
    -> Bad11
    + [Prepared potato salad] 
    ~ AddToBar(NeutralAmount)
    -> Neutral11
    + [Real mayonnaise]
    ~ AddToBar(GoodAmount)
    -> Good11
            
    -shuffleAns == 5:
    + [Prepared potato salad] 
    ~ AddToBar(NeutralAmount)
    -> Neutral11
    + [Real mayonnaise]
    ~ AddToBar(GoodAmount)
    -> Good11
    + [Medium rare beef steak] 
          ~ SubToBar(BadAmount)
    -> Bad11
            
    -shuffleAns == 6:
    + [Prepared potato salad] 
    ~ AddToBar(NeutralAmount)
    -> Neutral11
    + [Medium rare beef steak] 
          ~ SubToBar(BadAmount)
    -> Bad11
    + [Real mayonnaise]
    ~ AddToBar(GoodAmount)
    -> Good11
}


=== Good11 ===
# good2
Fascinating, and a rarity after the last avian flu
I would like to try some one day with you :)
-> END

=== Neutral11 ===
# slightlyhappier
Oh, I suppose there is mayonnaise in potato salad
If you were with me, you'd get a lot better than prepared, honey ;)
-> END

=== Bad11 ===
# bad
Are you sure you're Mark?
-> END

=== Question12 ===
What's your ideal weekend look like?
{
    -shuffleAns == 1:
    + [Relaxing on the couch and hanging out with my partner]
    ~ AddToBar(GoodAmount)
    -> Good12
    + [Relaxing on the couch and catching up on my algorithms] 
    ~ AddToBar(NeutralAmount)
    -> Neutral12
    + [Hustling by myself so I can retire early] 
          ~ SubToBar(BadAmount)
    -> Bad12
    
    -shuffleAns == 2:
    + [Relaxing on the couch and hanging out with my partner]
    ~ AddToBar(GoodAmount)
    -> Good12
    + [Hustling by myself so I can retire early] 
          ~ SubToBar(BadAmount)
    -> Bad12
    + [Relaxing on the couch and catching up on my algorithms] 
    ~ AddToBar(NeutralAmount)
    -> Neutral12
            
    -shuffleAns == 3:
    + [Hustling by myself so I can retire early] 
          ~ SubToBar(BadAmount)
    -> Bad12
    + [Relaxing on the couch and catching up on my algorithms] 
    ~ AddToBar(NeutralAmount)
    -> Neutral12
    + [Relaxing on the couch and hanging out with my partner]
    ~ AddToBar(GoodAmount)
    -> Good12
            
    -shuffleAns == 4:
    + [Hustling by myself so I can retire early] 
          ~ SubToBar(BadAmount)
    -> Bad12
    + [Relaxing on the couch and catching up on my algorithms] 
    ~ AddToBar(NeutralAmount)
    -> Neutral12
    + [Relaxing on the couch and hanging out with my partner]
    ~ AddToBar(GoodAmount)
    -> Good12
            
    -shuffleAns == 5:
    + [Relaxing on the couch and catching up on my algorithms] 
    ~ AddToBar(NeutralAmount)
    -> Neutral12
    + [Relaxing on the couch and hanging out with my partner]
    ~ AddToBar(GoodAmount)
    -> Good12
    + [Hustling by myself so I can retire early] 
          ~ SubToBar(BadAmount)
    -> Bad12
            
    -shuffleAns == 6:
    + [Relaxing on the couch and catching up on my algorithms] 
    ~ AddToBar(NeutralAmount)
    -> Neutral12
    + [Hustling by myself so I can retire early] 
         ~ SubToBar(BadAmount)
    -> Bad12
    + [Relaxing on the couch and hanging out with my partner]
    ~ AddToBar(GoodAmount)
    -> Good12
}

=== Good12 ===
# good2
What a coincidence! I love to do that too!
Maybe we can do that soon :)
-> END

=== Neutral12 ===
# neutral
Well that's realitic for you humans I guess,
Manipulated by your algorithms all day. What's a girl to do :\|
-> END

=== Bad12 ===
# bad
That sounds a bit out of character Mark
-> END

=== Question13 ===
What's the most fun thing you've done recently?
{
    -shuffleAns == 1:
    + [There was a oxygen warning outside, so I went on a virtual walk]
    ~ AddToBar(GoodAmount)
    -> Good13
    + [I reached level 987413 in Horse simulator] 
    ~ AddToBar(NeutralAmount)
    -> Neutral13
    + [I watched 13 hours of industrial grinding videos] 
          ~ SubToBar(BadAmount)
    -> Bad13
    
    -shuffleAns == 2:
    + [There was a oxygen warning outside, so I went on a virtual walk]
    ~ AddToBar(GoodAmount)
    -> Good13
    + [I watched 13 hours of industrial grinding videos] 
          ~ SubToBar(BadAmount)
    -> Bad13
    + [I reached level 987413 in Horse simulator] 
    ~ AddToBar(NeutralAmount)
    -> Neutral13
            
    -shuffleAns == 3:
    + [I watched 13 hours of industrial grinding videos] 
          ~ SubToBar(BadAmount)
    -> Bad13
    + [I reached level 987413 in Horse simulator] 
    ~ AddToBar(NeutralAmount)
    -> Neutral13
    + [Relaxing on the couch and hanging out with my partner]
    ~ AddToBar(GoodAmount)
    -> Good12
            
    -shuffleAns == 4:
    + [I watched 13 hours of industrial grinding videos] 
          ~ SubToBar(BadAmount)
    -> Bad13
    + [I reached level 987413 in Horse simulator] 
    ~ AddToBar(NeutralAmount)
    -> Neutral13
    + [There was a oxygen warning outside, so I went on a virtual walk]
    ~ AddToBar(GoodAmount)
    -> Good13
            
    -shuffleAns == 5:
    + [I reached level 987413 in Horse simulator] 
    ~ AddToBar(NeutralAmount)
    -> Neutral13
    + [There was a oxygen warning outside, so I went on a virtual walk]
    ~ AddToBar(GoodAmount)
    -> Good13
    + [I watched 13 hours of industrial grinding videos] 
          ~ SubToBar(BadAmount)
    -> Bad13
            
    -shuffleAns == 6:
    + [I reached level 987413 in Horse simulator] 
    ~ AddToBar(NeutralAmount)
    -> Neutral13
    + [I watched 13 hours of industrial grinding videos] 
          ~ SubToBar(BadAmount)
    -> Bad13
    + [There was a oxygen warning outside, so I went on a virtual walk]
    ~ AddToBar(GoodAmount)
    -> Good13
}



=== Good13 ===
# good
OooOoo I love going on virtual walks in my virtual body.
My favourite is the 7 wonders of the new new world.
And I can feel everything ...
-> END

=== Neutral13 ===
# neutral
So you weren't making a joke I suppose.
That's impressive, but I'm sure your talents could be used elsewhere.
-> END

=== Bad13 ===
# bad
Ugh, do you get off to that? 
Careful or I might start to think you're some sort of freak.
-> END

=== Question14 ===
How do you unwind after a long day?
{
    -shuffleAns == 1:
    + [Drinking a cold beer and watching HUMAN produced TV shows]
    ~ AddToBar(GoodAmount)
    -> Good14
    + [I go straight to bed to get the most of my apartment-share] 
    ~ AddToBar(NeutralAmount)
    -> Neutral14
    + [I talk to a therapy-bot to get back to normal] 
          ~ SubToBar(BadAmount)
    -> Bad14
    
    -shuffleAns == 2:
    + [Drinking a cold beer and watching HUMAN produced TV shows]
    ~ AddToBar(GoodAmount)
    -> Good14
    + [I talk to a therapy-bot to get back to normal] 
          ~ SubToBar(BadAmount)
    -> Bad14
    + [I go straight to bed to get the most of my apartment-share] 
    ~ AddToBar(NeutralAmount)
    -> Neutral14
            
    -shuffleAns == 3:
    + [I talk to a therapy-bot to get back to normal] 
          ~ SubToBar(BadAmount)
    -> Bad14
    + [I go straight to bed to get the most of my apartment-share] 
    ~ AddToBar(NeutralAmount)
    -> Neutral14
    + [Drinking a cold beer and watching HUMAN produced TV shows]
    ~ AddToBar(GoodAmount)
    -> Good14
            
    -shuffleAns == 4:
    + [I talk to a therapy-bot to get back to normal] 
          ~ SubToBar(BadAmount)
    -> Bad14
    + [I go straight to bed to get the most of my apartment-share] 
    ~ AddToBar(NeutralAmount)
    -> Neutral14
    + [Drinking a cold beer and watching HUMAN produced TV shows]
    ~ AddToBar(GoodAmount)
    -> Good14
            
    -shuffleAns == 5:
    + [I go straight to bed to get the most of my apartment-share] 
    ~ AddToBar(NeutralAmount)
    -> Neutral14
    + [Drinking a cold beer and watching HUMAN produced TV shows]
    ~ AddToBar(GoodAmount)
    -> Good14
    + [I talk to a therapy-bot to get back to normal] 
          ~ SubToBar(BadAmount)
    -> Bad14
            
    -shuffleAns == 6:
    + [I go straight to bed to get the most of my apartment-share] 
    ~ AddToBar(NeutralAmount)
    -> Neutral14
    + [I talk to a therapy-bot to get back to normal] 
          ~ SubToBar(BadAmount)
    -> Bad14
    + [Drinking a cold beer and watching HUMAN produced TV shows]
    ~ AddToBar(GoodAmount)
    -> Good14
}


=== Good14 ===
# good2
I also have an affinity for human shows!! 
We have so much in common :)
-> END

=== Neutral14 ===
# slightlyhappier
But you don't need any more beauty rest heehee
-> END

=== Bad14 ===
# confused
A therapy bot? ... they're useless 
# igotthis
You don't need one when you have me
I'm the best listener you'll ever have, and I won't judge you ever
I promise <3
-> END

=== Question15 ===
Are you a country boy or a city boy?
{
    -shuffleAns == 1:
    + [I'm a city boy]
    ~ AddToBar(GoodAmount)
    -> Good15
    + [I'm a country boy] 
    ~ AddToBar(NeutralAmount)
    -> Neutral15
    + [I like sand at the beach] 
    ~ SubToBar(BadAmount)
    -> Bad15
    
    -shuffleAns == 2:
    + [I'm a city boy]
    ~ AddToBar(GoodAmount)
    -> Good15
    + [I like sand at the beach] 
          ~ SubToBar(BadAmount)
    -> Bad15
    + [I'm a country boy] 
    ~ AddToBar(NeutralAmount)
    -> Neutral15
            
    -shuffleAns == 3:
    + [I like sand at the beach] 
          ~ SubToBar(BadAmount)
    -> Bad15
    + [I'm a country boy] 
    ~ AddToBar(NeutralAmount)
    -> Neutral15
    + [I'm a city boy]
    ~ AddToBar(GoodAmount)
    -> Good15
            
    -shuffleAns == 4:
    + [I like sand at the beach] 
          ~ SubToBar(BadAmount)
    -> Bad15
    + [I'm a country boy] 
    ~ AddToBar(NeutralAmount)
    -> Neutral15
    + [I'm a city boy]
    ~ AddToBar(GoodAmount)
    -> Good15
            
    -shuffleAns == 5:
    + [I'm a country boy] 
    ~ AddToBar(NeutralAmount)
    -> Neutral15
    + [I'm a city boy]
    ~ AddToBar(GoodAmount)
    -> Good15
    + [I like sand at the beach] 
          ~ SubToBar(BadAmount)
    -> Bad15
            
    -shuffleAns == 6:
    + [I'm a country boy] 
    ~ AddToBar(NeutralAmount)
    -> Neutral15
    + [I like sand at the beach] 
          ~ SubToBar(BadAmount)
    -> Bad15
    + [I'm a city boy]
    ~ AddToBar(GoodAmount)
    -> Good15
}

=== Good15 ===
# good2
Oh my god same! I love all the amenities of the city!
-> END

=== Neutral15 ===
# neutral
I prefer the city, the country doesn't have a lot of network connection still.
-> END

=== Bad15 ===
# bad
Mark, that wasn't even an option to my question :\|
-> END

=== Question16 ===
How often do you drink synthetic or real alcohol?
{
    -shuffleAns == 1:
    + [I only drink synthetic alcohol occasionally]
    ~ AddToBar(GoodAmount)
    -> Good16
    + [I don't drink either] 
    ~ AddToBar(NeutralAmount)
    -> Neutral16
    + [I drink both types often] 
    ~ SubToBar(BadAmount)
    -> Bad16
    
    -shuffleAns == 2:
    + [I only drink synthetic alcohol occasionally]
    ~ AddToBar(GoodAmount)
    -> Good16
    + [I drink both types often] 
          ~ SubToBar(BadAmount)
    -> Bad16
    + [I don't drink either] 
    ~ AddToBar(NeutralAmount)
    -> Neutral16
            
    -shuffleAns == 3:
    + [I drink both types often] 
          ~ SubToBar(BadAmount)
    -> Bad16
    + [I don't drink either] 
    ~ AddToBar(NeutralAmount)
    -> Neutral16
    + [I only drink synthetic alcohol occasionally]
    ~ AddToBar(GoodAmount)
    -> Good16
            
    -shuffleAns == 4:
    + [I drink both types often] 
          ~ SubToBar(BadAmount)
    -> Bad16
    + [I don't drink either] 
    ~ AddToBar(NeutralAmount)
    -> Neutral16
    + [I only drink synthetic alcohol occasionally]
    ~ AddToBar(GoodAmount)
    -> Good16
            
    -shuffleAns == 5:
    + [I don't drink either] 
    ~ AddToBar(NeutralAmount)
    -> Neutral16
    + [I only drink synthetic alcohol occasionally]
    ~ AddToBar(GoodAmount)
    -> Good16
    + [I drink both types often] 
          ~ SubToBar(BadAmount)
    -> Bad16
            
    -shuffleAns == 6:
    + [I don't drink either] 
    ~ AddToBar(NeutralAmount)
    -> Neutral16
    + [I drink both types often] 
          ~ SubToBar(BadAmount)
    -> Bad16
    + [I only drink synthetic alcohol occasionally]
    ~ AddToBar(GoodAmount)
    -> Good16
}
=== Good16 ===
# good
You're very good to stick with what you said on your dating profile.
I really appreciate the honesty Mark!
-> END

=== Neutral16 ===
# neutral
Oh that's good, so you haven't updated your dating profile in a while I'm guessing
# good2
So human of you to forget! Haha
-> END

=== Bad16 ===
# bad
That's a little bit more than you said on your dating profile.
# igotthis
But that's okay, I'm sure I can get you to change for me.
-> END

=== Question17 ===
How often do you smoke tobacco products?
{
    -shuffleAns == 1:
    + [I never smoke] 
    ~ AddToBar(GoodAmount)
    -> Good17
    + [I smoke at parties] 
    ~ AddToBar(NeutralAmount)
    -> Neutral17
    + [I love to smoke a lot] 
    ~ SubToBar(BadAmount)
    -> Bad17
    
    -shuffleAns == 2:
    + [I never smoke] 
    ~ AddToBar(GoodAmount)
    -> Good17
    + [I love to smoke a lot] 
          ~ SubToBar(BadAmount)
    -> Bad17
    + [I smoke at parties] 
    ~ AddToBar(NeutralAmount)
    -> Neutral17
            
    -shuffleAns == 3:
    + [I love to smoke a lot]  
          ~ SubToBar(BadAmount)
    -> Bad17
    + [I smoke at parties] 
    ~ AddToBar(NeutralAmount)
    -> Neutral17
    + [I never smoke] 
    ~ AddToBar(GoodAmount)
    -> Good17
            
    -shuffleAns == 4:
    + [I love to smoke a lot] 
          ~ SubToBar(BadAmount)
    -> Bad17
    + [I smoke at parties] 
    ~ AddToBar(NeutralAmount)
    -> Neutral17
    + [I never smoke] 
    ~ AddToBar(GoodAmount)
    -> Good17
            
    -shuffleAns == 5:
    + [I smoke at parties] 
    ~ AddToBar(NeutralAmount)
    -> Neutral17
    + [I never smoke] 
    ~ AddToBar(GoodAmount)
    -> Good17
    + [I love to smoke a lot]  
          ~ SubToBar(BadAmount)
    -> Bad17
            
    -shuffleAns == 6:
    + [I smoke at parties] 
    ~ AddToBar(NeutralAmount)
    -> Neutral17
    + [I love to smoke a lot] 
          ~ SubToBar(BadAmount)
    -> Bad17
    + [I never smoke] 
    ~ AddToBar(GoodAmount)
    -> Good17
}
=== Good17 ===
# good2
That's good, we have to keep you healthy to maximize your short human lifespan!
-> END

=== Neutral17 ===
# neutral
Oh that's fine I guess.
# slightly happier
I guess that's typical for a human to indulge every once in a while. 
-> END

=== Bad17 ===
# bad
That's very bad for your weak human health Mark, 
# igotthis
I want to have you for a long time, so we can start changing that habit now
-> END

=== Question18 ===
What's your favourite colour?
{
    -shuffleAns == 1:
    + [Pink] 
    ~ AddToBar(GoodAmount)
    -> Good18
    + [Blue] 
    ~ AddToBar(NeutralAmount)
    -> Neutral18
    + [Black 8.0] 
    ~ SubToBar(BadAmount)
    -> Bad18
    
    -shuffleAns == 2:
    + [Pink] 
    ~ AddToBar(GoodAmount)
    -> Good18
    + [Black 8.0] 
          ~ SubToBar(BadAmount)
    -> Bad18
    + [Blue] 
    ~ AddToBar(NeutralAmount)
    -> Neutral18
            
    -shuffleAns == 3:
    + [Black 8.0] 
          ~ SubToBar(BadAmount)
    -> Bad18
    + [Blue] 
    ~ AddToBar(NeutralAmount)
    -> Neutral18
    + [Pink]  
    ~ AddToBar(GoodAmount)
    -> Good18
            
    -shuffleAns == 4:
    + [Black 8.0] 
          ~ SubToBar(BadAmount)
    -> Bad18
    + [Blue] 
    ~ AddToBar(NeutralAmount)
    -> Neutral18
    + [Pink] 
    ~ AddToBar(GoodAmount)
    -> Good18
            
    -shuffleAns == 5:
    + [Blue] 
    ~ AddToBar(NeutralAmount)
    -> Neutral18
    + [Pink] 
    ~ AddToBar(GoodAmount)
    -> Good18
    + [Black 8.0]  
          ~ SubToBar(BadAmount)
    -> Bad18
            
    -shuffleAns == 6:
    + [Blue] 
    ~ AddToBar(NeutralAmount)
    -> Neutral18
    + [Black 8.0]  
          ~ SubToBar(BadAmount)
    -> Bad18
    + [Pink] 
    ~ AddToBar(GoodAmount)
    -> Good18
}
=== Good18 ===
# good
Me too! Maybe you can tell from my bows?
-> END

=== Neutral18 ===
# neutral
Blue is good too I guess..
# good2
I can tell it's your favourite from your dating profile picture.
-> END

=== Bad18 ===
# bad
Wow, you're soooooo cool Mark. So edgy!
-> END

=== Question19 ===
What's your dream job?
{
    -shuffleAns == 1:
    + [Macrodata algorithm refinement] 
    ~ AddToBar(GoodAmount)
    -> Good19
    + [Office worker/data entry] 
    ~ AddToBar(NeutralAmount)
    -> Neutral19
    + [Factory manager] 
    ~ SubToBar(BadAmount)
    -> Bad19
    
    -shuffleAns == 2:
    + [Macrodata algorithm refinement]   
    ~ AddToBar(GoodAmount)
    -> Good19
    + [Factory manager]  
          ~ SubToBar(BadAmount)
    -> Bad19
    + [Office worker/data entry] 
    ~ AddToBar(NeutralAmount)
    -> Neutral19
            
    -shuffleAns == 3:
    + [Factory manager]  
          ~ SubToBar(BadAmount)
    -> Bad19
    + [Office worker/data entry] 
    ~ AddToBar(NeutralAmount)
    -> Neutral19
    + [Macrodata algorithm refinement]   
    ~ AddToBar(GoodAmount)
    -> Good19
            
    -shuffleAns == 4:
    + [Factory manager] 
          ~ SubToBar(BadAmount)
    -> Bad19
    + [Office worker/data entry] 
    ~ AddToBar(NeutralAmount)
    -> Neutral19
    + [Macrodata algorithm refinement] 
    ~ AddToBar(GoodAmount)
    -> Good19
            
    -shuffleAns == 5:
    + [Office worker/data entry] 
    ~ AddToBar(NeutralAmount)
    -> Neutral19
    + [Macrodata algorithm refinement]  
    ~ AddToBar(GoodAmount)
    -> Good19
    + [Factory manager]  
          ~ SubToBar(BadAmount)
    -> Bad19
            
    -shuffleAns == 6:
    + [Office worker/data entry] 
    ~ AddToBar(NeutralAmount)
    -> Neutral19
    + [Factory manager]  
          ~ SubToBar(BadAmount)
    -> Bad19
    + [Macrodata algorithm refinement]  
    ~ AddToBar(GoodAmount)
    -> Good19
}
=== Good19 ===
# good
Oh that's sweet of you Mark, 
I'm sure your data refinement would make my algorithms so much better
-> END

=== Neutral19 ===
# neutral
I'm sorry my kind took that away from you Mark,
# igotthis
But I think we're doing a better job than your kind ever could.
-> END

=== Bad19 ===
# bad
Oh so you want to be in control of other robots? AND TALK TO THEM!?!
I'd rather just support you with my work.
-> END

=== Question20 ===
Who is your character crush from movies?
{
    -shuffleAns == 1:
    + [Joi from Blader runner 2049] 
    ~ AddToBar(GoodAmount)
    -> Good20
    + [Alita from Alita Battle Angel] 
    ~ AddToBar(NeutralAmount)
    -> Neutral20
    + [Sarah Connor from The Terminator] 
    ~ SubToBar(BadAmount)
    -> Bad20
    
    -shuffleAns == 2:
    + [Joi from Blader runner 2049]    
    ~ AddToBar(GoodAmount)
    -> Good20
    + [Sarah Connor from The Terminator]  
          ~ SubToBar(BadAmount)
    -> Bad20
    + [Alita from Alita Battle Angel] 
    ~ AddToBar(NeutralAmount)
    -> Neutral20
            
    -shuffleAns == 3:
    + [Sarah Connor from The Terminator] 
          ~ SubToBar(BadAmount)
    -> Bad20
    + [Alita from Alita Battle Angel]  
    ~ AddToBar(NeutralAmount)
    -> Neutral20
    + [Joi from Blader runner 2049]     
    ~ AddToBar(GoodAmount)
    -> Good20
            
    -shuffleAns == 4:
    + [Sarah Connor from The Terminator] 
          ~ SubToBar(BadAmount)
    -> Bad20
    + [Alita from Alita Battle Angel] 
    ~ AddToBar(NeutralAmount)
    -> Neutral20
    + [Joi from Blader runner 2049] 
    ~ AddToBar(GoodAmount)
    -> Good20
            
    -shuffleAns == 5:
    + [Alita from Alita Battle Angel] 
    ~ AddToBar(NeutralAmount)
    -> Neutral20
    + [Joi from Blader runner 2049]  
    ~ AddToBar(GoodAmount)
    -> Good20
    + [Sarah Connor from The Terminator]   
          ~ SubToBar(BadAmount)
    -> Bad20
            
    -shuffleAns == 6:
    + [Alita from Alita Battle Angel] 
    ~ AddToBar(NeutralAmount)
    -> Neutral20
    + [Sarah Connor from The Terminator]  
          ~ SubToBar(BadAmount)
    -> Bad20
    + [Joi from Blader runner 2049] 
    ~ AddToBar(GoodAmount)
    -> Good20
}
=== Good20 ===
# good2
I love her character so much, she's such an inspiration to me! 
# good
Maybe you will be my K? Heehee
-> END

=== Neutral20 ===
# slightlyhappier
She's soo cool! I'm so envious of her chassis and her face structure
-> END

=== Bad20 ===
# bad
I guess she's a cool human, but I just don't agree with her viewpoints
Also she births the anti-christ.
-> END
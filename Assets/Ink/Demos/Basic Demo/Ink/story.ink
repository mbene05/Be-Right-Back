VAR wager_amount = 0
VAR his_mood = 0

- I looked at Monsieur Fogg 
~ wager_amount = RANDOM(10000, 50000)
~ his_mood = RANDOM(1, 3)
*   ... and I could contain myself no longer.
    'What is the purpose of our journey, Monsieur?'
    'A wager,' he replied.
    * *     'A wager!'[] I returned.
            {
            - his_mood == 1: He nodded with great satisfaction.
            - his_mood == 2: He gave a thin smile.
            - else: He stared off into the distance.
            }
            * * *   'But surely that is foolishness!'
            * * *  'A most serious matter then!'
            - - -   He collected himself.
            * * *   'But can we win?'
                    'That is what we will endeavour to find out,' he answered.
            * * *   'A modest wager, I trust?'
                    'Twenty {wager_amount} pounds,' he replied, quite flatly.
            * * *   I asked nothing further of him then[.], and after a final, polite cough, he offered nothing more to me. <>
    * *     'Ah[.'],' I replied, uncertain what I thought.
    - -     After that, <>
*   ... but I said nothing[] and <>
- we passed the day in silence.
- -> END
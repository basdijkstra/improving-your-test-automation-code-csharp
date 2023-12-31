﻿namespace ImprovingYourTestAutomationCode.Suggestions
{
    internal class Suggestions03
    {
        // Suggestion 1: So, the first problem is that we cannot create a new User with an admin account
        // with the way our code is currently written. Do you have a quick solution for that?

        // Suggestion 2: There's another problem here... The User class contains some logic that is probably
        // better placed in the Account class. Password generation, for example, or determining whether
        // someone can access the log files. What's the SOLID principle being violated here and how
        // would you redesign the class?

        // Suggestion 3: Even after you have addressed the problem in Suggestions 1 and 2, you probably still
        // construct an Account in the constructor of the user class. That's a violation of another SOLID
        // principle. Do you know which one, and can you implement an improvement?
        // Please note that there is no one right or wrong answer here, there are many ways to
        // address this issue, and a lot of it depends on personal preference :)

        // Suggestion 4: One way that leads to a simple implementation and is highly extensible,
        // without a lot of logic, is by creating different classes for different types of accounts,
        // and having all these classes adhere to the same structure. Using interfaces or abstract classes,
        // or in more general terms, applying the abstraction principle of object-oriented programming,
        // is one way to do this (and it's the one I've used in my answers).

        // After you have implemented the changes above, is it easier now to:
        // - create a user with an admin account
        // - write a test that checks that a user with an admin account can access the log files?
    }
}

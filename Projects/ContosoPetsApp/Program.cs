﻿using System.Globalization;

CultureInfo.CurrentCulture = new CultureInfo("en-US");


// the ourAnimals array will store the following: 
string animalSpecies = "";
string animalID = "";
string animalAge = "";
string animalPhysicalDescription = "";
string animalPersonalityDescription = "";
string animalNickname = "";
string suggestedDonation = "";
decimal decimalDonation = 0.00M;

// variables that support data entry
int maxPets = 8;
string? readResult;
string menuSelection = "";

// array used to store runtime data, there is no persisted data
string[,] ourAnimals = new string[maxPets, 7];


// create some initial ourAnimals array entries
for (int i = 0; i < maxPets; i++)
{
    switch (i)
    {
        case 0:
            animalSpecies = "dog";
            animalID = "d1";
            animalAge = "2";
            animalPhysicalDescription = "medium sized cream colored female golden retriever weighing about 65 pounds. housebroken.";
            animalPersonalityDescription = "loves to have her belly rubbed and likes to chase her tail. gives lots of kisses.";
            animalNickname = "lola";
            suggestedDonation = "85.00";
            break;
        case 1:
            animalSpecies = "dog";
            animalID = "d2";
            animalAge = "9";
            animalPhysicalDescription = "large reddish-brown male golden retriever weighing about 85 pounds. housebroken.";
            animalPersonalityDescription = "loves to have his ears rubbed when he greets you at the door, or at any time! loves to lean-in and give doggy hugs.";
            animalNickname = "loki";
            suggestedDonation = "49.99";
            break;
        case 2:
            animalSpecies = "cat";
            animalID = "c3";
            animalAge = "1";
            animalPhysicalDescription = "small white female weighing about 8 pounds. litter box trained.";
            animalPersonalityDescription = "friendly";
            animalNickname = "Puss";
            suggestedDonation = "40.00";
            break;
        case 3:
            animalSpecies = "cat";
            animalID = "c4";
            animalAge = "?";
            animalPhysicalDescription = "";
            animalPersonalityDescription = "";
            animalNickname = "";
            suggestedDonation = "";
            break;
        default:
            animalSpecies = "";
            animalID = "";
            animalAge = "";
            animalPhysicalDescription = "";
            animalPersonalityDescription = "";
            animalNickname = "";
            suggestedDonation = "";
            break;
    }

    ourAnimals[i, 0] = "ID #: " + animalID;
    ourAnimals[i, 1] = "Species: " + animalSpecies;
    ourAnimals[i, 2] = "Age: " + animalAge;
    ourAnimals[i, 3] = "Nickname: " + animalNickname;
    ourAnimals[i, 4] = "Physical description: " + animalPhysicalDescription;
    ourAnimals[i, 5] = "Personality: " + animalPersonalityDescription;

    if (!decimal.TryParse(suggestedDonation, out decimalDonation))
    {
        decimalDonation = 45.00M;   // if suggestedDonation NOT a number, default to 45.00
    }
    ourAnimals[i, 6] = $"Suggested Donation: {decimalDonation:C}";
}



// display the top-level menu options
do
{
    Console.Clear();

    Console.WriteLine("Welcome to the Contoso PetFriends app. Your main menu options are:");
    Console.WriteLine(" 1. List all of our current pet information");
    Console.WriteLine(" 2. Add a new animal friend to the ourAnimals array");
    Console.WriteLine(" 3. Ensure animal ages and physical descriptions are complete");
    Console.WriteLine(" 4. Ensure animal nicknames and personality descriptions are complete");
    Console.WriteLine(" 5. Edit an animal’s age");
    Console.WriteLine(" 6. Edit an animal’s personality description");
    Console.WriteLine(" 7. Display all cats with a specified characteristic");
    Console.WriteLine(" 8. Display all dogs with a specified characteristic");
    Console.WriteLine();
    Console.WriteLine("Enter your selection number (or type Exit to exit the program)");

    readResult = Console.ReadLine();
    if (readResult != null)
    {
        menuSelection = readResult.ToLower();
    }

    // Console.WriteLine($"You selected menu option {menuSelection}.");
    // Console.WriteLine("Press the Enter key to continue");
    // // pause code execution
    // readResult = Console.ReadLine();

    switch (menuSelection)
    {
        case "1":
            //> 1. List all of our current pet information
            for (int i = 0; i < ourAnimals.GetLength(0); ++i)
            {
                if (ourAnimals[i, 0] != "ID #: ")     // Check animal ID
                {
                    for (int j = 0; j < ourAnimals.GetLength(1); ++j)
                    {
                        Console.WriteLine(ourAnimals[i, j]);
                    }
                    Console.WriteLine("=============================\n");
                }
            }
            Console.WriteLine("Press the Enter key to continue.");
            readResult = Console.ReadLine();
            break;
        case "2":
            //> 2. Add a new animal friend to the ourAnimals array

            string anotherPet = "y";
            int petCount = 0;

            //> Calculate pet count:
            for (int i = 0; i < maxPets; ++i)
            {
                if (ourAnimals[i, 0] != "ID #: ")
                {
                    petCount++;
                }
            }

            if (petCount < maxPets)
            {
                Console.WriteLine($"We currently have {petCount} pets that need homes. We can manage {maxPets - petCount} more.");
            }

            while (petCount < maxPets && anotherPet == "y")
            {

                bool validEntry = false;

                do
                {
                    Console.WriteLine("\n\rEnter 'dog' or 'cat' to begin a new entry");
                    readResult = Console.ReadLine();

                    if (readResult != null)
                    {
                        animalSpecies = readResult.ToLower();
                    }

                    if (animalSpecies != "dog" && animalSpecies != "cat")
                    {
                        validEntry = false;
                    }
                    else
                    {
                        validEntry = true;
                    }

                } while (!validEntry);

                //> Build the animal ID number:
                animalID = animalSpecies == "cat" ? $"c{petCount + 1}" : $"d{petCount + 1}";

                do
                {
                    int petAge;
                    Console.WriteLine("Enter the pet's age or enter ? if unkonwn");
                    readResult = Console.ReadLine();

                    if (readResult != null)
                    {
                        animalAge = readResult;
                        if (animalAge != "?")
                        {
                            validEntry = int.TryParse(animalAge, out petAge);
                        }
                        else
                        {
                            validEntry = true;
                        }
                    }
                } while (!validEntry);


                do
                {
                    Console.WriteLine("Enter a pysical description of the pet (size, color, gender, weight, housebroken)");
                    readResult = Console.ReadLine();

                    if (readResult != null)
                    {
                        animalPhysicalDescription = readResult.ToLower();

                        if (animalPhysicalDescription == "")
                        {
                            animalPhysicalDescription = "Unset value";
                        }
                    }

                } while (animalPhysicalDescription == "");

                do
                {
                    Console.WriteLine("Enter a personal description of the pet (likes or dislikes, tricks, energy level)");
                    readResult = Console.ReadLine();

                    if (readResult != null)
                    {
                        animalPersonalityDescription = readResult.ToLower();

                        if (animalPersonalityDescription == "")
                        {
                            animalPersonalityDescription = "Unset value";
                        }
                    }
                } while (animalPersonalityDescription == "");

                do
                {
                    Console.WriteLine("Enter a nickname for the pet.");
                    readResult = Console.ReadLine();

                    if (readResult != null)
                    {
                        animalNickname = readResult.ToLower();

                        if (animalNickname == "")
                        {
                            animalNickname = "Unset value";
                        }
                    }
                } while (animalNickname == "");

                ourAnimals[petCount, 0] = $"ID #: {animalID}";
                ourAnimals[petCount, 1] = $"Species: {animalSpecies}";
                ourAnimals[petCount, 2] = $"Age: {animalAge}";
                ourAnimals[petCount, 3] = $"Nickname: {animalNickname}";
                ourAnimals[petCount, 4] = $"Physical description: {animalPhysicalDescription}";
                ourAnimals[petCount, 5] = $"Personal description: {animalPersonalityDescription}";

                petCount++;

                if (petCount < maxPets)
                {
                    Console.WriteLine("Do you want to enter info for another pet (y/n)?");
                    do
                    {
                        readResult = Console.ReadLine();
                        if (readResult != null)
                        {
                            anotherPet = readResult.ToLower();
                        }
                    } while (anotherPet != "y" && anotherPet != "n");

                }
            }

            if (petCount >= maxPets)
            {
                Console.WriteLine("We have reached our limit on the number of pets that we can manage.");
                Console.WriteLine("Press the Enter key to continue.");
                readResult = Console.ReadLine();
            }
            break;
        case "3":
            int validPetAge;
            bool validAge;

            for (int i = 0; i < ourAnimals.GetLength(0); ++i)
            {
                if (ourAnimals[i, 0] != "ID #: ")
                {
                    animalPhysicalDescription = ourAnimals[i, 4].Split(": ")[1];

                    do
                    {

                        validAge = int.TryParse(ourAnimals[i, 2].Split(": ")[1], out validPetAge);

                        if (!validAge)
                        {
                            Console.WriteLine($"Please inter a valid age for pet with ID: {ourAnimals[i, 0]}");
                            readResult = Console.ReadLine();

                            if (readResult != null)
                            {
                                ourAnimals[i, 2] = $"Age: {readResult}";
                            }
                        }
                        else
                        {
                            validAge = true;
                        }

                    } while (!validAge);

                    while (animalPhysicalDescription == "" || animalPhysicalDescription == "Unset value")
                    {
                        Console.WriteLine($"Please enter a valid physical description for pet with ID: {ourAnimals[i, 0]}");
                        animalPhysicalDescription = Console.ReadLine();
                    }

                    ourAnimals[i, 4] = $"Physical description: {animalPhysicalDescription}";
                }
            }

            Console.WriteLine("Age and physical description fields are complete for all of our friends.");

            Console.WriteLine("Press the Enter key to continue.");
            readResult = Console.ReadLine();
            break;
        case "4":
            for (int i = 0; i < ourAnimals.GetLength(0); ++i)
            {
                if (ourAnimals[i, 0] != "ID #: ")
                {
                    animalNickname = ourAnimals[i, 3].Split(": ")[1];
                    animalPersonalityDescription = ourAnimals[i, 5].Split(": ")[1];

                    while (animalNickname == "Unset value" || animalNickname == "")
                    {
                        Console.WriteLine($"Please enter a valid nickname for pet with ID: {ourAnimals[i, 0]}");
                        animalNickname = Console.ReadLine();
                    }

                    ourAnimals[i, 3] = $"Nickname: {animalNickname}";

                    while (animalPersonalityDescription == "Unset value" || animalPersonalityDescription == "")
                    {
                        Console.WriteLine($"Please enter a valid personal description for pet with ID: {ourAnimals[i, 0]}");
                        animalPersonalityDescription = Console.ReadLine();
                    }

                    ourAnimals[i, 5] = $"Personality description: {animalPersonalityDescription}";
                }
            }

            Console.WriteLine("Age and physical description fields are complete for all of our friends.");

            Console.WriteLine("Press the Enter key to continue.");
            readResult = Console.ReadLine();
            break;
        case "5":
            //> 5. Edit an animal’s age
            Console.WriteLine("This app feature is comming soon. Please check beack to see progress.");
            Console.WriteLine("Press the Enter key to continue.");
            readResult = Console.ReadLine();
            break;
        case "6":
            //> 6. Edit an animal’s personality description
            Console.WriteLine("This app feature is comming soon. Please check beack to see progress.");
            Console.WriteLine("Press the Enter key to continue.");
            readResult = Console.ReadLine();
            break;
        case "7":
            //> 7. Display all cats with a specified characteristic
            Console.WriteLine("This app feature is comming soon. Please check beack to see progress.");
            Console.WriteLine("Press the Enter key to continue.");
            readResult = Console.ReadLine();
            break;
        case "8":
            //> 8. Display all dogs with a specified characteristic
            string dogCharacteristic = string.Empty;
            string[] dogCharacteristics = new string[20];

            bool noMatchesDog = true;
            Console.WriteLine("Enter one desired dog characteristics to search for(Note: terms should be separated by commas):");
            readResult = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(readResult))
            {
                dogCharacteristics = readResult.Split(", ");
                Array.Sort(dogCharacteristics);

                // foreach(string characteristic in dogCharacteristics)
                // {
                //     Console.WriteLine(characteristic);
                // }

                // dogCharacteristic = readResult.Trim().ToLower();

                for (int i = 0; i < ourAnimals.GetLength(0); ++i)
                {
                    if (ourAnimals[i, 1].Contains("dog"))
                    {
                        for (int k = 0; k < dogCharacteristics.Length; ++k)
                        {
                            if (ourAnimals[i, 4].Contains(dogCharacteristics[k]) || ourAnimals[i, 5].Contains(dogCharacteristics[k]))
                            {
                                noMatchesDog = false;       // TODO: ineffecient memory access.

                                animalNickname = ourAnimals[i, 3].Substring(10);

                                Console.WriteLine($"Our dog {animalNickname} is a match for your search for {dogCharacteristics[k]}");
                                // for (int j = 0; j < ourAnimals.GetLength(1); ++j)
                                // {
                                //     Console.WriteLine(ourAnimals[i, j]);
                                // }
                            }
                        }

                        if (noMatchesDog == false)
                        {
                            Console.WriteLine($"Nickname: {animalNickname} ({ourAnimals[i, 0]})");
                            Console.WriteLine($"{ourAnimals[i, 4]}");
                            Console.WriteLine($"{ourAnimals[i, 5]}\n");
                        }

                    }
                }
            }

            if (noMatchesDog)
            {
                Console.WriteLine($"None of our dogs are a match found for: {readResult}");
            }

            Console.WriteLine("Press the Enter key to continue.");
            readResult = Console.ReadLine();

            break;
        default:
            // Message for any minue selection rather than [1:8] or exit.
            break;
    }

} while (menuSelection != "exit");
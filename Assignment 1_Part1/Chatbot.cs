using System;
using System.Media;
using System.Threading;
using System.Collections.Generic;
using static System.Console;

namespace Assignment_1_Part1
{
    internal class Chatbot
    {
        private string userName;
        private int questionCount = 0;
        Random rand = new Random();

        // Dictionary for specific cybersecurity tips
        Dictionary<string, string> cyberTips = new Dictionary<string, string>()
        {
            {"vpn", "A VPN protects your privacy when using public WiFi by encrypting your connection, preventing others from seeing what you're doing online."},
            {"2fa", "Two-factor authentication (2FA) adds an extra layer of protection to your accounts, requiring not just a password but also a code sent to your phone or email."},
            {"scam", "Be cautious with unsolicited emails or messages asking for personal information. Legitimate companies will never ask for sensitive data this way."}
        };

        // Default responses for unknown questions
        string[] unknownResponses =
        {
            "Try asking about passwords.",
            "Ask about phishing.",
            "I can explain malware.",
            "Try cybersecurity topics.",
            "Ask how to stay safe online."
        };

        // Main entry point to start the application
        public void StartApplication()
        {
            SetupConsole();
            PlayVoiceGreeting();
            DisplayLogo();
            DisplayWelcomeMessage();
            GetUserName();
            StartConversation();
            ExitMessage();
        }

        // Console setup
        private void SetupConsole()
        {
            Title = "Cybersecurity Awareness Bot";
            Clear();
        }

        // Displaying the chatbot logo
        private void DisplayLogo()
        {
            ForegroundColor = ConsoleColor.Cyan;
            WriteLine("  ██████ ██    ██ ██████  ███████ ██████  ███████ ███████  ██████ ██    ██ ██████  ██ ████████ ██    ██      █████  ██     ██  █████  ██████  ███████ ███    ██ ███████ ███████ ███████     ██████   ██████  ████████ \r\n██       ██  ██  ██   ██ ██      ██   ██ ██      ██      ██      ██    ██ ██   ██ ██    ██     ██  ██      ██   ██ ██     ██ ██   ██ ██   ██ ██      ████   ██ ██      ██      ██          ██   ██ ██    ██    ██    \r\n██        ████   ██████  █████   ██████  ███████ █████   ██      ██    ██ ██████  ██    ██      ████       ███████ ██  █  ██ ███████ ██████  █████   ██ ██  ██ █████   ███████ ███████     ██████  ██    ██    ██    \r\n██         ██    ██   ██ ██      ██   ██      ██ ██      ██      ██    ██ ██   ██ ██    ██       ██        ██   ██ ██ ███ ██ ██   ██ ██   ██ ██      ██  ██ ██ ██           ██      ██     ██   ██ ██    ██    ██    \r\n ██████    ██    ██████  ███████ ██   ██ ███████ ███████  ██████  ██████  ██   ██ ██    ██       ██        ██   ██  ███ ███  ██   ██ ██   ██ ███████ ██   ████ ███████ ███████ ███████     ██████   ██████     ██    \r\n                                                                                                                                                                                                                     \r\n                                                                                                                                                                                                                      ");
            ResetColor();
        }

        // Play the initial greeting sound
        public void PlayVoiceGreeting()
        {
            try
            {
                ForegroundColor = ConsoleColor.Cyan;
                WriteLine("Playing greeting audio...");
                ResetColor();

                SoundPlayer player = new SoundPlayer("C:\\Users\\Student\\source\\repos\\Assignment 1_Part1\\Voice 1.wav");
                player.PlaySync();

                Console.Clear();
            }
            catch
            {
                ForegroundColor = ConsoleColor.Red;
                WriteLine("Audio could not play.");
                ResetColor();
            }
        }

        // Displaying the initial welcome message
        private void DisplayWelcomeMessage()
        {
            ForegroundColor = ConsoleColor.Green;
            TypeWriterEffect("Welcome to the Cybersecurity Awareness Bot");
            TypeWriterEffect("I help you stay safe online");
            TypeWriterEffect("This chatbot promotes cybersecurity awareness.");
            TypeWriterEffect("Type HELP to see topics.");
            ResetColor();
        }

        // Get the user's name for personalized experience
        public void GetUserName()
        {
            ForegroundColor = ConsoleColor.Yellow;
            Write("Enter your name: ");
            ResetColor();
            userName = ReadLine();
            while (string.IsNullOrWhiteSpace(userName))
            {
                ForegroundColor = ConsoleColor.Red;
                WriteLine("Invalid input. Please enter a valid name.");
                ResetColor();
                Write("Enter name: ");
                userName = ReadLine();
            }
            userName = FormatName(userName);
            ForegroundColor = ConsoleColor.Green;
            WriteLine("Welcome " + userName);
            ResetColor();
        }

        // Start the conversation with the user
        private void StartConversation()
        {
            string question = "";
            while (question != "exit")
            {
                WriteLine();
                DrawLine();
                ForegroundColor = ConsoleColor.Yellow;
                Write(userName + ": ");
                ResetColor();
                question = ReadLine()?.ToLower();
                if (string.IsNullOrWhiteSpace(question))
                {
                    ForegroundColor = ConsoleColor.Red;
                    WriteLine("Input cannot be empty.");
                    ResetColor();
                    continue;
                }
                questionCount++;
                Respond(question);
            }
        }

        // Respond to user's questions
        private void Respond(string question)
        {
            ForegroundColor = ConsoleColor.Cyan;
            Write("Bot: ");
            ResetColor();

            if (question.Contains("how are you"))
            {
                TypeWriterEffect("I am functioning perfectly and ready to help. How can I assist you with your cybersecurity concerns?");
            }
            else if (question.Contains("purpose"))
            {
                TypeWriterEffect("My purpose is to provide cybersecurity education and promote awareness about various online security threats, helping you stay safe in the digital world.");
            }
            else if (question.Contains("password"))
            {
                TypeWriterEffect("Passwords are the first line of defense against cyberattacks. A strong password includes a mix of uppercase and lowercase letters, numbers, and symbols. Use different passwords for each of your accounts and enable multi-factor authentication (MFA) to enhance security.");
            }
            else if (question.Contains("phishing"))
            {
                TypeWriterEffect("Phishing is when attackers try to trick you into revealing sensitive information like passwords, social security numbers, or bank account details. Be cautious of unsolicited emails or messages, and always verify the sender's authenticity before clicking on links or downloading attachments.");
            }
            else if (question.Contains("help"))
            {
                TypeWriterEffect("Here are some topics you can ask about:\n- Password safety\n- Phishing\n- Malware\n- Safe browsing\n- Social engineering\n- VPN\n- 2FA (Two-Factor Authentication)\nType 'exit' to quit.");
            }
            else if (question == "exit")
            {
                TypeWriterEffect($"Goodbye {userName}! Stay safe online!");
            }
            else
            {
                TypeWriterEffect(unknownResponses[rand.Next(unknownResponses.Length)]);
            }
        }

        // Display exit message
        private void ExitMessage()
        {
            ForegroundColor = ConsoleColor.Green;
            WriteLine("Thank you for using the chatbot. Stay safe and informed!");
            ResetColor();
        }

        // Typewriter effect for displaying text
        private void TypeWriterEffect(string text)
        {
            foreach (char letter in text)
            {
                Write(letter);
                Thread.Sleep(20);
            }
            WriteLine();
        }

        // Draw a line to separate outputs for clarity
        private void DrawLine()
        {
            ForegroundColor = ConsoleColor.DarkGray;
            WriteLine("-------------------------------------------------");
            ResetColor();
        }

        // Format name with proper capitalization
        private string FormatName(string name)
        {
            return char.ToUpper(name[0]) + name.Substring(1).ToLower();
        }
    }
}
﻿using HideAndSeek;

GameController gameController = new();
while (true)
{
    Console.WriteLine(gameController.Status);
    Console.Write(gameController.Prompt);
    Console.WriteLine(gameController.ParseInput(Console.ReadLine()));
}

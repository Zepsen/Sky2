﻿using System;

namespace Sky
{
    class Program
    {
        static void Main(string[] args)
        {
            var map = new Map();									
			map.RunDefault(new [] { 0,0,0,1,3,1,0,0,0});		
			map.Show();

        }
    }
}
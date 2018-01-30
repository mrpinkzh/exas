﻿using System;
using ExAs.Utils.StringExtensions;
using static System.Environment;

namespace ExAs.Utils
{
    public class Dojo
    {
        private readonly Ninja master;
        private readonly DateTime founded;

        public Dojo(Ninja master, DateTime founded)
        {
            this.master = master;
            this.founded = founded;
        }

        public Ninja Master
        {
            get { return master; }
        }

        public DateTime Founded
        {
            get { return founded; }
        }

        public override string ToString()
        {
	        return $"Dojo: Master  = {Master.ToValueString()}{NewLine}" +
	               $"      Founded = {Founded.ToValueString()}";
        }
    }
}
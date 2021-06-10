using System;
using System.Collections.Generic;

namespace _08.SchoolTeams
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] girls = Console.ReadLine().Split(", ");
            string[] boys = Console.ReadLine().Split(", ");
            string[] girlsTeam = new string[3];
            string[] boysTeam = new string[2];

            HashSet<string> girlsComb = new HashSet<string>();
            FindComb(0, 0,girls,girlsTeam,girlsComb);

            HashSet<string> boysComb = new HashSet<string>();
            FindComb(0, 0,boys,boysTeam,boysComb);

            foreach (var girlTeam in girlsComb)
            {
                foreach (var boyTeam in boysComb)
                {
                    Console.WriteLine($"{girlTeam}, {boyTeam}");
                }
            }
        }

        private static void FindComb(int studInd, int combInd
            ,string [] students,string[]studentsTeam,HashSet<string>studentsComb)
        {
            if (combInd >= studentsTeam.Length)
            {
                studentsComb.Add(new string(string.Join(", ", studentsTeam)));
                return;
            }
            for (int i = studInd; i < students.Length; i++)
            {
                studentsTeam[combInd] = students[i];
                FindComb(i + 1, combInd + 1,students,studentsTeam,studentsComb);
            }
        }
    }
}

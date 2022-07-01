using System;
using P01_StudentSystem.Data;

namespace P01_StudentSystem
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            var db = new StudentSystemContext();
            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();
        }
    }
}

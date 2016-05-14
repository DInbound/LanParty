using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DatabaseExample.Database;
using DatabaseExample.Models;

namespace LanPartyTesting
{
    [TestClass]
    public class TestGenreController
    {
        GenreController gc;
        Genre fps;

        [TestInitialize]
        public void Initialize()
        {
            gc = new GenreController();
            fps = new Genre { Name = "FPS", Verslavend = true };
        }


        [TestMethod]
        public void TestInsertGenre()
        {
            gc.InsertGenre(fps);
        }
    }
}

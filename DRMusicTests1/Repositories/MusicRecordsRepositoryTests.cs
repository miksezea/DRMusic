using Microsoft.VisualStudio.TestTools.UnitTesting;
using DRMusic.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DRMusic.Models;

namespace DRMusic.Repositories.Tests
{
    [TestClass()]
    public class MusicRecordsRepositoryTests
    {
        private MusicRecordsRepository repository;
        MusicRecord newRecord = new MusicRecord() { "My Way", "Frank Sinatra", 277, 1969};

        [TestInitialize]
        public void BeforeEachTest()
        {
            repository = new MusicRecordsRepository();
        }

        [TestMethod()]
        public void GetAllTest()
        {
            var actual = repository.GetAll();
            Assert.IsNotNull(actual);
            Assert.AreEqual(2, actual.Count());
            Assert.AreEqual(typeof(List<MusicRecord>), actual.GetType());
        }
        [TestMethod()]
        public void AddTest()
        {
            var actual = repository.GetAll();

        }
    }
}
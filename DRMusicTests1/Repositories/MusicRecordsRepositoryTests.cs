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
        MusicRecord newRecord = new MusicRecord() { Id = 3, Title = "My Way", Artist = "Frank Sinatra", Duration = 277, PublicationYear = 1969};

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

            string title = "Get Down";
            Assert.AreEqual(1, repository.GetAll(title).Count());
            title = null;
            string artist = "luc";
            Assert.AreEqual(1, repository.GetAll(title, artist).Count());
            title = "7";
            Assert.AreEqual(1, repository.GetAll(title, artist).Count());
            title = "dfghjklæ";
            Assert.AreEqual(0, repository.GetAll(title).Count());


        }
        [TestMethod()]
        public void AddTest()
        {
            var actual = repository.GetAll();
            MusicRecord testRecord = repository.Add(newRecord);


            Assert.IsNotNull(testRecord);
            Assert.AreEqual(actual.Count + 1, repository.GetAll().Count());
            Assert.AreEqual(3, testRecord.Id);
        }
    }
}
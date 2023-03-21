using DRMusic.Models;
namespace DRMusic.Repositories
{
    public class MusicRecordsRepository
    {
        private int _nextId;
        private List<MusicRecord> _musicRecords;
        public MusicRecordsRepository()
        {
            _nextId = 1;
            _musicRecords = new List<MusicRecord>()
            {
                new MusicRecord() {Id = _nextId++, Title = "Get down on it", Artist = "Kool and the gang", Duration = 294, PublicationYear = 1981},
                new MusicRecord() {Id = _nextId++, Title = "7 Years", Artist = "Lucas Graham", Duration = 235, PublicationYear = 2015}
            };
        }

        public List<MusicRecord> GetAll()
        {
            return new List<MusicRecord>(_musicRecords);
        }

        public MusicRecord Add(MusicRecord record)
        {
            record.Id = _nextId++;
            _musicRecords.Add(record);
            return record;
        }

        public MusicRecord Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}

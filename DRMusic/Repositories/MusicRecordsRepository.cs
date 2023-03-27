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

        public List<MusicRecord> GetAll(string title = null, string artist = null)
        {
            List<MusicRecord> result = new List<MusicRecord>(_musicRecords);
            if (title != null && artist == null)
            {
                return result.FindAll(x=>x.Title.Contains(title, StringComparison.InvariantCultureIgnoreCase));
            }
            if (title == null && artist != null)
            {
                return result.FindAll(x=>x.Artist.Contains(artist, StringComparison.InvariantCultureIgnoreCase));
            }
            if(title != null && artist != null)
            {
                return result.FindAll(x=>x.Title.Contains(title, StringComparison.InvariantCultureIgnoreCase) && x.Artist.Contains(title, StringComparison.InvariantCultureIgnoreCase));

            }
            return result;
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

using System.Collections.Generic;
using SQLite;
using MyChat002.Models;
using System.Threading.Tasks;

namespace MyChat002.Data
{
    public class NoteDB
    {
        readonly SQLiteAsyncConnection myConnection;
        public NoteDB(string connectionString)
        {
            myConnection = new SQLiteAsyncConnection(connectionString);

            myConnection.CreateTableAsync<Note>().Wait();
        }

        public Task<List<Note>> GetNotesAsync()
        {
            return myConnection.Table<Note>().ToListAsync();
        }
        public Task<Note> GetNoteAsync(int id)
        {
            return myConnection.Table<Note>()
                                    .Where(x => x.ID == id)
                                    .FirstOrDefaultAsync();
        }
        public Task<int> SaveNoteAsync(Note note)
        {
            if (note.ID != 0)
            {
                return myConnection.UpdateAsync(note);
            }
            else
            {
                return myConnection.InsertAsync(note);
            }
        }
        public Task<int> DeleteNoteAsync(Note note)
        {
            return myConnection.DeleteAsync(note);
        }
    }
}

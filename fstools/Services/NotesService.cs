namespace fstools.Services
{
    public class NotesService
    {
        public string Notes { get; set; }

        private readonly string defaultNotes = @"<h3 class=""""><u>Altitudes</u></h3><ul><li><br></li></ul>
                                    <p><br></p>
                                    <h3 class=""""><u>Frequencies</u></h3><ul><li><br></li></ul>
                                    <p><br></p>
                                    <h3 class=""""><u>Notes</u></h3><ul><li><u><br></u></li></ul>";

        public NotesService()
        {
            Notes = defaultNotes;
        }
    }
}

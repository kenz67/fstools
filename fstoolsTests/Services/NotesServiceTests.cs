using fstools.Services;
using Xunit;

namespace fstoolsTests.Services
{
    public class NotesServiceTests
    {
        private readonly string defaultNotes = """
        <h3 class="">
            <u>Altitudes</u>
        </h3>
        <ul><li><br></li></ul>
        <p><br></p>
        <h3 class="">
            <u>Frequencies</u>
        </h3>
        <ul><li><br></li></ul>
        <p><br></p>
        <h3 class="">
            <u>Notes</u>
        </h3>
        <ul><li><u><br></u></li></ul>
""";

        [Fact]
        public void NotesServiceTest()
        {
            var svc = new NotesService();

            Assert.Equal(defaultNotes, svc.Notes);
        }

        [Fact]
        public void SetDefaultTest()
        {
            var svc = new NotesService
            {
                Notes = "Some Notes"
            };

            Assert.Equal("Some Notes", svc.Notes);
            svc.Notes = defaultNotes;

            Assert.Equal(defaultNotes, svc.Notes);
        }
    }
}
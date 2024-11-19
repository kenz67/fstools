using fstools.Services;

namespace fstoolsTests.Services
{
    [TestClass()]
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

        [TestMethod()]
        public void NotesServiceTest()
        {
            var svc = new NotesService();

            Assert.AreEqual(defaultNotes, svc.Notes);
        }

        [TestMethod()]
        public void SetDefaultTest()
        {
            var svc = new NotesService
            {
                Notes = "Some Notes"
            };

            Assert.AreEqual("Some Notes", svc.Notes);
            svc.Notes = defaultNotes;

            Assert.AreEqual(defaultNotes, svc.Notes);
        }
    }
}
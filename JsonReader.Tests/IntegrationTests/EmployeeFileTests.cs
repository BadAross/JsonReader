using JsonReader.Handlers;

namespace JsonReader.Tests.IntegrationTests;

[TestFixture]
public class EmployeeFileTests
{
    private const string FolderName = "TestFiles";
    private const string FileName = "TestRecord";

    [Test]
    public void TestFileOperations()
    {
        using var handler = new TxtFileHandler<string>(FolderName, FileName);
        var testData = new List<string> { "Data1", "Data2", "Data3" }; 
        handler.WriteFile(testData);

        var readData = handler.ReadFile();

        Assert.That(readData, Is.Not.Null);
        Assert.That(readData, Has.Count.EqualTo(testData.Count));

        readData.Add("Data4");
        handler.WriteFile(readData);

        var updatedData = handler.ReadFile();
        Assert.That(updatedData, Is.Not.Null);
        Assert.That(updatedData, Has.Count.EqualTo(readData.Count));
    }
    
    [TearDown]
    public void Cleanup()
    {
        var projectDirectory = Directory.GetParent(Directory.GetCurrentDirectory())?.Parent?.Parent?.FullName;

        var path = string.Empty; 
        if (projectDirectory != null)
        {
            path = Path.Combine(projectDirectory, FolderName, FileName + ".txt");
        }

        if (!string.IsNullOrEmpty(path) && File.Exists(path))
        {
            File.Delete(path);
        }
    }
}
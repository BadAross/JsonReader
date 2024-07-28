using JsonReader.Services;
using Newtonsoft.Json;

namespace JsonReader.Handlers;

/// <summary>
/// Обработчик файлов формата TXT.
/// </summary>
/// <typeparam name="TEntity">Модель данных.</typeparam>
public class TxtFileHandler<TEntity> : IDisposable
{
    private static  TxtFileHandler<TEntity>? _instance;
    private readonly string _folderName;
    private readonly string _fileName;
    private readonly string _filePath;

    /// <summary>
    /// Конструктор <inheritdoc cref="TxtFileHandler{TEntity}"/>.
    /// </summary>
    /// <param name="folderName">Имя папки.</param>
    /// <param name="fileName">Имя файла.</param>
    public TxtFileHandler(string folderName, string fileName)
    {
        _folderName = folderName;
        _fileName = fileName + ".txt";
        _filePath = GetFilePath();
        OpenOrCreateFile();
    }
 
    /// <summary>
    /// Возвращает экземпляр класса <inheritdoc cref="TxtFileHandler{TEntity}"/>.
    /// </summary>
    /// <returns>Экземпляр класса <inheritdoc cref="TxtFileHandler{TEntity}"/>.</returns>
    public static TxtFileHandler<TEntity> GetInstance(string folderName, string fileName) =>
        _instance ??= new TxtFileHandler<TEntity>(folderName, fileName);
    

    /// <summary>
    /// Читает содержимое файла и возвращает список объектов типа TEntity.
    /// </summary>
    /// <returns>Список объектов типа TEntity или null.</returns>
    public List<TEntity>? ReadFile()
    {
        try
        {
            string json;
            using (var fileStream = new FileStream(_filePath, FileMode.Open, FileAccess.Read))
            using (var reader = new StreamReader(fileStream))
            {
                json = reader.ReadToEnd();
            }
            return JsonConvert.DeserializeObject<List<TEntity>>(json);
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException("Ошибка при чтении файла: " + ex.Message);
        }
    }
    
    /// <summary>
    /// Записывает объект типа TEntity в файл.
    /// </summary>
    /// <param name="entity">Объект для записи в файл.</param>
    public void WriteFile(List<TEntity> entity)
    {
        try
        {
            var json = JsonConvert.SerializeObject(entity, Formatting.Indented);
            using (var fileStream = new FileStream(_filePath, FileMode.Create, FileAccess.Write))
            using (var writer = new StreamWriter(fileStream))
            {
                writer.Write(json);
            }
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException("Ошибка при записи в файл: " + ex.Message);
        }
    }

    /// <inheritdoc />
    public void Dispose()
    {
    }

    /// <summary>
    /// Создает файл, если он не существует.
    /// </summary>
    /// <exception cref="InvalidOperationException">Ошибка при создании файла</exception>
    private void OpenOrCreateFile()
    {
        try
        {
            if (File.Exists(_filePath))
            {
                return;
            }
            using (File.Create(_filePath))
            {
            }
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException("Ошибка при создании файла: " + ex.Message);
        }
    }

    /// <summary>
    /// Получает полный путь к файлу.
    /// </summary>
    /// <returns>Полный путь к файлу.</returns>
    private string GetFilePath()
    {
        var projectDirectory = Directory.GetParent(Directory.GetCurrentDirectory())?.Parent?.Parent?.FullName;

        if (projectDirectory != null)
        {
            return Path.Combine(projectDirectory, _folderName, _fileName);
        }

        throw new InvalidOperationException("Не удалось получить путь к проекту.");
    }
}
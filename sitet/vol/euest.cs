public class StateStorage
{
    private string _storageKey;
    private string _filePath;

    // Constructor to initialize the StateStorage with a specific key
    public StateStorage(string key)
    {
        if (string.IsNullOrEmpty(key))
        {
            throw new ArgumentException("Key cannot be null or empty.", nameof(key));
        }

        _storageKey = key;
        _filePath = GenerateFilePathForKey(key);
    }

    // Generates a file path based on the key
    private string GenerateFilePathForKey(string key)
    {
        // Assuming a simple hash-based filename generation for the example
        var hashedKey = key.GetHashCode().ToString("X");
        return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), hashedKey + ".storage");
    }

    // Saves the state to the file
    public void SaveState(string value)
    {
        File.WriteAllText(_filePath, value);
    }

    // Loads the state from the file
    public string LoadState()
    {
        if (File.Exists(_filePath))
        {
            return File.ReadAllText(_filePath);
        }

        return null; // or throw an exception if preferred
    }
}

using System.Text.Json;

namespace Modelos.Servicios
{
    internal class JSONManager<T> where T : new() // Limita el tipo generico a que tengan constructores publicos sin parametros
    {
        private readonly string filePath;

        public JSONManager(string fileName = "config.json")
        {
            string directory = AppDomain.CurrentDomain.BaseDirectory;
            filePath = Path.Combine(directory, fileName);
        }

        public void SaveData(T config)
        {
            string json = JsonSerializer.Serialize(config, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filePath, json);
        }

        public T LoadData()
        {
            if (!File.Exists(filePath))
                return new T(); // Retorna un objeto con valores por defecto

            string json = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<T>(json) ?? new T();
        }
    }
}

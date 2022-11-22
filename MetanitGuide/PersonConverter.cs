using System.Text.Json;
using System.Text.Json.Serialization;

internal class PersonConverter : JsonConverter<Person>
{
    public override Person Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var Name = "Undefined";
        var Age = 0;
        while (reader.Read())
        {
            if (reader.TokenType == JsonTokenType.PropertyName)
            {
                var propertyName = reader.GetString();
                reader.Read();
                switch (propertyName?.ToLower())
                {
                    // если свойство age и оно содержит число
                    case "age" when reader.TokenType == JsonTokenType.Number:
                        Age = reader.GetInt32();  // считываем число из json
                        break;
                    // если свойство age и оно содержит строку
                    case "age" when reader.TokenType == JsonTokenType.String:
                        string? stringValue = reader.GetString();
                        // пытаемся конвертировать строку в число
                        if (int.TryParse(stringValue, out int value))
                        {
                            Age = value;
                        }
                        break;
                    case "name":    // если свойство Name/name
                        string? name = reader.GetString();
                        if (name != null)
                            Name = name;
                        break;
                }
            }
        }
        return new Person(Name, Age);
    }
    // сериализуем объект Person в json
    public override void Write(Utf8JsonWriter writer, Person person, JsonSerializerOptions options)
    {
        writer.WriteStartObject();
        writer.WriteString("name", person.Name);
        writer.WriteNumber("age", person.Age);

        writer.WriteEndObject();
    }
}
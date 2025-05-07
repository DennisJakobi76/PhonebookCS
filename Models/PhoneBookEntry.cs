using System.Text.Json.Serialization;

public class PhoneBookEntry
{
	[JsonPropertyName("id")]
	public long Id { get; set; }

	[JsonPropertyName("firstName")]
	public string FirstName { get; set; }

	[JsonPropertyName("lastName")]
	public string LastName { get; set; }

	[JsonPropertyName("phonePrefix")]
	public string PhonePrefix { get; set; }

	[JsonPropertyName("phoneNumber")]
	public string PhoneNumber { get; set; }

	// Konstruktor
	public PhoneBookEntry(long id, string firstName, string lastName, string phonePrefix, string phoneNumber)
	{
		Id = id;
		FirstName = firstName;
		LastName = lastName;
		PhonePrefix = phonePrefix;
		PhoneNumber = phoneNumber;
	}

}
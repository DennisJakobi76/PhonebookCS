using System.Text.Json.Serialization;

public class PhoneBookEntry
{
	[JsonPropertyName("id")]
	public long Id { get; set; }

	[JsonPropertyName("vorname")]
	public string Vorname { get; set; }

	[JsonPropertyName("nachname")]
	public string Nachname { get; set; }

	[JsonPropertyName("telefonVorwahl")]
	public string TelefonVorwahl { get; set; }

	[JsonPropertyName("telefonnummer")]
	public string Telefonnummer { get; set; }

	// Konstruktor
	public PhoneBookEntry(long id, string vorname, string nachname, string telefonVorwahl, string telefonnummer)
	{
		Id = id;
		Vorname = vorname;
		Nachname = nachname;
		TelefonVorwahl = telefonVorwahl;
		Telefonnummer = telefonnummer;
	}
}
using phonebook_cs.Models;
using System.Text.Json;

namespace phonebook_cs.Models.Services
{
	public class PhoneBookService
	{
		private List<PhoneBookEntry> eintraege = new();
		private readonly string jsonPath = "data.json";

		public PhoneBookService()
		{
			if (File.Exists(jsonPath))
			{
				string json = File.ReadAllText(jsonPath);
				eintraege = JsonSerializer.Deserialize<List<PhoneBookEntry>>(json)!;
			}
		}

		public List<PhoneBookEntry> GetAll() => eintraege;

		public IEnumerable<PhoneBookEntry> FilterByNameOrPrefix(string userInput) =>
	eintraege.Where(e =>
		(!string.IsNullOrEmpty(e.FirstName) && e.FirstName.Contains(userInput, StringComparison.OrdinalIgnoreCase)) ||
		(!string.IsNullOrEmpty(e.LastName) && e.LastName.Contains(userInput, StringComparison.OrdinalIgnoreCase)) ||
		(!string.IsNullOrEmpty(e.PhonePrefix) && e.PhonePrefix.Contains(userInput, StringComparison.OrdinalIgnoreCase)));


		public PhoneBookEntry? GetById(long id) => eintraege.FirstOrDefault(e => e.Id == id);

		public void Add(PhoneBookEntry entry)
		{
			entry.Id = eintraege.Max(e => e.Id) + 1;
			eintraege.Add(entry);
		}

		public bool Update(long id, PhoneBookEntry updated)
		{
			var existing = GetById(id);
			if (existing == null) return false;

			existing.FirstName = updated.FirstName;
			existing.LastName = updated.LastName;
			existing.PhonePrefix = updated.PhonePrefix;
			existing.PhoneNumber = updated.PhoneNumber;
			return true;
		}

		public bool Delete(long id) =>
			eintraege.RemoveAll(e => e.Id == id) > 0;
	}
}
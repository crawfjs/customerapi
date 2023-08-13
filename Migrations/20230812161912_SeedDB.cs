using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace customerapi.Migrations
{
    /// <inheritdoc />
    public partial class SeedDB : Migration
    {
        // 100 randomly generated first names
        string[] firstNames = new string[] { "Owen", "Tariq", "Paula", "Sam", "Omari", "Rahim", "Tony", "Szymon", "Denzel", "Sufyan", "Phillip", "Michaela", "Anas", "Tammy", "Lorraine", "Liyana", "Kaleb", "Junior", "Owais", "Ruben", "Leia", "Davina", "Cyrus", "Kayla", "Isabelle", "Hanna", "Stella", "Jak", "Laurie", "Ellis O", "Kira", "Jazmine", "Subhan", "Deborah", "Lucinda", "Ava", "Jed", "John", "Ciara", "Rosie", "Lewis", "Mark", "Alivia", "Cassius", "Myla", "Barry", "Zakir", "Earl", "Ollie", "Ibraheem", "Aneesa", "Johnathan", "Willie", "India", "Ned", "Autumn", "Crystal", "Lacey", "Mikolaj", "Shane", "Antony", "Andrew", "Ezekiel", "Maksymilian", "Rhianna", "Keith", "Katherine", "Warren", "Eva", "Idris", "Mercedes", "Abdulrahman", "Niall", "Zachary", "Martha", "Lara", "Caleb", "Keyaan", "Enya", "Ebony", "Rafe", "Neve", "Hussain", "Matthew", "Abigail", "Luke", "Steve", "Shauna", "Athena", "Maddie", "Ayden", "Leonardo", "Sandra", "Yusra", "Greta", "Valentina", "Jakub", "Farhan", "Kyra", "Freddy" };

        // 100 randomly generated last names
        string[] lastNames = new string[] { "Calhoun", "Wilcox", "Andrade", "Christian", "Murray", "French", "Collins", "Myers", "Lane", "Carver", "Oconnor", "Heath", "Phelps", "Contreras", "Shaffer", "Gonzalez", "Cervantes", "Moses", "Mack", "Cole", "Wong", "Pearce", "Doherty", "Ortiz", "Floyd", "Potter", "Jordan", "Wolf", "Wagner", "Neill", "Sanders", "Terry", "Robinson", "Martinez", "Strong", "Allen", "Melendez", "Juarez", "Bowman", "Boone", "Cherry", "Tate", "Wu", "Roman", "Walter", "Mosley", "Roy", "House", "Thompson", "Roach", "Lucero", "Buck", "Thornton", "Caldwell", "Fuller", "Whitehead", "Holland", "Blackburn", "Gillespie", "Petersen", "Glass", "Hicks", "Beasley", "Foley", "Harrison", "Parsons", "Trujillo", "Rivas", "Boyle", "Hart", "Blankenship", "Reynolds", "Henderson", "Bonilla", "Hahn", "Burch", "Rose", "Carey", "Cardenas", "Bell", "Gross", "Kennedy", "Harris", "Irwin", "Church", "Owen", "Craig", "Rangel", "Dejesus", "Burke", "Hammond", "Hancock", "Hanson", "Mullen", "Molina", "Perez", "Maxwell", "Cain", "Deleon", "Hughes" };

        /// Inserts 100 random customers
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            Random random = new Random();

            // Insert 1000 customers using random name combinations
            for (int i = 0; i < 1000; i++)
            {
                migrationBuilder.InsertData(
                    table: "Customer",
                    columns: new[] { "first_name", "last_name" },
                    columnTypes: new[] { "varchar", "varchar" },
                    values: new string[] { firstNames[random.Next(0, firstNames.Length)], lastNames[random.Next(0, lastNames.Length)] }
                );
            }
        }

        /// Delete all customers
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Customer",
                keyColumn: "id",
                keyValues: null
            );
        }
    }
}

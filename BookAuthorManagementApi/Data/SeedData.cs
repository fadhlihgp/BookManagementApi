using BookAuthorManagementApi.Entities;

namespace BookAuthorManagementApi.Data;

public class SeedData
{
    public static readonly List<User> Users = new List<User>
    {
        new User
        {
            Id = "fa5d042a-9fe5-4cac-867f-339e1cf7e183",
            UserName = "admin",
            Password = BCrypt.Net.BCrypt.HashPassword("Admin123/"),
            Role = Roles.Administrator.ToString()
        },
        new User
        {
            Id = "4f2da188-4413-41f9-863a-4ce2f0b53bb4",
            UserName = "admin2",
            Password = BCrypt.Net.BCrypt.HashPassword("Admin123/"),
            Role = Roles.Administrator.ToString()
        }
    };

    public static readonly List<Author> Authors = new List<Author>
    {
        new Author
        {
            Id = "722e680a-cd6d-4e76-9c26-7211d0715389",
            FullName = "Rangga Duta",
            Address = "Jalan Raya, Pasar Rebo, Jakarta Timur",
            Phone = "08988838388",
            BirthDate = new DateTime(1990, 11, 12),
        },
        new Author
        {
            Id ="bf238d0a-386b-4728-a570-62f41b654548",
            FullName = "Arya Samudra",
            Address = "Jalan Palembang, Bekasi",
            Phone = "08378723",
            BirthDate = new DateTime(1983, 10, 01),
        },
        new Author
        {
            Id ="d7238d0a-386b-4728-a570-62f41b654549",
            FullName = "Budi Santoso",
            Address = "Jalan Sudirman, Jakarta Selatan",
            Phone = "081234567890",
            BirthDate = new DateTime(1985, 5, 15),
        },
        new Author
        {
            Id ="e8238d0a-386b-4728-a570-62f41b654550",
            FullName = "Dewi Putri",
            Address = "Jalan Gatot Subroto, Bandung",
            Phone = "087654321098",
            BirthDate = new DateTime(1992, 8, 23),
        },
        new Author
        {
            Id ="f9238d0a-386b-4728-a570-62f41b654551",
            FullName = "Eko Prasetyo",
            Address = "Jalan Ahmad Yani, Surabaya",
            Phone = "089876543210",
            BirthDate = new DateTime(1988, 3, 30),
        }
    };

    public static readonly List<Publisher> Publishers = new List<Publisher>
    {
        new Publisher
        {
            Id = "b6e5cb17-7758-4cdf-ac9f-5bf12cb4086e",
            Name = "Gramedia",
            Address = "Jakarta Pusat",
            Phone = "02100309944",
            IsDeleted = false,
        },
        new Publisher
        {
            Id ="c8e5cb17-7758-4cdf-ac9f-5bf12cb4086f",
            Name = "Erlangga",
            Address = "Jakarta Selatan",
            Phone = "02177309944",
            IsDeleted = false,
        },
        new Publisher
        {
            Id ="d9e5cb17-7758-4cdf-ac9f-5bf12cb4086g",
            Name = "Mizan",
            Address = "Bandung",
            Phone = "02288309944",
            IsDeleted = false,
        }

    };

    public static readonly List<Book> Books = new List<Book>
    {
        new Book
        {
            Id ="4ef010ae-5996-47c3-b367-7a6f93b2c605",
            Title = "Sang Penjaga Langit",
            PublicationYear = 2017,
            Description =
                "Buku tentang petualangan seorang penjaga langit yang menjadi saksi dari kejadian misterius di langit.",
            AuthorId ="e8238d0a-386b-4728-a570-62f41b654550",
            PublisherId ="c8e5cb17-7758-4cdf-ac9f-5bf12cb4086f",
        },
        new Book
        {
            Id ="5ef010ae-5996-47c3-b367-7a6f93b2c606",
            Title = "Rahasia Pulau Tersembunyi",
            PublicationYear = 2019,
            Description =
                "Sebuah novel petualangan tentang ekspedisi ke pulau misterius yang menyimpan banyak rahasia.",
            AuthorId ="e8238d0a-386b-4728-a570-62f41b654550",
            PublisherId ="b6e5cb17-7758-4cdf-ac9f-5bf12cb4086e",
        },
        new Book
        {
            Id ="6ef010ae-5996-47c3-b367-7a6f93b2c607",
            Title = "Kisah dari Masa Depan",
            PublicationYear = 2020,
            Description = "Buku fiksi ilmiah yang mengisahkan kehidupan manusia di tahun 2150.",
            AuthorId ="f9238d0a-386b-4728-a570-62f41b654551",
            PublisherId ="d9e5cb17-7758-4cdf-ac9f-5bf12cb4086g",
        },
        new Book
        {
            Id ="7ef010ae-5996-47c3-b367-7a6f93b2c608",
            Title = "Jejak Sang Penulis",
            PublicationYear = 2018,
            Description = "Memoar seorang penulis terkenal yang mengungkap perjalanan hidupnya dalam dunia literasi.",
            AuthorId ="e8238d0a-386b-4728-a570-62f41b654550",
            PublisherId ="c8e5cb17-7758-4cdf-ac9f-5bf12cb4086f",
        },
        new Book
        {
            Id ="8ef010ae-5996-47c3-b367-7a6f93b2c609",
            Title = "Filosofi Kehidupan",
            PublicationYear = 2021,
            Description = "Buku yang membahas berbagai aspek filosofis dalam kehidupan sehari-hari.",
            AuthorId ="f9238d0a-386b-4728-a570-62f41b654551",
            PublisherId ="b6e5cb17-7758-4cdf-ac9f-5bf12cb4086e",
        },
        new Book
        {
            Id ="9ef010ae-5996-47c3-b367-7a6f93b2c610",
            Title = "Misteri Kota Tua",
            PublicationYear = 2022,
            Description = "Novel misteri yang mengungkap rahasia gelap sebuah kota tua yang terlupakan.",
            AuthorId ="e8238d0a-386b-4728-a570-62f41b654550",
            PublisherId ="d9e5cb17-7758-4cdf-ac9f-5bf12cb4086g",
        }

    };
}
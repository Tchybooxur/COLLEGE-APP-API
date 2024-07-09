namespace COLLEGE_APPLICATION.Models
{
    public static class CollegeRepository
    {
        public static List<Student> students { get; set; } = new List<Student>() 
        {
            new Student()
            {
                Id = 1,
                Name = "chibuzoreze",
                Email = "chibuzor@email.com",
                Address = "Banana Island, Lagos"
            },
            new Student()
            {
                Id = 2,
                Name = "sundayokobi",
                Email = "Okobi@email.com",
                Address = "Ogba Island, Lagos"
            },
            new Student()
            {
                Id = 3,
                Name = "attahbecky",
                Email = "becky@email.com",
                Address = "Gbagada Island, Lagos"
            },
            new Student()
            {
                Id = 4,
                Name = "mohammedsaleh",
                Email = "saleh@email.com",
                Address = "Obalende Island, Lagos"
            },
            new Student()
            {
                Id = 5,
                Name = "ogbechristopher",
                Email = "ogbe@email.com",
                Address = "iyanaoworo Island, Lagos"
            },
            new Student()
            {
                Id = 6,
                Name = "ozuemabanifi",
                Email = "ozuem@email.com",
                Address = "alapere Island, Lagos"
            },
            new Student()
            {
                Id = 7,
                Name = "izieisioro",
                Email = "izie@email.com",
                Address = "berger Island, Lagos"
            }

        };
    }
}

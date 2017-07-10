using System.ComponentModel.DataAnnotations;

namespace webapp{
    public class Child{
        public Child(){}
        public Child(int id, string name, int age, string favoriteMovieId){
            Id=id;
            Name = name;
            Age = age;
            FavoriteMovieId = favoriteMovieId;
        }
        public int Id {get;set;}
        [Required]
        [StringLength(50,MinimumLength=3)]
        public string Name {get;set;}
        [Range(0,120)]
        public int Age {get;set;}
        public string Email {get;set;}
        public string FavoriteMovieId {get;set;}
        public Movie FavoriteMovie {get;set;}
        public int FamilyId {get;set;}
    }
}

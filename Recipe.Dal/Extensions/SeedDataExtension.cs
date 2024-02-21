using Microsoft.EntityFrameworkCore;
using Recipe.Entities;

namespace Recipe.Dal.Extensions
{
    public static class SeedDataExtension
    {
        public static void SeedCategories(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CategoriesEntity>().HasData
                (
                new CategoriesEntity
                {
                    Id = 1,
                    Name = "Tatli",
                    ImageUrl= "https://localhost:7056/Images/842f340a-df95-4056-a69d-e3c52b018e80.jpg",
                    Description = "Sütlaç, revani, irmik helvası, muhallebi, tiramisu, kalburabastı, trileçe... Sütlüsü şerbetlisi, fırında kızaranı, ocakta pişeni derken liste uzar da gider."
                },
                new CategoriesEntity
                {
                    Id = 2,
                    Name="Corba",
                    ImageUrl = "https://localhost:7056/Images/22e74683-6324-405e-b56c-708f6daa1a2e.jpg",
                    Description = "Hem doyuruculuğu hem de lezzetiyle sofraların vazgeçilmezi olan çorbalar, hemen hemen her öğünde damaklarımızı şenlendiriyor."
                },
                new CategoriesEntity
                {
                    Id=3,
                    Name="Tavuk",
                    ImageUrl = "https://localhost:7056/Images/72af10ba-47ff-47a6-b5a0-b7b649963450.jpg",
                    Description = "Mutfakta tecrübeniz olmasa da hiç vakit kaybetmeden, kolaylıkla hazırlayabileceğiniz en lezzetli tavuk yemekleri tarifleri sofralarınızda! "
                },
                new CategoriesEntity
                {
                    Id=4,
                    Name="Et",
                    ImageUrl = "https://localhost:7056/Images/55f13044-d2e4-40c8-a98e-ec97c0072c05.jpg",
                    Description = "Hazırladığınız et yemeklerin herkesin beğenisini kazanması için sayfalarımıza göz atmanın tam zamanı! Evde kebap yapımı gibi zorlu yemekleri yapmanın kolay ve pratik yollarını kim öğrenmek istemez?"
                },
                new CategoriesEntity
                {
                    Id=5,
                    Name="Pilav",
                    ImageUrl = "https://localhost:7056/Images/91a1f4cc-8023-430c-9731-e6c8a58dcf6d.jpg",
                    Description = "Türk mutfağının vazgeçilmez yemekleri arasında olan pilavın yapımı, birkaç püf noktayla oldukça kolaylaşır."
                },
                new CategoriesEntity
                {
                    Id=6,
                    Name="Makarna",
                    ImageUrl = "https://localhost:7056/Images/05f58fef-a481-4875-8d9c-99b4bac3c84f.jpg",
                    Description = "Oldukça kolay ve pratik bir şekilde hazırlanan makarnalar, mutfaktaki kurtarıcınız oluyor."
                },
                new CategoriesEntity
                {
                    Id = 7,
                    Name = "Salata",
                    ImageUrl = "https://localhost:7056/Images/cad8a1d6-4033-4f65-bd37-4a0c5d9e16d1.jpg",
                    Description = "Her yemeğin yanına yakışan, sofralarınıza renk katan, damaklarda muhteşem lezzetler bırakan salata tarifleri, sadece bir tık kadar yakınınızda. "
                },
                new CategoriesEntity
                {
                    Id = 8,
                    Name = "Balik",
                    ImageUrl = "https://localhost:7056/Images/af4d177c-494e-4955-9252-0719026d9cdd.jpg",
                    Description = "Balık ile ilgili farklı lezzetler arayanlar, birbirinden pratik balık tarifleri ile sofralarına ayrı bir tat katabilir."
                },
                new CategoriesEntity
                {
                    Id = 9,
                    Name = "Sulu Yemek",
                    ImageUrl = "https://localhost:7056/Images/fcd6b7bd-a184-402e-8fa6-b96131308ad1.jpg",
                    Description = "Çeşit çeşit malzemelerle hazırlayabileceğiniz onlarca sulu yemek tarifi keşfetmeye hazır mısınız? "
                },
                new CategoriesEntity
                {
                    Id = 10,
                    Name = "Hamur Isi",
                    ImageUrl = "https://localhost:7056/Images/82f508e6-2823-408e-8e8f-2a2339dfd5fc.jpg",
                    Description = "İster yumuşacık ister kıyır kıyır olsun, sıcacık bir poğaçaya kim hayır diyebilir ki? Görünümüyle iştah kabartan, lezzetiyle damak çatlatan börek tarifleri sizi bekliyor. zümlü, portakallı, cevizli, tarçınlı, havuçlu ve kakaolu gibi onlarca çeşidi bulunan kekler iştah kabartan kokularıyla bütün evi etkisi altına alacak."
                }
                );
        }
        public static void SeedAmountTypes(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AmountTypesEntity>().HasData(
                new AmountTypesEntity()
                {
                    Id = 1,
                    Name = "Cay Kasigi"

                },
                new AmountTypesEntity()
                {
                    Id = 2,
                    Name = "Tatli Kasigi"

                },
                new AmountTypesEntity()
                {
                    Id = 3,
                    Name = "Yemek Kasigi"

                },
                new AmountTypesEntity()
                {
                    Id = 4,
                    Name = "Cay Bardagi"

                },
                new AmountTypesEntity()
                {
                    Id = 5,
                    Name = "Su Bardagi"

                },
                new AmountTypesEntity()
                {
                    Id = 6,
                    Name = "Gram"

                },
                new AmountTypesEntity()
                {
                    Id = 7,
                    Name = "Adet"

                },
                new AmountTypesEntity()
                {
                    Id = 8,
                    Name = "Dis"

                },
                new AmountTypesEntity()
                {
                    Id = 9,
                    Name = "Demet"

                }, new AmountTypesEntity()
                {
                    Id = 10,
                    Name = "Paket"

                }, new AmountTypesEntity()
                {
                    Id = 11,
                    Name = "Litre"

                },
                new AmountTypesEntity()
                {
                    Id = 12,
                    Name = "ml"

                }
                );
        }

        public static void SeedUsers(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserEntity>().HasData(
                new UserEntity() { Id = 1,UserName = "Admin", Password = "1234", Email = "ebc@gmail.com",RetryCount = 0,Role="Admin" });
        }
    }
}

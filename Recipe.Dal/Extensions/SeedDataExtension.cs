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
                    Description = "Sütlaç, revani, irmik helvası, muhallebi, tiramisu, kalburabastı, trileçe... Sütlüsü şerbetlisi, fırında kızaranı, ocakta pişeni derken liste uzar da gider."
                },
                new CategoriesEntity
                {
                    Id = 2,
                    Name="Corba",
                    Description= "Hem doyuruculuğu hem de lezzetiyle sofraların vazgeçilmezi olan çorbalar, hemen hemen her öğünde damaklarımızı şenlendiriyor."
                },
                new CategoriesEntity
                {
                    Id=3,
                    Name="Tavuk",
                    Description= "Mutfakta tecrübeniz olmasa da hiç vakit kaybetmeden, kolaylıkla hazırlayabileceğiniz en lezzetli tavuk yemekleri tarifleri sofralarınızda! "
                },
                new CategoriesEntity
                {
                    Id=4,
                    Name="Et",
                    Description= "Hazırladığınız et yemeklerin herkesin beğenisini kazanması için sayfalarımıza göz atmanın tam zamanı! Evde kebap yapımı gibi zorlu yemekleri yapmanın kolay ve pratik yollarını kim öğrenmek istemez?"
                },
                new CategoriesEntity
                {
                    Id=5,
                    Name="Pilav",
                    Description= "Türk mutfağının vazgeçilmez yemekleri arasında olan pilavın yapımı, birkaç püf noktayla oldukça kolaylaşır."
                },
                new CategoriesEntity
                {
                    Id=6,
                    Name="Makarna",
                    Description= "Oldukça kolay ve pratik bir şekilde hazırlanan makarnalar, mutfaktaki kurtarıcınız oluyor."
                },
                new CategoriesEntity
                {
                    Id = 7,
                    Name = "Salata",
                    Description = "Her yemeğin yanına yakışan, sofralarınıza renk katan, damaklarda muhteşem lezzetler bırakan salata tarifleri, sadece bir tık kadar yakınınızda. "
                },
                new CategoriesEntity
                {
                    Id = 8,
                    Name = "Balik",
                    Description = "Balık ile ilgili farklı lezzetler arayanlar, birbirinden pratik balık tarifleri ile sofralarına ayrı bir tat katabilir."
                },
                new CategoriesEntity
                {
                    Id = 9,
                    Name = "Sulu Yemek",
                    Description = "Çeşit çeşit malzemelerle hazırlayabileceğiniz onlarca sulu yemek tarifi keşfetmeye hazır mısınız? "
                },
                new CategoriesEntity
                {
                    Id = 10,
                    Name = "Hamur Isi",
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
    }
}

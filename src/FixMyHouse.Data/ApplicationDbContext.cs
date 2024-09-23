using FixMyHouse.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Linq.Expressions;
using System.Text.Json;

namespace FixMyHouse.Data;
public class ApplicationDbContext : IdentityDbContext
{
    public DbSet<ArtisanEntity> Artisans { get; private set; }
    public DbSet<ServiceEntity> Services { get; private set; }
    public DbSet<ArtisanServiceEntity> ArtisanServices { get; private set; }
    public DbSet<ServiceReservationEntity> ServiceReservations { get; private set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        {//Configure schema
            builder
                .Entity<ArtisanServiceEntity>()
                //.OwnsOne(x => x.CustomizationDefaults, x => x.ToJson());
                .Property(x => x.CustomizationDefaults, x => x.HasJsonConversion());

            builder
                .Entity<ServiceReservationEntity>()
                .Property(x => x.CustomizationBooleans, x => x.HasJsonConversion())
                .Property(x => x.CustomizationGuids, x => x.HasJsonConversion())
                .Property(x => x.CustomizationWholeNumbers, x => x.HasJsonConversion());
        }

        OnSeedData(builder);
    }

    private static void OnSeedData(ModelBuilder builder)
    {
        var artisanIds = new
        {
            GoshoPetrov = new Guid("b27681a2-a41c-4b8e-951f-ecf8ecf3f4a7"),
            PetarGeorgiev = new Guid("936f63da-8730-4344-8421-64bf343661f7"),
        };

        var serviceIds = new
        {
            ThermalInsulation = new Guid("4522c17e-c161-4f42-8467-1854344a373b"),
            RoofHydroInsulation = new Guid("f90735af-c71a-4e5a-8e3f-f13919ed4d5d"),
            BathroomTiles = new Guid("608f46ff-bd6d-4025-8435-c768df3cb434"),
            Laminate = new Guid("4cb9e004-1d75-400a-9de1-1a5804303d3a"),
        };

        builder
            .Entity<ArtisanEntity>()
            .HasData([
                new () {
                    Id = artisanIds.GoshoPetrov, FirstName = "Георги", LastName = "Петров",
                    Picture = "gosho.png",
                    Bio = "Георги е алпинист и специализира в покриви и външни топлоизолации",
                },
                new () {
                    Id = artisanIds.PetarGeorgiev, FirstName = "Петър", LastName = "Георгиев",
                    Picture = "pesho.png",
                    Bio = "Петър е майстор по вътрешни ремонти и бани",
                },
            ]);

        builder
            .Entity<ArtisanServiceEntity>()
            .HasData([
                new (){
                    Ref_Artisan = artisanIds.GoshoPetrov, Ref_Service = serviceIds.ThermalInsulation,
                    CustomizationDefaults = [
                        new ServiceCustomizationEntity.Checkbox {
                            Id = new("525e7b61-27d7-4995-9338-9119b54b63b5"),
                            Name = "Екстра дюбели",
                            Description = "+2 години гаранция",
                            Value = false,
                            ValueIfTrue = 100,
                        },
                        new ServiceCustomizationEntity.WholeNumber {
                            Id = new("9aa0097e-135a-47af-beb3-0e3739662e51"),
                            Name = "Външна квадратура",
                            Description = "50 лв/кв.м",
                            Value = 20,
                            ValueMultiplier = 50,
                        },
                        new ServiceCustomizationEntity.Options {
                            Id = new("16a41a23-66b9-42a0-a61d-69aedf9f9c64"),
                            Value = new("a4b86f3c-43c8-4c67-b6af-9f7c5cc45680"),
                            Description = "Цвят на фасадата",
                            Name = "Цвят",
                            AvailableOptions = [
                                new (){ Id = new("a4b86f3c-43c8-4c67-b6af-9f7c5cc45680"), Name = "Бял", Price = 100 },
                                new (){ Id = new("6ec1d8b3-cfe5-4943-8922-ea37ad1579c5"), Name = "Жълт", Price = 150 },
                                new (){ Id = new("f11c62dc-b3d5-4f5a-8cb1-9331e234f61f"), Name = "Розов", Price = 300 },
                            ],
                        }
                    ]
                },
                new (){ Ref_Artisan = artisanIds.GoshoPetrov, Ref_Service = serviceIds.RoofHydroInsulation, CustomizationDefaults = [
                    new ServiceCustomizationEntity.WholeNumber {
                         Id = new("de5a0771-df9d-408c-abce-864e54de37e8"),
                         Name = "Размер на покрив (кв.м)",
                         Description  = "Колко е голям вашият покрив? 70лв/кв.м",
                         Value = 250,
                         ValueMultiplier = 70
                    },
                    new ServiceCustomizationEntity.WholeNumber {
                         Id = new("0f49866d-1215-49ee-8d0f-d0ebdc8fecd5"),
                         Name = "Брой комини и други препятствия",
                         Description  = "100лв / комин",
                         Value = 1,
                         ValueMultiplier = 100
                    },
                ] },
                new (){ Ref_Artisan = artisanIds.PetarGeorgiev, Ref_Service = serviceIds.BathroomTiles, CustomizationDefaults = [
                    new ServiceCustomizationEntity.WholeNumber {
                         Id = new("14a09ac4-3db2-43d1-a471-d6d74a95cd92"),
                         Name = "Общ размер на помещенията (кв.м)",
                         Description  = "Обща квадратура на всички помещения (бани, тоалетни) 110лв/кв.м",
                         Value = 30,
                         ValueMultiplier = 110,
                    },
                    new ServiceCustomizationEntity.WholeNumber {
                         Id = new("69dc7312-25df-4705-8bf0-4fab9a5588b5"),
                         Name = "Брой помещения",
                         Description  = "+1000лв / помещение",
                         Value = 1,
                         ValueMultiplier = 1000
                    },
                ] },
                new (){ Ref_Artisan = artisanIds.PetarGeorgiev, Ref_Service = serviceIds.Laminate, CustomizationDefaults = [
                    new ServiceCustomizationEntity.WholeNumber {
                         Id = new("da89dcb9-ee1a-4eb2-b09c-5d6a0c0e0bca"),
                         Name = "Общ размер на помещенията (кв.м)",
                         Description  = "Обща квадратура на всички помещения (дневна, кухня, спалня) 55лв/кв.м",
                         Value = 70,
                         ValueMultiplier = 55,
                    },
                    new ServiceCustomizationEntity.WholeNumber {
                         Id = new("7d666de3-5f4f-4110-883d-100fe2ea4c2c"),
                         Name = "Брой помещения",
                         Description  = "+300лв / помещение",
                         Value = 1,
                         ValueMultiplier = 300
                    },
                    new ServiceCustomizationEntity.Options {
                        Id = new("130820ee-1ec2-418f-b113-8485bc168d29"),
                        Value = new("13f5e1d4-38d7-4189-84c7-a11765e3eac2"),
                        Description = "Изберете как да излежда вашият под",
                        Name = "Вид настилка",
                        AvailableOptions = [
                            new (){ Id = new("13f5e1d4-38d7-4189-84c7-a11765e3eac2"), Name = "Мокет", Price = 100 },
                            new (){ Id = new("e7671bf6-061e-4bb5-bd85-65caf770936f"), Name = "Ламинат", Price = 150 },
                            new (){ Id = new("dbd2051b-8753-4454-9eee-f5655093b111"), Name = "Паркет", Price = 300 },
                            new (){ Id = new("cb010910-0c31-412e-a32a-5d10f026cbb9"), Name = "Балатум", Price = 75 },
                        ],
                    }
                ] },
            ]);

        builder
            .Entity<ServiceEntity>()
            .HasData([
                new () { Id = serviceIds.ThermalInsulation, Name = "Топлоизолация", Description = "Външни и вътрешни топлоизолации", Picture = "thermal-insulation.png" },
                    new () { Id = serviceIds.BathroomTiles, Name = "Лепене на плочки", Description = "Поставяне на плочки във вашата баня", Picture = "bathroom-tiles.png" },
                    new () { Id = serviceIds.RoofHydroInsulation, Name = "Хидроизолация на покриви", Description = "Хидроизолация на покриви на жилищни сгради. Обадете се, ако покрива тече!", Picture = "roof-hydro.png" },
                    new () { Id = serviceIds.Laminate, Name = "Подова настилка", Description = "Поставяне на подова настилка: паркет, ламинат, мокети и балатум", Picture = "laminate.png" },
            ]);
    }
}

internal static class EntityExtensions
{
    public static EntityTypeBuilder<TEntity> Property<TEntity, TProperty>(
        this EntityTypeBuilder<TEntity> entityBuilder,
        Expression<Func<TEntity, TProperty>> propertyExpression,
        Action<PropertyBuilder<TProperty>> configureProperty)
        where TEntity : class
    {
        configureProperty(entityBuilder.Property(propertyExpression));
        return entityBuilder;
    }

    public static PropertyBuilder<T> HasJsonConversion<T>(this PropertyBuilder<T> builder)
    {
        //https://stackoverflow.com/questions/78320186/ef-core-data-seeding-for-json-column
        builder.HasConversion(
             v => JsonSerializer.Serialize(v, null as JsonSerializerOptions),
            v => JsonSerializer.Deserialize<T>(v, null as JsonSerializerOptions)!
        );
        return builder;
    }
}

public sealed class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
{
    public ApplicationDbContext CreateDbContext(string[] args)
    {
        string connectionString = @"Data Source=localhost;Database=FixMyHouse;Integrated Security=sspi;Encrypt=true;TrustServerCertificate=true;";
        DbContextOptionsBuilder<ApplicationDbContext> builder = new();
        builder.UseSqlServer(connectionString);
        DbContextOptions<ApplicationDbContext> options = builder.Options;
        return new(options);
    }
}

using Microsoft.EntityFrameworkCore;
using OnlineStore.Storage.MS_SQL.DataBase.Interfaces;
using OnlineStore.Storage.MS_SQL.Entities;

namespace OnlineStore.Storage.MS_SQL
{
    public class Context : DbContext, IContext
    {
        public Context(DbContextOptions<Context> options) : base(options) { }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        //public DbSet<ProductToSales> ProductToSales { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var kitchenId = Guid.NewGuid();
            var bedId = Guid.NewGuid();
            var closetId = Guid.NewGuid();
            var divanId = Guid.NewGuid();

            modelBuilder.Entity<ProductType>().HasData
                (
                    new ProductType() { Id = kitchenId, Name = "Кухни" },
                    new ProductType() { Id = bedId, Name = "Кровати" },
                    new ProductType() { Id = closetId, Name = "Шкафы" },
                    new ProductType() { Id = divanId, Name = "Диваны" }
                );

            modelBuilder.Entity<Product>().HasData
                (
                     //Кухни
                     new Product()
                     {
                         ProductTypeId = kitchenId,
                         Id = Guid.NewGuid(),
                         Name = "Кухня Деми Белый / Дуб Сонома 1 м",
                         Cost = 6990,
                         ImageUrl = "~/images/kitchen1.jpg",
                         Characteristics = "Размеры (Ш×В×Г): 100 × 200 × 60 см\r\nМатериал корпуса: ЛДСП высокого качества, устойчивое к механическим повреждениям и влаге.\r\nМатериал фасада: МДФ, покрытый защитной пленкой, легко чистится и стойкий к загрязнениям.\r\nЦвет: Корпус – Белый, Фасады – Дуб Сонома.",
                         CountOfProduct = 100
                     },
                     new Product()
                     {
                         ProductTypeId = kitchenId,
                         Id = Guid.NewGuid(),
                         Name = "Кухонный гарнитур Деми 1 м Авиньон/Перлино",
                         Cost = 5990,
                         ImageUrl = "~/images/kitchen2.jpg",
                         Characteristics = "Размеры (Ш×В×Г): 100 × 200 × 60 см, оптимальный вариант для небольшой кухни.\r\nМатериал корпуса: Высококачественное ЛДСП, устойчивое к влаге, царапинам и длительной эксплуатации.\r\nМатериал фасадов: ЛДСП с защитной пленкой, которая защищает поверхность от пятен и упрощает уход.\r\nЦвет: Корпус выполнен в цвете Авиньон (приглушенный серый), фасады — в светлом Перлино\r\nФурнитура: Металлические ручки и надежные петли, обеспечивающие плавное открытие и долговечность гарнитура.",
                         CountOfProduct = 100
                     },
                      new Product()
                      {
                          ProductTypeId = kitchenId,
                          Id = Guid.NewGuid(),
                          Name = "Кухня Элен Белый/Дуб Планк, 1.7 м",
                          Cost = 19990,
                          ImageUrl = "~/images/kitchen3.jpg",
                          Characteristics = "Размеры (Ш×В×Г): 170 × 200 × 60 см — гарнитур подойдет как для небольшой, так и для средней кухни, обеспечивая достаточно места для хранения.\r\nМатериал корпуса: ЛДСП, устойчивая к влаге и высоким температурам, с защитной поверхностью от пятен и царапин.\r\nМатериал фасадов: ЛДСП с ламинированным покрытием — практичное и долговечное решение для кухни.\r\nЦвет: Белоснежные фасады в сочетании с текстурой древесины Дуб Планк создают стильный, но нейтральный дизайн, который легко интегрируется в разные интерьеры.\r\nФурнитура: Современные металлические ручки и качественная фурнитура, обеспечивающая плавное и бесшумное открытие дверей.",
                          CountOfProduct = 100
                      },
                       new Product()
                       {
                           ProductTypeId = kitchenId,
                           Id = Guid.NewGuid(),
                           Name = "Кухонный гарнитур Регина, 2.4 м",
                           Cost = 27990,
                           ImageUrl = "~/images/kitchen4.jpg",
                           Characteristics = "Размеры (Ш×В×Г): 240 × 210 × 60 см — идеально подходит для просторных кухонь, обеспечивая большое рабочее пространство и достаточное количество мест для хранения.\r\nМатериал корпуса: ЛДСП, устойчивая к механическим повреждениям, влаге и высокой температуре.\r\nМатериал фасадов: МДФ с глянцевым покрытием — обеспечивает легкий уход и привлекательный внешний вид.\r\nЦвет: Деликатный кремовый оттенок с текстурой дерева, который привносит в интерьер уют и гармонию.\r\nФурнитура: Надежные металлические ручки и высококачественные петли для плавного и бесшумного открытия дверей.",
                           CountOfProduct = 100
                       },

                    //Шкафы
                    new Product()
                    {
                        ProductTypeId = closetId,
                        Id = Guid.NewGuid(),
                        Name = "Шкаф-купе Медея СБ-2907, 1500",
                        Cost = 20990,
                        ImageUrl = "~/images/closet1.jpg",
                        Characteristics = "Размеры (Ш×В×Г): 1500 × 2200 × 600 мм\r\nМатериал корпуса: ЛДСП высокого качества, устойчивое к износу и влаге.\r\nМатериал фасада: МДФ с покрытием, легкий в уходе и стойкий к царапинам.\r\nЦвет: Корпус и фасады выполнены в современном дизайне, с благородными оттенками дерева.\r\nФурнитура: Долговечная и надежная, из нержавеющей стали, обеспечивает плавное скольжение дверей.",
                        CountOfProduct = 100
                    },
                    new Product()
                    {
                        ProductTypeId = closetId,
                        Id = Guid.NewGuid(),
                        Name = "Шкаф-купе Терра СБ-2610",
                        Cost = 13490,
                        ImageUrl = "~/images/closet2.jpg",
                        Characteristics = "Размеры (Ш×В×Г): 1200 × 2000 × 500 мм\r\nМатериал корпуса: ЛДСП с высококачественным покрытием, стойким к повреждениям и влаге.\r\nМатериал фасада: МДФ с защитным покрытием, легким в уходе и устойчивым к царапинам.\r\nЦвет: Универсальные оттенки, подходящие для большинства интерьеров.\r\nФурнитура: Прочная и удобная в использовании, обеспечивает бесшумное открытие дверей.",
                        CountOfProduct = 100
                    },
                    new Product()
                    {
                        ProductTypeId = closetId,
                        Id = Guid.NewGuid(),
                        Name = "Шкаф-купе Бася СБ-2746/1",
                        Cost = 18990,
                        ImageUrl = "~/images/closet3.jpg",
                        Characteristics = "Размеры (Ш×В×Г): 1500 × 2100 × 600 мм\r\nМатериал корпуса: ЛДСП высокого качества с устойчивым к повреждениям и влаге покрытием.\r\nМатериал фасада: МДФ с защитной пленкой, что облегчает уход и сохраняет внешний вид на долгое время.\r\nЦвет: Современные оттенки, подходящие для различных интерьеров.\r\nФурнитура: Надежная и долговечная, обеспечивает плавное и бесшумное движение дверей.",
                        CountOfProduct = 100
                    },
                    new Product()
                    {
                        ProductTypeId = closetId,
                        Id = Guid.NewGuid(),
                        Name = "Шкаф 4-дверный с ящиками Леон СБ-3364",
                        Cost = 17490,
                        ImageUrl = "~/images/closet4.jpg",
                        Characteristics = "Размеры (Ш×В×Г): 1600 × 2200 × 600 мм\r\nМатериал корпуса: ЛДСП высокого качества, устойчивый к влаге и механическим повреждениям.\r\nМатериал фасада: Ламинированная поверхность, защищённая от царапин и легко чистится.\r\nЦвет: Современный универсальный оттенок, который гармонично впишется в любой интерьер.\r\nФурнитура: Надежная и долговечная, обеспечивает плавное открывание и закрывание дверей и ящиков.",
                        CountOfProduct = 100
                    },

                    //Диваны
                    new Product()
                    {
                        ProductTypeId = divanId,
                        Id = Guid.NewGuid(),
                        Name = "Диван угловой Венеция",
                        Cost = 21990,
                        ImageUrl = "~/images/sofa1.jpg",
                        Characteristics = "Размеры (Ш×В×Г): 2200 × 950 × 950 мм\r\nМатериал обивки: Экокожа высокого качества, устойчивая к загрязнениям и легко очищаемая.\r\nНаполнитель: Поролон с высокой плотностью для максимального комфорта.\r\nЦвет: Светлый бежевый, который легко комбинируется с любыми оттенками интерьера.\r\nМеханизм трансформации: Положение «книжка» для удобства сна и отдыха.",
                        CountOfProduct = 50
                    },
                    new Product()
                    {
                        ProductTypeId = divanId,
                        Id = Guid.NewGuid(),
                        Name = "Диван прямой Классик",
                        Cost = 12490,
                        ImageUrl = "~/images/sofa2.jpg",
                        Characteristics = "Размеры (Ш×В×Г): 1800 × 850 × 900 мм\r\nМатериал обивки: Ткань рогожка, приятная на ощупь и устойчивая к износу.\r\nНаполнитель: Холлофайбер, который долго сохраняет свою форму.\r\nЦвет: Темно-серый, универсальный и стильный оттенок для любой комнаты.\r\nФурнитура: Прочные металлические ножки и застежки, которые обеспечивают долговечность и стабильность.",
                        CountOfProduct = 80
                    },
                    new Product()
                    {
                        ProductTypeId = divanId,
                        Id = Guid.NewGuid(),
                        Name = "Диван модульный Лондон",
                        Cost = 29990,
                        ImageUrl = "~/images/sofa3.jpg",
                        Characteristics = "Размеры (Ш×В×Г): 2500 × 950 × 1000 мм\r\nМатериал обивки: Высококачественная микрофибра, не выгорает на солнце и легко чистится.\r\nНаполнитель: Мемори-фоам, адаптирующийся под форму тела, обеспечивающий комфорт при длительном сидении.\r\nЦвет: Синий с легким оттенком серого, придающий элегантности и свежести любому помещению.\r\nОсобенности: Раздвижной механизм, который позволяет преобразовывать диван в удобное спальное место.",
                        CountOfProduct = 30
                    },
                    new Product()
                    {
                        ProductTypeId = divanId,
                        Id = Guid.NewGuid(),
                        Name = "Диван угловой Санторини",
                        Cost = 24990,
                        ImageUrl = "~/images/sofa4.jpg",
                        Characteristics = "Размеры (Ш×В×Г): 2400 × 1000 × 950 мм\r\nМатериал обивки: Бархат с эффектом перелива, который добавляет текстуры и уюта.\r\nНаполнитель: Водорослевый латекс, обеспечивающий комфорт и поддержку в течение всего дня.\r\nЦвет: Глубокий бордовый оттенок, который идеально подходит для современного интерьера.\r\nМеханизм трансформации: Аккордеон, что позволяет быстро разложить диван в удобное спальное место.",
                        CountOfProduct = 60
                    },

                    //Кровати
                    new Product()
                    {
                        ProductTypeId = bedId,
                        Id = Guid.NewGuid(),
                        Name = "Кровать двухспальная Элита",
                        Cost = 19990,
                        ImageUrl = "~/images/catalog_bed1.jpg",
                        Characteristics = "Размеры (Ш×Д×В): 1600 × 2000 × 900 мм\r\nМатериал каркаса: Ламинированный МДФ, устойчивый к механическим повреждениям и воздействию влаги.\r\nМатериал изголовья: Мягкое велюровое покрытие с современным дизайном.\r\nЦвет: Белый с серыми вставками, подходящий для различных интерьеров.\r\nОсобенности: Встроенные ящики для хранения постельных принадлежностей, легкость в сборке.",
                        CountOfProduct = 40
                    },
                    new Product()
                    {
                        ProductTypeId = bedId,
                        Id = Guid.NewGuid(),
                        Name = "Кровать с подъемным механизмом Вальс",
                        Cost = 22490,
                        ImageUrl = "~/images/catalog_bed2.jpg",
                        Characteristics = "Размеры (Ш×Д×В): 1800 × 2000 × 950 мм\r\nМатериал каркаса: Бук и фанера, прочные и экологичные материалы.\r\nМатериал обивки: Ткань с эффектом кожи, приятная на ощупь и устойчивая к загрязнениям.\r\nЦвет: Классический черный с элементами дерева.\r\nОсобенности: Подъемный механизм для легкого доступа к месту хранения, максимальный комфорт для сна.",
                        CountOfProduct = 25
                    },
                    new Product()
                    {
                        ProductTypeId = bedId,
                        Id = Guid.NewGuid(),
                        Name = "Кровать с каркасом из металла Орион",
                        Cost = 15990,
                        ImageUrl = "~/images/catalog_bed3.jpg",
                        Characteristics = "Размеры (Ш×Д×В): 1400 × 2000 × 850 мм\r\nМатериал каркаса: Сталь с порошковым покрытием, защищающим от коррозии.\r\nМатериал обивки: Легкая дышащая ткань с антисептическими свойствами.\r\nЦвет: Серый металлик, современный и стильный.\r\nОсобенности: Компактный и удобный вариант для небольших помещений, простота в уходе.",
                        CountOfProduct = 60
                    },
                    new Product()
                    {
                        ProductTypeId = bedId,
                        Id = Guid.NewGuid(),
                        Name = "Кровать с мягким изголовьем Венеция",
                        Cost = 27990,
                        ImageUrl = "~/images/catalog_bed4.jpg",
                        Characteristics = "Размеры (Ш×Д×В): 2000 × 2100 × 1000 мм\r\nМатериал каркаса: Массив дерева с дополнительной усиленной конструкцией.\r\nМатериал изголовья: Мягкое велюровое покрытие с декоративной отделкой.\r\nЦвет: Шоколадный с золотыми вставками, элегантный и роскошный.\r\nОсобенности: Удобное изголовье для чтения или отдыха, богатая отделка и внимание к деталям.",
                        CountOfProduct = 35
                    }
                );
            modelBuilder.Entity<Client>()
                .HasMany(c => c.Sales)
                .WithOne(Sale => Sale.Client)
                .HasForeignKey(Sale => Sale.ClientId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ProductType>()
                .HasMany(p => p.Products)
                .WithOne(p => p.ProductType)
                .HasForeignKey(p => p.ProductTypeId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Sale>()
                .HasMany(s => s.Products)
                .WithMany(p => p.Sales)
                .UsingEntity(j => j.ToTable("ProductsToSales"));
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Server = localhost, 1433;DataBase = OnlineStoreDataBase;User ID = sa;Password=sjfkdjFDF!so12fjks;MultipleActiveResultSets=true;TrustServerCertificate=True");
        //}

    }
}

using Catalog.API.Entities;
using MongoDB.Driver;

namespace Catalog.API.Data;

public class CatalogContextSeed
{
    public static void SeedData(IMongoCollection<Product> productCollection)
    {
        bool existProduct = productCollection.Find(p => true).Any();
        if (!existProduct)
        {
            productCollection.InsertManyAsync(GetPreconfiguredProducts());
        }
    }

    private static IEnumerable<Product> GetPreconfiguredProducts()
    {
        return new List<Product>
    {
        // SMARTPHONES
        new() { Id = Guid.NewGuid(), Name = "iPhone X", Description = "Smartphone Apple com ótimo desempenho.", ImageFile = "product-1.png", Price = 950.00M, Category = "Smartphone" },
        new() { Id = Guid.NewGuid(), Name = "iPhone 13", Description = "Smartphone Apple com câmera avançada.", ImageFile = "product-2.png", Price = 4200.00M, Category = "Smartphone" },
        new() { Id = Guid.NewGuid(), Name = "iPhone 14 Pro", Description = "Modelo premium da Apple com alta performance.", ImageFile = "product-3.png", Price = 6200.00M, Category = "Smartphone" },
        new() { Id = Guid.NewGuid(), Name = "Samsung Galaxy S21", Description = "Smartphone Samsung rápido e moderno.", ImageFile = "product-4.png", Price = 2800.00M, Category = "Smartphone" },
        new() { Id = Guid.NewGuid(), Name = "Samsung Galaxy S23", Description = "Top de linha Samsung com excelente câmera.", ImageFile = "product-5.png", Price = 4500.00M, Category = "Smartphone" },
        new() { Id = Guid.NewGuid(), Name = "Xiaomi Mi 11", Description = "Smartphone com ótimo custo-benefício.", ImageFile = "product-6.png", Price = 2200.00M, Category = "Smartphone" },
        new() { Id = Guid.NewGuid(), Name = "Xiaomi Redmi Note 12", Description = "Smartphone intermediário muito popular.", ImageFile = "product-7.png", Price = 1500.00M, Category = "Smartphone" },
        new() { Id = Guid.NewGuid(), Name = "Motorola Edge 40", Description = "Smartphone moderno com bom desempenho.", ImageFile = "product-8.png", Price = 2300.00M, Category = "Smartphone" },

        // NOTEBOOKS
        new() { Id = Guid.NewGuid(), Name = "MacBook Air M1", Description = "Notebook leve e rápido da Apple.", ImageFile = "product-9.png", Price = 6500.00M, Category = "Notebook" },
        new() { Id = Guid.NewGuid(), Name = "MacBook Pro M2", Description = "Notebook profissional de alto desempenho.", ImageFile = "product-10.png", Price = 9800.00M, Category = "Notebook" },
        new() { Id = Guid.NewGuid(), Name = "Dell XPS 13", Description = "Notebook premium compacto.", ImageFile = "product-11.png", Price = 8200.00M, Category = "Notebook" },
        new() { Id = Guid.NewGuid(), Name = "Dell Inspiron 15", Description = "Notebook para uso diário.", ImageFile = "product-12.png", Price = 3900.00M, Category = "Notebook" },
        new() { Id = Guid.NewGuid(), Name = "Lenovo ThinkPad X1", Description = "Notebook corporativo robusto.", ImageFile = "product-13.png", Price = 8800.00M, Category = "Notebook" },
        new() { Id = Guid.NewGuid(), Name = "Acer Aspire 5", Description = "Notebook custo-benefício.", ImageFile = "product-14.png", Price = 3500.00M, Category = "Notebook" },

        // CONSOLES
        new() { Id = Guid.NewGuid(), Name = "PlayStation 5", Description = "Console de última geração da Sony.", ImageFile = "product-15.png", Price = 4200.00M, Category = "Console" },
        new() { Id = Guid.NewGuid(), Name = "Xbox Series X", Description = "Console potente da Microsoft.", ImageFile = "product-16.png", Price = 4100.00M, Category = "Console" },
        new() { Id = Guid.NewGuid(), Name = "Xbox Series S", Description = "Console compacto e acessível.", ImageFile = "product-17.png", Price = 2600.00M, Category = "Console" },
        new() { Id = Guid.NewGuid(), Name = "Nintendo Switch", Description = "Console híbrido portátil.", ImageFile = "product-18.png", Price = 2900.00M, Category = "Console" },

        // HEADSETS / ÁUDIO
        new() { Id = Guid.NewGuid(), Name = "AirPods Pro", Description = "Fone sem fio com cancelamento de ruído.", ImageFile = "product-19.png", Price = 1800.00M, Category = "Áudio" },
        new() { Id = Guid.NewGuid(), Name = "Sony WH-1000XM5", Description = "Headphone premium com ANC.", ImageFile = "product-20.png", Price = 2300.00M, Category = "Áudio" },
        new() { Id = Guid.NewGuid(), Name = "JBL Tune 510BT", Description = "Fone Bluetooth custo-benefício.", ImageFile = "product-21.png", Price = 320.00M, Category = "Áudio" },
        new() { Id = Guid.NewGuid(), Name = "HyperX Cloud II", Description = "Headset gamer confortável.", ImageFile = "product-22.png", Price = 650.00M, Category = "Áudio" },

        // PERIFÉRICOS
        new() { Id = Guid.NewGuid(), Name = "Mouse Logitech MX Master 3", Description = "Mouse sem fio profissional.", ImageFile = "product-23.png", Price = 650.00M, Category = "Periféricos" },
        new() { Id = Guid.NewGuid(), Name = "Teclado Mecânico Redragon", Description = "Teclado gamer mecânico.", ImageFile = "product-24.png", Price = 450.00M, Category = "Periféricos" },
        new() { Id = Guid.NewGuid(), Name = "Monitor LG 27''", Description = "Monitor Full HD para trabalho.", ImageFile = "product-25.png", Price = 1200.00M, Category = "Periféricos" },
        new() { Id = Guid.NewGuid(), Name = "Webcam Logitech C920", Description = "Webcam Full HD.", ImageFile = "product-26.png", Price = 550.00M, Category = "Periféricos" },

        // SMART HOME
        new() { Id = Guid.NewGuid(), Name = "Echo Dot 5ª Geração", Description = "Assistente virtual Alexa.", ImageFile = "product-27.png", Price = 380.00M, Category = "Smart Home" },
        new() { Id = Guid.NewGuid(), Name = "Google Nest Mini", Description = "Assistente virtual Google.", ImageFile = "product-28.png", Price = 350.00M, Category = "Smart Home" },
        new() { Id = Guid.NewGuid(), Name = "Lâmpada Inteligente Wi-Fi", Description = "Lâmpada controlada por app.", ImageFile = "product-29.png", Price = 120.00M, Category = "Smart Home" },
        new() { Id = Guid.NewGuid(), Name = "Tomada Inteligente", Description = "Controle remoto de energia.", ImageFile = "product-30.png", Price = 150.00M, Category = "Smart Home" },

        // DIVERSOS
        new() { Id = Guid.NewGuid(), Name = "HD Externo 1TB", Description = "Armazenamento portátil.", ImageFile = "product-31.png", Price = 420.00M, Category = "Armazenamento" },
        new() { Id = Guid.NewGuid(), Name = "SSD NVMe 1TB", Description = "SSD de alta velocidade.", ImageFile = "product-32.png", Price = 650.00M, Category = "Armazenamento" },
        new() { Id = Guid.NewGuid(), Name = "Power Bank 20000mAh", Description = "Bateria portátil.", ImageFile = "product-33.png", Price = 220.00M, Category = "Acessórios" },
        new() { Id = Guid.NewGuid(), Name = "Carregador USB-C 65W", Description = "Carregador rápido.", ImageFile = "product-34.png", Price = 180.00M, Category = "Acessórios" },

        // GAMER
        new() { Id = Guid.NewGuid(), Name = "Cadeira Gamer", Description = "Cadeira ergonômica gamer.", ImageFile = "product-35.png", Price = 1200.00M, Category = "Gamer" },
        new() { Id = Guid.NewGuid(), Name = "Mousepad XXL", Description = "Mousepad grande para jogos.", ImageFile = "product-36.png", Price = 150.00M, Category = "Gamer" },
        new() { Id = Guid.NewGuid(), Name = "Controle Xbox", Description = "Controle sem fio original.", ImageFile = "product-37.png", Price = 480.00M, Category = "Gamer" },

        // EXTRA
        new() { Id = Guid.NewGuid(), Name = "Tablet Samsung S8", Description = "Tablet para trabalho e lazer.", ImageFile = "product-38.png", Price = 3900.00M, Category = "Tablet" },
        new() { Id = Guid.NewGuid(), Name = "iPad 10ª Geração", Description = "Tablet Apple versátil.", ImageFile = "product-39.png", Price = 4500.00M, Category = "Tablet" },
        new() { Id = Guid.NewGuid(), Name = "Kindle Paperwhite", Description = "Leitor de e-books.", ImageFile = "product-40.png", Price = 650.00M, Category = "Leitura" }
    };
    }

}
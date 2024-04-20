﻿namespace BethanysPieShop.Models;

public static class DbInitializer
{
    /// <summary>
    /// Método para popular o banco de dados com dados iniciais	
    /// </summary>
    /// <param name="applicationBuilder">Interface para configurar uma aplicação</param>
    public static void Seed(IApplicationBuilder applicationBuilder)
    {
        // Cria uma instância do contexto do banco de dados.
        BethanysPieShopDbContext context = applicationBuilder.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<BethanysPieShopDbContext>();

        // Verifica se a tabela de categorias está vazia. Se estiver, adiciona as categorias predefinidas ao banco de dados.
        if (!context.Categorias.Any())
        {
            context.Categorias.AddRange(Categorias.Select(c => c.Value));
        }

        // Verifica se a tabela de tortas está vazia. Se estiver, adiciona as tortas predefinidas ao banco de dados.
        if (!context.Tortas.Any())
        {
            context.AddRange
            (
                new Torta { Nome = "Torta de Caramelo com Pipoca", Preco = 22.95M, DescricaoCurta = "A torta de queijo definitiva", DescricaoDetalhada = "Icing carrot cake jelly-o cheesecake. Sweet roll marzipan marshmallow toffee brownie brownie candy tootsie roll. Chocolate cake gingerbread tootsie roll oat cake pie chocolate bar cookie dragée brownie. Lollipop cotton candy cake bear claw oat cake. Dragée candy canes dessert tart. Marzipan dragée gummies lollipop jujubes chocolate bar candy canes. Icing gingerbread chupa chups cotton candy cookie sweet icing bonbon gummies. Gummies lollipop brownie biscuit danish chocolate cake. Danish powder cookie macaroon chocolate donut tart. Carrot cake dragée croissant lemon drops liquorice lemon drops cookie lollipop toffee. Carrot cake carrot cake liquorice sugar plum topping bonbon pie muffin jujubes. Jelly pastry wafer tart caramels bear claw. Tiramisu tart pie cake danish lemon drops. Brownie cupcake dragée gummies.", Categoria = Categorias["Tortas de Queijo"], ImagemUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/bethanyspieshop/cheesecakes/caramelpopcorncheesecake.jpg", EmEstoque = true, EhTortaDaSemana = true, ImagemThumbnailUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/bethanyspieshop/cheesecakes/caramelpopcorncheesecakesmall.jpg", InformacoesAlergicas = "" },
                new Torta { Nome = "Torta de Chocolate", Preco = 19.95M, DescricaoCurta = "O sonho do amante de chocolate", DescricaoDetalhada = "Icing carrot cake jelly-o cheesecake. Sweet roll marzipan marshmallow toffee brownie brownie candy tootsie roll. Chocolate cake gingerbread tootsie roll oat cake pie chocolate bar cookie dragée brownie. Lollipop cotton candy cake bear claw oat cake. Dragée candy canes dessert tart. Marzipan dragée gummies lollipop jujubes chocolate bar candy canes. Icing gingerbread chupa chups cotton candy cookie sweet icing bonbon gummies. Gummies lollipop brownie biscuit danish chocolate cake. Danish powder cookie macaroon chocolate donut tart. Carrot cake dragée croissant lemon drops liquorice lemon drops cookie lollipop toffee. Carrot cake carrot cake liquorice sugar plum topping bonbon pie muffin jujubes. Jelly pastry wafer tart caramels bear claw. Tiramisu tart pie cake danish lemon drops. Brownie cupcake dragée gummies.", Categoria = Categorias["Tortas de Queijo"], ImagemUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/bethanyspieshop/cheesecakes/chocolatecheesecake.jpg", EmEstoque = true, EhTortaDaSemana = true, ImagemThumbnailUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/bethanyspieshop/cheesecakes/chocolatecheesecakesmall.jpg", InformacoesAlergicas = "" },
                new Torta { Nome = "Torta de Pistache", Preco = 21.95M, DescricaoCurta = "Estamos ficando loucos com este", DescricaoDetalhada = "Icing carrot cake jelly-o cheesecake. Sweet roll marzipan marshmallow toffee brownie brownie candy tootsie roll. Chocolate cake gingerbread tootsie roll oat cake pie chocolate bar cookie dragée brownie. Lollipop cotton candy cake bear claw oat cake. Dragée candy canes dessert tart. Marzipan dragée gummies lollipop jujubes chocolate bar candy canes. Icing gingerbread chupa chups cotton candy cookie sweet icing bonbon gummies. Gummies lollipop brownie biscuit danish chocolate cake. Danish powder cookie macaroon chocolate donut tart. Carrot cake dragée croissant lemon drops liquorice lemon drops cookie lollipop toffee. Carrot cake carrot cake liquorice sugar plum topping bonbon pie muffin jujubes. Jelly pastry wafer tart caramels bear claw. Tiramisu tart pie cake danish lemon drops. Brownie cupcake dragée gummies.", Categoria = Categorias["Tortas de Queijo"], ImagemUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/bethanyspieshop/cheesecakes/pistachecheesecake.jpg", EmEstoque = true, EhTortaDaSemana = true, ImagemThumbnailUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/bethanyspieshop/cheesecakes/pistachecheesecakesmall.jpg", InformacoesAlergicas = "" },
                new Torta { Nome = "Torta de Pecã", Preco = 21.95M, DescricaoCurta = "Mais nozes do que você pode lidar!", DescricaoDetalhada = "Icing carrot cake jelly-o cheesecake. Sweet roll marzipan marshmallow toffee brownie brownie candy tootsie roll. Chocolate cake gingerbread tootsie roll oat cake pie chocolate bar cookie dragée brownie. Lollipop cotton candy cake bear claw oat cake. Dragée candy canes dessert tart. Marzipan dragée gummies lollipop jujubes chocolate bar candy canes. Icing gingerbread chupa chups cotton candy cookie sweet icing bonbon gummies. Gummies lollipop brownie biscuit danish chocolate cake. Danish powder cookie macaroon chocolate donut tart. Carrot cake dragée croissant lemon drops liquorice lemon drops cookie lollipop toffee. Carrot cake carrot cake liquorice sugar plum topping bonbon pie muffin jujubes. Jelly pastry wafer tart caramels bear claw. Tiramisu tart pie cake danish lemon drops. Brownie cupcake dragée gummies.", Categoria = Categorias["Tortas de Frutas"], ImagemUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/bethanyspieshop/fruitpies/pecanpie.jpg", EmEstoque = true, EhTortaDaSemana = false, ImagemThumbnailUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/bethanyspieshop/fruitpies/pecanpiesmall.jpg", InformacoesAlergicas = "" },
                new Torta { Nome = "Torta de Aniversário", Preco = 29.95M, DescricaoCurta = "Um Feliz Aniversário com esta torta!", DescricaoDetalhada = "Icing carrot cake jelly-o cheesecake. Sweet roll marzipan marshmallow toffee brownie brownie candy tootsie roll. Chocolate cake gingerbread tootsie roll oat cake pie chocolate bar cookie dragée brownie. Lollipop cotton candy cake bear claw oat cake. Dragée candy canes dessert tart. Marzipan dragée gummies lollipop jujubes chocolate bar candy canes. Icing gingerbread chupa chups cotton candy cookie sweet icing bonbon gummies. Gummies lollipop brownie biscuit danish chocolate cake. Danish powder cookie macaroon chocolate donut tart. Carrot cake dragée croissant lemon drops liquorice lemon drops cookie lollipop toffee. Carrot cake carrot cake liquorice sugar plum topping bonbon pie muffin jujubes. Jelly pastry wafer tart caramels bear claw. Tiramisu tart pie cake danish lemon drops. Brownie cupcake dragée gummies.", Categoria = Categorias["Tortas Sazonais"], ImagemUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/bethanyspieshop/seasonal/birthdaypie.jpg", EmEstoque = true, EhTortaDaSemana = false, ImagemThumbnailUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/bethanyspieshop/seasonal/birthdaypiesmall.jpg", InformacoesAlergicas = "" },
                new Torta { Nome = "Torta de Maçã", Preco = 12.95M, DescricaoCurta = "Nossas famosas tortas de maçã!", DescricaoDetalhada = "Icing carrot cake jelly-o cheesecake. Sweet roll marzipan marshmallow toffee brownie brownie candy tootsie roll. Chocolate cake gingerbread tootsie roll oat cake pie chocolate bar cookie dragée brownie. Lollipop cotton candy cake bear claw oat cake. Dragée candy canes dessert tart. Marzipan dragée gummies lollipop jujubes chocolate bar candy canes. Icing gingerbread chupa chups cotton candy cookie sweet icing bonbon gummies. Gummies lollipop brownie biscuit danish chocolate cake. Danish powder cookie macaroon chocolate donut tart. Carrot cake dragée croissant lemon drops liquorice lemon drops cookie lollipop toffee. Carrot cake carrot cake liquorice sugar plum topping bonbon pie muffin jujubes. Jelly pastry wafer tart caramels bear claw. Tiramisu tart pie cake danish lemon drops. Brownie cupcake dragée gummies.", Categoria = Categorias["Tortas de Frutas"], ImagemUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/applepie.jpg", EmEstoque = true, EhTortaDaSemana = false, ImagemThumbnailUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/applepiesmall.jpg", InformacoesAlergicas = "" },
                new Torta { Nome = "Torta de Mirtilo", Preco = 18.95M, DescricaoCurta = "Você vai adorar!", DescricaoDetalhada = "Icing carrot cake jelly-o cheesecake. Sweet roll marzipan marshmallow toffee brownie brownie candy tootsie roll. Chocolate cake gingerbread tootsie roll oat cake pie chocolate bar cookie dragée brownie. Lollipop cotton candy cake bear claw oat cake. Dragée candy canes dessert tart. Marzipan dragée gummies lollipop jujubes chocolate bar candy canes. Icing gingerbread chupa chups cotton candy cookie sweet icing bonbon gummies. Gummies lollipop brownie biscuit danish chocolate cake. Danish powder cookie macaroon chocolate donut tart. Carrot cake dragée croissant lemon drops liquorice lemon drops cookie lollipop toffee. Carrot cake carrot cake liquorice sugar plum topping bonbon pie muffin jujubes. Jelly pastry wafer tart caramels bear claw. Tiramisu tart pie cake danish lemon drops. Brownie cupcake dragée gummies.", Categoria = Categorias["Tortas de Queijo"], ImagemUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/bethanyspieshop/cheesecakes/blueberrycheesecake.jpg", EmEstoque = true, EhTortaDaSemana = false, ImagemThumbnailUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/bethanyspieshop/cheesecakes/blueberrycheesecakesmall.jpg", InformacoesAlergicas = "" },
                new Torta { Nome = "Torta de Queijo", Preco = 18.95M, DescricaoCurta = "Torta de queijo simples. Prazer simples.", DescricaoDetalhada = "Icing carrot cake jelly-o cheesecake. Sweet roll marzipan marshmallow toffee brownie brownie candy tootsie roll. Chocolate cake gingerbread tootsie roll oat cake pie chocolate bar cookie dragée brownie. Lollipop cotton candy cake bear claw oat cake. Dragée candy canes dessert tart. Marzipan dragée gummies lollipop jujubes chocolate bar candy canes. Icing gingerbread chupa chups cotton candy cookie sweet icing bonbon gummies. Gummies lollipop brownie biscuit danish chocolate cake. Danish powder cookie macaroon chocolate donut tart. Carrot cake dragée croissant lemon drops liquorice lemon drops cookie lollipop toffee. Carrot cake carrot cake liquorice sugar plum topping bonbon pie muffin jujubes. Jelly pastry wafer tart caramels bear claw. Tiramisu tart pie cake danish lemon drops. Brownie cupcake dragée gummies.", Categoria = Categorias["Tortas de Queijo"], ImagemUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/bethanyspieshop/cheesecakes/cheesecake.jpg", EmEstoque = true, EhTortaDaSemana = false, ImagemThumbnailUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/bethanyspieshop/cheesecakes/cheesecakesmall.jpg", InformacoesAlergicas = "" },
                new Torta { Nome = "Torta de Cereja", Preco = 15.95M, DescricaoCurta = "Um clássico de verão!", DescricaoDetalhada = "Icing carrot cake jelly-o cheesecake. Sweet roll marzipan marshmallow toffee brownie brownie candy tootsie roll. Chocolate cake gingerbread tootsie roll oat cake pie chocolate bar cookie dragée brownie. Lollipop cotton candy cake bear claw oat cake. Dragée candy canes dessert tart. Marzipan dragée gummies lollipop jujubes chocolate bar candy canes. Icing gingerbread chupa chups cotton candy cookie sweet icing bonbon gummies. Gummies lollipop brownie biscuit danish chocolate cake. Danish powder cookie macaroon chocolate donut tart. Carrot cake dragée croissant lemon drops liquorice lemon drops cookie lollipop toffee. Carrot cake carrot cake liquorice sugar plum topping bonbon pie muffin jujubes. Jelly pastry wafer tart caramels bear claw. Tiramisu tart pie cake danish lemon drops. Brownie cupcake dragée gummies.", Categoria = Categorias["Tortas de Frutas"], ImagemUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/cherrypie.jpg", EmEstoque = true, EhTortaDaSemana = false, ImagemThumbnailUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/cherrypiesmall.jpg", InformacoesAlergicas = "" },
                new Torta { Nome = "Torta de Maçã de Natal", Preco = 13.95M, DescricaoCurta = "Felizes festas com esta torta!", DescricaoDetalhada = "Icing carrot cake jelly-o cheesecake. Sweet roll marzipan marshmallow toffee brownie brownie candy tootsie roll. Chocolate cake gingerbread tootsie roll oat cake pie chocolate bar cookie dragée brownie. Lollipop cotton candy cake bear claw oat cake. Dragée candy canes dessert tart. Marzipan dragée gummies lollipop jujubes chocolate bar candy canes. Icing gingerbread chupa chups cotton candy cookie sweet icing bonbon gummies. Gummies lollipop brownie biscuit danish chocolate cake. Danish powder cookie macaroon chocolate donut tart. Carrot cake dragée croissant lemon drops liquorice lemon drops cookie lollipop toffee. Carrot cake carrot cake liquorice sugar plum topping bonbon pie muffin jujubes. Jelly pastry wafer tart caramels bear claw. Tiramisu tart pie cake danish lemon drops. Brownie cupcake dragée gummies.", Categoria = Categorias["Tortas Sazonais"], ImagemUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/christmasapplepie.jpg", EmEstoque = true, EhTortaDaSemana = false, ImagemThumbnailUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/christmasapplepiesmall.jpg", InformacoesAlergicas = "" },
                new Torta { Nome = "Torta de Cranberry", Preco = 17.95M, DescricaoCurta = "Um favorito de Natal", DescricaoDetalhada = "Icing carrot cake jelly-o cheesecake. Sweet roll marzipan marshmallow toffee brownie brownie candy tootsie roll. Chocolate cake gingerbread tootsie roll oat cake pie chocolate bar cookie dragée brownie. Lollipop cotton candy cake bear claw oat cake. Dragée candy canes dessert tart. Marzipan dragée gummies lollipop jujubes chocolate bar candy canes. Icing gingerbread chupa chups cotton candy cookie sweet icing bonbon gummies. Gummies lollipop brownie biscuit danish chocolate cake. Danish powder cookie macaroon chocolate donut tart. Carrot cake dragée croissant lemon drops liquorice lemon drops cookie lollipop toffee. Carrot cake carrot cake liquorice sugar plum topping bonbon pie muffin jujubes. Jelly pastry wafer tart caramels bear claw. Tiramisu tart pie cake danish lemon drops. Brownie cupcake dragée gummies.", Categoria = Categorias["Tortas Sazonais"], ImagemUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/cranberrypie.jpg", EmEstoque = true, EhTortaDaSemana = false, ImagemThumbnailUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/cranberrypiesmall.jpg", InformacoesAlergicas = "" },
                new Torta { Nome = "Torta de Pêssego", Preco = 15.95M, DescricaoCurta = "Doce como pêssego", DescricaoDetalhada = "Icing carrot cake jelly-o cheesecake. Sweet roll marzipan marshmallow toffee brownie brownie candy tootsie roll. Chocolate cake gingerbread tootsie roll oat cake pie chocolate bar cookie dragée brownie. Lollipop cotton candy cake bear claw oat cake. Dragée candy canes dessert tart. Marzipan dragée gummies lollipop jujubes chocolate bar candy canes. Icing gingerbread chupa chups cotton candy cookie sweet icing bonbon gummies. Gummies lollipop brownie biscuit danish chocolate cake. Danish powder cookie macaroon chocolate donut tart. Carrot cake dragée croissant lemon drops liquorice lemon drops cookie lollipop toffee. Carrot cake carrot cake liquorice sugar plum topping bonbon pie muffin jujubes. Jelly pastry wafer tart caramels bear claw. Tiramisu tart pie cake danish lemon drops. Brownie cupcake dragée gummies.", Categoria = Categorias["Tortas de Frutas"], ImagemUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/peachpie.jpg", EmEstoque = false, EhTortaDaSemana = false, ImagemThumbnailUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/peachpiesmall.jpg", InformacoesAlergicas = "" },
                new Torta { Nome = "Torta de Abóbora", Preco = 12.95M, DescricaoCurta = "Nosso favorito de Halloween", DescricaoDetalhada = "Icing carrot cake jelly-o cheesecake. Sweet roll marzipan marshmallow toffee brownie brownie candy tootsie roll. Chocolate cake gingerbread tootsie roll oat cake pie chocolate bar cookie dragée brownie. Lollipop cotton candy cake bear claw oat cake. Dragée candy canes dessert tart. Marzipan dragée gummies lollipop jujubes chocolate bar candy canes. Icing gingerbread chupa chups cotton candy cookie sweet icing bonbon gummies. Gummies lollipop brownie biscuit danish chocolate cake. Danish powder cookie macaroon chocolate donut tart. Carrot cake dragée croissant lemon drops liquorice lemon drops cookie lollipop toffee. Carrot cake carrot cake liquorice sugar plum topping bonbon pie muffin jujubes. Jelly pastry wafer tart caramels bear claw. Tiramisu tart pie cake danish lemon drops. Brownie cupcake dragée gummies.", Categoria = Categorias["Tortas Sazonais"], ImagemUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/pumpkinpie.jpg", EmEstoque = true, EhTortaDaSemana = false, ImagemThumbnailUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/pumpkinpiesmall.jpg", InformacoesAlergicas = "" },
                new Torta { Nome = "Torta de Ruibarbo", Preco = 15.95M, DescricaoCurta = "Meu Deus, tão doce!", DescricaoDetalhada = "Icing carrot cake jelly-o cheesecake. Sweet roll marzipan marshmallow toffee brownie brownie candy tootsie roll. Chocolate cake gingerbread tootsie roll oat cake pie chocolate bar cookie dragée brownie. Lollipop cotton candy cake bear claw oat cake. Dragée candy canes dessert tart. Marzipan dragée gummies lollipop jujubes chocolate bar candy canes. Icing gingerbread chupa chups cotton candy cookie sweet icing bonbon gummies. Gummies lollipop brownie biscuit danish chocolate cake. Danish powder cookie macaroon chocolate donut tart. Carrot cake dragée croissant lemon drops liquorice lemon drops cookie lollipop toffee. Carrot cake carrot cake liquorice sugar plum topping bonbon pie muffin jujubes. Jelly pastry wafer tart caramels bear claw. Tiramisu tart pie cake danish lemon drops. Brownie cupcake dragée gummies.", Categoria = Categorias["Tortas de Frutas"], ImagemUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/rhubarbpie.jpg", EmEstoque = true, EhTortaDaSemana = false, ImagemThumbnailUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/rhubarbpiesmall.jpg", InformacoesAlergicas = "" },
                new Torta { Nome = "Torta de Morango", Preco = 15.95M, DescricaoCurta = "Nossa deliciosa torta de morango!", DescricaoDetalhada = "Icing carrot cake jelly-o cheesecake. Sweet roll marzipan marshmallow toffee brownie brownie candy tootsie roll. Chocolate cake gingerbread tootsie roll oat cake pie chocolate bar cookie dragée brownie. Lollipop cotton candy cake bear claw oat cake. Dragée candy canes dessert tart. Marzipan dragée gummies lollipop jujubes chocolate bar candy canes. Icing gingerbread chupa chups cotton candy cookie sweet icing bonbon gummies. Gummies lollipop brownie biscuit danish chocolate cake. Danish powder cookie macaroon chocolate donut tart. Carrot cake dragée croissant lemon drops liquorice lemon drops cookie lollipop toffee. Carrot cake carrot cake liquorice sugar plum topping bonbon pie muffin jujubes. Jelly pastry wafer tart caramels bear claw. Tiramisu tart pie cake danish lemon drops. Brownie cupcake dragée gummies.", Categoria = Categorias["Tortas de Frutas"], ImagemUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/strawberrypie.jpg", EmEstoque = true, EhTortaDaSemana = false, ImagemThumbnailUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/strawberrypiesmall.jpg", InformacoesAlergicas = "" },
                new Torta { Nome = "Torta de Morango com Queijo", Preco = 18.95M, DescricaoCurta = "Você vai adorar!", DescricaoDetalhada = "Icing carrot cake jelly-o cheesecake. Sweet roll marzipan marshmallow toffee brownie brownie candy tootsie roll. Chocolate cake gingerbread tootsie roll oat cake pie chocolate bar cookie dragée brownie. Lollipop cotton candy cake bear claw oat cake. Dragée candy canes dessert tart. Marzipan dragée gummies lollipop jujubes chocolate bar candy canes. Icing gingerbread chupa chups cotton candy cookie sweet icing bonbon gummies. Gummies lollipop brownie biscuit danish chocolate cake. Danish powder cookie macaroon chocolate donut tart. Carrot cake dragée croissant lemon drops liquorice lemon drops cookie lollipop toffee. Carrot cake carrot cake liquorice sugar plum topping bonbon pie muffin jujubes. Jelly pastry wafer tart caramels bear claw. Tiramisu tart pie cake danish lemon drops. Brownie cupcake dragée gummies.", Categoria = Categorias["Tortas de Queijo"], ImagemUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/strawberrycheesecake.jpg", EmEstoque = false, EhTortaDaSemana = false, ImagemThumbnailUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/strawberrycheesecakesmall.jpg", InformacoesAlergicas = "" }
            );
        }

        context.SaveChanges();
    }

    private static Dictionary<string, Categoria>? categorias;

    public static Dictionary<string, Categoria> Categorias
    {
        get
        {
            if (categorias == null)
            {
                var listaCategoria = new Categoria[]
                {
                    new Categoria { CategoriaNome = "Tortas de Frutas" },
                    new Categoria { CategoriaNome = "Tortas de Queijo" },
                    new Categoria { CategoriaNome = "Tortas Sazonais" }
                };

                categorias = new Dictionary<string, Categoria>();

                foreach (Categoria categoria in listaCategoria)
                {
                    categorias.Add(categoria.CategoriaNome, categoria);
                }
            }

            return categorias;
        }
    }
}

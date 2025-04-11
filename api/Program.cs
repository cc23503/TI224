using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args); // criação do builder
var app = builder.Build(); // 'app' nasce me função do builder que starta as principais ações de uma API


// API/ API RESTFULL
// métodos 'Map..' recebem dois argumentos: nome da rota e função ao ser executada com o acesso]
// sendo apenas um comando podemos fazer após a arrow function ('=>')
app.MapGet("/", () => "Hello World! Modo API ativo. 1"); // a partir desse momentos utilizamos está variavel para o mapeamento de rotas

app.MapGet("/getProduto", ([FromQuery] string dtInicial, [FromQuery] string dtFinal)=>{ // 'FromQuery' retira as informações diretamente da URL
    return dtInicial + " - " + dtFinal;
});

// nos exemplos a seguir
app.MapGet("/produtos/{codigo}", ([FromRoute] string codigo) =>
{
    var prod = RepositorioDeProduto.PegarPorCodigo(codigo);
    if (prod != null)
    return Results.Ok(prod);
    return Results.NotFound();
});

app.MapPost("/produto",(Produto prod) => 
{
    RepositorioDeProduto.Adicionar(prod);
});

// app.MapPut("/produto", (Produto prod) => {
//     var prodSalvo = RepositorioDeProduto.PegarPorCodigo(prod.Codigo);
//     prodSalvo.Nome = prod.Nome;
// });

app.Run(); // comando para rodar o projeto criado anteriormente

using AppMAUIGalery.Models;
using AppMAUIGalery.Views.Layouts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppMAUIGalery.Repositories;
internal class CategoryRepository
{
    public CategoryRepository() { }

    public List<Category> GetCategories() 
    {
        List<Category> categories = new List<Category>(); //lista da classe category
        categories.Add(new Category //adicionando uma category a lista 
        {
            Name = "Layout",
            Components = new List<Component> { //adicionando um item da classe component que também está na classe category
                new Component {
                    Titulo = "StackLayout",
                    Description = "Organização sequencial dos elementos",
                    Page = typeof(StackLayoutPage) //pega o tipo da página 
                },
                new Component {
                    Titulo = "Grid",
                    Description = "Organiza os elementos dentro de uma tabela",
                    Page = typeof(GridLayoutPage) //pega o tipo da página 
                }
            }
        });
        return categories; //retornando a lista da classe category
    }
}

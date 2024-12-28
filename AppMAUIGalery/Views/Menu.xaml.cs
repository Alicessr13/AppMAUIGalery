using AppMAUIGalery.Repositories;

namespace AppMAUIGalery.Views;

public partial class Menu : ContentPage
{
	public Menu()
	{
		InitializeComponent();
		var categories = new CategoryRepository().GetCategories();
		//instanciando a classe CategoryRepository onde tem as categorias com nome e dentro de cada categoria listas com componentes com titulo, descri��o e p�gina associada
		//e atribuindo as categorias a variavel categories

		foreach (var category in categories) //passando pela lista de categorias, criando uma label e passando no texto dela o nome da categoria
		{
            var lblCategory = new Label();
            lblCategory.Text = category.Name;

			MenuContainer.Children.Add(lblCategory); //adicionando a categoria que � uma label ao VerticalStackLayout (MenuContainer)

            foreach (var component in category.Components) //passando pelos componentes na lista de categorias e adicionando titulo e descri��o as labels
            {
				var lblComponentTitle = new Label();
				lblComponentTitle.Text = component.Titulo;

				var lblComponentDescription = new Label();
				lblComponentDescription.Text = component.Description;

				MenuContainer.Children.Add(lblComponentTitle); //adicionando titulo e descri��o que s�o labels ao VerticalStackLayout
				MenuContainer.Children.Add(lblComponentDescription);
			}
        }

    }


}
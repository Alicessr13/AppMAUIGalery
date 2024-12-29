using AppMAUIGalery.Repositories;
using System.Xml.Linq;

namespace AppMAUIGalery.Views;

public partial class Menu : ContentPage
{
	public Menu()
	{
		InitializeComponent();
		var categories = new CategoryRepository().GetCategories();
		//instanciando a classe CategoryRepository onde tem as categorias com nome e dentro de cada categoria listas com componentes com titulo, descrição e página associada
		//e atribuindo as categorias a variavel categories

		foreach (var category in categories) //passando pela lista de categorias, criando uma label e passando no texto dela o nome da categoria
		{
            var lblCategory = new Label();
            lblCategory.Text = category.Name;
			lblCategory.FontFamily = "OpenSansSemibold";


            MenuContainer.Children.Add(lblCategory); //adicionando a categoria que é uma label ao VerticalStackLayout (MenuContainer)

            foreach (var component in category.Components) //passando pelos componentes na lista de categorias e adicionando titulo e descrição as labels
            {
				//para fazer alguma coisa quando clicar no componente pelo c#
				var tap = new TapGestureRecognizer();//instanciando evento de clique na váriavel tap
				tap.CommandParameter = component.Page; //no CommandParameter pode ser colocado o que quiser, está sendo colocado a página que precisa ser aberta
                tap.Tapped += OnTapComponent; //associando o metodo ao evento

                var lblComponentTitle = new Label();
				lblComponentTitle.Text = component.Titulo;
				lblComponentTitle.FontFamily = "OpenSansSemibold";
				lblComponentTitle.Margin = new Thickness(20, 10, 0, 0);
				lblComponentTitle.GestureRecognizers.Add(tap); //adicionando o evento a label 

                var lblComponentDescription = new Label();
				lblComponentDescription.Text = component.Description;
				lblComponentDescription.Margin = new Thickness(20, 0, 0, 0);
                lblComponentDescription.GestureRecognizers.Add(tap);

                MenuContainer.Children.Add(lblComponentTitle); //adicionando titulo e descrição que são labels ao VerticalStackLayout
				MenuContainer.Children.Add(lblComponentDescription);
			}
        }

    }

    private void OnTapComponent(object sender, EventArgs e)
    {
		//sender = elemento que foi clicado
		var label = (Label)sender; //recebendo a label que foi clicada
		var tap = (TapGestureRecognizer)label.GestureRecognizers[0];//recebendo o gesto que foi adicionado
		//TapGestureRecognizer é uma coleção e o gesto adicionado está na posição zero 
		var page = (Type)tap.CommandParameter; //pegando o commandparameter que foi passado para o tap

		((FlyoutPage)App.Current.MainPage).Detail = new NavigationPage( (Page)Activator.CreateInstance(page)); //alterando a página e instanciando quando for clicado, também adiciona a página uma navigationpage
        ((FlyoutPage)App.Current.MainPage).IsPresented = false; //esconde o menu
    }

    private void OnTapInicio(object sender, EventArgs e)
    {
        ((FlyoutPage)App.Current.MainPage).Detail = new NavigationPage(new MainPage()); //alterando a página e instanciando quando for clicado, também adiciona a página uma navigationpage
        ((FlyoutPage)App.Current.MainPage).IsPresented = false; //esconde o menu
    }
}

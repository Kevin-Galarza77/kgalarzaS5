using System.Xml.Linq;
using kgalarzaS5.Models; 

namespace kgalarzaS5.Views;

public partial class vHome : ContentPage
{
    int personId = 0;
	public vHome()
	{
		InitializeComponent();
        loadPersons();
	}

    private async void Button_Clicked(object sender, EventArgs e)
    {
        string lastName = lastNameTxt.Text;
        string name = nameTxt.Text;

        string validate = ValidateForm(name, lastName);

        if (validate == "")
        {
            if (App.personRepository_.AddNewPerson(new Models.Person(name, lastName)))
            {
                await DisplayAlert("Exito", "Se inserto correctamente la persona", "OK");
                loadPersons();
                cancelBTN_Clicked(sender, e);
            }
            else
            {
                await DisplayAlert("Error", "Se produjo un error al ingresar la persona, intenta nuevamente", "OK");
            }
        }
        else
        {
            await DisplayAlert("Error", validate, "OK");
        }
    }

    private async void updateBTN_Clicked(object sender, EventArgs e)
    {
        string lastName = lastNameTxt.Text;
        string name = nameTxt.Text;

        string validate = ValidateForm(name, lastName);

        if (validate == "")
        {
            if (App.personRepository_.UpdatePerson(new Models.Person(personId, name, lastName)))
            {
                await DisplayAlert("Exito", "Se actualizo correctamente la persona", "OK");
                cancelBTN_Clicked(sender, e);
                loadPersons();
            }
            else
            {
                await DisplayAlert("Error", "Se produjo un error al actualizar la persona, intenta nuevamente", "OK");
            }
        }
        else
        {
            await DisplayAlert("Error", validate, "OK");
        }
    }

    private void loadPersons()
    {
        listPersonCV.ItemsSource = App.personRepository_.ListAllPersons();
    }

    private string ValidateForm(string name, string lastName)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            return "Por favor ingresa los nombres.";
        }

        if (!name.All(c => char.IsLetter(c) || char.IsWhiteSpace(c)))
        {
            return "Los nombres solo deben contener letras.";
        }

        if (string.IsNullOrWhiteSpace(lastName))
        {
            return "Por favor ingresa los apellidos.";
        }

        if (!lastName.All(c => char.IsLetter(c) || char.IsWhiteSpace(c)))
        {
            return "Los apellidos solo deben contener letras.";
        }

        return "";
    }

    private void OnUpdateClicked(object sender, EventArgs e)
    {
        if (sender is Button button && button.CommandParameter is Person person)
        {
            lastNameTxt.Text = person.personLastName;
            nameTxt.Text = person.personName;
            personId = person.personId;

            updateBTN.IsVisible = true;
            cancelBTN.IsVisible = true;
            newBTN.IsVisible = false;

        }
    }

    private async void OnDeleteClicked(object sender, EventArgs e)
    {
        if (sender is Button button && button.CommandParameter is Person person)
        {
            bool confirmed = await DisplayAlert("Eliminar", $"¿Estas seguro de eliminar a {person.personName}?", "Sí", "No");
            if (confirmed)
            {
                if (App.personRepository_.DeletePerson(person))
                {
                    await DisplayAlert("Exito", "Se elimino correctamente la persona", "OK");
                    cancelBTN_Clicked(sender, e);
                    loadPersons();
                }
                else
                {
                    await DisplayAlert("Error", "Se produjo un error al eliminar la persona, intenta nuevamente", "OK");
                }
            }
        }
    }

    private void cancelBTN_Clicked(object sender, EventArgs e)
    {
        personId = 0;
        lastNameTxt.Text = "";
        nameTxt.Text = "";

        updateBTN.IsVisible = false;
        cancelBTN.IsVisible = false;
        newBTN.IsVisible = true;


    }

}
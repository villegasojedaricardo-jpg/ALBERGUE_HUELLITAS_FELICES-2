using System.Drawing;
using System.Windows.Forms;

namespace ALBERGUE_HUELLITAS_FELICES;

internal static class SelectorFecha
{
    public static DateTimePicker Crear()
    {
        var selector = new DateTimePicker();
        Configurar(selector);
        return selector;
    }

    public static Label CrearEtiqueta(string texto, Point ubicacion)
    {
        return new Label
        {
            AutoSize = true,
            Location = ubicacion,
            Text = texto
        };
    }

    public static void Configurar(DateTimePicker selector)
    {
        selector.Format = DateTimePickerFormat.Custom;
        selector.CustomFormat = "dd/MM/yyyy";
        selector.ShowCheckBox = true;
        selector.Checked = false;
    }

    public static void Vaciar(DateTimePicker selector)
    {
        selector.Checked = false;
        selector.Value = DateTime.Today;
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CalculoIndiceIntec
{
    public partial class MainPage : ContentPage
    {
     
        public MainPage()
        {
            InitializeComponent();
        }   
        int n;
        float[] creditosIngresado;
        float[] creditoynota;
        float[] notaIngresada;
        int aux;
        private void EntradaMaterias_Clicked(object sender, EventArgs e)
        {
            limpiarTodo();
            n = int.Parse(NroMaterias.Text);
            aux = n;
            creditosIngresado = new float[n];
            notaIngresada = new float[n];
            ContadorMateriasjeje();

        }
        void ContadorMateriasjeje ()
        {
            ContadorMaterias.Text = "Materias Numero: " + aux;
        }

        private void CalculoParaIndice_Clicked(object sender, EventArgs e)
        {
            if (creditos.Text != null && nota.Text != null)
            {
                creditosIngresado[aux-1] = float.Parse(creditos.Text);
                notaIngresada[aux-1] = float.Parse(nota.Text);
                aux = aux-1;
                creditos.Text = null;
                nota.Text = null;
                ContadorMateriasjeje();
                if (aux == 0)
                {
                    ResultadoIndice.Text = Indice().ToString();
                }
            } 

        }
        float suma(float[]x)
        {
            float t = 0;
            for( int i = 0; i < x.Length;i++)
            {
                t = t + x[i];
            }
            return t;
        }
        float Indice()
        {

            creditoynota = new float[n];
            float indiceTotal = 0;
            for ( int i = 0; i < n; i++)
            {
                creditoynota[i] = creditosIngresado[i] * notaIngresada[i];
                float SumaCreditos = suma(creditosIngresado);
                float sumaNotas = suma(creditoynota);
                indiceTotal = sumaNotas / SumaCreditos;
            }
            return indiceTotal;
        }

        void limpiarTodo()
        {
            n = 0;
            creditosIngresado = null;
            creditoynota = null;
            notaIngresada = null;
            aux= 0;
            ResultadoIndice.Text = null;
            
        }
        private void Limpiar_Clicked(object sender, EventArgs e)
        {
            
            limpiarTodo();
            NroMaterias.Text = null;
            ContadorMaterias.Text = null;
        }
    }
}

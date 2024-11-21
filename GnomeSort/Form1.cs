using System.Windows.Forms;

namespace GnomeSort
{
    public partial class Form1 : Form
    {
        private int[] numbers = { 34, 2, 23, 67, 4, 90, 3 };

        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            DisplayNumbers(numbers);
        }
        private async void btnSort_Click(object sender, EventArgs e)
        {
            await GnomeSort(numbers);
        }

        private void DisplayNumbers(int[] array, int highlightIndex1 = -1, int highlightIndex2 = -1)
        {
            listBox1.Items.Clear();

            string displayText = "";

            for (int i = 0; i < array.Length; i++)
            {
                // Resaltar los elementos en comparación o intercambio
                if (i == highlightIndex1 || i == highlightIndex2)
                {
                    displayText += $"[{array[i]}] ";  // Números comparados o intercambiados
                }
                else
                {
                    displayText += $"{array[i]} ";  // Números normales
                }
            }

            // Mostrar todos los números en una fila
            listBox1.Items.Add(displayText.Trim());
        }

        private async Task GnomeSort(int[] array)
        {
            int index = 0;

            while (index < array.Length)
            {
                // Si estamos en el primer índice o el número actual es mayor o igual que el anterior
                if (index == 0 || array[index] >= array[index - 1])
                {
                    // Mostrar los números actuales y avanzar al siguiente índice
                    DisplayNumbers(array, index, index - 1); // Resaltamos los números que estamos comparando
                    await Task.Delay(1000); // Pausa para visualizar la comparación sin intercambio
                    index++;
                }
                else
                {
                    // Si el número actual es menor que el anterior, intercambiamos
                    DisplayNumbers(array, index, index - 1); // Resaltamos los números que estamos intercambiando
                    await Task.Delay(1000); // Pausa para visualizar el intercambio

                    // Realizamos el intercambio
                    int temp = array[index];
                    array[index] = array[index - 1];
                    array[index - 1] = temp;

                    // Retrocedemos al índice anterior para seguir comparando
                    index--;

                    // Asegurarse de no retroceder más allá del principio
                    if (index < 0)
                    {
                        index = 0;
                    }

                    // Actualizar la visualización del arreglo con el intercambio
                    DisplayNumbers(array);
                    await Task.Delay(1000); // Pausa para visualizar el estado después del intercambio
                }
            }

            // Mostrar el resultado final
            DisplayNumbers(array);
            MessageBox.Show("¡Complete ordering!", "Gnome Sort", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnShuffle_Click(object sender, EventArgs e)
        {
            ShuffleArray(numbers);
            // Muestra los números mezclados
            DisplayNumbers(numbers);
        }

        private void ShuffleArray(int[] array)
        {
            Random rng = new Random();
            int n = array.Length;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                int value = array[k];
                array[k] = array[n];
                array[n] = value;
            }
        }
    }
}

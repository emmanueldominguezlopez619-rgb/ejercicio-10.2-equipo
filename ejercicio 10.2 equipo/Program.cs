using System;

namespace P2_PA_IM_26B
{
    // Clase que gestiona el diagnóstico de un motor
    public class MotorDiagnostico
    {
        // Propiedades (usamos string? para evitar advertencias de nulos)
        public string? Identificador { get; set; }
        public double PromedioCorriente { get; private set; }

        // Método para calcular el promedio a partir de un arreglo de 4 mediciones
        public double CalcularPromedio(double[] mediciones)
        {
            double suma = 0;
            foreach (double med in mediciones)
            {
                suma += med;
            }
            PromedioCorriente = suma / mediciones.Length;
            return PromedioCorriente;
        }

        // Método para determinar el estado del motor según el promedio de corriente
        public string ObtenerEstado()
        {
            if (PromedioCorriente <= 5.0)
            {
                return "NORMAL";
            }
            else
            {
                return "REQUIERE MANTENIMIENTO";
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string? respuesta = "s";

            // Ciclo while para evaluar una cantidad desconocida de motores según el usuario
            while (respuesta != null && respuesta.ToLower() == "s")
            {
                Console.Clear();
                Console.WriteLine("--- DIAGNÓSTICO DE MOTORES ELÉCTRICOS ---");

                MotorDiagnostico motor = new MotorDiagnostico();

                Console.Write("Ingrese el identificador del motor: ");
                motor.Identificador = Console.ReadLine();

                double[] mediciones = new double[4];

                // Ciclo for para capturar las 4 mediciones de corriente
                for (int i = 0; i < 4; i++)
                {
                    Console.Write($"Ingrese la medición de corriente #{i + 1} (A): ");
                    mediciones[i] = Convert.ToDouble(Console.ReadLine());
                }

                // Procesamiento de datos con los métodos de la clase
                motor.CalcularPromedio(mediciones);
                string estadoMotor = motor.ObtenerEstado();

                // Mostrar resultados con unidades correspondientes
                Console.WriteLine("\n--- REPORTE DE DIAGNÓSTICO ---");
                Console.WriteLine($"Motor ID: {motor.Identificador}");
                Console.WriteLine($"Promedio de Corriente: {motor.PromedioCorriente:F2} A");
                Console.WriteLine($"Estado del Motor: {estadoMotor}");

                // Preguntar si se desea registrar otro motor
                Console.Write("\n¿Desea registrar otro motor? (s/n): ");
                respuesta = Console.ReadLine();
            }

            Console.WriteLine("\nFin del programa de diagnóstico. Presione una tecla para salir...");
            Console.ReadKey();
        }
    }
}

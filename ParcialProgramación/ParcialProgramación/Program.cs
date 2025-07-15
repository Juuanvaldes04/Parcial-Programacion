using System;

namespace ControlCombustibleSemanal
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int dia, cargaDia, litros, totalSuper = 0, totalPremium = 0, totalLitros = 0, cargaNum;
            int bajas, medias, altas;
            string tipo, respuesta, nombreDia, clasificacion;
            double galonesUSA, galonesUK, promedioDiario, promedioSemanal;

            for (dia = 1; dia <= 7; dia++)
            {
                
                switch (dia)
                {
                    case 1: nombreDia = "Lunes"; break;
                    case 2: nombreDia = "Martes"; break;
                    case 3: nombreDia = "Miércoles"; break;
                    case 4: nombreDia = "Jueves"; break;
                    case 5: nombreDia = "Viernes"; break;
                    case 6: nombreDia = "Sábado"; break;
                    case 7: nombreDia = "Domingo"; break;
                    default: nombreDia = "Día desconocido"; break;
                }

                Console.WriteLine();
                Console.WriteLine($"DÍA {dia} - {nombreDia}");

                cargaDia = 0;
                cargaNum = 1;
                promedioDiario = 0;
                bajas = 0;
                medias = 0;
                altas = 0;

                do
                {
                    
                    do
                    {
                        Console.Write("Ingrese tipo de combustible (super o premium): ");
                        tipo = Console.ReadLine().ToLower();
                    } while (tipo != "super" && tipo != "premium");

                    
                    do
                    {
                        Console.Write("Ingrese cantidad de litros (entre 5 y 50): ");
                        litros = int.Parse(Console.ReadLine() ?? "0");
                    } while (litros < 5 || litros > 50);

                    
                    galonesUSA = litros * 0.26417;
                    galonesUK = litros * 0.21997;

                    
                    if (tipo == "super")
                        totalSuper += litros;
                    else
                        totalPremium += litros;

                    totalLitros += litros;
                    promedioDiario += litros;
                    cargaDia++;

                    
                    if (litros <= 10)
                    {
                        clasificacion = "Baja";
                        bajas++;
                    }
                    else if (litros <= 30)
                    {
                        clasificacion = "Media";
                        medias++;
                    }
                    else
                    {
                        clasificacion = "Alta";
                        altas++;
                    }

                    
                    Console.WriteLine();
                    Console.WriteLine($"Carga {cargaNum}:");
                    Console.WriteLine($"Litros: {litros}");
                    Console.WriteLine($"Galones USA: {galonesUSA:F2}");
                    Console.WriteLine($"Galones UK: {galonesUK:F2}");
                    Console.WriteLine($"Tipo: {tipo}");
                    Console.WriteLine($"Clasificación: {clasificacion}");
                    cargaNum++;

                    
                    do
                    {
                        Console.Write("¿Desea ingresar otra carga para este día? (S/N): ");
                        respuesta = Console.ReadLine().ToUpper();
                    } while (respuesta != "S" && respuesta != "N");

                } while (respuesta == "S");

                promedioDiario /= cargaDia;

                
                
                Console.WriteLine($"Resumen del Día {dia} ({nombreDia}):");
                Console.WriteLine($"Total de cargas: {cargaDia}");
                Console.WriteLine($"Promedio por carga: {promedioDiario:F2}");
                Console.WriteLine($"Cargas bajas: {bajas}");
                Console.WriteLine($"Cargas medias: {medias}");
                Console.WriteLine($"Cargas altas: {altas}");
               
            }

            promedioSemanal = totalLitros / 7.0;

            
            
            Console.WriteLine("RESUMEN SEMANAL");
            Console.WriteLine("Total litros SUPER: " + totalSuper);
            Console.WriteLine("Total litros PREMIUM: " + totalPremium);
            Console.WriteLine("Consumo promedio semanal: " + promedioSemanal.ToString("F2"));
            
        }
    }
}

using System.Runtime.ConstrainedExecution;
using System;

namespace _08Arrays
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Arrays();
            Aufgabe();
            Lottozahlen();
            static void Arrays()
            {
                // Arrays speichern mehrere Werte in einer einzelnen Variable.
                // Wir können einen einzigen Bezeichner nutzen um auf mehrere Werte zugreifen zu können.
                // Die einzelnen Einträge nennt man auch Felder bzw. Wertefelden.

                // Die Syntax eines Arrays sieht folgendermaßen aus:
                //<datentyp[]> <bezeichner> = {<"wert1"> , <"wert2"> , <"wert3"> usw... }

                // Deklaration eines String-Arrays:
                string[] autos = { "BMW", "Audi", "Opel", "Skoda" };

                // Deklaration eine Int-Arrays:
                int[] zahlen = { 1, 4, 7, -5, 22, 17 };

                // Wie schon bei einem String, können wir über den Index Operator geziehlt bestimmte Felder ansprechen.
                Console.WriteLine($"erstes Feld: {autos[0]}");
                Console.WriteLine($"zweites Feld: {autos[1]}");

                // Länge eines Arrays kann man mit Length ausgeben lassen
                Console.WriteLine($"In unserer Liste haben wir {autos.Length} Autos.");

                // Bestimmung des letzten Elements
                Console.WriteLine($"Das letzte Auto in der Liste ist der {autos[autos.Length - 1]}");

                // Ausgabe aller Elemente des Arrays
                for (int i = 0; i < autos.Length; i++)
                {
                    Console.WriteLine(autos[i]);
                }

                // Ausgabe aller Elemente mit der foreach-Schleife
                foreach (string auto in autos)
                {
                    Console.WriteLine(auto);
                }

                Console.Clear();

                Console.WriteLine($"Alter Wert des ersten Feldes {autos[0]}");
                // Wertzuweisung
                autos[0] = "Mercedes";
                Console.WriteLine($"Neuer Wert des ersen Feldes {autos[0]}");

                // Suchen nach einem bestimmten Wert, der dann ersetzt werden soll.
                // Wir suchen nach dem Opel und dann ersetzten wir ihn durch den Toyoty.

                for (int i = 0; i < autos.Length; i++)
                {
                    Console.WriteLine($"Ich habe den {autos[i]} gefunden.");
                    autos[i] = "Toyota";
                    Console.WriteLine($"Ich habe an Index {i}, also dem {i + 1}ten Feld, den Opel mit einem {autos[i]} ersetzt!");
                }

                // Erstellen eines Arrays ohne direkte Wertzuweisung
                int[] zahlen2 = new int[5]; // int-Array der Länge 5 ohne Werte#
                                            // Initialisierung des ersten Felds
                zahlen2[0] = 1;
            }   // Was ist ein Array + Beispiele
            static void Aufgabe()
            {
                //Aufgabe:
                //Erstellen Sie ein int[]-Array der Größe 7 und initialisieren Sie die Felder mit beliebigen von Ihnen ausgesuchten Werten.
                //Die Werte müssen nicht zufällig bestimmt werden.  
                //Lassen Sie dann zählen wie oft die Zahl 1 vorkommt. Geben Sie die Anzahl in der Konsole aus.

                Console.Clear();

                int[] intArray = new int[7];
                intArray[0] = 1;
                intArray[1] = 2;
                intArray[2] = 3;
                intArray[3] = 4;
                intArray[4] = 5;
                intArray[5] = 6;
                intArray[6] = 7;

                int zaehler = 0;

                for (int i = 0; i < intArray.Length; i++)
                {
                    if (intArray[i] == 1) zaehler++;
                }
                Console.WriteLine($"Die Zahl 1 kommt {zaehler} mal vor.");
            }   // Korrektur der Aufgabe
            static void Lottozahlen()
            {
                //Teil1

                //Lottozahlen
                //Erstellen Sie ein int[] lottozahlen mit der Länge 49.
                //Schreiben Sie dann einen Code der dieses Array automatisch mit den Zahlen 1 - 49 befüllt.

                //Teil2

                //Ziehung der Lottozahlen
                //Aus dem Array unserer Lottozahlen sollen nun sechs Zahlen zufällig gezogen werden.
                //Diese sechs Zahlen müssen in einem neuen Array abgelegt werden. 
                //Verwenden Sie auch wieder Random für die Zufällige Ziehung.
                //Bei den gezogenen Zahlen darf es zu keiner Dopplung kommen.

                //Teil3

                //User-Eingabe und Gewinnausgabe
                //Der User soll in der Lage sein, sechs Zahlen einzugeben.
                //Diese werden in einem Array abgelegt.
                //Danach soll überprüft werden, wieviele Zahlen der User im Vergleich zu den gezogenen Lottozahlen richtig getippt hat.
                //Geben Sie in der Konsole aus, wieviele Richtige getippt wurden.

                //Sollten Sie in der vorherigen Aufgabe zu keiner Lösung gekommen sein, schreiben Sie von Hand ein Array mit gezogenen Zahlen.

                Console.Clear();

                int[] lottozahlen = new int[49];

                for (int i = 0;i < 49; i++)
                {
                    lottozahlen[i] = i + 1;
                }

                Random zufall = new Random();
                int[] gezogeneZahlen = new int[6];

                for (int i = 0; i < 6; i++)
                {
                    int zufallsIndex;
                    int gezogeneZahl;
                    int bereitsGezogen = -1;

                    do
                    {
                        zufallsIndex = zufall.Next(0, 49);
                        gezogeneZahl = lottozahlen[zufallsIndex];
                    }
                    while (gezogeneZahl == bereitsGezogen);
                    
                        lottozahlen[zufallsIndex] = bereitsGezogen;
                        gezogeneZahlen[i] = gezogeneZahl;
                    
                }

                int[] tippZahlen = new int[6];

                Console.WriteLine("Hallo User! Bitte gib nacheinander sechs Zahlen zwischen 1 und 49 ein.\nBitte bestätige jede Eingabe mit Enter.");

                for (int i = 0; i < 6; i++)
                {
                    bool doppelt;
                    do
                    {
                        doppelt = false;
                        tippZahlen[i] = Convert.ToInt32(Console.ReadLine());

                        for (int j = 0; j < i; j++)
                        {
                            if (tippZahlen[i] == tippZahlen[j])
                            {
                                doppelt = true;
                                Console.WriteLine("Du hast diese Zahl bereits eingegeben!");
                            }
                        }
                    }
                    while (tippZahlen[i] <= 0 || tippZahlen[i] > 49 || doppelt);
                }

                int anzahlRichtig = 0;

                for (int i = 0; i < 6; i++)
                {
                    for (int j = 0; j < i; j++)
                    {
                        if (gezogeneZahlen[i] == tippZahlen[j])
                        {
                            anzahlRichtig++;
                        }
                    }
                }
                Console.Clear();
                Console.WriteLine($"Du hast {anzahlRichtig} Richtige.\nDeine angegebenen Zahlen sind: {string.Join(" - ", tippZahlen)}\nDie Lottozahlen von heute sind {string.Join(" - ", gezogeneZahlen)}");









            }

        }
    }    
}       
        












    


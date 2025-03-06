using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using static System.Net.Mime.MediaTypeNames;

namespace ConsoleApp1
{
    internal class Program
    {

        static void Main(string[] args)
        {
            int strandnumber;
            char[] Dnastrand1 = new char[400];
            char[] Dnastrand2 = new char[400];
            char[] Dnastrand3 = new char[400];
            bool exit = false;
            while (exit == false)
            {//Writes 3 DNA sequences to the screen as DNA strand 1,2,3.
                Console.Write($"DNA strand 1 : ");
                for (int h = 0; h < Dnastrand1.Length; h++)
                {
                    if (h % 3 == 0 && h != 0)
                    {
                        Console.Write(" ");
                    }
                    Console.Write(Dnastrand1[h]);
                }
                Console.WriteLine();
                Console.Write($"DNA strand 2 : ");
                for (int h = 0; h < Dnastrand2.Length; h++)
                {
                    if (h % 3 == 0 && h != 0)
                    {
                        Console.Write(" ");
                    }
                    Console.Write(Dnastrand2[h]);
                }
                Console.WriteLine();
                Console.Write($"DNA strand 3 : ");
                for (int h = 0; h < Dnastrand3.Length; h++)
                {
                    if (h % 3 == 0 && h != 0)
                    {
                        Console.Write(" ");
                    }
                    Console.Write(Dnastrand3[h]);
                }
                Console.WriteLine();

                Console.WriteLine("*------------------------------------------------------------------------------------------------------------------*");
                Console.WriteLine("|                                                                                                                  |");
                Console.WriteLine("| 1. Load a DNA sequence from a file              10. Find codons                                                  |");
                Console.WriteLine("|                                                                                                                  |");
                Console.WriteLine("| 2. Load a DNA sequence from a string            11. Reverse codons                                               |");
                Console.WriteLine("|                                                                                                                  |");
                Console.WriteLine("| 3. Generate random DNA sequence of a BLOB       12. Find number of genes in a DNA strand                         |");
                Console.WriteLine("|                                                                                                                  |");
                Console.WriteLine("| 4. Check DNA gene structure                     13. Find the shortest gene in a DNA strand                       |");
                Console.WriteLine("|                                                                                                                  |");
                Console.WriteLine("| 5. Check DNA of a BLOB organism                 14. Find the longest gene in a DNA strand                        |");
                Console.WriteLine("|                                                                                                                  |");
                Console.WriteLine("| 6. Produce complement of a DNA sequence         15. Find the most repeated n-nucleotide sequence in a Dna strand |");
                Console.WriteLine("|                                                                                                                  |");
                Console.WriteLine("| 7. Determine amino acids                        16. Hydrogen bond statistics for a DNA strand                    |");
                Console.WriteLine("|                                                                                                                  |");
                Console.WriteLine("| 8. Delete codons                                17. Simulate BLOB generations using DNA strand 1 and 2           |");
                Console.WriteLine("|                                                                                                                  |");
                Console.WriteLine("| 9. Insert codons                                18. Exit                                                         |");
                Console.WriteLine("|                                                                                                                  |");
                Console.WriteLine("*------------------------------------------------------------------------------------------------------------------*");
                Console.Write("Choose operation number: ");

                int input = 0;
                // for wrong input
                try
                {
                    input = Convert.ToInt16(Console.ReadLine());


                }
                catch
                {
                    Console.WriteLine("Please input chosen operation number");
                    Console.ReadLine();
                    Console.Clear();
                }

                //It properly writes the DNA to the screen by reading it from the file as a string.
                if (input == 1)
                {
                    string text = "";
                    Console.Write("Strand Number: ");
                    strandnumber = Convert.ToInt16(Console.ReadLine());
                    Console.Write("Enter document name: ");
                    string textname = Console.ReadLine();
                    if (File.Exists(textname))
                    {
                        Console.WriteLine("Load");
                        StreamReader file1 = new StreamReader(textname);
                        text = file1.ReadLine();
                        //(for testing)  Console.WriteLine(text);
                        file1.Close();
                        Console.WriteLine(text);

                    }
                    else
                    {
                        Console.WriteLine($"I can't find {textname} file");
                        Console.ReadLine();
                    }



                    char[] OP1DNA = new char[400];
                    for (int i = 0; i < text.Length; i++)
                    {
                        OP1DNA[i] = text[i];

                    }
                    if (strandnumber == 1)
                    {
                        Dnastrand1 = OP1DNA;
                    }
                    else if (strandnumber == 2)
                    {
                        Dnastrand2 = OP1DNA;
                    }
                    else if (strandnumber == 3)
                    {
                        Dnastrand3 = OP1DNA;
                    }
                    Console.Clear();

                }//it takes a dna from user
                else if (input == 2)
                {
                    Console.Write("Strand to Load: ");
                    strandnumber = Convert.ToInt16(Console.ReadLine());
                    string text = Console.ReadLine();

                    int space = 0;
                    char[] OP2DNA = new char[400];
                    for (int i = 0; i < text.Length; i++)
                    {
                        if (text[i] == 'A' || text[i] == 'a')
                            OP2DNA[i - space] = 'A';
                        else if (text[i] == 'T' || text[i] == 't')
                            OP2DNA[i - space] = 'T';
                        else if (text[i] == 'G' || text[i] == 'g')
                            OP2DNA[i - space] = 'G';
                        else if (text[i] == 'C' || text[i] == 'c')
                            OP2DNA[i - space] = 'C';
                        else
                        {
                            space++;
                        }


                    }
                    if (strandnumber == 1)
                    {
                        Dnastrand1 = OP2DNA;
                    }
                    else if (strandnumber == 2)
                    {
                        Dnastrand2 = OP2DNA;
                    }
                    else if (strandnumber == 3)
                    {
                        Dnastrand3 = OP2DNA;
                    }
                    Console.Clear();

                }// Generates DNA randomly
                else if (input == 3)
                {
                    Random random = new Random();

                    int gene_number = random.Next(1, 7);
                    int randnumber = random.Next(1, 5);

                    char firstN = 'N';
                    char secondN = 'N';
                    int lastpoint = 12;

                    char[] Strand = new char[400];
                    Strand[0] = 'A'; Strand[1] = 'T'; Strand[2] = 'G';

                    Console.Write("Input gender: ");
                    string Gender = Console.ReadLine();

                    Console.Write("To which string: ");
                    strandnumber = Convert.ToInt32(Console.ReadLine());

                    // All possibilities for gender
                    if (Gender == "f" || Gender == "F")
                    {
                        if (randnumber == 1)
                        {
                            Strand[3] = 'A'; Strand[4] = 'A'; Strand[5] = 'A';
                            Strand[6] = 'A'; Strand[7] = 'A'; Strand[8] = 'A';
                        }
                        else if (randnumber == 2)
                        {
                            Strand[3] = 'A'; Strand[4] = 'A'; Strand[5] = 'A';
                            Strand[6] = 'T'; Strand[7] = 'T'; Strand[8] = 'T';
                        }
                        else if (randnumber == 3)
                        {
                            Strand[3] = 'T'; Strand[4] = 'T'; Strand[5] = 'T';
                            Strand[6] = 'T'; Strand[7] = 'T'; Strand[8] = 'T';
                        }
                        else if (randnumber == 4)
                        {
                            Strand[3] = 'T'; Strand[4] = 'T'; Strand[5] = 'T';
                            Strand[6] = 'A'; Strand[7] = 'A'; Strand[8] = 'A';
                        }
                    }
                    else if (Gender == "m" || Gender == "M")
                    {
                        randnumber = random.Next(1, 9);

                        if (randnumber == 1)
                        {
                            Strand[3] = 'A'; Strand[4] = 'A'; Strand[5] = 'A';
                            Strand[6] = 'G'; Strand[7] = 'G'; Strand[8] = 'G';
                        }
                        else if (randnumber == 2)
                        {
                            Strand[3] = 'A'; Strand[4] = 'A'; Strand[5] = 'A';
                            Strand[6] = 'C'; Strand[7] = 'C'; Strand[8] = 'C';
                        }
                        else if (randnumber == 3)
                        {
                            Strand[3] = 'T'; Strand[4] = 'T'; Strand[5] = 'T';
                            Strand[6] = 'G'; Strand[7] = 'G'; Strand[8] = 'G';
                        }
                        else if (randnumber == 4)
                        {
                            Strand[3] = 'T'; Strand[4] = 'T'; Strand[5] = 'T';
                            Strand[6] = 'C'; Strand[7] = 'C'; Strand[8] = 'C';
                        }
                        else if (randnumber == 5)
                        {
                            Strand[3] = 'G'; Strand[4] = 'G'; Strand[5] = 'G';
                            Strand[6] = 'T'; Strand[7] = 'T'; Strand[8] = 'T';
                        }
                        else if (randnumber == 6)
                        {
                            Strand[3] = 'G'; Strand[4] = 'G'; Strand[5] = 'G';
                            Strand[6] = 'A'; Strand[7] = 'A'; Strand[8] = 'A';
                        }
                        else if (randnumber == 7)
                        {
                            Strand[3] = 'C'; Strand[4] = 'C'; Strand[5] = 'C';
                            Strand[6] = 'T'; Strand[7] = 'T'; Strand[8] = 'T';
                        }
                        else if (randnumber == 8)
                        {
                            Strand[3] = 'C'; Strand[4] = 'C'; Strand[5] = 'C';
                            Strand[6] = 'A'; Strand[7] = 'A'; Strand[8] = 'A';
                        }
                    }

                    Strand[9] = 'T'; Strand[10] = 'A'; Strand[11] = 'G';

                    int codon_number;

                    // from start starting codon added top of the strand
                    // after that gene filled with random codons
                    // finally one of the ending codon is added as last codon

                    for (int i = 1; i <= gene_number; i++)
                    {
                        codon_number = random.Next(3, 9);

                        Strand[lastpoint] = 'A'; Strand[lastpoint + 1] = 'T'; Strand[lastpoint + 2] = 'G';
                        lastpoint += 3;


                        for (int j = 0; j < (codon_number - 2); j++)
                        {


                            randnumber = random.Next(1, 5);
                            if (randnumber == 1)
                            {
                                Strand[lastpoint] = 'A';
                                firstN = 'A';
                            }
                            else if (randnumber == 2)
                            {
                                Strand[lastpoint] = 'T';
                                firstN = 'T';


                            }
                            else if (randnumber == 3)
                            {
                                Strand[lastpoint] = 'G';
                                firstN = 'G';

                            }
                            else if (randnumber == 4)
                            {
                                Strand[lastpoint] = 'C';
                                firstN = 'C';

                            }
                            lastpoint += 1;
                            randnumber = random.Next(1, 5);
                            if (randnumber == 1)
                            {
                                Strand[lastpoint] = 'A';
                                secondN = 'A';
                            }
                            else if (randnumber == 2)
                            {
                                Strand[lastpoint] = 'T';
                                secondN = 'T';


                            }
                            else if (randnumber == 3)
                            {
                                Strand[lastpoint] = 'G';
                                secondN = 'G';

                            }
                            else if (randnumber == 4)
                            {
                                Strand[lastpoint] = 'C';
                                secondN = 'C';
                            }
                            lastpoint += 1;

                            if (firstN == 'A' && secondN == 'T')
                            {
                                randnumber = random.Next(1, 4);
                                if (randnumber == 1)
                                {
                                    Strand[lastpoint] = 'A';
                                }
                                else if (randnumber == 2)
                                {
                                    Strand[lastpoint] = 'T';
                                }
                                else if (randnumber == 3)
                                {
                                    Strand[lastpoint] = 'C';
                                }
                                lastpoint += 1;

                            }
                            else if (firstN == 'T' && secondN == 'A')
                            {
                                randnumber = random.Next(1, 3);
                                if (randnumber == 1)
                                {
                                    Strand[lastpoint] = 'T';
                                }
                                else if (randnumber == 2)
                                {
                                    Strand[lastpoint] = 'C';
                                }
                                lastpoint += 1;
                            }
                            else if (firstN == 'T' && secondN == 'G')
                            {
                                randnumber = random.Next(1, 4);
                                if (randnumber == 1)
                                {
                                    Strand[lastpoint] = 'G';
                                }
                                else if (randnumber == 2)
                                {
                                    Strand[lastpoint] = 'T';
                                }
                                else if (randnumber == 3)
                                {
                                    Strand[lastpoint] = 'C';
                                }
                                lastpoint += 1;
                            }
                            else
                            {
                                randnumber = random.Next(1, 5);
                                if (randnumber == 1)
                                {
                                    Strand[lastpoint] = 'A';
                                }
                                else if (randnumber == 2)
                                {
                                    Strand[lastpoint] = 'T';
                                }
                                else if (randnumber == 3)
                                {
                                    Strand[lastpoint] = 'G';
                                }
                                else if (randnumber == 4)
                                {
                                    Strand[lastpoint] = 'C';

                                }
                                lastpoint += 1;
                            }
                        }

                        randnumber = random.Next(1, 4);
                        if (randnumber == 1)
                        {
                            Strand[lastpoint] = 'T'; Strand[lastpoint + 1] = 'A'; Strand[lastpoint + 2] = 'A';
                        }
                        else if (randnumber == 2)
                        {
                            Strand[lastpoint] = 'T'; Strand[lastpoint + 1] = 'A'; Strand[lastpoint + 2] = 'G';
                        }
                        else if (randnumber == 3)
                        {
                            Strand[lastpoint] = 'T'; Strand[lastpoint + 1] = 'G'; Strand[lastpoint + 2] = 'A';
                        }

                        lastpoint += 3;

                    }

                    if (strandnumber == 1)
                    {
                        for (int i = 0; i < 400; i++)
                        {
                            Dnastrand1[i] = Strand[i];

                        }
                    }
                    else if (strandnumber == 2)
                    {
                        for (int i = 0; i < 400; i++)
                        {
                            Dnastrand2[i] = Strand[i];

                        }
                    }
                    else if (strandnumber == 3)
                    {
                        for (int i = 0; i < 400; i++)
                        {
                            Dnastrand3[i] = Strand[i];
                        }

                    }
                    Console.Clear();
                }
                else if (input == 4)
                {
                    char[] OP4DNA = new char[400];
                    Console.Write("Strand Number:");
                    strandnumber = Convert.ToInt32(Console.ReadLine());
                    if (strandnumber == 1)
                    {
                        OP4DNA = Dnastrand1;
                    }

                    else if (strandnumber == 2)
                    {
                        OP4DNA = Dnastrand2;
                    }

                    else if (strandnumber == 3)
                    {
                        OP4DNA = Dnastrand2;
                    }

                    bool gene = true;
                    bool error = false;

                    int counter = 0;

                    // to Determine how many nucleotide strand have
                    for (int i = 0; i < OP4DNA.Length; i++)
                    {
                        if (OP4DNA[i] == 'A' || OP4DNA[i] == 'T' || OP4DNA[i] == 'G' || OP4DNA[i] == 'C')
                            counter++;

                    }

                    // if its not divided by three it cause error
                    if (counter % 3 != 0)
                    {
                        Console.WriteLine("Codon structure error");
                        error = true;
                    }


                    // if starting is not starting codon 
                    if (OP4DNA[0] != 'A' || OP4DNA[1] != 'T' || OP4DNA[2] != 'G')
                    {
                        Console.WriteLine("Gene structure error.");
                        error = true;
                        gene = false;
                    }

                    // when starting codon read gene became true and when one of the ending codons came gene became false
                    // if gene is true and current codon is starting codon or
                    // if gene is true but  for loop ended so there is no ending codon
                    // it cause an error message came up

                    if (gene)
                    {
                        for (int i = 3; i < counter; i += 3)
                        {
                            if (gene == true && OP4DNA[i] == 'A' && OP4DNA[i + 1] == 'T' && OP4DNA[i + 2] == 'G')
                            {
                                Console.WriteLine("Gene structure error.");
                                error = true;
                                break;
                            }

                            else if (gene == false && OP4DNA[i] == 'A' && OP4DNA[i + 1] == 'T' && OP4DNA[i + 2] == 'G')
                                gene = true;

                            if (gene == true && OP4DNA[i] == 'T' && OP4DNA[i + 1] == 'A' && OP4DNA[i + 2] == 'G' || OP4DNA[i] == 'T' && OP4DNA[i + 1] == 'A' && OP4DNA[i + 2] == 'A' || OP4DNA[i] == 'T' && OP4DNA[i + 1] == 'G' && OP4DNA[i + 2] == 'A')
                                gene = false;

                        }
                        if (gene == true && error == false)
                        {
                            Console.WriteLine("Gene structure error.");
                            error = true;
                        }
                    }
                    if (error == false)
                        Console.WriteLine("Gene structure is OK");

                    Console.ReadLine();

                }
                else if (input == 5)
                {
                    char[] OP5DNA = new char[400];
                    Console.Write("Strand Number:");
                    strandnumber = Convert.ToInt32(Console.ReadLine());
                    if (strandnumber == 1)
                    {
                        OP5DNA = Dnastrand1;
                    }

                    else if (strandnumber == 2)
                    {
                        OP5DNA = Dnastrand2;
                    }
                    else if (strandnumber == 3)
                    {
                        OP5DNA = Dnastrand3;
                    }

                    bool error = false;
                    int gene_number = 0;

                    int counter = 0;


                    for (int i = 0; i < OP5DNA.Length; i++)
                    {
                        if (OP5DNA[i] == 'A' || OP5DNA[i] == 'T' || OP5DNA[i] == 'G' || OP5DNA[i] == 'C')
                            counter++;

                    }


                    // All possibilities for gender if strand don't match one of them that means strand is wrong 
                    if (OP5DNA[3] == 'G' && OP5DNA[4] == 'G' && OP5DNA[5] == 'G' || OP5DNA[3] == 'C' && OP5DNA[4] == 'C' && OP5DNA[5] == 'C')
                    {
                        if (OP5DNA[6] == 'A' && OP5DNA[7] == 'A' && OP5DNA[8] == 'A' || OP5DNA[6] == 'T' && OP5DNA[7] == 'T' && OP5DNA[8] == 'T')
                        {
                            if (OP5DNA[9] == 'T' && OP5DNA[10] == 'A' && OP5DNA[11] == 'G')
                            {

                            }
                            else
                            {
                                Console.Write("Gender error. ");
                                error = true;
                            }
                        }
                        else
                        {
                            Console.Write("Gender error. ");
                            error = true;
                        }
                    }
                    else if (OP5DNA[3] == 'A' && OP5DNA[4] == 'A' && OP5DNA[5] == 'A' || OP5DNA[3] == 'T' && OP5DNA[4] == 'T' && OP5DNA[5] == 'T')
                    {
                        if (OP5DNA[6] == 'A' && OP5DNA[7] == 'A' && OP5DNA[8] == 'A' || OP5DNA[6] == 'T' && OP5DNA[7] == 'T' && OP5DNA[8] == 'T' || OP5DNA[6] == 'G' && OP5DNA[7] == 'G' && OP5DNA[8] == 'G' || OP5DNA[6] == 'C' && OP5DNA[7] == 'C' && OP5DNA[8] == 'C')
                        {
                            if (OP5DNA[9] == 'T' && OP5DNA[10] == 'A' && OP5DNA[11] == 'G')
                            {

                            }
                            else
                            {
                                Console.Write("Gender error. ");
                                error = true;
                            }

                        }
                        else
                        {
                            Console.Write("Gender error. ");
                            error = true;
                        }
                    }
                    else
                    {
                        Console.Write("Gender error. ");
                        error = true;
                    }


                    // if ending codons came just after starting ones it cause error too
                    try
                    {
                        for (int i = 0; i < counter; i += 3)
                        {
                            if (OP5DNA[i] == 'A' && OP5DNA[i + 1] == 'T' && OP5DNA[i + 2] == 'G')
                            {
                                gene_number++;
                                if (OP5DNA[i + 3] == 'T' && OP5DNA[i + 4] == 'A' && OP5DNA[i + 5] == 'G' || OP5DNA[i + 3] == 'T' && OP5DNA[i + 4] == 'A' && OP5DNA[i + 5] == 'A' || OP5DNA[i + 3] == 'T' && OP5DNA[i + 4] == 'G' && OP5DNA[i + 5] == 'A')
                                {
                                    Console.Write("Number of codons error. ");
                                    error = true;
                                    break;
                                }
                            }
                        }
                        // if gene number is not in right interval its false and got error
                        if (8 > gene_number && gene_number > 1)
                        {
                        }
                        else
                        {
                            Console.Write("Number of genes error.");
                            error = true;

                        }
                    }
                    catch
                    {
                        Console.WriteLine("Gene structure error.");
                        error = true;
                    }

                    if (error == false)
                        Console.WriteLine("BLOB is OK.");

                    Console.ReadLine();
                    Console.Clear();
                }
                else if (input == 6)
                {
                    char[] OP6DNA = new char[400];
                    Console.Write("Strand Number:");
                    strandnumber = Convert.ToInt16(Console.ReadLine());//Getting wanted strand into operation DNA.
                    if (strandnumber == 1)
                    {
                        OP6DNA = Dnastrand1;
                    }
                    else if (strandnumber == 2)
                    {
                        OP6DNA = Dnastrand2;
                    }
                    else if (strandnumber == 3)
                    {
                        OP6DNA = Dnastrand3;
                    }

                    for (int i = 0; i < OP6DNA.Length; i++)//Writing before complemation.
                    {
                        if (i % 3 == 0 && i != 0)
                        {
                            Console.Write(" ");
                        }
                        Console.Write(OP6DNA[i]);
                    }
                    Console.WriteLine();
                    char[] OP6DNA2 = new char[400];
                    for (int i = 0; i < OP6DNA.Length; i++)//Creating new complement dna array
                    {
                        if (OP6DNA[i] == 'A')
                        {
                            OP6DNA2[i] = 'T';
                        }
                        else if (OP6DNA[i] == 'T')
                        {
                            OP6DNA2[i] = 'A';
                        }
                        else if (OP6DNA[i] == 'G')
                        {
                            OP6DNA2[i] = 'C';
                        }
                        else if (OP6DNA[i] == 'C')
                        {
                            OP6DNA2[i] = 'G';
                        }
                    }
                    for (int i = 0; i < OP6DNA2.Length; i++)//writing new dna to dna strands to use in another operation.
                    {
                        if (i % 3 == 0 && i != 0)
                        {
                            Console.Write(" ");
                        }
                        Console.Write(OP6DNA2[i]);
                    }
                    if (strandnumber == 1)
                    {
                        Dnastrand1 = OP6DNA2;
                    }
                    else if (strandnumber == 2)
                    {
                        Dnastrand2 = OP6DNA2;
                    }
                    else if (strandnumber == 3)
                    {
                        Dnastrand3 = OP6DNA2;
                    }
                    Console.Read();
                    Console.Clear();
                }
                else if (input == 7)
                {
                    char[] OP7DNA = new char[400];
                    Console.Write("Strand Number:");
                    strandnumber = Convert.ToInt16(Console.ReadLine());
                    if (strandnumber == 1)
                    {
                        for (int ii = 0; ii < Dnastrand1.Length; ii++)
                        {
                            OP7DNA[ii] = Dnastrand1[ii];
                        }
                    }
                    else if (strandnumber == 2)
                    {
                        for (int ii = 0; ii < Dnastrand2.Length; ii++)
                        {
                            OP7DNA[ii] = Dnastrand2[ii];
                        }
                    }
                    else if (strandnumber == 3)
                    {
                        for (int ii = 0; ii < Dnastrand3.Length; ii++)
                        {
                            OP7DNA[ii] = Dnastrand3[ii];
                        }
                    }
                    string[] codons = new string[] {"GCT","GCC","GCA","GCG", "CGT","CGC","CGA","CGG","AGA","AGG", "AAT","AAC" ,"GAT","GAC", "TGT","TGC", "CAA","Cag"
                    ,"GAA","GAG", "GGT","GGC","GGA","GGG", "CAT","CAC", "ATT","ATC","ATA", "CTT","CTC","CTA","CTG","TTA","TTG", "AAA","AAG", "ATG", "TTT","TTC", "CCT","CCC","CCA","CCG", "TCT","TCC","TCA","TCG","AGT","AGC",
                     "ACT","ACC","ACA","ACG", "TGG", "TAT","TAC", "GTT","GTC","GTA","GTG", "TAG","TAA","TGA"};
                    string[] aminoacids = new string[] { "Ala", "Ala", "Ala", "Ala", "Arg","Arg","Arg","Arg","Arg","Arg", "Asn","Asn"  ,"Asp","Asp", "Cys","Cys", "Gln","Gln"
                    ,"Glu","Glu", "Gly","Gly","Gly","Gly", "His","His", "Ile","Ile","Ile","Leu","Leu","Leu","Leu","Leu","Leu", "Lys","Lys", "Met", "Phe","Phe", "Pro","Pro","Pro","Pro", "Ser","Ser","Ser","Ser","Ser","Ser",
                     "Thr", "Thr", "Thr", "Thr", "Trp" ,"Tyr","Tyr", "Val","Val","Val","Val","End","End","End"};
                    string codon = "";

                    Console.Write("DNA strand :" + " ");
                    for (int i = 0; i < OP7DNA.Length; i++)
                    {
                        if (i != 0 && i % 3 == 0)
                        { Console.Write(" "); }
                        if (OP7DNA[i] != ' ')
                        Console.Write(OP7DNA[i]);

                    }
                    Console.WriteLine();
                    Console.Write("Amino acids :" + " ");

                    for (int i = 0; i < OP7DNA.Length-3; i+=3)
                    {
                        codon = Convert.ToString(OP7DNA[i]) + Convert.ToString(OP7DNA[i+1]) + Convert.ToString(OP7DNA[i+2]);

                        for (int j = 0; j < codons.Length; j++)
                        {
                            if (codon == codons[j])
                            {
                                Console.Write(aminoacids[j]+" ");
                            }
                        }
                    }
                    Console.ReadLine();
                    Console.Clear();
                }
                else if (input == 8)
                {
                    char[] OP8DNA = new char[400];
                    char[] OP8DNA2 = new char[400];
                    Console.Write("Strand Number:");
                    strandnumber = Convert.ToInt16(Console.ReadLine());
                    Console.Write("Enter Starting Codon: ");
                    int m = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Enter Number of Codon: ");
                    int n = Convert.ToInt32(Console.ReadLine());

                    if (strandnumber == 1)
                    {
                        OP8DNA = Dnastrand1;
                    }
                    else if (strandnumber == 2)
                    {
                        OP8DNA = Dnastrand2;
                    }
                    else if (strandnumber == 3)
                    {
                        OP8DNA = Dnastrand3;
                    }


                    Console.Write($"DNA strand (stage 1) : ");
                    for (int h = 0; h < OP8DNA.Length; h++)
                    {
                        if (h % 3 == 0 && h != 0)
                        {
                            Console.Write(" ");
                        }
                        Console.Write(OP8DNA[h]);
                    }
                    Console.WriteLine();

                    int l = 0;
                    for (int k = 0; k < OP8DNA.Length; k++) //if k is before our start or after our finish, array will not transfer.
                    {
                        if (k < 3 * (m - 1) || k > 3 * (m + n) - 4)
                        {
                            OP8DNA2[l] = OP8DNA[k];
                            l += 1;
                        }
                    }
                    Console.Write($"DNA strand (stage 2) : ");
                    for (int h = 0; h < OP8DNA2.Length; h++)
                    {
                        if (h % 3 == 0 && h != 0)
                        {
                            Console.Write(" ");
                        }
                        Console.Write(OP8DNA2[h]);
                    }
                    if (strandnumber == 1)
                    {
                        Dnastrand1 = OP8DNA2;
                    }
                    else if (strandnumber == 2)
                    {
                        Dnastrand2 = OP8DNA;
                    }
                    else if (strandnumber == 3)
                    {
                        Dnastrand3 = OP8DNA;
                    }
                    Console.Read();
                    Console.Clear();

                }//it inserts a codon at a desired location on DNA.
                else if (input == 9)
                {
                    char[] OP9DNA = new char[500];
                    char[] helper = new char[500];
                    Console.Write("Strand Number:");
                    strandnumber = Convert.ToInt16(Console.ReadLine());

                    if (strandnumber == 1)
                    {
                        OP9DNA = Dnastrand1;
                    }
                    else if (strandnumber == 2)
                    {
                        OP9DNA = Dnastrand2;
                    }
                    else if (strandnumber == 3)
                    {
                        OP9DNA = Dnastrand3;
                    }


                    //to take codon sequence from user to insert it
                    Console.Write("Enter Codon Sequence:");

                    string codonsequence = Console.ReadLine();

                    char[] Codonarray = new char[400];

                    int codonlenght = 0;
                    int counter = 0;

                    //to learn where it start to insert codon sequence
                    Console.Write("Enter Starting Codon:");

                    int startingcodon = Convert.ToInt32(Console.ReadLine());

                    //here, I checked length of codon sequence and to find how many space between the codons. 
                    for (int i = 0; i < codonsequence.Length; i++)
                    {
                        if (codonsequence[i] == 'A' || codonsequence[i] == 'a')
                        {
                            Codonarray[i - counter] = 'A';
                            codonlenght++;

                        }
                        else if (codonsequence[i] == 'T' || codonsequence[i] == 't')
                        {
                            Codonarray[i - counter] = 'T';
                            codonlenght++;

                        }
                        else if (codonsequence[i] == 'G' || codonsequence[i] == 'g')
                        {
                            Codonarray[i - counter] = 'G';
                            codonlenght++;

                        }
                        else if (codonsequence[i] == 'C' || codonsequence[i] == 'c')
                        {
                            Codonarray[i - counter] = 'C';
                            codonlenght++;

                        }
                        else
                        {
                            counter++;
                        }
                    }

                    counter = 0;
                    for (int i = 3 * (startingcodon - 1); i < Dnastrand1.Length; i++)
                    {
                        helper[counter] = Dnastrand1[i];
                        counter++;

                    }
                    counter = 0;

                    for (int i = 3 * (startingcodon - 1); i <= codonlenght + (3 * (startingcodon - 1)); i++)
                    {
                        Dnastrand1[i] = Codonarray[counter];
                        counter++;


                    }
                    // to find length of char helper
                    int helperlenght = 0;
                    counter = 0;
                    for (int i = 0; i < helper.Length; i++)
                    {
                        if (helper[i] == 'A')
                        {
                            helperlenght++;

                        }
                        else if (helper[i] == 'T')
                        {
                            helperlenght++;

                        }
                        else if (helper[i] == 'G')
                        {
                            helperlenght++;

                        }
                        else if (helper[i] == 'C')
                        {
                            helperlenght++;

                        }
                    }
                    //Calculates where the DNA sequence to be added will begin and end.it also inserts the codon sequence.
                    for (int i = codonlenght + (3 * (startingcodon - 1)); i < codonlenght + (3 * (startingcodon - 1)) + helperlenght; i++)
                    {
                        Dnastrand1[i] = helper[counter];
                        counter++;

                    }
                    //to write to the screen properly.
                    for (int i = 0; i < Dnastrand1.Length; i++)
                    {
                        if (i % 3 == 0 && i != 0)
                            Console.Write(" ");
                        Console.Write(Dnastrand1[i]);

                    }

                    if (strandnumber == 1)
                    {
                        Dnastrand1 = OP9DNA;
                    }
                    else if (strandnumber == 2)
                    {
                        Dnastrand2 = OP9DNA;
                    }
                    else if (strandnumber == 3)
                    {
                        Dnastrand3 = OP9DNA;
                    }
                    Console.ReadLine();
                    Console.Clear();
                }
                else if (input == 10)
                {
                    char[] OP10DNA = new char[400];
                    Console.Write("Strand Number:");
                    strandnumber = Convert.ToInt16(Console.ReadLine());
                    if (strandnumber == 1)
                    {
                        OP10DNA = Dnastrand1;
                    }
                    else if (strandnumber == 2)
                    {
                        OP10DNA = Dnastrand2;
                    }
                    else if (strandnumber == 3)
                    {
                        OP10DNA = Dnastrand3;
                    }

                    Console.Write("Codon Sequance(without spaces):");
                    string codons = Console.ReadLine();
                    char[] codon_arr = codons.ToCharArray();
                    Console.Write("Start from:");
                    int start = Convert.ToInt32(Console.ReadLine());
                    int result = -1;
                    for (int i = 3 * start - 3; i < OP10DNA.Length; i += 3)//stepping codon array and dna array in 2 for loops and comparing values.
                    {
                        int j = 0;
                        int temp = i;
                        if ((OP10DNA[i] == codon_arr[j]) && (OP10DNA[i + 1] == codon_arr[j + 1]) && (OP10DNA[i + 2] == codon_arr[j + 2]))
                        {
                            result = i / 3 + 1;
                            for (int l = j; l < codon_arr.Length; l++)
                            {
                                if (OP10DNA[temp] != codon_arr[l])
                                {
                                    result = -1;
                                    break;
                                }
                                else
                                {
                                    temp++;
                                }
                            }
                        }
                    }
                    Console.WriteLine($"Result: {result}");
                    Console.ReadLine();
                    Console.Clear();
                }
                //to reverse a codon sequence
                else if (input == 11)
                {
                    char[] OP11DNA = new char[400];
                    Console.Write("Strand Number:");
                    strandnumber = Convert.ToInt16(Console.ReadLine());
                    if (strandnumber == 1)
                    {
                        OP11DNA = Dnastrand1;
                    }
                    else if (strandnumber == 2)
                    {
                        OP11DNA = Dnastrand2;
                    }
                    else if (strandnumber == 3)
                    {
                        OP11DNA = Dnastrand3;
                    }

                    char[] char_dna_strand_2 = new char[1000];
                    char[] will_reverse_codon = new char[1000];
                    char[] char_reversed_codon = new char[1000];
                    char temp = '1';

                    int counter = 0;
                    //finds the length of the dna and edits the letter size
                    for (int i = 0; i < OP11DNA.Length; i++)
                    {

                        if (OP11DNA[i] == 'a')
                        {
                            counter++;
                            OP11DNA[i] = 'A';
                        }
                        else if (OP11DNA[i] == 't')
                        {
                            counter++;
                            OP11DNA[i] = 'T';
                        }
                        else if (OP11DNA[i] == 'g')
                        {
                            counter++;
                            OP11DNA[i] = 'G';
                        }
                        else if (OP11DNA[i] == 'c')
                        {
                            counter++;
                            OP11DNA[i] = 'C';
                        }
                        else if (OP11DNA[i] == 'A')
                        {
                            counter++;
                        }
                        else if (OP11DNA[i] == 'T')
                        {
                            counter++;
                        }
                        else if (OP11DNA[i] == 'G')
                        {
                            counter++;
                        }
                        else if (OP11DNA[i] == 'C')
                        {
                            counter++;
                        }
                    }
                    //takes the how many codon will reverse and where we start.
                    Console.Write("Please enter how many condons will reverse: ");
                    int how_many_codons_reverse = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Please enter where to start reverse action: ");
                    int where_to_start_reverse = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine();

                    // I find which dna sequence will reverse
                    for (int e = 0; e < counter; e++)
                    {
                        if (e == (where_to_start_reverse - 1) * 3)
                        {
                            for (int i = 0; i < how_many_codons_reverse * 3; i++)
                            {
                                will_reverse_codon[i] = (OP11DNA[e]);
                                e += 1;
                            }

                            break;
                        }
                    }



                    // I reverse the codon sequence
                    for (int i = 1; i < 1 + how_many_codons_reverse; i++)
                    {
                        for (int e = 0; e < 3; e++)
                        {
                            temp = will_reverse_codon[(how_many_codons_reverse * 3) - (i * 3 - e)];
                            char_reversed_codon[(3 * i - 3) + e] = temp;

                        }

                    }
                    // crates final dna char
                    for (int i = 0; i < counter; i++)
                    {
                        if (i == (where_to_start_reverse - 1) * 3)
                        {
                            for (int e = 0; e < how_many_codons_reverse * 3; e++)
                            {

                                char_dna_strand_2[i] = char_reversed_codon[e];
                                i += 1;

                            }
                            i -= 1;
                        }
                        else
                        {
                            char_dna_strand_2[i] = OP11DNA[i];

                        }

                    }
                    Console.WriteLine();

                    // I do that to write informations to screen 
                    Console.Write("DNA strand (stage 1)   : ");
                    for (int i = 0; i < counter; i++)
                    {
                        if (i % 3 == 0 && i != 0)
                        {
                            Console.Write(" ");
                        }
                        Console.Write(OP11DNA[i]);
                    }
                    Console.WriteLine();
                    Console.WriteLine("Reverse " + how_many_codons_reverse + " codons, " + "starting from " + where_to_start_reverse);

                    Console.Write("DNA strand (stage 2)   : ");

                    for (int i = 0; i < counter; i++)
                    {

                        if (i % 3 == 0 && i != 0)
                        {
                            Console.Write(" ");
                        }
                        Console.Write(char_dna_strand_2[i]);

                    }
                    if (strandnumber == 1)
                    {
                        Dnastrand1 = char_dna_strand_2;
                    }
                    else if (strandnumber == 2)
                    {
                        Dnastrand2 = char_dna_strand_2;
                    }
                    else if (strandnumber == 3)
                    {
                        Dnastrand3 = char_dna_strand_2;
                    }
                    Console.ReadLine();
                    Console.Clear();

                }//finds the number of genes is dna strand
                else if (input == 12)
                {
                    char[] OP12DNA = new char[400];
                    Console.Write("Strand Number:");
                    strandnumber = Convert.ToInt16(Console.ReadLine());

                    if (strandnumber == 1)
                    {
                        OP12DNA = Dnastrand1;
                    }
                    else if (strandnumber == 2)
                    {
                        OP12DNA = Dnastrand2;
                    }
                    else if (strandnumber == 3)
                    {
                        OP12DNA = Dnastrand3;
                    }

                    // here , if a codon sequence start with atg and end with taa tga tag, it is a gen.
                    int number_of_ganes = 0;
                    bool atg = false;
                    bool tagtaatga = false;
                    for (int i = 0; i < OP12DNA.Length; i += 3)
                    {
                        if (OP12DNA[i] == 'A' && OP12DNA[i + 1] == 'T' && OP12DNA[i + 2] == 'G')
                        {
                            atg = true;
                        }
                        else if ((OP12DNA[i] == 'T' && OP12DNA[i + 1] == 'A' && OP12DNA[i + 2] == 'A') || (OP12DNA[i] == 'T' && OP12DNA[i + 1] == 'A' && OP12DNA[i + 2] == 'G') || (OP12DNA[i] == 'T' && OP12DNA[i + 1] == 'G' && OP12DNA[i + 2] == 'A'))
                        {
                            tagtaatga = true;
                        }
                        if (atg && tagtaatga)
                        {
                            number_of_ganes++;
                            atg = false;
                            tagtaatga = false;
                        }
                    }
                    // to write sceen information properly.
                    Console.Write("DNA strand       : ");
                    for (int e = 0; e < OP12DNA.Length - 3; e += 3)
                    {
                        if (e == 0)
                            Console.Write(OP12DNA[0].ToString() + OP12DNA[1].ToString() + OP12DNA[2].ToString());
                        else
                            Console.Write(" " + OP12DNA[e].ToString() + OP12DNA[e + 1].ToString() + OP12DNA[e + 2].ToString());
                    }
                    Console.WriteLine();
                    Console.Write($"Number of genes  : {number_of_ganes}");
                    Console.ReadLine();
                    Console.Clear();
                }
                else if (input == 13)
                {
                    char[] OP13DNA = new char[400];
                    Console.Write("Strand Number:");
                    strandnumber = Convert.ToInt16(Console.ReadLine());
                    if (strandnumber == 1)
                    {
                        OP13DNA = Dnastrand1;
                    }
                    else if (strandnumber == 2)
                    {
                        OP13DNA = Dnastrand2;
                    }
                    else if (strandnumber == 3)
                    {
                        OP13DNA = Dnastrand3;
                    }

                    //Taking first gene as a minimum gene.
                    int counter = 0;
                    int temp_counter = 0;
                    for (int i = 0; i < OP13DNA.Length; i += 3)
                    {
                        if (OP13DNA[i] == 'T' && OP13DNA[i + 1] == 'A' && OP13DNA[i + 2] == 'G')
                        {
                            counter++;
                            temp_counter = counter;
                            break;
                        }
                        else if (OP13DNA[i] == 'T' && OP13DNA[i + 1] == 'G' && OP13DNA[i + 2] == 'A')
                        {
                            counter++;
                            temp_counter = counter;
                            break;
                        }
                        else if (OP13DNA[i] == 'T' && OP13DNA[i + 1] == 'A' && OP13DNA[i + 2] == 'A')
                        {
                            counter++;
                            temp_counter = counter;
                            break;
                        }
                        else
                        {
                            counter++;
                        }
                    }
                    //comparing first gene length with another genes.
                    counter = 0;
                    int min_length = temp_counter;
                    int min_starts = 0;
                    for (int j = 0; j < OP13DNA.Length; j += 3)
                    {
                        //In start codon, our counter must return to first value to calculate all genes' length.
                        if (OP13DNA[j] == 'A' && OP13DNA[j + 1] == 'T' && OP13DNA[j + 2] == 'G')
                        {
                            counter = 1;
                        }
                        else if (OP13DNA[j] == 'T' && OP13DNA[j + 1] == 'A' && OP13DNA[j + 2] == 'G')//stop codons takes counter as a temprary and compare it with last minimum gene length.
                        {
                            counter++;
                            temp_counter = counter;
                            if (temp_counter < min_length)
                            {
                                min_length = temp_counter;
                                min_starts = j / 3 - min_length + 2;//if minimum lenght changes, minimum lenght-gene start changes too.
                            }
                        }
                        else if (OP13DNA[j] == 'T' && OP13DNA[j + 1] == 'G' && OP13DNA[j + 2] == 'A')
                        {
                            counter++;
                            temp_counter = counter;
                            if (temp_counter < min_length)
                            {
                                min_length = temp_counter;
                                min_starts = j / 3 - min_length + 2;
                            }
                        }
                        else if (OP13DNA[j] == 'T' && OP13DNA[j + 1] == 'A' && OP13DNA[j + 2] == 'A')
                        {
                            counter++;
                            temp_counter = counter;
                            if (temp_counter < min_length)
                            {
                                min_length = temp_counter;
                                min_starts = j / 3 - min_length + 2;
                            }
                        }
                        else
                        {
                            counter++;
                        }
                    }
                    Console.Write("Shortest gene is:");
                    if (min_starts == 0)
                    {
                        for (int j = 3 * (min_starts); j <= 3 * (min_starts - 1) + 1 + 3 + 3 * (min_length) - 2; j++)
                        {
                            Console.Write(OP13DNA[j]);
                            if ((j - 2) % 3 == 0 && j != 0)
                            {
                                Console.Write(" ");
                            }
                        }
                    }
                    else
                    {
                        Console.Write("ATG ");
                        for (int j = 3 * (min_starts); j <= 3 * (min_starts - 1) + 1 + 3 * (min_length) - 2; j++)
                        {
                            Console.Write(OP13DNA[j]);
                            if ((j - 2) % 3 == 0 && j != 0)
                            {
                                Console.Write(" ");
                            }
                        }

                    }

                    Console.WriteLine();
                    Console.WriteLine($"Shortest gene length is {min_length}.");
                    Console.WriteLine($"Shortest gene length starts from codon {min_starts}.");
                    Console.Read();

                }
                else if (input == 14)
                {
                    char[] OP14DNA = new char[400];
                    Console.Write("Strand Number:");
                    strandnumber = Convert.ToInt16(Console.ReadLine());
                    if (strandnumber == 1)
                    {
                        OP14DNA = Dnastrand1;
                    }
                    else if (strandnumber == 2)
                    {
                        OP14DNA = Dnastrand2;
                    }
                    else if (strandnumber == 3)
                    {
                        OP14DNA = Dnastrand3;
                    }

                    int counter = 0;
                    int temp_counter = 0;
                    int max_length = 0;
                    int max_starts = 0;

                    for (int i = 0; i < OP14DNA.Length - 3; i += 3)
                    {
                        if (OP14DNA[i] == 'A' && OP14DNA[i + 1] == 'T' && OP14DNA[i + 2] == 'G')//similar with 13th operation, compared all genes and chose longest one.
                        {
                            counter = 1;
                        }
                        else if (OP14DNA[i] == 'T' && OP14DNA[i + 1] == 'G' && OP14DNA[i + 2] == 'A')
                        {
                            counter++;
                            temp_counter = counter;
                            if (temp_counter > max_length)
                            {
                                max_length = temp_counter;
                                max_starts = i / 3 - max_length + 2;
                            }
                        }
                        else if (OP14DNA[i] == 'T' && OP14DNA[i + 1] == 'A' && OP14DNA[i + 2] == 'G')
                        {
                            counter++;
                            temp_counter = counter;
                            if (temp_counter > max_length)
                            {
                                max_length = temp_counter;
                                max_starts = i / 3 - max_length + 2;
                            }
                        }
                        else if (OP14DNA[i] == 'T' && OP14DNA[i + 1] == 'A' && OP14DNA[i + 2] == 'A')
                        {
                            counter++;
                            temp_counter = counter;
                            if (temp_counter > max_length)
                            {
                                max_length = temp_counter;
                                max_starts = i / 3 - max_length + 2;
                            }
                        }
                        else
                        {
                            counter++;
                        }
                    }
                    Console.Write("Longest gene is: ");
                    for (int j = 3 * (max_starts - 1); j <= 3 * (max_starts - 1) + 1 + 3 * (max_length) - 2; j++)
                    {
                        Console.Write(OP14DNA[j]);
                        if ((j - 2) % 3 == 0 && j != 0)
                        {
                            Console.Write(" ");
                        }
                    }
                    Console.WriteLine();
                    Console.WriteLine($"Longest gene length is {max_length}.");
                    Console.WriteLine($"Longest gene length starts from codon {max_starts}.");
                    Console.Read();


                    Console.Clear();

                }//finds the most repeated dna sequence in a dna strand(short tandem repeat)
                else if (input == 15)
                {
                    char[] OP15DNA = new char[400];
                    Console.Write("Strand Number:");
                    strandnumber = Convert.ToInt16(Console.ReadLine());

                    if (strandnumber == 1)
                    {
                        OP15DNA = Dnastrand1;
                    }
                    else if (strandnumber == 2)
                    {
                        OP15DNA = Dnastrand2;
                    }
                    else if (strandnumber == 3)
                    {
                        OP15DNA = Dnastrand3;
                    }
                    int counter = 0;

                    for (int i = 0; i < OP15DNA.Length; i++)
                    {

                        if (OP15DNA[i] == 'a')
                        {
                            counter++;
                            OP15DNA[i] = 'A';
                        }
                        else if (OP15DNA[i] == 't')
                        {
                            counter++;
                            OP15DNA[i] = 'T';
                        }
                        else if (OP15DNA[i] == 'g')
                        {
                            counter++;
                            OP15DNA[i] = 'G';
                        }
                        else if (OP15DNA[i] == 'c')
                        {
                            counter++;
                            OP15DNA[i] = 'C';
                        }
                        else if (OP15DNA[i] == 'A')
                        {
                            counter++;
                        }
                        else if (OP15DNA[i] == 'T')
                        {
                            counter++;
                        }
                        else if (OP15DNA[i] == 'G')
                        {
                            counter++;
                        }
                        else if (OP15DNA[i] == 'C')
                        {
                            counter++;
                        }
                    }

                    Console.WriteLine();
                    // to write screen dna strand
                    Console.Write("DNA strand       : ");
                    for (int e = 0; e < counter; e += 3)
                    {
                        if (e == 0)
                            Console.Write(OP15DNA[0].ToString() + OP15DNA[1].ToString() + OP15DNA[2].ToString());
                        else
                            Console.Write(" " + OP15DNA[e].ToString() + OP15DNA[e + 1].ToString() + OP15DNA[e + 2].ToString());
                    }
                    Console.WriteLine();
                    Console.Write("Enter number  of nucleotide:");
                    int num_of_nucleotid = Convert.ToInt32(Console.ReadLine());

                    //I determined char arrays and wrote the code to find the most repeating nucleotide sequence.
                    char[] repeated_Final = new char[num_of_nucleotid];
                    char[] repeated_char = new char[num_of_nucleotid];
                    char[] temp_repeated_char = new char[num_of_nucleotid];
                    int frequency = 0;
                    int temp_frequency = 0;
                    int i_15 = 0;
                    int repeat = Convert.ToInt32(counter - num_of_nucleotid + 1);
                    string test = "";
                    string test1 = "";
                    string test2 = "";
                    while (i_15 < repeat)
                    {//first for loop to determine which nucleotit sequence we look for.
                        for (int a = 0; a < num_of_nucleotid; a++)
                        {
                            repeated_char[a] = OP15DNA[i_15 + a];

                            if (a == num_of_nucleotid - 1)
                            {//here , I compare nukleotid sequence to each others.
                                for (int p = 0; p < num_of_nucleotid; p++)
                                {
                                    test += repeated_Final[p];
                                    test1 += repeated_char[p];
                                }


                                if (test == test1)
                                {
                                    i_15++;
                                    break;
                                }
                                test = "";

                                int i = 0;
                                while (i < counter - (num_of_nucleotid - 1))
                                {
                                    for (int b = 0; b < num_of_nucleotid; b++)
                                    {
                                        temp_repeated_char[b] = OP15DNA[i_15 + i + b];

                                    }

                                    for (int n = 0; n < num_of_nucleotid; n++)
                                    {
                                        test2 += temp_repeated_char[n];
                                    }

                                    if (test1 == test2)
                                    {
                                        temp_frequency++;
                                        i += (num_of_nucleotid - 1);

                                    }
                                    ;
                                    test2 = "";

                                    i++;
                                }
                                test1 = "";
                                i_15++;
                            }// I append nucleotid sequence which is most repeated in repated_Final char array
                            if (temp_frequency > frequency)
                            {
                                string temp = "";
                                for (int j = 0; j < num_of_nucleotid; j++)
                                {
                                    temp += repeated_char[j].ToString();

                                    repeated_Final[j] = temp[j];

                                }

                                frequency = temp_frequency;
                                temp_frequency = 0;
                                // I clear the inside of repeated_char array to avoid mistakes
                                for (int u = 0; u < num_of_nucleotid; u++)
                                {
                                    repeated_char[u] = 'Y';
                                }
                            }
                            temp_frequency = 0;
                        }

                    }
                    //I wrote screen the results
                    Console.Write("Most repeated sequence     :");
                    for (int i = 0; i < num_of_nucleotid; i++)
                    {
                        Console.Write(repeated_Final[i].ToString());
                    }
                    Console.WriteLine();

                    Console.Write("Frequency                  :");
                    Console.Write(frequency);

                    Console.ReadLine();
                    Console.Clear();
                }
                else if (input == 16)
                {
                    char[] OP16DNA = new char[400];
                    Console.Write("Strand Number:");
                    strandnumber = Convert.ToInt16(Console.ReadLine());

                    if (strandnumber == 1)
                    {
                        OP16DNA = Dnastrand1;
                    }
                    else if (strandnumber == 2)
                    {
                        OP16DNA = Dnastrand2;
                    }
                    else if (strandnumber == 3)
                    {
                        OP16DNA = Dnastrand3;
                    }
                    //if there is a or t, there is double hydrogen bond
                    int double_bond = 0;
                    int triple_bond = 0;
                    for (int i = 0; i < OP16DNA.Length; i++)
                    {
                        if (OP16DNA[i] == 'A' || OP16DNA[i] == 'T')

                            double_bond += 1;
                    }
                    for (int j = 0; j < OP16DNA.Length; j++)
                    {
                        if (OP16DNA[j] == 'G' || OP16DNA[j] == 'C')//if there is g or c, there is triple hydrogen bond

                            triple_bond += 1;
                    }

                    Console.WriteLine();
                    Console.WriteLine($"Triple Hydrogen Bond: {triple_bond}");
                    Console.WriteLine($"Double Hydrogen Bond: {double_bond}");
                    int total_bond = 3 * triple_bond + 2 * double_bond;
                    Console.WriteLine($"Total Hydrogen Bond: {total_bond}");
                    Console.Read();

                    Console.Clear();
                }
                else if (input == 17)
                {
                    int Generation = 0;
                    char[] DnaStrand1 = new char[1000];
                    char[] DnaStrand2 = new char[1000];
                    char[] DnaStrand3 = new char[1000];
                    for (int i = 0; i < Dnastrand1.Length; i++)
                    {
                        DnaStrand1[i] = Dnastrand1[i];
                    }
                    for (int i = 0; i < Dnastrand2.Length; i++)
                    {
                        DnaStrand2[i] = Dnastrand2[i];
                    }
                    for (int i = 0; i < Dnastrand1.Length; i++)
                    {
                        DnaStrand2[i] = Dnastrand2[i];
                    }
                    char Gender;
                    while (Generation < 10)
                    {
                        string Gender1 = "";
                        string Gender2 = "";
                        string Gender3 = "";
                        Generation++;
                        double faultycodons = 0;
                        double Dna3Len = 0;
                        int Dna2Len = 0;
                        int Dna1Len = 0;
                        int count = 0;
                        int Gen1count = 0;
                        int Gen2count = 0;
                        int lenght3 = 12;
                        int lastpoint = 12;
                        Console.WriteLine("Generation {0}:", Generation);
                        // Get lenght for DNA 1
                        Dna1Len = 0;
                        for (int i = 0; i < DnaStrand1.Length; i++)
                        {
                            if (DnaStrand1[i] == 'A' || DnaStrand1[i] == 'T' || DnaStrand1[i] == 'G' || DnaStrand1[i] == 'C')
                            {
                                Dna1Len++;
                            }
                        }
                        //Get lenght for DNA 2
                        Dna2Len = 0;
                        for (int i = 0; i < DnaStrand2.Length; i++)
                        {
                            if (DnaStrand2[i] == 'A' || DnaStrand2[i] == 'T' || DnaStrand2[i] == 'G' || DnaStrand2[i] == 'C')
                            {
                                Dna2Len++;
                            }
                        }
                        // Determine gender for DNA 1 
                        if ((DnaStrand1[4] == 'A' || DnaStrand1[4] == 'T') && (DnaStrand1[7] == 'A' || DnaStrand1[7] == 'T'))
                            Gender1 = "XX";
                        else if ((DnaStrand1[4] == 'A' || DnaStrand1[4] == 'T') && (DnaStrand1[7] == 'G' || DnaStrand1[7] == 'C'))
                            Gender1 = "XY";
                        else if ((DnaStrand1[4] == 'G' || DnaStrand1[4] == 'C') && (DnaStrand1[7] == 'A' || DnaStrand1[7] == 'T'))
                            Gender1 = "YX";

                        //Write the DNA 1 
                        Console.Write("BLOB1 - {0}: ", Gender1);
                        for (int i = 0; i < Dna1Len; i++)
                        {
                            if (i % 3 == 0 && i != 0)
                                Console.Write(" ");
                            Console.Write(DnaStrand1[i]);
                        }
                        // Determine gender for DNA 2 
                        if ((DnaStrand2[4] == 'A' || DnaStrand2[4] == 'T') && (DnaStrand2[7] == 'A' || DnaStrand2[7] == 'T'))
                            Gender2 = "XX";
                        else if ((DnaStrand2[4] == 'A' || DnaStrand2[4] == 'T') && (DnaStrand2[7] == 'G' || DnaStrand2[7] == 'C'))
                            Gender2 = "XY";
                        else if ((DnaStrand2[4] == 'G' || DnaStrand2[4] == 'C') && (DnaStrand2[7] == 'A' || DnaStrand2[7] == 'T'))
                            Gender2 = "YX";

                        //Write the DNA 2
                        Console.Write("\nBLOB2 - {0} : ", Gender2);
                        for (int i = 0; i < Dna2Len; i++)
                        {
                            if (i % 3 == 0 && i != 0)
                                Console.Write(" ");

                            Console.Write(DnaStrand2[i]);

                        }
                        //Determine BLOB3's gender
                        for (int i = 0; i < 12; i += 3)
                        {
                            if (i % 2 != 0 && i != 0)
                            {
                                DnaStrand3[i] = DnaStrand1[i];
                                DnaStrand3[i + 1] = DnaStrand1[i + 1];
                                DnaStrand3[i + 2] = DnaStrand1[i + 2];
                            }
                            else
                            {
                                DnaStrand3[i] = DnaStrand2[i];
                                DnaStrand3[i + 1] = DnaStrand2[i + 1];
                                DnaStrand3[i + 2] = DnaStrand2[i + 2];
                            }
                        }
                        Dna3Len = 0;
                        for (int i = 0; i < DnaStrand3.Length; i++)
                        {
                            if (DnaStrand3[i] == 'A' || DnaStrand3[i] == 'T' || DnaStrand3[i] == 'G' || DnaStrand3[i] == 'C')
                            {
                                Dna3Len++;
                            }
                        }
                        //-------------------------------------------------------------------------------------
                        //determine how many genes BLOB1 and BLOB2  have
                        for (int i = 0; i < DnaStrand1.Length; i += 3)
                        {
                            if ((DnaStrand1[i] == 'A' && DnaStrand1[i + 1] == 'T' && DnaStrand1[i + 2] == 'G'))
                            {
                                Gen1count++;
                            }
                        }
                        for (int i = 0; i < DnaStrand2.Length; i += 3)
                        {
                            if ((DnaStrand2[i] == 'A' && DnaStrand2[i + 1] == 'T' && DnaStrand2[i + 2] == 'G'))
                            {
                                Gen2count++;

                            }
                        }
                        int longest;
                        int shortest;
                        if (Gen1count > Gen2count)
                            shortest = Gen2count;
                        else
                            shortest = Gen1count;

                        if (Gen1count > Gen2count)
                            longest = Gen1count;
                        else
                            longest = Gen2count;
                        int turn = 1;
                        int codonnumber = 0;
                        int passedSTARTÝNG = 0;
                        int startingcodon = 0;
                        int endingcodon = 0;
                        // gene sharing part
                        // until shortest parents gene depleted they are share
                        // after that other parents genes are copy
                        for (int h = 2; h < shortest; h++)
                        {
                            codonnumber = h;
                            passedSTARTÝNG = 0;
                            startingcodon = 0;
                            endingcodon = 0;
                            if (Gen1count >= h && Gen2count < h)
                            {
                                turn = 1;

                            }
                            else if (Gen2count >= h && Gen1count < h)
                            {
                                turn = 2;
                            }
                            else if (Gen2count < h && Gen1count < h)
                            {
                                break;
                            }
                            if (turn == 1)
                            {
                                for (int i = 0; i < 400; i += 3)
                                {
                                    if ((DnaStrand1[i] == 'A' && DnaStrand1[i + 1] == 'T' && DnaStrand1[i + 2] == 'G'))
                                    {
                                        passedSTARTÝNG++;
                                        if (passedSTARTÝNG == codonnumber)
                                        {
                                            startingcodon = i;
                                            break;
                                        }
                                    }
                                }
                                for (int j = startingcodon; j < 400; j += 3)
                                {
                                    if ((DnaStrand1[j] == 'T' && DnaStrand1[j + 1] == 'A' && DnaStrand1[j + 2] == 'A') || (DnaStrand1[j] == 'T' && DnaStrand1[j + 1] == 'G' && DnaStrand1[j + 2] == 'A') ||
                                        (DnaStrand1[j] == 'T' && DnaStrand1[j + 1] == 'A' && DnaStrand1[j + 2] == 'G'))
                                    {
                                        endingcodon = j;
                                        break;
                                    }

                                }
                                for (int k = startingcodon; k < endingcodon + 3; k++)
                                {
                                    DnaStrand3[lenght3] = DnaStrand1[k];
                                    lenght3++;
                                }
                                turn = 2;

                            }
                            else if (turn == 2)
                            {
                                for (int i = 0; i < 400; i += 3)
                                {
                                    if ((DnaStrand2[i] == 'A' && DnaStrand2[i + 1] == 'T' && DnaStrand2[i + 2] == 'G'))
                                    {
                                        passedSTARTÝNG++;
                                        if (passedSTARTÝNG == codonnumber)
                                        {
                                            startingcodon = i;
                                            break;
                                        }
                                    }
                                }
                                for (int j = startingcodon; j < 400; j += 3)
                                {
                                    if ((DnaStrand2[j] == 'T' && DnaStrand2[j + 1] == 'A' && DnaStrand2[j + 2] == 'A') || (DnaStrand2[j] == 'T' && DnaStrand2[j + 1] == 'G' && DnaStrand2[j + 2] == 'A') ||
                                        (DnaStrand2[j] == 'T' && DnaStrand2[j + 1] == 'A' && DnaStrand2[j + 2] == 'G'))
                                    {
                                        endingcodon = j;
                                        break;
                                    }

                                }
                                for (int k = startingcodon; k < endingcodon + 3; k++)
                                {
                                    DnaStrand3[lenght3] = DnaStrand2[k];
                                    lenght3++;
                                }
                                turn = 1;
                            }
                        }
                        startingcodon = endingcodon + 3;
                        if (longest == Gen1count)
                        {
                            for (int i = startingcodon; i < 400; i += 3)
                            {
                                if ((DnaStrand1[i] == 'A' && DnaStrand1[i + 1] == 'T' && DnaStrand1[i + 2] == 'G'))
                                {
                                    startingcodon = i;
                                    break;
                                }
                            }
                            for (int k = startingcodon; k < startingcodon + Dna1Len; k++)
                            {
                                DnaStrand3[lenght3] = DnaStrand1[k];
                                lenght3++;
                            }

                        }
                        else if (longest == Gen2count)
                        {
                            for (int i = startingcodon; i < 400; i += 3)
                            {
                                if ((DnaStrand2[i] == 'A' && DnaStrand2[i + 1] == 'T' && DnaStrand2[i + 2] == 'G'))
                                {
                                    startingcodon = i;
                                    break;
                                }
                            }
                            for (int k = startingcodon; k < startingcodon + Dna2Len; k++)
                            {
                                DnaStrand3[lenght3] = DnaStrand2[k];
                                lenght3++;
                            }

                        }
                        Dna3Len = 0;
                        for (int i = 0; i < DnaStrand3.Length; i++)
                        {
                            if (DnaStrand3[i] == 'A' || DnaStrand3[i] == 'T' || DnaStrand3[i] == 'G' || DnaStrand3[i] == 'C')
                            {
                                Dna3Len++;
                            }
                        }

                        // To determine BLOB3's gender
                        lenght3 = Convert.ToInt32(Dna3Len);

                        if ((DnaStrand3[4] == 'A' || DnaStrand3[4] == 'T') && (DnaStrand3[7] == 'A' || DnaStrand3[7] == 'T'))
                            Gender3 = "XX";
                        else if ((DnaStrand3[4] == 'A' || DnaStrand3[4] == 'T') && (DnaStrand3[7] == 'G' || DnaStrand3[7] == 'C'))
                            Gender3 = "XY";
                        else if ((DnaStrand3[4] == 'G' || DnaStrand3[4] == 'C') && (DnaStrand3[7] == 'A' || DnaStrand3[7] == 'T'))
                            Gender3 = "YX";

                        // To write Strand 3
                        Console.Write("\nBLOB3 - {0}: ", Gender3);
                        for (int i = 0; i < Dna3Len; i++)
                        {
                            if (i % 3 == 0 && i != 0)
                                Console.Write(" ");

                            Console.Write(DnaStrand3[i]);

                        }

                        // Faulty codons part

                        count = 0;
                        double allfaulty = 0;
                        faultycodons = 0;
                        for (int i = 0; i < Dna3Len; i += 3)
                        {

                            if (count >= 9)
                            {
                                faultycodons += count;
                                i += count;
                            }

                            if ((DnaStrand3[i] == 'T' || DnaStrand3[i] == 'A') || (DnaStrand3[i + 1] == 'T' || DnaStrand3[i + 1] == 'A') || (DnaStrand3[i + 2] == 'T' || DnaStrand3[i + 2] == 'A'))
                            {
                                count = 0;
                            }
                            else if ((DnaStrand3[i] == 'G' || DnaStrand3[i] == 'C') && (DnaStrand3[i + 1] == 'G' || DnaStrand3[i + 1] == 'C') && (DnaStrand3[i + 2] == 'G' || DnaStrand3[i + 2] == 'C'))
                            {
                                count += 3;
                            }
                        }
                        // Decide what gender needed for next generation

                        if ((DnaStrand3[3] == 'A' && DnaStrand3[6] == 'A') || (DnaStrand3[3] == 'A' && DnaStrand3[6] == 'T') || (DnaStrand3[3] == 'T' && DnaStrand3[6] == 'A') || (DnaStrand3[3] == 'A' && DnaStrand3[6] == 'T'))
                        {
                            Gender = 'm';

                        }
                        else
                        {
                            Gender = 'f';
                        }
                        //------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

                        //-------------------------------------------------------------------------------------------------------------------------------------------------------
                        //-------------------------------------------------------------------------------------------------------------------------------------------------------
                        //-------------------------------------------------------------------------------------------------------------------------------------------------------
                        // Operation 3 for next generation
                        {


                            Random random = new Random();

                            int gene_number = random.Next(1, 7);
                            int randnumber = random.Next(1, 5);

                            char firstN = 'N';
                            char secondN = 'N';

                            char[] Strand = new char[400];
                            Strand[0] = 'A'; Strand[1] = 'T'; Strand[2] = 'G';

                            if (Gender == 'f')
                            {
                                if (randnumber == 1)
                                {
                                    Strand[3] = 'A'; Strand[4] = 'A'; Strand[5] = 'A';
                                    Strand[6] = 'A'; Strand[7] = 'A'; Strand[8] = 'A';
                                }
                                else if (randnumber == 2)
                                {
                                    Strand[3] = 'A'; Strand[4] = 'A'; Strand[5] = 'A';
                                    Strand[6] = 'T'; Strand[7] = 'T'; Strand[8] = 'T';
                                }
                                else if (randnumber == 3)
                                {
                                    Strand[3] = 'T'; Strand[4] = 'T'; Strand[5] = 'T';
                                    Strand[6] = 'T'; Strand[7] = 'T'; Strand[8] = 'T';
                                }
                                else if (randnumber == 4)
                                {
                                    Strand[3] = 'T'; Strand[4] = 'T'; Strand[5] = 'T';
                                    Strand[6] = 'A'; Strand[7] = 'A'; Strand[8] = 'A';
                                }
                            }
                            else if (Gender == 'm')
                            {
                                randnumber = random.Next(1, 9);

                                if (randnumber == 1)
                                {
                                    Strand[3] = 'A'; Strand[4] = 'A'; Strand[5] = 'A';
                                    Strand[6] = 'G'; Strand[7] = 'G'; Strand[8] = 'G';
                                }
                                else if (randnumber == 2)
                                {
                                    Strand[3] = 'A'; Strand[4] = 'A'; Strand[5] = 'A';
                                    Strand[6] = 'C'; Strand[7] = 'C'; Strand[8] = 'C';
                                }
                                else if (randnumber == 3)
                                {
                                    Strand[3] = 'T'; Strand[4] = 'T'; Strand[5] = 'T';
                                    Strand[6] = 'G'; Strand[7] = 'G'; Strand[8] = 'G';
                                }
                                else if (randnumber == 4)
                                {
                                    Strand[3] = 'T'; Strand[4] = 'T'; Strand[5] = 'T';
                                    Strand[6] = 'C'; Strand[7] = 'C'; Strand[8] = 'C';
                                }
                                else if (randnumber == 5)
                                {
                                    Strand[3] = 'G'; Strand[4] = 'G'; Strand[5] = 'G';
                                    Strand[6] = 'T'; Strand[7] = 'T'; Strand[8] = 'T';
                                }
                                else if (randnumber == 6)
                                {
                                    Strand[3] = 'G'; Strand[4] = 'G'; Strand[5] = 'G';
                                    Strand[6] = 'A'; Strand[7] = 'A'; Strand[8] = 'A';
                                }
                                else if (randnumber == 7)
                                {
                                    Strand[3] = 'C'; Strand[4] = 'C'; Strand[5] = 'C';
                                    Strand[6] = 'T'; Strand[7] = 'T'; Strand[8] = 'T';
                                }
                                else if (randnumber == 8)
                                {
                                    Strand[3] = 'C'; Strand[4] = 'C'; Strand[5] = 'C';
                                    Strand[6] = 'A'; Strand[7] = 'A'; Strand[8] = 'A';
                                }
                            }
                            Strand[9] = 'T'; Strand[10] = 'A'; Strand[11] = 'G';

                            int codon_number;

                            for (int i = 1; i <= gene_number; i++)
                            {
                                codon_number = random.Next(3, 9);

                                Strand[lastpoint] = 'A'; Strand[lastpoint + 1] = 'T'; Strand[lastpoint + 2] = 'G';
                                lastpoint += 3;


                                for (int j = 0; j < (codon_number - 2); j++)
                                {


                                    randnumber = random.Next(1, 5);
                                    if (randnumber == 1)
                                    {
                                        Strand[lastpoint] = 'A';
                                        firstN = 'A';
                                    }
                                    else if (randnumber == 2)
                                    {
                                        Strand[lastpoint] = 'T';
                                        firstN = 'T';


                                    }
                                    else if (randnumber == 3)
                                    {
                                        Strand[lastpoint] = 'G';
                                        firstN = 'G';

                                    }
                                    else if (randnumber == 4)
                                    {
                                        Strand[lastpoint] = 'C';
                                        firstN = 'C';

                                    }
                                    lastpoint += 1;
                                    randnumber = random.Next(1, 5);
                                    if (randnumber == 1)
                                    {
                                        Strand[lastpoint] = 'A';
                                        secondN = 'A';
                                    }
                                    else if (randnumber == 2)
                                    {
                                        Strand[lastpoint] = 'T';
                                        secondN = 'T';


                                    }
                                    else if (randnumber == 3)
                                    {
                                        Strand[lastpoint] = 'G';
                                        secondN = 'G';

                                    }
                                    else if (randnumber == 4)
                                    {
                                        Strand[lastpoint] = 'C';
                                        secondN = 'C';
                                    }
                                    lastpoint += 1;

                                    if (firstN == 'A' && secondN == 'T')
                                    {
                                        randnumber = random.Next(1, 4);
                                        if (randnumber == 1)
                                        {
                                            Strand[lastpoint] = 'A';
                                        }
                                        else if (randnumber == 2)
                                        {
                                            Strand[lastpoint] = 'T';
                                        }
                                        else if (randnumber == 3)
                                        {
                                            Strand[lastpoint] = 'C';
                                        }
                                        lastpoint += 1;

                                    }
                                    else if (firstN == 'T' && secondN == 'A')
                                    {
                                        randnumber = random.Next(1, 3);
                                        if (randnumber == 1)
                                        {
                                            Strand[lastpoint] = 'T';
                                        }
                                        else if (randnumber == 2)
                                        {
                                            Strand[lastpoint] = 'C';
                                        }
                                        lastpoint += 1;
                                    }
                                    else if (firstN == 'T' && secondN == 'G')
                                    {
                                        randnumber = random.Next(1, 4);
                                        if (randnumber == 1)
                                        {
                                            Strand[lastpoint] = 'G';
                                        }
                                        else if (randnumber == 2)
                                        {
                                            Strand[lastpoint] = 'T';
                                        }
                                        else if (randnumber == 3)
                                        {
                                            Strand[lastpoint] = 'C';
                                        }
                                        lastpoint += 1;
                                    }
                                    else
                                    {
                                        randnumber = random.Next(1, 5);
                                        if (randnumber == 1)
                                        {
                                            Strand[lastpoint] = 'A';
                                        }
                                        else if (randnumber == 2)
                                        {
                                            Strand[lastpoint] = 'T';
                                        }
                                        else if (randnumber == 3)
                                        {
                                            Strand[lastpoint] = 'G';
                                        }
                                        else if (randnumber == 4)
                                        {
                                            Strand[lastpoint] = 'C';

                                        }
                                        lastpoint += 1;
                                    }
                                }

                                randnumber = random.Next(1, 4);
                                if (randnumber == 1)
                                {
                                    Strand[lastpoint] = 'T'; Strand[lastpoint + 1] = 'A'; Strand[lastpoint + 2] = 'A';
                                }
                                else if (randnumber == 2)
                                {
                                    Strand[lastpoint] = 'T'; Strand[lastpoint + 1] = 'A'; Strand[lastpoint + 2] = 'G';
                                }
                                else if (randnumber == 3)
                                {
                                    Strand[lastpoint] = 'T'; Strand[lastpoint + 1] = 'G'; Strand[lastpoint + 2] = 'A';
                                }

                                lastpoint += 3;


                            }
                            for (int j = 0; j < Strand.Length; j++)
                            {
                                DnaStrand2[j] = Strand[j];
                            }

                        }

                        //-------------------------------------------------------------------------------------------------------------------------------------------------------
                        //-------------------------------------------------------------------------------------------------------------------------------------------------------
                        //-------------------------------------------------------------------------------------------------------------------------------------------------------

                        // Determine which codons are faulty
                        // if 3 or more consecutive codons contain just G or C nukleotide then that codons became faulty
                        double ratio = ((faultycodons-allfaulty) / Dna3Len) * 100;

                        Console.WriteLine("\nBLOB3 faulty codons ratio {0}/{1}  = {2}\n ", faultycodons / 3, Dna3Len / 3, ratio);

                        if (((faultycodons) / Dna3Len) > (1 / 10))
                        {
                            Console.WriteLine("\nNewborn dies. Generations are over.");
                            Generation = 11;
                        }
                        else
                        {
                            for (int i = 0; i < DnaStrand3.Length; i++)
                            {
                                DnaStrand1[i] = DnaStrand3[i];

                            }
                        }
                    }
                    Console.ReadLine();
                    Console.Clear();
                }
                else if (input == 18)
                {
                    exit = true;
                }

            }
        }
    }
}

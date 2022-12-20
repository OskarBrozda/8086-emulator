using System;
using static System.Net.Mime.MediaTypeNames;

namespace e8086
{
    class Emulator

    {
        public static void Main(String[] args)
        {
            

            //przywitanie
            Console.WriteLine("Welcome to Intel 8086 simple emulator!");

        start:
            Console.WriteLine("Please select an option: \n set, \n move, \n add, \n substring, \n clear, \n print. \n");
            Console.Write("Your select: ");

            string choice = Console.ReadLine();

            Background Y = new Background();
            if (choice.Contains("set")) Y.Set();
            else if (choice.Contains("mov")) Y.Mov();
            else if (choice.Contains("add")) Y.Add();
            else if (choice.Contains("sub")) Y.Substring();
            else if (choice.Contains("clear")) Y.Clear();
            else if (choice.Contains("print")) Y.Print();
            else Console.WriteLine("Select an correct option.");

            Console.WriteLine("\n \n");            
            goto start;
        }
    }

    
    class Background
    {

        static string AX_h = "0";
        static string BX_h = "0";
        static string CX_h = "0";
        static string DX_h = "0";
        static string AH = "0";
        static string BH = "0";
        static string CH = "0";
        static string DH = "0";
        static string AL = "0";
        static string BL = "0";
        static string CL = "0";
        static string DL = "0";

        

        public void Set()
        {
        O1:
            Console.Write("Select register: 16bit or 8bit. ");
            string a = Console.ReadLine();

            if (a.Contains("16"))
            {
            O11:
                Console.Write("Select record: AX, BX, CX, DX: ");
                string b = Console.ReadLine();
                string value;
                do
                {
                    Console.Write("Enter hex value: ");
                    value = Console.ReadLine();
                    if (!value.All("0123456789abcdefABCDEF".Contains) || value.Length > 4)
                    {
                        Console.WriteLine("Error. That is not hex value for 16 bit register!");
                    }
                } while (!value.All("0123456789abcdefABCDEF".Contains) || value.Length > 4);

                if (b.Contains("ax")) AX_h = value;
                else if (b.Contains("bx")) BX_h = value; 
                else if (b.Contains("cx")) CX_h = value;
                else if (b.Contains("dx")) DX_h = value;
                else
                {
                    Console.WriteLine("The correct register has not been selected.");
                    goto O11;
                }
                Add0_16();
                Update8bit();
                

            }
            else if (a.Contains("8"))
            {
            O12:
                Console.Write("Select record: AH, AL, BH, BL, CH, CL, DH, DL: ");
                string b = Console.ReadLine();
                string value;
                do
                {
                    Console.Write("Enter hex value: ");
                    value = Console.ReadLine();
                    if (!value.All("0123456789abcdefABCDEF".Contains) || value.Length > 2)
                    {
                        Console.WriteLine("Error. That is not hex value for 8 bit register!");
                    }
                } while (!value.All("0123456789abcdefABCDEF".Contains) || value.Length > 2);

                if      (b.Contains("ah")) AH = value;
                else if (b.Contains("al")) AL = value;
                else if (b.Contains("bh")) BH = value;
                else if (b.Contains("bl")) BL = value;
                else if (b.Contains("ch")) CH = value; 
                else if (b.Contains("cl")) CL = value;
                else if (b.Contains("dh")) DH = value;
                else if (b.Contains("dl")) DL = value;
                else
                {
                    Console.WriteLine("The correct register has not been selected.");
                    goto O12;
                }
                Add0_8();
                Update16bit();
                
                
            }
            else
            {
                Console.WriteLine("The correct register has not been selected.");
                goto O1;
            }
        }


        public void Mov()
        {
        O2:
            Console.Write("Select register: 16bit or 8bit. ");
            string a = Console.ReadLine();

            if (a.Contains("16"))
            {
            O21:
                Console.Write("Select firs record (FROM): AX, BX, CX, DX: ");
                string b = Console.ReadLine();
                Console.Write("Select second record (TO): AX, BX, CX, DX: ");
                string c = Console.ReadLine();

                if (b.Contains("ax"))
                {
                    if (c.Contains("ax")) { Console.WriteLine("Cannot move to the same register."); goto O21; }
                    else if (c.Contains("bx")) BX_h = AX_h;
                    else if (c.Contains("cx")) CX_h = AX_h;
                    else if (c.Contains("dx")) DX_h = AX_h;
                }
                else if (b.Contains("bx"))
                {
                    if (c.Contains("ax")) AX_h = BX_h;
                    else if (c.Contains("bx")) { Console.WriteLine("Cannot move to the same register."); goto O21; }
                    else if (c.Contains("cx")) CX_h = BX_h;
                    else if (c.Contains("dx")) DX_h = BX_h;
                }
                else if (b.Contains("cx"))
                {
                    if (c.Contains("ax")) AX_h = CX_h;
                    else if (c.Contains("bx")) BX_h = CX_h;
                    else if (c.Contains("cx")) { Console.WriteLine("Cannot move to the same register."); goto O21; }
                    else if (c.Contains("dx")) DX_h = CX_h;
                }
                else if (b.Contains("dx"))
                {
                    if (c.Contains("ax")) AX_h = DX_h;
                    else if (c.Contains("bx")) BX_h = DX_h;
                    else if (c.Contains("cx")) CX_h = DX_h;
                    else if (c.Contains("dx")) { Console.WriteLine("Cannot move to the same register."); goto O21; }
                }
                else
                {
                    Console.WriteLine("The correct register has not been selected.");
                    goto O21;
                }
                Add0_16();
                Update8bit();
            }
            else if (a.Contains("8"))
            {
            O22:
                Console.Write("Select firs record (FROM): AH, AL, BH, BL, CH, CL, DH, DL: ");
                string b = Console.ReadLine();
                Console.Write("Select second record (TO): AH, AL, BH, BL, CH, CL, DH, DL: ");
                string c = Console.ReadLine();

                if (b.Contains("ah"))
                {
                    if (c.Contains("ah")) { Console.WriteLine("Cannot move to the same register."); goto O22; }
                    else if (c.Contains("al")) AL = AH;
                    else if (c.Contains("bh")) BH = AH;
                    else if (c.Contains("bl")) BL = AH;
                    else if (c.Contains("ch")) CH = AH;
                    else if (c.Contains("cl")) CL = AH;
                    else if (c.Contains("dh")) DH = AH;
                    else if (c.Contains("dl")) DL = AH;
                }
                else if (b.Contains("al"))
                {
                    if (c.Contains("ah")) AH = AL;
                    else if (c.Contains("al")) { Console.WriteLine("Cannot move to the same register."); goto O22; }
                    else if (c.Contains("bh")) BH = AL;
                    else if (c.Contains("bl")) BL = AL;
                    else if (c.Contains("ch")) CH = AL;
                    else if (c.Contains("cl")) CL = AL;
                    else if (c.Contains("dh")) DH = AL;
                    else if (c.Contains("dl")) DL = AL;
                }
                else if (b.Contains("bh"))
                {
                    if (c.Contains("ah")) AH = BH;
                    else if (c.Contains("al")) AL = BH;
                    else if (c.Contains("bh")) { Console.WriteLine("Cannot move to the same register."); goto O22; }
                    else if (c.Contains("bl")) BL = BH;
                    else if (c.Contains("ch")) CH = BH;
                    else if (c.Contains("cl")) CL = BH;
                    else if (c.Contains("dh")) DH = BH;
                    else if (c.Contains("dl")) DL = BH;
                }
                else if (b.Contains("bl"))
                {
                    if (c.Contains("ah")) AH = BL;
                    else if (c.Contains("al")) AL = BL;
                    else if (c.Contains("bh")) BH = BL;
                    else if (c.Contains("bl")) { Console.WriteLine("Cannot move to the same register."); goto O22; }
                    else if (c.Contains("ch")) CH = BL;
                    else if (c.Contains("cl")) CL = BL;
                    else if (c.Contains("dh")) DH = BL;
                    else if (c.Contains("dl")) DL = BL;
                }
                else if (b.Contains("ch"))
                {
                    if (c.Contains("ah")) AH = CH;
                    else if (c.Contains("al")) AL = CH;
                    else if (c.Contains("bh")) BH = CH;
                    else if (c.Contains("bl")) BL = CH;
                    else if (c.Contains("ch")) { Console.WriteLine("Cannot move to the same register."); goto O22; }
                    else if (c.Contains("cl")) CL = CH;
                    else if (c.Contains("dh")) DH = CH;
                    else if (c.Contains("dl")) DL = CH;
                }
                else if (b.Contains("cl"))
                {
                    if (c.Contains("ah")) AH = CL;
                    else if (c.Contains("al")) AL = CL;
                    else if (c.Contains("bh")) BH = CL;
                    else if (c.Contains("bl")) BL = CL;
                    else if (c.Contains("ch")) CH = CL;
                    else if (c.Contains("cl")) { Console.WriteLine("Cannot move to the same register."); goto O22; }
                    else if (c.Contains("dh")) DH = CL;
                    else if (c.Contains("dl")) DL = CL;
                }
                else if (b.Contains("dh"))
                {
                    if (c.Contains("ah")) AH = DH;
                    else if (c.Contains("al")) AL = DH;
                    else if (c.Contains("bh")) BH = DH;
                    else if (c.Contains("bl")) BL = DH;
                    else if (c.Contains("ch")) CH = DH;
                    else if (c.Contains("cl")) CL = DH;
                    else if (c.Contains("dh")) { Console.WriteLine("Cannot move to the same register."); goto O22; }
                    else if (c.Contains("dl")) DL = DH;
                }
                else if (b.Contains("dl"))
                {
                    if (c.Contains("ah")) AH = DL;
                    else if (c.Contains("al")) AL = DL;
                    else if (c.Contains("bh")) BH = DL;
                    else if (c.Contains("bl")) BL = DL;
                    else if (c.Contains("ch")) CH = DL;
                    else if (c.Contains("cl")) CL = DL;
                    else if (c.Contains("dh")) DH = DL;
                    else if (c.Contains("dl")) { Console.WriteLine("Cannot move to the same register."); goto O22; }
                }
                else
                {
                    Console.WriteLine("The correct register has not been selected.");
                    goto O22;
                }
                Add0_8();
                Update16bit();   
            }           
        }


        public void Add()
        {
        O3:
            Console.Write("Select register: 16bit or 8bit. ");
            string a = Console.ReadLine();

            if (a.Contains("16"))
            {
            O31:
                Console.Write("Select record: AX, BX, CX, DX: ");
                string b = Console.ReadLine();
                string value;
                do
                {
                    Console.Write("Enter hex value: ");
                    value = Console.ReadLine();
                    if (!value.All("0123456789abcdefABCDEF".Contains) || value.Length > 4)
                    {
                        Console.WriteLine("Error. That is not hex value for 16 bit register!");
                    }
                } while (!value.All("0123456789abcdefABCDEF".Contains) || value.Length > 4);

                if (b.Contains("ax")) AX_h = Hex_sum(AX_h, value);//((int.Parse(AX_h) + int.Parse(value)).ToString());
                else if (b.Contains("bx")) BX_h = Hex_sum(BX_h, value);
                else if (b.Contains("cx")) CX_h = Hex_sum(CX_h, value);
                else if (b.Contains("dx")) DX_h = Hex_sum(DX_h, value);
                else
                {
                    Console.WriteLine("The correct register has not been selected.");
                    goto O31;
                }
                Console.WriteLine(AX_h);
                Add0_16();
                Update8bit();
            }
            else if (a.Contains("8"))
            {
            O32:
                Console.Write("Select record: AH, AL, BH, BL, CH, CL, DH, DL: ");
                string b = Console.ReadLine();
                string value;
                do
                {
                    Console.Write("Enter hex value: ");
                    value = Console.ReadLine();
                    if (!value.All("0123456789abcdefABCDEF".Contains) || value.Length > 2)
                    {
                        Console.WriteLine("Error. That is not hex value for 8 bit register!");
                    }
                } while (!value.All("0123456789abcdefABCDEF".Contains) || value.Length > 2);

                if (b.Contains("ah")) AH = Hex_sum(AH, value);
                else if (b.Contains("al")) AL = Hex_sum(AL, value);
                else if (b.Contains("bh")) BH = Hex_sum(BH, value);
                else if (b.Contains("bl")) BL = Hex_sum(BL, value);
                else if (b.Contains("ch")) CH = Hex_sum(CH, value);
                else if (b.Contains("cl")) CL = Hex_sum(CL, value);
                else if (b.Contains("dh")) DH = Hex_sum(DH, value);
                else if (b.Contains("dl")) DL = Hex_sum(DL, value);
                else
                {
                    Console.WriteLine("The correct register has not been selected.");
                    goto O32;
                }
                Add0_8();
                Update16bit();
            }
            else
            {
                Console.WriteLine("The correct register has not been selected.");
                goto O3;
            }
        }


        public void Substring()
        {
        O4:
            Console.Write("Select register: 16bit or 8bit. ");
            string a = Console.ReadLine();

            if (a.Contains("16"))
            {
            O41:
                Console.Write("Select record: AX, BX, CX, DX: ");
                string b = Console.ReadLine();
                string value;
                do
                {
                    Console.Write("Enter hex value: ");
                    value = Console.ReadLine();
                    if (!value.All("0123456789abcdefABCDEF".Contains) || value.Length > 4)
                    {
                        Console.WriteLine("Error. That is not hex value for 16 bit register!");
                    }
                } while (!value.All("0123456789abcdefABCDEF".Contains) || value.Length > 4);

                if (b.Contains("ax")) AX_h = Hex_minus(AX_h, value);//((int.Parse(AX_h) + int.Parse(value)).ToString());
                else if (b.Contains("bx")) BX_h = Hex_minus(BX_h, value);
                else if (b.Contains("cx")) CX_h = Hex_minus(CX_h, value);
                else if (b.Contains("dx")) DX_h = Hex_minus(DX_h, value);
                else
                {
                    Console.WriteLine("The correct register has not been selected.");
                    goto O41;
                }
                Console.WriteLine(AX_h);
                Add0_16();
                Update8bit();
            }
            else if (a.Contains("8"))
            {
            O42:
                Console.Write("Select record: AH, AL, BH, BL, CH, CL, DH, DL: ");
                string b = Console.ReadLine();
                string value;
                do
                {
                    Console.Write("Enter hex value: ");
                    value = Console.ReadLine();
                    if (!value.All("0123456789abcdefABCDEF".Contains) || value.Length > 2)
                    {
                        Console.WriteLine("Error. That is not hex value for 8 bit register!");
                    }
                } while (!value.All("0123456789abcdefABCDEF".Contains) || value.Length > 2);

                if (b.Contains("ah")) AH = Hex_minus(AH, value);
                else if (b.Contains("al")) AL = Hex_minus(AL, value);
                else if (b.Contains("bh")) BH = Hex_minus(BH, value);
                else if (b.Contains("bl")) BL = Hex_minus(BL, value);
                else if (b.Contains("ch")) CH = Hex_minus(CH, value);
                else if (b.Contains("cl")) CL = Hex_minus(CL, value);
                else if (b.Contains("dh")) DH = Hex_minus(DH, value);
                else if (b.Contains("dl")) DL = Hex_minus(DL, value);
                else
                {
                    Console.WriteLine("The correct register has not been selected.");
                    goto O42;
                }
                Add0_8();
                Update16bit();
            }
            else
            {
                Console.WriteLine("The correct register has not been selected.");
                goto O4;
            }
        }


        public void Clear()
        {
            AX_h = "0";
            BX_h = "0";
            CX_h = "0";
            DX_h = "0";
            AH = "0";
            BH = "0";
            CH = "0";
            DH = "0";
            AL = "0";
            BL = "0";
            CL = "0";
            DL = "0";
        }


        public void Print()
        {
            string AX_d = Add0_16_dec(Convert.ToInt32(AX_h, 16).ToString());
            string BX_d = Add0_16_dec(Convert.ToInt32(BX_h, 16).ToString());
            string CX_d = Add0_16_dec(Convert.ToInt32(CX_h, 16).ToString());
            string DX_d = Add0_16_dec(Convert.ToInt32(DX_h, 16).ToString());
            Add0_8();
            Add0_16();
            
            Console.WriteLine($@"       16 bit                8 bit
AX: {AX_d}    {AX_h}      AH: {AH}   AL: {AL}
BX: {BX_d}    {BX_h}      BH: {BH}   BL: {BL}
CX: {CX_d}    {CX_h}      CH: {CH}   CL: {CL}
DX: {DX_d}    {DX_h}      DH: {DH}   DL: {DL}");
        }



        //funkcje uzupełniające
        public void Add0_16()  //dodajemy zera 16-bit (4 miejsca)
        {
            while (AX_h.Length + BX_h.Length + CX_h.Length + DX_h.Length < 16)
            {
                while (AX_h.Length < 4) AX_h = "0" + AX_h;
                while (BX_h.Length < 4) BX_h = "0" + BX_h;
                while (CX_h.Length < 4) CX_h = "0" + CX_h;
                while (DX_h.Length < 4) DX_h = "0" + DX_h;
            }
        }


        public string Add0_16_dec(string number)  // dodajemy zera 16-bit do liczb dziesiętnych (5 miejsc)
        {
            while (number.Length < 5) number = "0" + number;
            return number;
        }


        public void Add0_8() //dodajemy zera 8-bit (2 miejsca)
        {
            while (AH.Length + AL.Length + BH.Length + BL.Length + CH.Length + CL.Length+ DH.Length + DL.Length < 16)
            {
                while (AH.Length < 2) AH = "0" + AH;
                while (AL.Length < 2) AL = "0" + AL;
                while (BH.Length < 2) BH = "0" + BH;
                while (BL.Length < 2) BL = "0" + BL;
                while (CH.Length < 2) CH = "0" + CH;
                while (CL.Length < 2) CL = "0" + CL;
                while (DH.Length < 2) DH = "0" + DH;
                while (DL.Length < 2) DL = "0" + DL;
            }

        }


        public void Update16bit() // aktualizujemy rejestr 16 bitowy
        {
            AX_h = AH + AL;
            BX_h = BH + BL;
            CX_h = CH + CL;
            DX_h = DH + DL;            
        } 


        public void Update8bit() // aktualizujemy rejestr 8 bitowy
        {
            AH = AX_h.Substring(0, 2);
            AL = AX_h.Substring(2, 2);

            BH = BX_h.Substring(0, 2);
            BL = BX_h.Substring(2, 2);

            CH = CX_h.Substring(0, 2);
            CL = CX_h.Substring(2, 2);

            DH = DX_h.Substring(0, 2);
            DL = DX_h.Substring(2, 2);            
        }


        public string Hex_sum(string a, string b) //dodaje 2 liczby hexadecymalne
        {


            string k = "";
            return k;
        }

        public string Hex_minus(string a, string b) //odejmuje 2 liczby hexadecymalne
        {


            string k = "";
            return k;
        }
    }
}
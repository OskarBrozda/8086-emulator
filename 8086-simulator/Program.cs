using System;
using static System.Net.Mime.MediaTypeNames;

namespace e8086
{
    class Emulator

    {
        public static void Main(String[] args)
        {
            string AX_h = "0000";
            string BX_h = "0000";
            string CX_h = "0000";
            string DX_h = "0000";
            string AH = "00";
            string BH = "00";
            string CH = "00";
            string DH = "00";
            string AL = "00";
            string BL = "00";
            string CL = "00";
            string DL = "00";

            //przywitanie
            Console.WriteLine("Welcome to Intel 8086 simple emulator!");

        start:
            Console.WriteLine("Please select an option: \n set \n move \n clear \n print \n");
            Console.Write("Your select: ");

            string choice = Console.ReadLine();
            Console.WriteLine();

            string lower = choice.ToLower();
            if (lower == "set")
            {
            O1:
                Console.Write("Select register: 16bit or 8bit. ");
                string a = Console.ReadLine();
            
                if (a == "16" || a == "16bit" || a == "16 bit")
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

                    if (b == "ax" || b == "AX") AX_h = value;
                    else if (b == "bx" || b == "BX") BX_h = value;
                    else if (b == "cx" || b == "CX") CX_h = value;
                    else if (b == "dx" || b == "DX") DX_h = value;
                    else
                    {
                        Console.WriteLine("The correct register has not been selected.");
                        goto O11;
                    }
                    //Update8bit(ref AX_h, ref BX_h, ref CX_h, ref DX_h, ref AH, ref AL, ref BH, ref BL, ref CH, ref CL, ref DH, ref DL);
                }
                else if (a == "8" || a == "8bit" || a == "8 bit")
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
                            Console.WriteLine("Error. That is not hex value for 8bit register!");
                        }
                    } while (!value.All("0123456789abcdefABCDEF".Contains) || value.Length > 4);

                    if (b == "ah" || b == "AH") AH = value;
                    else if (b == "al" || b == "AL") AL = value;
                    else if (b == "bh" || b == "BH") BH = value;
                    else if (b == "bl" || b == "BL") BL = value;
                    else if (b == "ch" || b == "CH") CH = value;
                    else if (b == "cl" || b == "CL") CL = value;
                    else if (b == "dh" || b == "DH") DH = value;
                    else if (b == "dl" || b == "DL") DL = value;
                    else
                    {
                        Console.WriteLine("The correct register has not been selected.");
                        goto O12;
                    }
                    Update16bit(ref AX_h, ref BX_h, ref CX_h, ref DX_h, ref AH, ref BH, ref CH, ref DH, ref AL, ref BL,  ref CL, ref DL);

                }
                else
                {
                    Console.WriteLine("The correct register has not been selected.");
                    goto O1;
                }
            }
            else if (lower == "mov")
            {
            O2:
                Console.Write("Select register: 16bit or 8bit. ");
                string a = Console.ReadLine();
            
                if (a == "16" || a == "16bit" || a == "16 bit")
                {

                }
                else if (a == "8" || a == "8bit" || a == "8 bit")
                {

                }
                else
                {
                    Console.WriteLine("The correct register has not been selected.");
                    goto O2;
                }
            }
            else if (lower == "clear")
            {
                AX_h = "0000";
                BX_h = "0000";
                CX_h = "0000";
                DX_h = "0000";
                AH = "00";
                BH = "00";
                CH = "00";
                DH = "00";
                AL = "00";
                BL = "00";
                CL = "00";
                DL = "00";
            }
            else if (lower == "print")
            {
                string AX_d = Add0_16(Convert.ToInt32(AX_h, 16).ToString());
                string BX_d = Add0_16(Convert.ToInt32(BX_h, 16).ToString());
                string CX_d = Add0_16(Convert.ToInt32(CX_h, 16).ToString());
                string DX_d = Add0_16(Convert.ToInt32(DX_h, 16).ToString());
                AX_h = Add0_16(AX_h);
                BX_h = Add0_16(BX_h);
                CX_h = Add0_16(CX_h);
                DX_h = Add0_16(DX_h);
                AH = Add0_8(AH);
                BH = Add0_8(BH);
                CH = Add0_8(CH);
                DH = Add0_8(DH);
                AL = Add0_8(AL);
                BL = Add0_8(BL);
                CL = Add0_8(CL);
                DL = Add0_8(DL);

                Console.WriteLine($@"       16 bit               8 bit
AX: {AX_d}    {AX_h}      AH: {AH}   AL: {AL}
BX: {BX_d}    {BX_h}      BH: {BH}   BL: {BL}
CX: {CX_d}    {CX_h}      CH: {CH}   CL: {CL}
DX: {DX_d}    {DX_h}      DH: {DH}   DL: {DL}");
            }
            else Console.WriteLine("The correct option has not been selected.");

            Console.WriteLine("\n\n");
            goto start;

        }
        public static string Add0_16(string number)  //dodajemy zera 16-bit
        {
            while (number.Length < 4) number = "0" + number;
            return number;
        }
        public static string Add0_8(string number) //dodajemy zera 8-bit
        {
            while (number.Length < 2) number = "0" + number;
            return number;
        }
        public static void Update16bit(
            ref string AX_h,
            ref string BX_h,
            ref string CX_h,
            ref string DX_h,
            ref string AH,
            ref string BH,
            ref string CH,
            ref string DH,
            ref string AL,
            ref string BL,
            ref string CL,
            ref string DL)
        {

            AX_h = AL + AH;
            BX_h = BL + BH;
            CX_h = CL + CH;
            DX_h = DL + DH;

            //AL = AX_h.Substring(2, 2);
            //AH = AX_h.Substring(0, 2);

            //BL = BX_h.Substring(2, 2);
            //BH = BX_h.Substring(0, 2);

            //CL = CX_h.Substring(2, 2);
            //CH = CX_h.Substring(0, 2);

            //DL = DX_h.Substring(2, 2);
            //DH = DX_h.Substring(0, 2);
        }

    }
}
    //        public static void Print(string AX_h, string BX_h, string CX_h, string DX_h, string AH, string BH, string CH, string DH, string AL, string BL, string CL, string DL)
    //        {   
    //            string AX_d = Add0_16(Convert.ToInt32(AX_h, 16).ToString());
    //            string BX_d = Add0_16(Convert.ToInt32(BX_h, 16).ToString());
    //            string CX_d = Add0_16(Convert.ToInt32(CX_h, 16).ToString());
    //            string DX_d = Add0_16(Convert.ToInt32(DX_h, 16).ToString());
    //            AX_h = Add0_16(AX_h);
    //            BX_h = Add0_16(BX_h);
    //            CX_h = Add0_16(CX_h);
    //            DX_h = Add0_16(DX_h);
    //            AH = Add0_8(AH);
    //            BH = Add0_8(BH);
    //            CH = Add0_8(CH);
    //            DH = Add0_8(DH);
    //            AL = Add0_8(AL);
    //            BL = Add0_8(BL);
    //            CL = Add0_8(CL);
    //            DL = Add0_8(DL);

    //            Console.WriteLine($@"       16 bit               8 bit
    //AX: {AX_d}    {AX_h}      AH: {AH}   AL: {AL}
    //BX: {BX_d}    {BX_h}      BH: {BH}   AL: {BL}
    //CX: {CX_d}    {CX_h}      CH: {CH}   AL: {CL}
    //DX: {DX_d}    {DX_h}      DH: {DH}   AL: {DL}");

    //        }

    //        public static void Clear()
    //        {
    //            string AX_h = "0000";
    //            string BX_h = "0000";
    //            string CX_h = "0000";
    //            string DX_h = "0000";
    //            string AH = "00";
    //            string BH = "00";
    //            string CH = "00";
    //            string DH = "00";
    //            string AL = "00";
    //            string BL = "00";
    //            string CL = "00";
    //            string DL = "00";

    //            //Print(AX_h, BX_h, CX_h, DX_h, AH, BH, CH, DH, AL, BL, CL, DL);
    //        }




    //        public static void Option(string choice)
    //        {

    //            string lower = choice.ToLower();
    //            if(lower == "set")
    //            {
    //                Console.Write("Select register: 16bit or 8bit. ");
    //                string a = Console.ReadLine();
    //;               O1:
    //                if (a == "16" || a == "16bit" || a == "16 bit")
    //                {

    //                }
    //                else if (a == "8" || a == "8bit" || a == "8 bit")
    //                {

    //                }                
    //                else 
    //                {
    //                    Console.WriteLine("The correct register has not been selected.");
    //                    goto O1;
    //                }
    //            }
    //            else if(lower == "mov")
    //            {
    //                Console.Write("Select register: 16bit or 8bit. ");
    //                string a = Console.ReadLine();
    //                O1:
    //                if (a == "16" || a == "16bit" || a == "16 bit")
    //                {

    //                }
    //                else if (a == "8" || a == "8bit" || a == "8 bit")
    //                {

    //                }
    //                else
    //                {
    //                    Console.WriteLine("The correct register has not been selected.");
    //                    goto O1;
    //                }
    //            }          
    //            else if (lower == "clear")
    //            {
    //                Clear();
    //            }
    //            else if (lower == "print")
    //            {
    //                Print(AX_h, BX_h, CX_h, DX_h, AH, BH, CH, DH, AL, BL, CL, DL);
    //            }
    //            else Console.WriteLine("The correct option has not been selected.");   
    //        }

    //    }



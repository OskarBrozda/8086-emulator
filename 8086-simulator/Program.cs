using System;

namespace e8086
{
    class Emulator

    {                       
        public static void Main(String[] args)
        {
            string AX_h, BX_h, CX_h, DX_h, AH, BH, CH, DH, AL, BL, CL, DL;

            //przywitanie
            Console.WriteLine("Welcome to Intel 8086 simple emulator!");

            start:
                Console.WriteLine("Please select an option: \n set \n add \n substract \n clear \n print \n");
                Console.Write("Your select: ");
                string choice = Console.ReadLine();
                Console.WriteLine();

                Option(choice);
                Clear();

            int c = 34;
            test(ref c); 
            Console.WriteLine(c);

            Console.WriteLine();
            goto start;
                
            

        }

        
        public static void Print(string AX_h, string BX_h, string CX_h, string DX_h, string AH, string BH, string CH, string DH, string AL, string BL, string CL, string DL)
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
BX: {BX_d}    {BX_h}      BH: {BH}   AL: {BL}
CX: {CX_d}    {CX_h}      CH: {CH}   AL: {CL}
DX: {DX_d}    {DX_h}      DH: {DH}   AL: {DL}");
            
        }

        public static void Clear()
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

            Print(AX_h, BX_h, CX_h, DX_h, "2", BH, CH, DH, AL, BL, CL, DL);
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

        public static void Option(string choice)
        {
            
            
        }

        public static void test(ref int a)
        {
            a += 2;
            
        }
        
    }

}
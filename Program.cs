using System;

namespace CGS
{
    class Program
    {
        struct ArtPiece
        {
            public string ArtPieceID;
            public string Title;
            public string ArtistID;
            public int Year;
            public double EstmiateValue;
            public double SalePrice;
            public char Status;
            public double SoldDate;
        }

        struct Curator
        {
            public string CuratorId;
            public string CuratorName;
            public double CommissionEarned;
        }

        struct Artist
        {
            public string ArtistID;
            public string ArtistName;
            public string CuratorID;
        }

        static Curator[] myCurators = new Curator[10];
        static Artist[] myArtist = new Artist[12];
        static ArtPiece[] myArtpice = new ArtPiece[15];

        public static int curatorIndex = 0;
        public static int artistIndex = 0;
        public static int artPieceIndex = 0;

        static void Main(string[] args)
        {


            while (true)
            {
                int num = DisplayMenu();
                switch (num)
                {
                    case 1:
                        addCurator();
                        break;

                    case 2:
                        addArtist();
                        break;

                    case 3:
                        addArtPiece();
                        break;

                    case 4:
                        ListArtist();
                        break;


                    case 5:
                        SellArtPiece();
                        break;

                    case 6:

                        findCurator();
                        break;

                    case 7:

                        FindArtist();
                        break;

                    case 8:

                        findArtPiece();
                        break;

                    case 9:

                        ListCurators();
                        break;

                    case 10:

                        inventoryReport();
                        break;

                    case 11:

                        ReturnArtPiece();
                        break;
                    case 12:

                        ReplaceArtpiece();
                        break;
                }
                Console.WriteLine("===============================================================\n");


            }

        }


        public static int DisplayMenu()
        {

            Console.WriteLine("Select from the following menu");
            Console.WriteLine("Add Curator = 1");
            Console.WriteLine("Add Artist = 2");
            Console.WriteLine("Add ArtPiece = 3");
            Console.WriteLine("List Artist = 4");
            Console.WriteLine("Sell ArtPiece = 5");
            Console.WriteLine("Find Curator = 6");
            Console.WriteLine("Find Artist = 7");
            Console.WriteLine("Find ArtPiece = 8");
            Console.WriteLine("List Curators = 9");
            Console.WriteLine("Inventory Report = 10");
            Console.WriteLine("Return an ArtPiece = 11");
            Console.WriteLine("Replace an Artpiece = 12");

            int methodNum = Convert.ToInt32(Console.ReadLine());

            return methodNum;

        }

        public static void addCurator()
        {
            Console.WriteLine("Please enter 5 character unique curatorID");

            string ID = Convert.ToString(Console.ReadLine());
            string name = "";
            if (findCuratorId(ID) == false)
            {
                if (ID.Length == 5)
                {
                    Console.WriteLine("Please enter curator name");
                    name = Console.ReadLine();
                    myCurators[curatorIndex].CuratorId = ID;
                    myCurators[curatorIndex].CuratorName = name;
                    myCurators[curatorIndex].CommissionEarned = 0;
                    Console.WriteLine("Curator added successfully");
                    curatorIndex++;
                }
                else
                {
                    Console.WriteLine("ERROR - Id should be 5 character");
                }
            }
            else
            {
                Console.WriteLine("ERROR - Already exist one curator with this ID");
            }


        }
        
       
        public static void addArtist()
        {

            Console.WriteLine("Please enter 5 charcter unique ArtistID");
            string ID = Console.ReadLine();
            string name = "";
            string CuratorId = "";

            if (FindArtistId(ID) == false)
            {



                if (ID.Length == 5)
                {
                    Console.WriteLine("Please enter Artist name");
                    name = Console.ReadLine();

                    ListCurators();

                    Console.WriteLine("Please Enter 5 character curator Id");
                    CuratorId = Console.ReadLine();

                    if (findCuratorId(CuratorId) == true)
                    {
                        if (CuratorId.Length != 5)
                        {
                            Console.WriteLine("ID should be of 5 character");
                        }
                        else
                        {
                            Console.WriteLine("Artist added Successfully");

                            myArtist[artistIndex].ArtistID = ID;
                            myArtist[artistIndex].ArtistName = name;
                            myArtist[artistIndex].CuratorID = CuratorId;
                            artistIndex++;
                        }

                    }

                    else
                    {
                        Console.WriteLine("Curotar does not Exists");
                    }
                }


            }
            //Console.WriteLine("Please Enter 4 character curator Id");
            //CuratorId = Console.ReadLine();



            else
            {
                Console.WriteLine("ERROR - Already exist one Artist with this ID or its not of 5 character");
                Console.WriteLine("Please enter unique ID");

            }

        }

        public static void addArtPiece()

        {
            Console.WriteLine("Please enter your 5 character unique ArtPiece ID");
            string ID = Console.ReadLine();

            if (FindArtPieceId(ID) == false)
            {
                if (ID.Length == 5)
                {
                    Console.WriteLine("Please enter the Title");
                    string title = Console.ReadLine();

                    ListArtist();

                    Console.WriteLine("Please enter ArtistID");
                    string ArtistId = Console.ReadLine();

                    if (FindArtistId(ArtistId) == false)
                    {
                        Console.WriteLine("ArtistId does not exist");
                        Console.WriteLine("Please enter existed ArtistID");

                    }
                    else
                    {
                        if (ArtistId.Length == 5)
                        {
                            Console.WriteLine("Please enter the year");
                            int year = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Please enter Estimated value for Art Piece");
                            double Estimatedvalue = Convert.ToDouble(Console.ReadLine());
                            Console.WriteLine("Please enter the sale price of Art Piece");
                            double salevalue = Convert.ToDouble(Console.ReadLine());

                            if (salevalue > Estimatedvalue)
                            {
                                Console.WriteLine("Please enter the status Of ArtPiece");
                                char status = Convert.ToChar(Console.ReadLine());

                                myArtpice[artPieceIndex].ArtPieceID = ID;
                                myArtpice[artPieceIndex].Title = title;
                                myArtpice[artPieceIndex].ArtistID = ArtistId;
                                myArtpice[artPieceIndex].Year = year;
                                myArtpice[artPieceIndex].EstmiateValue = Estimatedvalue;
                                myArtpice[artPieceIndex].SalePrice = salevalue;
                                myArtpice[artPieceIndex].Status = status;
                                artPieceIndex++;

                                Console.WriteLine("ArtPiece added successfully");

                            }
                            else if (salevalue < Estimatedvalue)

                            {
                                Console.WriteLine("please enter sale value greater than estimated value");
                            }
                        }
                        else
                        {
                            Console.WriteLine("ArtistId is not of 5 character");
                        }
                    }


                }
            }

            else
            {
                Console.WriteLine("ERROR - Already exist one ArtPiece with this ID ");
                Console.WriteLine("Please enter unique 5 character ID");
            }
        }

        public static void ReturnArtPiece()
        {

            Console.WriteLine("Enter 5 character ArtpieceId:");
            string ID = Console.ReadLine();

           
             
                if (FindArtPieceId(ID) == true)
                {
                   if (CheckingStatus(ID) == true)
                   {
                    Console.WriteLine("you are eligible for return");
                    RestoreStatus(ID);

                    findMatch(ID);
                    AmountWillBeReceived(ID);

                   }
     
                   else 
                   {
                        Console.WriteLine("you are not eligible for Return");
                   }

                }

                else
                {
                    Console.WriteLine("ArtPiece Id does not exists");
                }

        }

        public static void ReplaceArtpiece()
        {
            Console.WriteLine("Enter 5 character ArtpieceId: ");
            string APID = Console.ReadLine();
            string newId = "";

            if (FindArtPieceId(APID) == true)
            {

            if (CheckingStatus(APID) == true)
            {
                Console.WriteLine("You are Eligible for the Replace");
                ListArtpiece();
                Console.WriteLine("Enter the ID of new ArtPiece you would like to replace with your old ArtPiece");
                newId = Console.ReadLine();
                if ((APID != newId))
                {
                    if (FindArtPieceId(newId) == true)
                    {
                        RPiece(newId);
                        ChangingBacK(APID);

                        if (GetSalePrice(newId) < GetSalePrice(APID))
                        {
                            double amount = GetSalePrice(APID) - GetSalePrice(newId);
                            Console.WriteLine("you will receive a refund of " + amount);
                        }
                        else if (GetSalePrice(newId) > GetSalePrice(APID))
                        {
                            double newamount = GetSalePrice(newId) - GetSalePrice(APID);
                            Console.WriteLine("you will need to pay an amount of " + newamount);
                        }
                    }

                    else
                    {
                        Console.WriteLine("ArtPiece ID does not Exists");
                    }
                }

                else if (APID == newId)
                {
                    Console.WriteLine("You entered your currentArtPiece Id, you cannot replace artpiece with itself ");

                }

            }
            else
                {
                    Console.WriteLine("you are not eligible for Replace or Return item");
                }


            }

            
            else
            {
                Console.WriteLine(" Artpiece ID do not exists ");
            }

         }

        public static void RPiece(string ID)
        {
            ListArtpiece();

            //Console.WriteLine("Please enter your 5 character ArtPieceID of new ArtPiece");
            //string ID = Console.ReadLine();
            double salesv = 0;
            double totalCommission = 0;



            if (FindArtPieceId(ID) == true)
            {
                foreach (ArtPiece apiece in myArtpice)
                {
                    if (apiece.ArtPieceID == ID)
                    {
                        Console.WriteLine("please enter sale value of new ArtPiece");
                        salesv = Convert.ToDouble(Console.ReadLine());

                        if (salesv > apiece.EstmiateValue)

                        {
                            totalCommission = (salesv * 0.025);
                            string cID = findMatch(ID);
                            foreach (Curator _cur in myCurators)
                            {
                                myCurators[curatorIndex - 1].CommissionEarned += totalCommission;

                                changeStatus(ID);


                            }
                           
                        }
                        else
                        {
                            Console.WriteLine("please enter sales value greater than estimated value :");

                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("ArtPiece ID not exist, please enter Valid Artpiece Id: ");

                //newID = Console.ReadLine();
                //SellArtPiece(newID);
            }
        }


        public static void ChangingBacK(string ID)
        {
            foreach (ArtPiece aP in myArtpice)
            {
                if (aP.ArtPieceID == ID)
                {
                    foreach (Curator _cur in myCurators)
                    {
                        double totalcommission = aP.SalePrice * 0.025;

                        myCurators[curatorIndex - 1].CommissionEarned -= totalcommission;

                    }
                }

            }
            for (int i = 0; i < myArtpice.Length; i++)
            {
                if (myArtpice[i].ArtPieceID == ID)
                {
                    myArtpice[i].Status = 'd';


                }
            }
        }

        public static double GetSalePrice(string Id)
        {
            double SalePrice = 0;
            foreach (ArtPiece art in myArtpice)
            {
                if (art.ArtPieceID == Id)
                {
                  SalePrice = art.SalePrice;
                }
            }
          return SalePrice;
        }

        public static bool CheckingStatus(string ID)
        {
            bool flag = false;
            
            foreach(ArtPiece artPi in myArtpice)
            {
                if (artPi.ArtPieceID == ID & artPi.Status == 's' &  artPi.SoldDate <= 14)
                { 

                  flag = true;
                    
                }
                
            }
            return flag;
        }

        
       
        public static void AmountWillBeReceived(string ID)
        {
           
            foreach (ArtPiece aP in myArtpice)
            {
                if (aP.ArtPieceID == ID)
                {
                    Console.WriteLine("Yow will receive Amount of " + aP.SalePrice);
                    foreach (Curator _cur in myCurators)
                    {
                        double totalcommission = aP.SalePrice * 0.025;

                        myCurators[curatorIndex - 1].CommissionEarned -= totalcommission;

                    }
                }
               
            }

        }

      

        public static void ListArtist()
        {
            foreach (Artist displayart in myArtist)
            {
                string artistID = displayart.ArtistID;
                string artistName = displayart.ArtistName;
                string curatorid = displayart.CuratorID;
                if (artistID != null)
                {
                    Console.WriteLine("ArtistID: " + artistID + "\n Artistname: " + artistName + "\n CuratorID: " + curatorid);
                }
            }


        }

        public static string findArtPiece()
        {

            string info = "";
            Console.WriteLine("Please enter your ArtpieceID");
            string ID = Console.ReadLine();

            if (FindArtPieceId(ID) == true)
            {
                foreach (ArtPiece piece in myArtpice)
                {
                    if (piece.ArtPieceID == ID)
                    {
                        Console.WriteLine("ArtPiece Found ");
                        info += " ArtPieceId: " + piece.ArtPieceID + "\n ArtistId: " + piece.ArtistID + "\n EstimatedValue: " + piece.EstmiateValue + "\n Title: " + piece.Title + "\n Year: " +
                            piece.Year + "\n Status: " + piece.Status + "\n SalePrice: " + piece.SalePrice;
                    }
                    else
                    {
                        Console.WriteLine("ArtPieceID not found");
                        Console.WriteLine("Please enter valid  ArtpieceID");
                        //newID = Console.ReadLine();
                        //findArtPiece(newID);
                    }

                }
            }

            Console.WriteLine(info);
            return info;
        }



        public static void SellArtPiece()
        {
            ListArtpiece();

            Console.WriteLine("Please enter your 5 character ArtPieceID");
            string ID = Console.ReadLine();
            double salesv = 0;
            double totalCommission = 0;



            if (FindArtPieceId(ID) == true)
            {
                foreach (ArtPiece apiece in myArtpice)
                {
                    if (apiece.ArtPieceID == ID)
                    {
                        Console.WriteLine("please enter sale value");
                        salesv = Convert.ToDouble(Console.ReadLine());

                        if (salesv > apiece.EstmiateValue)

                        {
                            totalCommission = (salesv * 0.025);
                            string cID = findMatch(ID);
                            foreach (Curator _cur in myCurators)
                            {
                                myCurators[curatorIndex - 1].CommissionEarned += totalCommission;

                                changeStatus(ID);
                               

                            }
                            SoldDate(ID);

                            Console.WriteLine("ArtPiece Sold sucessfully");


                        }
                        else
                        {
                            Console.WriteLine("please enter sales value greater than estimated value :");

                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("ArtPiece ID not exist, please enter Valid Artpiece Id: ");

                //newID = Console.ReadLine();
                //SellArtPiece(newID);
            }
        }
        /*
         * input: artPieceId
         * goal 1: find the artistID attached to artpiece
         * goal 2: find the curator attached to artist
         */

        public static string findMatch(string artID)
        {
            string fetchedArtistID = "";
            string fetchedCuratorID = "";
            foreach (ArtPiece PieceObj in myArtpice)
            {
                if (PieceObj.ArtPieceID == artID)
                {
                    fetchedArtistID = PieceObj.ArtistID;
                }
            }
            foreach (Artist artistObj in myArtist)
            {
                if (artistObj.ArtistID == fetchedArtistID)
                {
                    fetchedCuratorID = artistObj.CuratorID;
                }
            }
            return fetchedCuratorID;

        }
        /*
        public static void changeStatus(String artPID)
        {
            char aPID = 'S';
             (ArtPiece artpie in myArtpice)
            {
                if (artpie.ArtPieceID == artPID)
                {
                    artpie.Status = 's';
                }
            }
        }
        */

        public static void changeStatus(string artPID) {
            for (int i = 0; i < myArtpice.Length; i++) {
                if (myArtpice[i].ArtPieceID == artPID) {
                    myArtpice[i].Status = 's';
                }
            }
        }

        public static void RestoreStatus(string apID)
        {
            for (int i = 0; i < myArtpice.Length; i++)
            {
                if (myArtpice[i].ArtPieceID == apID)
                {
                    myArtpice[i].Status = 'd';


                }
            }

        }


        public static double SoldDate(string artPieceId)
        {
            Console.WriteLine("Enter Today's date (e.g. 10/22/1987): ");


                DateTime inputtedDate = DateTime.Parse(Console.ReadLine());

            Console.WriteLine(inputtedDate);

            TimeSpan ts = DateTime.Now.Date - inputtedDate.Date;
            double NoOFDays = ts.TotalDays;
            Convert.ToInt32((NoOFDays));

            for (int i = 0; i < myArtpice.Length; i++)
            {
                if (myArtpice[i].ArtPieceID == artPieceId)
                {
                    myArtpice[i].SoldDate = NoOFDays;
                    
                }
            }
            return NoOFDays;
        }



        public static string findCurator()
        {
            Console.WriteLine("Enter curatorID");
            string ID = Console.ReadLine();

            string curinfo = "";
            if (findCuratorId(ID) == true)
            {
                foreach (Curator cur in myCurators)
                {
                    if (cur.CuratorId == ID && cur.CuratorId != null)
                    {
                        Console.Write("Curator Found");
                        curinfo += " CuratorId: " + cur.CuratorId + "\n CuratorName: " + cur.CuratorName + "\n TotalCommission Earned: " + cur.CommissionEarned;
                    }


                }

            }
            else
            {
                Console.WriteLine("ID not found");
            }

            Console.WriteLine(curinfo);
            return curinfo;
        }

        public static string FindArtist()
        {
            Console.WriteLine("Enter ArtistID");
            string ID = Console.ReadLine();
            string ArtistInfo = "";

            if (FindArtistId(ID) == true)
            {
                foreach (Artist art in myArtist)
                {
                    if (art.ArtistID == ID && art.ArtistID != null)
                    {
                        Console.WriteLine("Artist Found");
                        ArtistInfo = " ArtistId: " + art.ArtistID + "\n ArtistName: " + art.ArtistName + "\n CuratorID: " + art.CuratorID;
                    }


                }
            }
            else
            {
                Console.WriteLine("Artist not found");
                DisplayMenu();
            }
            Console.WriteLine(ArtistInfo);
            return ArtistInfo;
        }


        public static void ListCurators()
        {
            foreach(Curator cur in myCurators)
            {
              string curid = cur.CuratorId;
                string curname = cur.CuratorName;
                double commission = cur.CommissionEarned;
                if (curid != null)
                {
                    Console.WriteLine("\n curatorId: " + curid + "\n curatorname: " + curname + "\n totalcomissionearned: " + commission);
                }
            }
        }

        public static void ListArtpiece()
        {
            foreach (ArtPiece artP in myArtpice)
            {
                if (artP.Status != 's')
                {
                    string artistId = artP.ArtistID;
                    string ArtPieceID = artP.ArtPieceID;
                    double Estvalue = artP.EstmiateValue;
                    double Salevalue = artP.SalePrice;
                    char Status = artP.Status;
                    string Title = artP.Title;
                    double year = artP.Year;
                    if (ArtPieceID != null)
                    {
                        Console.WriteLine("ArtpieceID: " + ArtPieceID + "\n Title: " + Title + "\n ArtistId: " + artistId + "\n Year: " + year +
                            "\n EstimatedValue: " + Estvalue + "\n Salevalue: " + Salevalue + "\n Status: " + Status);
                    }
                }
               
            }
        }

        public static bool findCuratorId(string ID)
        {
            bool flag = false;
            foreach (Curator cur in myCurators)
            {
                if (cur.CuratorId == ID)
                {
                   
                    flag = true;
                }
                   
            }
            return flag;
        }

        public static bool FindArtistId(string ID)
        {
            bool flag = false;
            foreach (Artist at in myArtist)
            {
                if (at.ArtistID == ID)
                {
                    flag = true;
                }
            
            }
            return flag;
        }

        public static bool FindArtPieceId(string ID)
        {
            bool flag = false;
            foreach (ArtPiece arp in myArtpice)
            {
                if (arp.ArtPieceID == ID)
                {
                    flag = true;
                }
                   
            }
            return flag;
        }


        public static double totalSale()
        {
            double totalSale = 0;
            foreach (ArtPiece art_local in myArtpice)
            {
                if (art_local.Status == 's')
                {
                    totalSale += art_local.SalePrice;
                }
            }
            return totalSale;
        }

        public static void inventoryReport()
        {
            foreach (ArtPiece _piece in myArtpice)
            {
                if (_piece.ArtPieceID != null)
                {
                    Console.WriteLine(" ArtPieceTitle: " + _piece.Title + "\n ArtPieceId: " + _piece.ArtPieceID + "\n ArtPieceYear: " + _piece.Year + "\n ArtPieceEValue: " +
                        _piece.EstmiateValue + "\n ArtistId: " + _piece.ArtistID + "\n Artpiece status: " + _piece.Status +
                        "\n ArtPiece sale Price: " + _piece.SalePrice + "\n totalSale: " + totalSale());
                }
               // Console.WriteLine();
            }
        }

    }
}

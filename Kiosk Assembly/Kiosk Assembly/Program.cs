﻿using System.Diagnostics;

namespace BackLogTasks
                    Console.WriteLine("Input the cost of an item.");
                }
                    Console.WriteLine("Input the cost of an another item. (Or press ENTER without typing to proceed to pay.)");
            totalCost = Math.Round(totalCost, 2);
                while (change >= 10.00 && kioskArray[3] > 0)
                while (change >= 5.00 && kioskArray[4] > 0)
                while (change >= 1.00 && kioskArray[5] > 0)
                while (change >= 0.25 && kioskArray[6] > 0)
                while (change >= 0.1 && kioskArray[7] > 0)
                while (change >= 0.05 && kioskArray[8] > 0)
                while (change >= 0.01 && kioskArray[9] > 0)
                if (change > 0)
                else
                    Console.WriteLine("Um...we actually have to see your card number to use it...");
                    cardNumber = Console.ReadLine();
                }//The user didn't type anything? Huh. Better give them another chance to do so.
                else if ((vendorNumber >= 601100 && vendorNumber <= 601199) || (vendorNumber >= 622126 && vendorNumber <= 622925) || (vendorNumber >= 624000 && vendorNumber <= 626999) || (vendorNumber >= 628200 && vendorNumber <= 628899) || (vendorNumber >= 640000 && vendorNumber <= 659999))
                else
                        else
                        if (doublerSwitch == false)
                { 
                    {
                        method = Console.ReadLine();
                        {
                            CashBackRequest = cashBack(endProgram);
                            totalCost += CashBackRequest;
                            totalCost = Math.Round(totalCost, 2);
                            string newTotalCost = formatMoneyValue(totalCost);
                            Console.WriteLine("The new total (including the cash back) is $" + newTotalCost + ".");
                        }//If the value is not -1, then the customer has already been asked about cashback, therefore the function shall not be Called more than once.
                            if (Math.Round(Convert.ToDouble(cardResults[1]), 2) == totalCost)
                            {
                                kioskArray = kioskStockRemaining(kioskArray, totalCost, CashBackRequest, endProgram);
                        string newCashBackRequest = formatMoneyValue(CashBackRequest);
                        {
                            Console.WriteLine("Payment accepted. (Dispenses $" + newCashBackRequest + " for cash back.)");
                Console.WriteLine("");
                Console.WriteLine("Kiosk Change left:");
                Console.WriteLine(kioskArray[0] + " \t$100 bills,");
                Console.WriteLine(kioskArray[1] + " \t$50 bills,");
                Console.WriteLine(kioskArray[2] + " \t$20 bills,");
                Console.WriteLine(kioskArray[3] + " \t$10 bills,");
                Console.WriteLine(kioskArray[4] + " \t$5 bills,");
                Console.WriteLine(kioskArray[5] + " \t$1 bills,");
                Console.WriteLine(kioskArray[6] + " \tquarters,");
                Console.WriteLine(kioskArray[7] + " \tdimes,");
                Console.WriteLine(kioskArray[8] + " \tnickels,");
                Console.WriteLine(kioskArray[9] + " \tpennies.");
            report[0] = Convert.ToString(Math.Round(cashPaid,2));                            //Amount of cash paid.
            report[2] = Convert.ToString(Math.Round(totalCost - cashPaid, 2));               //Amount paid with card.
            if (report[3] == "-0")
            {
                report[3] = "0.00";
            }
        static string formatMoneyValue(double rawMoneyValue)
        {
            string analysis = Convert.ToString(Math.Round(rawMoneyValue, 2));
            char[] arr = new char[analysis.Length];
            analysis.CopyTo(0, arr, 0, analysis.Length);
            bool decimalUsed = false;
            int afterDecimalCounter = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (decimalUsed == true)
                {
                    afterDecimalCounter += 1;
                }
                if (arr[i] == '.')
                {
                    decimalUsed = true;
                }
            }
            if (afterDecimalCounter == 0)
            {
                analysis += ".00";
            }
            else if (afterDecimalCounter == 1)
            {
                analysis += "0";
            }
            return analysis;
        }
﻿using System.Diagnostics;

namespace BackLogTasks
        //kiosk values (functions)
        public struct DefineGlobalBankStructure
        static int[] KioskStockAddition(int[] kioskArray, double payment)
            {
                kioskArray[9] += 1;
            }
            {
                kioskArray[8] += 1;
            }
            {
                kioskArray[7] += 1;
            }
            {
                kioskArray[6] += 1;
            }
            {
                kioskArray[5] += 1;
            }
            {
                kioskArray[4] += 1;
            }
            {
                kioskArray[3] += 1;
            }
            {
                kioskArray[2] += 1;
            }
            {
                kioskArray[1] += 1;
            }
            {
                kioskArray[0] += 1;
            }
        static int[] KioskStockRemaining(int[] kioskArray, double change)

        //input validation/formatting (functions)
        static string UserInputOfItemsAndValidation(bool plural)
                    Console.WriteLine("Welcome! Input the cost of an item to begin.");
                }
                    Console.WriteLine("Input the cost of an another item. (Or press ENTER without typing to proceed to pay.)");
                            arr[i] != '9' && arr[i] != '0')
                            else
                        }//It is not a number.
                    }
                if (errorFound == false)
            }
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
        static string[] CardRecognition(string cardNumber)
            else if ((vendorNumber >= 222100 && vendorNumber <= 272099) || (vendorNumber >= 510000 && vendorNumber <= 559999))
            else if ((vendorNumber >= 601100 && vendorNumber <= 601199) || (vendorNumber >= 622126 && vendorNumber <= 622925) ||
                (vendorNumber >= 624000 && vendorNumber <= 626999) || (vendorNumber >= 628200 && vendorNumber <= 628899) || (vendorNumber >= 640000 && vendorNumber <= 659999))
            else if ((vendorNumber >= 340000 && vendorNumber <= 349999) || (vendorNumber >= 370000 && vendorNumber <= 379999))
            else
            string[] cardDetails = new string[2] { Convert.ToString(cardIsRecognized), cardVendor };
        static bool CardValidation(string cardNumber)
                        && arr[i] != '0')
                }
            if (cardNumber.Length > 19 || cardNumber.Length < 12)
            if (errorFound == false)
                    else
                        else
                    }//Double the number.
                    if (doublerSwitch == false)
                    else
                }//Use the designated algorithm to determine the card's validity.
                while (runningTotal > 0)
            }//Condition 3: the LUHN algorithm.
            if (cardIsValid == false)

        //calculate cost (functions)
        static double DisplayItemTotal()
            totalCost = Math.Round(totalCost, 2);

        //choose payment (functions)
        static string PaymentMethodDirectory()
        {
            string paymentMethod = " ";
            while (paymentMethod != "1" && paymentMethod != "2" && paymentMethod != "3")
            {
                Console.WriteLine("Press '1' to use cash, press '2' to use a card, or press '3' to cancel the payment.");
                paymentMethod = Console.ReadLine();
                if (paymentMethod != "1" && paymentMethod != "2" && paymentMethod != "3")
                {
                    Console.WriteLine("ERROR: must type either '1', '2', or '3'.");
                }
            }
            return paymentMethod;
        }

        //cash (functions)
        static string[] UserInputOfFunds(double remainingCost)
                            arr[i] != '9' && arr[i] != '0')
                        payment == 50 || payment == 100)
            payment = Math.Round(payment, 2);
            if (remainingCost > 0)
            {
                string displayRemainingCost = FormatMoneyValue(remainingCost);
                Console.WriteLine("Remaining cost: $" + displayRemainingCost);
            }
            string[] returnFund = new string[2];
            returnFund[0] = Convert.ToString(remainingCost);
            returnFund[1] = Convert.ToString(payment);
            return returnFund;
        }
        static bool CheckKiosk(int[] kioskArray, double change)
            while (change >= 50.00 && kioskArray[1] > 0)
            while (change >= 20.00 && kioskArray[2] > 0)
            while (change >= 10.00 && kioskArray[3] > 0)
            while (change >= 5.00 && kioskArray[4] > 0)
            while (change >= 1.00 && kioskArray[5] > 0)
            while (change >= 0.25 && kioskArray[6] > 0)
            while (change >= 0.1 && kioskArray[7] > 0)
            while (change >= 0.05 && kioskArray[8] > 0)
            while (change >= 0.01 && kioskArray[9] > 0)
            if (change <= 0)
            return kioskIsValid;

        //card (functions)
        static double CashBack()
            return CashBackRequest;
        static string[] MoneyRequest(string account_number, decimal amount)
            bool pass = rnd.Next(100) < 50;//50% CHANCE THAT A FAILED TRANSACTION IS DECLINED
            bool declined = rnd.Next(100) < 50;
            }//end if
        }//DO NOT CHANGE THIS FUNCTION!
        static string DetectFailWithoutCashBack(string paymentMethod, string[] cardResults)
            if (cardResults[1] != "declined")
            }
            Console.WriteLine("Press '1' to choose another way to pay, or press '2' to cancel the payment.");
            bool repeat = true;
            while (repeat == true)
            {
                string howToProceed = Console.ReadLine();
                if (howToProceed == "1")
                {
                    repeat = false;
                    paymentMethod = PaymentMethodDirectory();
                }
                else if (howToProceed == "2")
                {
                    repeat = false;
                    Console.WriteLine("Maybe next time. Have a nice day!");
                    paymentMethod = "3";
                }
                else
                {
                    Console.WriteLine("ERROR: must type either '1' or '2'.");
                }
            }
            return paymentMethod;
            }
            bool repeat = true;
            while (repeat == true)
            {
                string howToProceed = Console.ReadLine();
                if (howToProceed == "1")
                {
                    paymentMethod = "2";
                    repeat = false;
                }
                else if (howToProceed == "2")
                {
                    Console.WriteLine("Maybe next time. Have a nice day!");
                    paymentMethod = "3";
                    repeat = false;
                }
                else
                {
                    Console.WriteLine("ERROR: must type either '1' or '2'.");
                }
            }

        //main
        static void Main(string[] args)
        {
            //kiosk values
            DefineGlobalBankStructure kiosk;
            int[] kioskArray = new int[] { kiosk.Hundreds, kiosk.Fifties, kiosk.Twenties, kiosk.Tens, kiosk.Fives, kiosk.Ones, kiosk.Quarters, kiosk.Dimes, kiosk.Nickels,
                kiosk.Pennies };
            int[] resetKioskArray = kioskArray;

            //log values
            string[] report = new string[4];
            report[0] = "N/A";//amount of cash paid
            report[1] = "N/A";//card vendor
            report[2] = "N/A";//amount paid with card
            report[3] = "N/A";//change given
            double change = 0;
            double cashBackRequest = 0;

            //calculate cost
            double totalCost = DisplayItemTotal();

            //choose payment
            string paymentMethod = PaymentMethodDirectory();
            while (paymentMethod != "3")
            {
                //cash
                if (paymentMethod == "1")
                {
                    //input payment
                    double remainingCost = totalCost;
                    while (remainingCost > 0)
                    {
                        string[] returnFund = UserInputOfFunds(remainingCost);
                        remainingCost = Convert.ToDouble(returnFund[0]);
                        double payment = Convert.ToDouble(returnFund[1]);
                        kioskArray = KioskStockAddition(kioskArray, payment);
                    }

                    //calculate change
                    change = -1 * (remainingCost);
                    Math.Round(change, 2);

                    //attempt to dispense change
                    bool kioskIsValid = CheckKiosk(kioskArray, change);
                    if (kioskIsValid == true)
                    {
                        if (change == 0)
                        {
                            change = 0;
                        }//ensures the value of change doesn't equal a negative zero (I'm speechless)
                        string newChange = FormatMoneyValue(change);
                        Console.WriteLine("Your change is $" + Convert.ToDecimal(newChange) + ". Have a great day!");
                        double cashPaid = totalCost;
                        report[0] = Convert.ToString(FormatMoneyValue(Math.Round(cashPaid, 2)));
                        report[3] = Convert.ToString(FormatMoneyValue(Math.Round(change + cashBackRequest, 2)));
                        paymentMethod = "3";
                    }//change is dispensable
                    else
                    {
                        Console.Write("Unfortunately, we do not have the sufficient change for this purchase (Refunds $" + (totalCost + change) + "). Please try paying " +
                            "another way.");
                        kioskArray = resetKioskArray;
                        paymentMethod = PaymentMethodDirectory();
                    }//insufficient kiosk change
                }//end of cash method

                //card
                else
                {
                    //input payment
                    Console.WriteLine("Please enter your card number. (Do not include spaces or hyphens.)");
                    string cardNumber = Console.ReadLine();
                    while (cardNumber.Length == 0)
                    {
                        Console.WriteLine("Whoops! Be sure to type your card number before pressing 'ENTER'.");
                        cardNumber = Console.ReadLine();
                    }//is the value "null"?
                    string[] cardDetails = CardRecognition(cardNumber);
                    bool cardIsRecognized = Convert.ToBoolean(cardDetails[0]);
                    bool cardIsValid = CardValidation(cardNumber);

                    //cashback attempt
                    if (cardIsRecognized == true && cardIsValid == true)
                    {
                        cashBackRequest = CashBack();
                        totalCost += cashBackRequest;
                        totalCost = Math.Round(totalCost, 2);
                        string newTotalCost = FormatMoneyValue(totalCost);
                        Console.WriteLine("The new total (including the cash back) is $" + newTotalCost + ".");
                        string[] cardResults = MoneyRequest(cardNumber, Convert.ToDecimal(totalCost));
                        if (cardResults[1] == "declined")
                        {
                            if (cashBackRequest == 0)
                            {
                                paymentMethod = DetectFailWithoutCashBack(paymentMethod, cardResults);
                            }
                            else
                            {
                                paymentMethod = DetectFailWithCashBack(paymentMethod, cardResults);
                                if (paymentMethod == "2")
                                {
                                    totalCost -= cashBackRequest;
                                    cashBackRequest = 0;
                                }
                            }
                        }//card declines
                        else
                        {
                            if (Math.Round(Convert.ToDouble(cardResults[1]), 2) == totalCost)
                            {
                                kioskArray = KioskStockRemaining(kioskArray, cashBackRequest);
                                string newCashBackRequest = FormatMoneyValue(cashBackRequest);
                                Console.WriteLine("Payment accepted. (Dispenses $" + newCashBackRequest + " for cash back.)");
                                report[1] = cardDetails[1];
                                report[2] = Convert.ToString(FormatMoneyValue(Math.Round(totalCost - cashBackRequest, 2)));
                                report[3] = Convert.ToString(FormatMoneyValue(Math.Round(change + cashBackRequest, 2)));
                                paymentMethod = "3";
                            }//sufficient funds on card
                            else
                            {
                                if (cashBackRequest == 0)
                                {
                                    paymentMethod = DetectFailWithoutCashBack(paymentMethod, cardResults);
                                }
                                else
                                {
                                    paymentMethod = DetectFailWithCashBack(paymentMethod, cardResults);
                                    if (paymentMethod == "2")
                                    {
                                        totalCost -= cashBackRequest;
                                        cashBackRequest = 0;
                                    }
                                }
                            }//insufficient funds on card
                        }//card did not decline
                    }//card is recognized/valid
                    else
                    {
                        Console.WriteLine("Please choose another method of payment.");
                        paymentMethod = PaymentMethodDirectory();
                    }//card didn't pass recognition/validation
                }//end of card method
            }//end of payment loop

            //show final kiosk values
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

            //transfer to log recorder
            string generic = report[0] + " " + report[1] + " " + report[2] + " " + report[3];
            startInfo.Arguments = generic;
        }//end of main
    }//end of class
}//end of namespace
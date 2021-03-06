﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _4.Items
{
    /*
    * This project uses the following licenses:
    *  MIT License
    *  Copyright (c) 2017 Ricardo Mendoza 
    *  Montréal Québec Canada
    *  Institut Teccart
    *  www.teccart.qc.ca
    *  Août 2017
   */
    public abstract class clsAccount
    {
        /// <summary>
        /// Fields
        /// </summary>
        private string Number;
        private string Type;
        private double Balance;
        /// <summary>
        /// Fields UnpaidAccount -> in the Function protected abstract : Charge  commission.
        /// </summary>
        private double Commission;
        private int Overdraft;
        private double CommissionCharge;
        /// <summary>
        /// Fields PaidAccount -> in the Function protected abstract : Pay interest.
        /// </summary>
        private double InterestRate;
        private double InterestPayment;
        /// <summary>
        /// ClsDate OpenDate -> when an account is open
        /// </summary>
        private clsDate OpenDate;
        /// <summary>
        /// Constructor that takes eigth arguments UnPaidAccount -> in the Function protected abstract : Charge  commission.
        /// </summary>
        public clsAccount(double vCommission, int vOverdraft, string vNumber, string vType, double vBalance, int vDay, int vMonth, int vYear)
        {
            // in the Function protected abstract : Charge  commission.
            Commission = vCommission;
            Overdraft = vOverdraft;

            Number = vNumber;
            Type = vType;
            Balance = vBalance;
            OpenDate = new clsDate(vDay, vMonth, vYear);
        }
        /// <summary>
        /// Constructor that takes seven arguments -> in the Function protected abstract : Pay interest.
        /// </summary>
        public clsAccount(double vInterestRate, string vNumber, string vType, double vBalance, int vDay, int vMonth, int vYear)
        {
            // in the Function protected abstract : Pay interest.
            InterestRate = vInterestRate;

            Number = vNumber;
            Type = vType;
            Balance = vBalance;
            OpenDate = new clsDate(vDay, vMonth, vYear);
        }
        /// <summary>
        /// Constructor that takes six arguments.
        /// </summary>
        public clsAccount(string vNumber, string vType, double vBalance, int vDay, int vMonth, int vYear)
        {
            Number = vNumber;
            Type = vType;
            Balance = vBalance;
            OpenDate = new clsDate(vDay, vMonth, vYear);
        }
        /// <summary>
        /// Constructor that takes no arguments.
        /// </summary>
        public clsAccount()
        {
            // in the Function protected abstract : Charge  commission.
            Commission = 0;
            Overdraft = 0;
            CommissionCharge = 0;
            // in the Function protected abstract : Pay interest.
            InterestRate = 0;
            InterestPayment = 0;

            Number = clsComplements.fncEmptyConstructor();
            Type = clsComplements.fncEmptyConstructor();
            Balance = 0;
            OpenDate = new clsDate();
        }

        /// <summary>
        /// Constructor TEST.
        /// </summary>
        public clsAccount(string vNumber, string vType, double vBalance)
        {
            Number = vNumber;
            Type = vType;
            Balance = vBalance;
        }


        /// <summary>
        /// Properties -> in the Function protected abstract : Charge  commission.
        /// </summary>
        public double vCommission
        {
            get { return Commission; }
            set { Commission = value; }
        }
        public int vOverdraft
        {
            get { return Overdraft; }
            set { Overdraft = value; }
        }
        public double vCommissionCharge
        {
            get { return CommissionCharge; }
            set { CommissionCharge = value; }
        }
        /// <summary>
        /// Properties -> in the Function protected abstract : Pay interest.
        /// </summary>
        public double vInterestRate
        {
            get { return InterestRate; }
            set
            {
                InterestRate = value;
            }
        }
        public double vInterestPayment
        {
            get { return InterestPayment; }
            set { InterestPayment = value; }
        }
        /// <summary>
        /// Properties.
        /// </summary>
        public string vNumber
        {
            get { return Number; }
            set { Number = value; }
        }

        public string vType
        {
            get { return Type; }
            set { Type = value; }
        }
        public double vBalance
        {
            get { return Balance; }
            set { Balance = value; }
        }

        public clsDate vOpenDate
        {
            get { return OpenDate; }
            set { OpenDate = value; }
        }

        // STARTS TEST PARA EL EXAMEN


        protected internal int Add(int x, int y)
        {
            return x + y;
        }



        // ENDS TEST PARA LE EXAMEN
        /// <summary>
        /// Function protected abstract : Charge  commission
        /// Un CompteNonRemunéré -> clsUnpaidAccount : clsAccount
        /// Est un compte d'un genre spécifique, qui possède une autorisation de découvert (overdraft)
        /// modifiable à tout moment par la banque, les retraits d'argent sont soumis au seuil défini
        /// par la valeur du découvert autorisé.A chaque fois qu'un retrait dépassant le solde (dans la
        /// limite du découvert autorisé) a lieu la banque prélève sur le compte des frais de gestion
        /// de 12% sur le montant du dépassement
        /// </summary>
        protected abstract double fncChargeComission(double amount);
        /// <summary>
        /// Functions : Pay interest
        /// Un CompteRemunéré:
        /// Est un compte d'un genre spécifique, qui rémunère les sommes déposées selon une
        /// formule dépendant d'un taux d'intérêt proposé et modifiable par la banque.Nous
        /// supposerons que la banque est une bonne institution car elle crédite le compte, pour tout
        /// dépôt, d'un intérêt immédiat sur la somme déposée.
        /// </summary>
        protected abstract double fncPayInterest(double deposit);

        /// <summary>
        /// Functions : Open Account
        /// </summary>
        /// <param name="Number"></param>
        /// <param name="Type"></param>
        public virtual void fncOpenAccount(string Number, string Type)
        {
            Number = vNumber;
            Balance = 0;
            Type = vType;
            OpenDate = new clsDate();
        }
        /// <summary>
        /// Functions : Deposit
        /// </summary>
        /// <param name="deposit">double deposit</param>
        /// <returns>true</returns>
        public virtual bool fncDeposit(double deposit)
        {
            if (deposit < 20 || 500 < deposit)
            {
                return false;
            }
            else
            {
                vBalance += deposit;
                return true;
            }
        }
        /// <summary>
        /// Functions : Withdrawal
        /// </summary>
        /// <param name="amount"></param>
        /// <returns></returns>
        public virtual int fncWithdrawal(double amount)
        {
            if (amount > 500) { return -2; }
            if (amount < 20) { return -1; }
            if (amount > vBalance) { return 1; }
            if (amount % 20 != 0) { return 2; }
            else
            {
                vBalance -= amount;
                return 0;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="commissionCharge"></param>
        public virtual void fncUnpaidAccountCommission(double commissionCharge)
        {
            vBalance -= commissionCharge;
        }
        /// <summary>
        /// Add interest to the balance
        /// </summary>
        /// <param name="interesPaid"></param>
        public virtual void fncPaidAccountPayInterest(double interestPayment)
        {
            vBalance += interestPayment;
        }
        /// <summary>
        /// Functions : Consultation of the balance and PDF Creation
        /// </summary>
        /// <returns>Account;</returns>
        public virtual string fncPrintBalance()
        {
            string Account = "";
            Account += "\nAccount Type : " + Type + "\n";
            Account += "Number : " + Number + "\n";
            Account += "Interest payable : " + InterestRate * 100 + " % " + "\n";
            Account += "Commission : " + Commission * 100 + " % " + "\n";
            Account += "Overdraft : " + Overdraft + " $ " + "\n";
            Account += "Open Date : " + OpenDate.fncPrintDate() + "\n";
            Account += "Balance : " + Balance + " $ " + "\n";
            return Account;
        }
        /// <summary>
        /// Functions : Consultation of the balance -> UnpaidAccount
        /// </summary>
        /// <returns>Account;</returns>
        public virtual string fncPrintBalanceUnPaidAccount()
        {
            string Account = "";
            Account += "\nCommission : " + Commission * 100 + " % " + "\n";
            Account += "Overdraft : " + Overdraft + " $ " + "\n";
            Account += "Number : " + Number + "\n";
            Account += "Type : " + Type + "\n";
            Account += "Open Date : " + OpenDate.fncPrintDate() + "\n";
            Account += "Balance : " + Balance + " $ " + "\n";
            return Account;
        }
        /// <summary>
        /// Functions : Consultation of the balance -> PaidAccount
        /// </summary>
        /// <returns>Account;</returns>
        public virtual string fncPrintBalancePaidAccount()
        {
            string Account = "";
            Account += "\nInterest payable : " + InterestRate * 100 + " % " + "\n";
            Account += "Number : " + Number + "\n";
            Account += "Type : " + Type + "\n";
            Account += "Open Date : " + OpenDate.fncPrintDate() + "\n";
            Account += "Balance : " + Balance + " $ " + "\n";
            return Account;
        }
    }
}
using System;

namespace FitnessManager.Model
{
    internal class Customer
    {
        public string Id { get; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public Gender Gender { get; set; }
        public DateTime SubscriptionDate { get; }

        private int age;
        public int Age 
        { 
            get 
            { 
                return age; 
            } 
            set 
            {
                if (value > 0)
                {
                    age = value;
                }
                else
                {
                    age = 0;
                }
            } 
        }

        private double height;
        public double Height { get => height; set => height = (value > 0) ? value : 0; }

        private double weight;
        public double Weight { get => weight; set => weight = (value > 0) ? value : 0; }



        public Customer(string name, string surname, int age, Gender gender)
        {
            Name = name;
            Surname = surname;
            Age = age;
            Gender = gender;
            SubscriptionDate = DateTime.Now;
            Id = CreateId(Name, Surname, SubscriptionDate);
        }

        public Customer(string id, string name, string surname, Gender gender, DateTime subscriptionDate, int age, double height, double weight)
        {
            Id = id;
            Name = name;
            Surname = surname;
            Gender= gender;
            SubscriptionDate = subscriptionDate;
            Age = age;
            Height = height;
            Weight = weight;
        }

        private string CreateId(string name, string surname, DateTime date)
        {
            string formattedDate = date.ToString("ddMMyyyyHHmmss");
            return name[0].ToString() + surname[0].ToString()+formattedDate;
        }

        private double CalculateBMI(double height, double weight) 
        {
            if (weight != 0 && height != 0)
            {
                return weight / (height * height);
            }
            else
            {
                return -1;
            }
        }

        //public string Description()
        //{
        //    string bMIString;
        //    double bMI = CalculateBMI(Height, Weight);

        //    if (bMI > 0)
        //    {
        //        bMIString = bMI + "";
        //    }
        //    else
        //    {
        //        bMIString = "Non Disponibile";
        //    }

        //    string description = "Id: " + Id + "\n"
        //        + "Nome: " + Name + " " + Surname + "\n"
        //        + "Età: " + Age + "\n"
        //        + "Genere: " + getGenderString(Gender) + "\n"
        //        + "Altezza: " + Height + "m\n"
        //        + "Peso: " + Weight + "Kg\n"
        //        + "BMI: " + bMIString + "\n"
        //        + "Data di iscrizione: " + SubscriptionDate.ToString("dd - MM - yyyy") + "\n";
        //    return description;
        //}
            
        private string getGenderString(Gender gender)
        {
            switch (gender)
            {
                case Gender.Male:
                    return "Maschio";
                case Gender.Female:
                    return "Femmina";
                case Gender.Unknown:
                    return "Non determinato";
                default:
                    return "Non determinato";
            }
        }

        public override string ToString()
        {
            string bMIString;
            double bMI = CalculateBMI(Height, Weight);

            if (bMI > 0)
            {
                bMIString = bMI + "";
            }
            else
            {
                bMIString = "Non Disponibile";
            }

            string description = "Id: " + Id + "\n"
                + "Nome: " + Name + " " + Surname + "\n"
                + "Età: " + Age + "\n"
                + "Genere: " + getGenderString(Gender) + "\n"
                + "Altezza: " + Height + "m\n"
                + "Peso: " + Weight + "Kg\n"
                + "BMI: " + bMIString + "\n"
                + "Data di iscrizione: " + SubscriptionDate.ToString("dd - MM - yyyy") + "\n";
            return description;
        }
    }

    public enum Gender: int
    {
        Male = 1,
        Female = 2,
        Unknown = 3
    }
}
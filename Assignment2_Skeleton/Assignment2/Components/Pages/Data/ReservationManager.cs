using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

// Group 1: Assignment 2

// Name: Adam Abubaker, Ibrahim Alhagaili, Leilanie Fayda Dizon, Jaryd Hibbert
// Date: 2024/03/09

// Description: This class which is named ReservationManager is used to manage the reservations within the Traveless application.
// It facilitates the functionalities such as finding reservations by reservation code, airline, or name, generating reservation codes,
// or travelers name, generating unique reservation codes, getting reservations, adding reservations, and updating reservations.
// Additionally, it also contains a method to check if a reservation code has been generated for error handling purposes.

namespace Assignment2.Components.Pages.Data
{
    internal class ReservationManager
    {

        /**
         * The location of the reservation file.
         */
        private static string Reservation_TXT = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\..\..\Resources\Files\reservation.csv");

        private static Random random = new Random();
        /**
         * Holds the Reservation objects.
         */
        private static List<Reservation> reservations = new List<Reservation>();

        /**
         * Finds reservations containing either reservation code or airline.
         * @param reservationCode Reservation code to search for.
         * @param airline Airline to search for.
         * @param name Travelers name to search for.
         * @return Any matching Reservation objects.
         */
        public List<Reservation> FindReservations(string reservationCode, string airline, string name)
        {
            List<Reservation> found = new List<Reservation>();

            foreach (Reservation reservation in reservations)
            {
                if (reservation.Code.Contains(reservationCode) && reservation.Airline.Contains(airline) && reservation.Name.Contains(name))
                {
                    found.Add(reservation);
                }
                else if (reservation.Code.Contains(reservationCode))
                {
                    found.Add(reservation);
                }
                // TODO
                // add a case to get reservation by Name   
                // add a case to get reservation by Airline   
                // ...................................

                // This code section allows the user to get their reservation information by either "Airline" or "Name" //Our Comments
                // then adds that reservation to the "found list" // Our Comments
                foreach (Reservation reservation1 in reservations)
                {
                    if ((string.IsNullOrEmpty(reservationCode) || reservation.Code.Contains(reservationCode)) &&
                        (string.IsNullOrEmpty(airline) || reservation.Airline.Contains(airline)) &&
                        (string.IsNullOrEmpty(name) || reservation.Name.Contains(name)))
                    {
                        found.Add(reservation1);
                    }
                }
            }

            return found;
        }

        public string GenerateResCode()
        {
            return GenerateReservationCode();
        }

        /**
         * Gets reservation code using a flight.
         * @param flight Flight instance.
         * @return Reservation code.
         */
        public string GenerateReservationCode()
        {           
            string reservationCode;

            do
            {
                char letter = (char)('A' + random.Next(26));
                string numbers = random.Next(1000, 10000).ToString();
                reservationCode = letter + numbers;
            } while (IsCodeGenerated(reservationCode, Reservation_TXT));

            return reservationCode;
        }

        private static bool IsCodeGenerated(string reservationCode, string Reservation_TXT)
        {
            if (!File.Exists(reservationCode))
            {
                return false;
            }

            List<string> existingCode = File.ReadAllLines(Reservation_TXT).ToList();

            return existingCode.Contains(reservationCode);
        }

        public static List<Reservation> GetReservations() 
        {
            List<Reservation> res = new List<Reservation>();
            foreach (string line in File.ReadLines(Reservation_TXT))
            {
                string[] parts = line.Split(",");
                string reservationCode = parts[0];
                string flightCode = parts[1];
                string airline = parts[2];
                double cost = double.Parse(parts[3]);
                string name = parts[4];
                string citizenship = parts[5];
                string status = parts[6];

                Reservation newReservation = new Reservation(reservationCode, flightCode, airline, cost, name, citizenship, status);
                res.Add(newReservation);
            }
            reservations = res;
            return res;
        }

        public void AddReservation(Reservation res)
        {
            File.AppendAllText(Reservation_TXT, $"{res.Code},{res.FlightCode},{res.Airline},{res.Cost},{res.Name},{res.Citizenship},{res.Active}\n");            
        }

        public void UpdateReservation(Reservation res)
        {
            var lines = File.ReadAllLines(Reservation_TXT).ToList();

            // TODO
            // Add code to change the status from Active to Cancelled for the selected flight
            // and update the record in the reservation.csv file  
            // ...................................

            // This block of code changes the reservation status from "active" to "cancelled" in the reservation.csv file by determining the value //Our Comments
            // at index 6 of the line. //Our Comments
            List<string> updatedLines = new List<string>();
            foreach (var line in lines)
            {
               string[] parts = line.Split(",");
               if (parts[0] == res.Code)
                {
                  parts[6] = "Cancelled"; 
                  updatedLines.Add(string.Join(",", parts)); 
                }
                else
                {
                    updatedLines.Add(line); 
                }
            }
            lines = updatedLines; 

            // Write the updated lines back to the file
            File.WriteAllLines(Reservation_TXT, lines);
        }
    }
}
    
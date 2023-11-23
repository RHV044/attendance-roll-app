namespace AttendanceRollApp.SharedUI.Models
{
    public static class AttendanceGForm
    {
        public static string FormUrl { get; set; } = "https://docs.google.com/forms/u/0/d/e/1FAIpQLSf4zmEOp48n_ABs-lk_lFqB5unnlFR-89G4vWitaE6eNiXz4w/formResponse";
        public static class Fields
        {
            public static string Year { get; set; } = "entry.1156334328_year";
            public static string Month { get; set; } = "entry.1156334328_month";
            public static string Day { get; set; } = "entry.1156334328_day";
            public static string Hour { get; set; } = "entry.1156334328_hour";
            public static string Minute { get; set; } = "entry.1156334328_minute";
            public static string NationalID { get; set; } = "entry.1838684073";
            public static string FullName { get; set; } = "entry.1838684073";
            public static string Gender { get; set; } = "entry.1838684073";
            public static string Birthdate { get; set; } = "entry.1838684073";
            public static string AuthMethod { get; set; } = "entry.1838684073";
            public static string Location { get; set; } = "entry.793539539";

        }
    }
}

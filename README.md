# CSharp_Assignment2

# Name: Ibrahim, Leilanie, Jaryd, Adam

# Flight.cs
<!-- <summary>
Represents the details and operations associated with an airline flight.
</summary>
# Description:
The Flight class encapsulates properties of a flight, providing a way to manage flight data such as the flight code, airline name, departure and arrival locations, time of departure, number of seats, and cost per seat. It includes methods to determine if the flight is domestic and to parse and validate flight codes based on predefined patterns.

# Input:
- `code`: A unique identifier for the flight.
- `airline`: The name of the airline operating the flight.
- `from`: The departure airport code.
- `to`: The arrival airport code.
- `weekday`: The day of the week the flight operates.
- `time`: The departure time of the flight.
- `seats`: The total number of seats available on the flight.
- `costPerSeat`: The cost per individual seat on the flight.

# Processes:
- `Flight(string code)`: Constructs a Flight object with a specific flight code.
- `Flight(...)`: Constructs a Flight object with full flight details.
- `Equals(object obj)`: Determines whether the specified object is equal to the current object.
- `isDomestic()`: Checks if the flight is a domestic flight based on the departure and arrival codes.
- `ParseCode(string code)`: Validates the flight code and assigns the corresponding airline.
- `GetHashCode()`: Retrieves a hash code for the flight object. (Not implemented)

# Outputs:
- Getters for `Code`, `Airline`, `From`, `To`, `Weekday`, `Time`, `Seats`, `CostPerSeat`: Retrieves the respective property values.
- Setters for `Code`, `Airline`, `From`, `To`, `Weekday`, `Time`, `Seats`, `CostPerSeat`: Allows setting the respective property values.
- `toString()`: Outputs the flight code as a string representation of the flight object. (Should be overridden as `ToString()`)
- Exception: Throws an Exception if the flight code does not match the required pattern or if an invalid airline code is provided.

Note: The class is marked as `internal`, meaning it is accessible only within the assembly that contains it. Additionally, the `GetHashCode` method is currently not implemented and will throw a `NotImplementedException` if used. -->


# FlightManager.cs
<!-- <summary>
Manages flight and airport data, providing functionality to search, retrieve, and manage flights and airports.
</summary>
# Description:
The `FlightManager` class is responsible for handling the operations related to managing flight and airport data. This includes maintaining lists of flights and airports, finding specific flights or airports by code, and finding flights between two airports on a particular day of the week. It utilizes data from CSV files to populate its lists.

# Input:
- Airports and flights data from CSV files.
- Search parameters such as airport codes and weekdays for finding flights.

# Processes:
- `FlightManager()`: Constructor that populates airports and flights from CSV files upon initialization.
- `getAirports()`: Retrieves a list of all airport codes.
- `getFlights()`: Retrieves a list of all flights.
- `findAirportByCode(string code)`: Searches for an airport code in the list of airports.
- `findFlightByCode(string code)`: Searches for a flight by its flight code.
- `findFlights(string from, string to, string weekday)`: Searches for flights based on departure and arrival airport codes and a specific weekday or any weekday.
- `populateFlights()`: Reads flight data from a CSV file and populates the `flights` list.
- `populateAirports()`: Reads airport data from a CSV file and populates the `airports` list.

# Outputs:
- Lists of airport codes and flight objects.
- Specific flight or airport objects based on search criteria.
- Potentially, console output of the CSV data lines as they are read (as seen in the `populateFlights` method).

# Constants:
- `WEEKDAY_ANY`, `WEEKDAY_SUNDAY`, `WEEKDAY_MONDAY`, etc.: Constants used to represent each day of the week for flight searches.
- `FLIGHTS_TEXT`: The file path to the flights CSV file.
- `AIRPORTS_TEXT`: The file path to the airports CSV file.

Note: Exception handling in the methods `populateFlights` and `populateAirports` is not fully fleshed out. Catch blocks are present, but they do not perform any action when an exception is caught. This may be an area to improve by adding logging or rethrowing a more specific exception. -->

# Flight.razor
<!-- Description:
The page, denoted by @page "/flights", is designed to allow users to search for flights based on origin, destination, and day of the week. Users can view search results and input details for booking a flight. The page also handles displaying error messages and processing user input for making a reservation.

Input:
Search Criteria: Users can select the origin, destination, and day for searching flights.
Flight and Traveller Details: Users can view selected flight details and enter traveller information such as name and citizenship for reservation purposes.

Processes:
Search Flights (FindFlights): When a user clicks the "Find Flights" button, the FindFlights method is called, which searches for flights based on the selected criteria.
Fill Form (fillForm): When a user selects a flight from the search results, the fillForm method is called to display the flight details in the form for review or editing.
Make Reservation (CallMakeReservation): Once the traveller details are entered, clicking the "Reserve" button calls CallMakeReservation, which attempts to create a reservation and generate a reservation code.

Outputs:
Flight Search Results: A list of flights that match the search criteria is displayed for selection.
Flight Details: The selected flight's details are displayed for confirmation.
Reservation Confirmation: If the reservation is successful, a reservation code is displayed. If there is an error, an error message is shown. -->


# Home.razor
<!-- Description:
The HTML snippet is part of a Razor page for an ASP.NET Core web application's landing page. The page is designed to welcome users to the "Traveless" application, a name that suggests a travel or booking platform.

Input:
No user input is captured here; it's a static welcome page.

Processes:
This snippet does not involve dynamic processes; it serves static content to the user.

Outputs:
The output is the rendered HTML content when a user visits the root URL ("/") of the application. It displays:

A heading (<h1>) with the text "Welcome to Traveless", which is presumably the name of the application or service.
An image (<img>) that uses a relative path to a file named cat.jpg within an Images directory, presented as the logo of Traveless. The image has specified dimensions of 100x100 pixels and an alternative text "Traveless Logo" for accessibility and in case the image fails to load.
The page is likely a part of a larger application, serving as an entry point that greets users and introduces them to the Traveless service. The image path should be verified to ensure it accurately points to the logo file within the application's directory structure. Additionally, the alt text for the image provides a brief description for users who may not be able to see the image, aiding in accessibility compliance. -->


# MainLayout.razor
<!-- Description:
The layout consists of two main parts: a sidebar and the main content area. The sidebar contains the navigation menu (NavMenu component), and the main content area is designed to hold the page-specific content (@Body).

Input:
This layout does not directly handle user input but provides a structure where individual pages can handle input within the @Body section.

Processes:
NavMenu: The NavMenu component is likely to render a list of navigation links that allows users to navigate through different parts of the application.
@Body: This is a directive that represents the body of the layout. It's where the content of Blazor pages that use this layout will be rendered.
Outputs:
The output is a webpage with a sidebar containing navigation links and a main content area where the content of child pages will be displayed.
The "About" link in the top row provides users with a link to the ASP.NET Core documentation, opening it in a new tab.
Styling:
The layout uses classes such as page, sidebar, top-row, and content, which are styled likely via an external CSS stylesheet not included in the snippet. The px-4 class suggests that padding is applied by a CSS framework, possibly Bootstrap.

Remarks:
The @inherits directive at the top indicates that this layout inherits from LayoutComponentBase, which provides it with the functionality necessary to be used as a layout in Blazor applications. The layout itself is flexible and designed to be reused across different pages of the application. The NavMenu component is a partial view that is included in the layout and is used across all the pages that utilize this layout, ensuring a consistent look and navigation experience. The @Body directive is a placeholder for where the content of the child pages will appear when this layout is applied to a Blazor page. -->


# MauiProgram.cs
<!-- Description:
MauiProgram is a static class that is responsible for creating and configuring the MAUI application. It contains a single static method CreateMauiApp that sets up the application builder with various configurations.

Input:
There is no direct input; the method is used during application startup to configure services and settings.

Processes:
CreateMauiApp: This method initializes a MauiAppBuilder, which is used to configure the app's services, fonts, and other settings.
UseMauiApp<App>(): Configures the application to use a class App, which is where you define your MAUI app.
ConfigureFonts: Defines custom fonts for the application, in this case adding "OpenSans-Regular.ttf" with the alias "OpenSansRegular".
AddMauiBlazorWebView: Registers the services required to host a Blazor application within the .NET MAUI app.
Conditional Compilation:
In Debug mode, additional development tools and logging are configured:
AddBlazorWebViewDeveloperTools: Adds Blazor Webview developer tools which are likely helpful during development for debugging purposes.
AddDebug: Adds a debug logger that will log information useful during the development phase.
Outputs:
The method returns a MauiApp, which is the built application instance ready to be started and displayed to the user.
Remarks:
The #if DEBUG preprocessor directive ensures that the Blazor WebView developer tools and debug logging are only added in the Debug configuration, which helps with troubleshooting during development but is not included in the production build for performance reasons.
The App class, referenced by UseMauiApp<App>(), is typically where you set up the structure of your application, such as registering any app shell, pages, and other resources.
The method and class are static because they are used to configure the app at startup before any instance-specific data is required.
The OpenSans-Regular.ttf font file should exist in the project for this code to work, and the alias "OpenSansRegular" is used to refer to this font in the application -->


# Reservation.cs
<!-- Description:
The Reservation class stores details about a flight reservation, including a unique code, flight code, airline name, passenger name, citizenship, cost of the reservation, and an active status indicating whether the reservation is active.

Constructors:
Reservation(): A parameterless constructor allowing instantiation without initializing properties.
Reservation(string code, string flightCode, string airline, double cost, string name, string citizenship, string active): Initializes a new instance with provided values for each property.
Reservation(string reservationCode, Flight flight, string name, string citizenship): Initializes a new instance with a specific reservation code, a Flight object, and personal details of the passenger.
Properties:
Code: A unique identifier for the reservation.
FlightCode: A reference to the code of the flight booked.
Airline: The name of the airline of the flight.
Name: The name of the passenger.
Citizenship: The citizenship of the passenger.
Cost: The total cost of the reservation.
Active: A string indicating whether the reservation is active (likely "Active" or "Cancelled").
Methods:
SetName(string name): Validates and sets the name of the passenger. Throws an ArgumentNullException if the provided name is null or empty.
setCitizenship(string citizenship): Validates and sets the citizenship of the passenger. Throws a generic Exception if the provided citizenship is null or empty. This should ideally throw a more specific exception.
toString(): Overridden to return a string representation of the reservation. However, the method should be renamed to ToString() to follow the C# naming convention and override the Object.ToString() method correctly. -->

# ReservationManager.cs
<!-- Description:
The ReservationManager class is responsible for handling various operations related to flight reservations. It provides methods for generating unique reservation codes, finding reservations by different criteria, adding new reservations, and updating the status of existing reservations.

Fields:
Reservation_TXT: A static field holding the file path to the reservations data file, reservation.csv.
random: A static instance of the Random class to generate random characters for reservation codes.
reservations: A static list that holds in-memory reservation objects.
Methods:
FindReservations(string reservationCode, string airline, string name): Searches for reservations that match the given criteria. If parameters are empty, it will ignore them during the search.
GenerateResCode(): A wrapper for the GenerateReservationCode method.
GenerateReservationCode(): Generates a unique reservation code by combining a random letter and numbers.
IsCodeGenerated(string reservationCode, string Reservation_TXT): Checks whether a given reservation code has already been generated.
GetReservations(): Retrieves all reservations from the CSV file and populates the reservations list.
AddReservation(Reservation res): Appends a new reservation's details to the CSV file.
UpdateReservation(Reservation res): Modifies the status of a reservation from "Active" to "Cancelled" in the CSV file.
Notes:
The class has a static context implying that it maintains a single state across the entire application and is not intended to be instantiated.
The methods for manipulating reservations perform direct file I/O operations to read from and write to the CSV file.
The CSV file operations in GetReservations, AddReservation, and UpdateReservation suggest that the file serves as a simple persistence mechanism for reservations data.
Exception handling is not explicitly addressed in the code. In a production environment, it would be essential to handle potential I/O errors, parsing errors, or other exceptions.
UpdateReservation method contains a TODO comment, indicating that the method is intended to change a reservation's status and requires further implementation to be fully functional.
The code uses the Contains method for searching, which is case-sensitive and could lead to missed matches if the case doesn't align. Additionally, it doesn't handle the possibility of a null reservations list before attempting to use it.
It's crucial to ensure thread safety for file operations and access to the reservations list since it's static and could be accessed by multiple threads simultaneously in a web application environment. -->